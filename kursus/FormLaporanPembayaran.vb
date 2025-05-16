Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing

Public Class FormLaporanPembayaran
    Private Sub FormLaporanPembayaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        LoadFilters()
        dtpMulai.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
        dtpSelesai.Value = DateTime.Now
    End Sub

    Private Sub LoadFilters()
        cbKelas.Items.Clear()
        cbKelas.Items.Add("Semua")

        Try
            CMD = New MySqlCommand("SELECT K.IDKelas, CONCAT(KU.NamaKursus, ' - ', K.Hari, ' ', K.JamMulai) AS InfoKelas " & _
                                  "FROM Kelas K JOIN Kursus KU ON K.KodeKursus = KU.KodeKursus", CONN)
            RD = CMD.ExecuteReader()

            Dim kelasDict As New Dictionary(Of Integer, String)

            While RD.Read()
                Dim id As Integer = Convert.ToInt32(RD("IDKelas"))
                Dim info As String = RD("InfoKelas").ToString()
                kelasDict.Add(id, info)
                cbKelas.Items.Add(info)
            End While

            RD.Close()

            cbKelas.Tag = kelasDict

        Catch ex As Exception
            MessageBox.Show("Gagal memuat data kelas: " & ex.Message)
        End Try

        cbKelas.SelectedIndex = 0
    End Sub

    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        TampilkanLaporan()
    End Sub

    Private Sub TampilkanLaporan()
        Try
            Dim whereClause As New List(Of String)

            If dtpMulai.Value > dtpSelesai.Value Then
                MessageBox.Show("Tanggal Mulai harus sebelum Tanggal Selesai")
                dtpMulai.Value = dtpSelesai.Value.AddDays(-1)
                dtpMulai.Focus()
            End If


            whereClause.Add("P.TanggalBayar BETWEEN @tglMulai AND @tglSelesai")

            If cbKelas.SelectedIndex > 0 Then
                Dim kelasDict As Dictionary(Of Integer, String) = DirectCast(cbKelas.Tag, Dictionary(Of Integer, String))
                Dim selectedKelasText As String = cbKelas.SelectedItem.ToString()
                Dim idKelas As Integer = -1

                For Each kvp As KeyValuePair(Of Integer, String) In kelasDict
                    If kvp.Value = selectedKelasText Then
                        idKelas = kvp.Key
                        Exit For
                    End If
                Next

                If idKelas <> -1 Then
                    whereClause.Add("P.IDKelas = @idKelas")
                End If
            End If

            Dim whereString As String = ""
            If whereClause.Count > 0 Then
                whereString = " WHERE " & String.Join(" AND ", whereClause)
            End If

            Dim query As String = "SELECT P.IDPembayaran, P.IDUser, U.NamaLengkap, KU.NamaKursus, P.TanggalBayar, " & _
                                  "P.Nominal, P.MetodePembayaran, P.Keterangan " & _
                                  "FROM pembayaran P " & _
                                  "JOIN user U ON P.IDUser = U.IDUser " & _
                                  "JOIN kelas K ON P.IDKelas = K.IDKelas " & _
                                  "JOIN kursus KU ON K.KodeKursus = KU.KodeKursus" & _
                                  whereString & _
                                  " ORDER BY P.TanggalBayar DESC"

            DA = New MySqlDataAdapter(query, CONN)

            DA.SelectCommand.Parameters.AddWithValue("@tglMulai", dtpMulai.Value.ToString("yyyy-MM-dd"))
            DA.SelectCommand.Parameters.AddWithValue("@tglSelesai", dtpSelesai.Value.ToString("yyyy-MM-dd"))

            If cbKelas.SelectedIndex > 0 Then
                Dim kelasDict As Dictionary(Of Integer, String) = DirectCast(cbKelas.Tag, Dictionary(Of Integer, String))
                Dim selectedKelasText As String = cbKelas.SelectedItem.ToString()
                Dim idKelas As Integer = -1

                For Each kvp As KeyValuePair(Of Integer, String) In kelasDict
                    If kvp.Value = selectedKelasText Then
                        idKelas = kvp.Key
                        Exit For
                    End If
                Next

                If idKelas <> -1 Then
                    DA.SelectCommand.Parameters.AddWithValue("@idKelas", idKelas)
                End If
            End If

            DS = New DataSet
            DS.Clear()
            DA.Fill(DS, "laporan")
            DataGridView1.DataSource = DS.Tables("laporan")

            Dim total As Decimal = 0
            For Each row As DataRow In DS.Tables("laporan").Rows
                total += Convert.ToDecimal(row("Nominal"))
            Next

            lblTotal.Text = "Rp. " & FormatNumber(total, 0)
            lblJumlahData.Text = DS.Tables("laporan").Rows.Count

            With DataGridView1
                .Columns("IDPembayaran").HeaderText = "ID"
                .Columns("IDUser").HeaderText = "ID User"
                .Columns("NamaLengkap").HeaderText = "Nama Peserta"
                .Columns("NamaKursus").HeaderText = "Kursus"
                .Columns("TanggalBayar").HeaderText = "Tanggal Bayar"
                .Columns("Nominal").HeaderText = "Nominal"
                .Columns("MetodePembayaran").HeaderText = "Metode"
                .Columns("Keterangan").HeaderText = "Keterangan"

                .Columns("Nominal").DefaultCellStyle.Format = "N0"
                .Columns("Nominal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

        Catch ex As Exception
            MessageBox.Show("Error menampilkan laporan: " & ex.Message)
        End Try
    End Sub

    Private currentPrintRow As Integer = 0
    Private rowsPerPage As Integer = 25

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            currentPrintRow = 0

            Dim printPreviewDialog As New PrintPreviewDialog()
            Dim printDoc As New PrintDocument()

            printDoc.DocumentName = "Laporan Pembayaran Kursus"

            AddHandler printDoc.PrintPage, AddressOf PrintReport

            With printPreviewDialog
                .Document = printDoc
                .WindowState = FormWindowState.Maximized
                .StartPosition = FormStartPosition.CenterScreen
                .ShowIcon = False
            End With

            printPreviewDialog.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Error saat mencetak: " & ex.Message)
        End Try
    End Sub

    Private Sub PrintReport(sender As Object, e As PrintPageEventArgs)
        Try
            If DataGridView1.Rows.Count = 0 OrElse DataGridView1.DataSource Is Nothing Then
                MessageBox.Show("Tidak ada data untuk dicetak!")
                e.Cancel = True
                Return
            End If

            Dim startX As Single = 50
            Dim startY As Single = 50
            Dim offset As Single = 20
            Dim pageWidth As Single = e.PageBounds.Width - 100

            Dim titleFont As New Font("Arial", 16, FontStyle.Bold)
            Dim subtitleFont As New Font("Arial", 12, FontStyle.Bold)
            Dim headerFont As New Font("Arial", 10, FontStyle.Bold)
            Dim contentFont As New Font("Arial", 9, FontStyle.Regular)

            Try
                e.Graphics.DrawString("LAPORAN PEMBAYARAN KURSUS", titleFont, Brushes.Black, startX, startY)
                startY += offset * 1.5

                e.Graphics.DrawString("Periode: " & dtpMulai.Value.ToString("dd-MM-yyyy") & " s/d " & dtpSelesai.Value.ToString("dd-MM-yyyy"),
                                     subtitleFont, Brushes.Black, startX, startY)
                startY += offset * 2

                Dim filters As New System.Text.StringBuilder("Filter: ")
                If cbKelas.SelectedIndex > 0 Then filters.Append("Kelas=" & cbKelas.Text & ", ")

                If filters.Length > "Filter: ".Length Then
                    filters.Length -= 2
                    e.Graphics.DrawString(filters.ToString(), contentFont, Brushes.Black, startX, startY)
                    startY += offset
                End If

                e.Graphics.DrawString("Total: " & lblTotal.Text & "  |  Jumlah Data: " & lblJumlahData.Text,
                                     headerFont, Brushes.Black, startX, startY)
                startY += offset * 1.5

                Dim colWidths() As Single = {30, 50, 100, 100, 80, 70, 80, 70, 100}
                Dim tableHeaders() As String = {"No", "ID User", "Nama", "Kursus", "Tanggal", "Nominal", "Metode", "Keterangan"}

                Dim currentX As Single = startX
                For i As Integer = 0 To tableHeaders.Length - 1
                    e.Graphics.DrawString(tableHeaders(i), headerFont, Brushes.Black, currentX, startY)
                    currentX += colWidths(i)
                Next

                startY += offset
                e.Graphics.DrawLine(New Pen(Color.Black, 1), startX, startY, startX + pageWidth, startY)
                startY += 5

                Dim rowsPrinted As Integer = 0
                While currentPrintRow < DataGridView1.Rows.Count AndAlso rowsPrinted < rowsPerPage
                    Dim row As DataGridViewRow = DataGridView1.Rows(currentPrintRow)

                    If Not row.IsNewRow Then
                        currentX = startX

                        e.Graphics.DrawString((currentPrintRow + 1).ToString(), contentFont, Brushes.Black, currentX, startY)
                        currentX += colWidths(0)

                        Dim idUser As String = If(row.Cells("IDUser").Value IsNot Nothing, row.Cells("IDUser").Value.ToString(), "")
                        e.Graphics.DrawString(idUser, contentFont, Brushes.Black, currentX, startY)
                        currentX += colWidths(1)

                        Dim nama As String = If(row.Cells("NamaLengkap").Value IsNot Nothing, row.Cells("NamaLengkap").Value.ToString(), "")
                        e.Graphics.DrawString(nama, contentFont, Brushes.Black, currentX, startY)
                        currentX += colWidths(2)

                        Dim kursus As String = If(row.Cells("NamaKursus").Value IsNot Nothing, row.Cells("NamaKursus").Value.ToString(), "")
                        e.Graphics.DrawString(kursus, contentFont, Brushes.Black, currentX, startY)
                        currentX += colWidths(3)

                        Dim tglBayar As String = ""
                        If row.Cells("TanggalBayar").Value IsNot Nothing Then
                            tglBayar = Convert.ToDateTime(row.Cells("TanggalBayar").Value).ToString("dd-MM-yyyy")
                        End If
                        e.Graphics.DrawString(tglBayar, contentFont, Brushes.Black, currentX, startY)
                        currentX += colWidths(4)

                        Dim nominal As String = "Rp 0"
                        If row.Cells("Nominal").Value IsNot Nothing Then
                            nominal = "Rp " & FormatNumber(row.Cells("Nominal").Value, 0)
                        End If
                        e.Graphics.DrawString(nominal, contentFont, Brushes.Black, currentX, startY)
                        currentX += colWidths(6)

                        Dim metode As String = If(row.Cells("MetodePembayaran").Value IsNot Nothing, row.Cells("MetodePembayaran").Value.ToString(), "")
                        e.Graphics.DrawString(metode, contentFont, Brushes.Black, currentX, startY)
                        currentX += colWidths(7)

                        Dim keterangan As String = If(row.Cells("Keterangan").Value IsNot Nothing, row.Cells("Keterangan").Value.ToString(), "")
                        e.Graphics.DrawString(keterangan, contentFont, Brushes.Black, currentX, startY)

                        startY += offset
                        rowsPrinted += 1
                    End If

                    currentPrintRow += 1

                    If startY >= e.MarginBounds.Bottom - 80 Then
                        Exit While
                    End If
                End While

                e.Graphics.DrawLine(New Pen(Color.Black, 1), startX, startY, startX + pageWidth, startY)
                startY += offset

                e.Graphics.DrawString("Dicetak pada: " & DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"),
                                     contentFont, Brushes.Black, startX, startY)

                startY += offset * 1.5
                e.Graphics.DrawString("Halaman: " & ((currentPrintRow - 1) \ rowsPerPage) + 1, contentFont, Brushes.Black, startX, startY)

                e.HasMorePages = currentPrintRow < DataGridView1.Rows.Count

            Finally
                titleFont.Dispose()
                subtitleFont.Dispose()
                headerFont.Dispose()
                contentFont.Dispose()
            End Try

        Catch ex As Exception
            MessageBox.Show("Error saat mencetak: " & ex.Message & vbCrLf & ex.StackTrace)
            currentPrintRow = 0
            e.Cancel = True
        End Try
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class