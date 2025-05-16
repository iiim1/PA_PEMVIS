Imports MySql.Data.MySqlClient

Public Class FormEnrollBayar
    Dim selectedKelasID As Integer = -1
    Dim selectedUserID As String = ""

    Private Class KelasItem
        Public Property IDKelas As Integer
        Public Property InfoKelas As String
        Public Property Biaya As Decimal
        Public Property KuotaTersisa As Integer

        Public Overrides Function ToString() As String
            Return InfoKelas & " (Kuota: " & KuotaTersisa & ")"
        End Function
    End Class

    Private Class PesertaItem
        Public Property IDUser As String
        Public Property Nama As String

        Public Overrides Function ToString() As String
            Return IDUser & " - " & Nama
        End Function
    End Class

    Sub Kosong()
        cbKelas.SelectedIndex = -1
        cbPeserta.SelectedIndex = -1
        lblBiayaValue.Text = "0"
        lblTanggalMulaiValue.Text = "-"
        lblHariJamValue.Text = "-"
        lblDurasiValue.Text = "-"
        lblKuotaTersisaValue.Text = "-"
        selectedKelasID = -1
        selectedUserID = ""
        cbMetodePembayaran.SelectedIndex = -1
        txtKeterangan.Clear()
        btnEnroll.Enabled = False
    End Sub

    Sub tampilEnrollmentPembayaran()
        Try
            DA = New MySqlDataAdapter("SELECT pk.IDKelas, pk.IDUser, u.NamaLengkap, " & _
                                     "CONCAT(kr.NamaKursus, ' - ', k.Hari, ' ', k.JamMulai) AS InfoKelas, " & _
                                     "k.Biaya, pk.TanggalDaftar, p.IDPembayaran, p.MetodePembayaran, p.Keterangan " & _
                                     "FROM peserta_kelas pk " & _
                                     "JOIN user u ON pk.IDUser = u.IDUser " & _
                                     "JOIN kelas k ON pk.IDKelas = k.IDKelas " & _
                                     "JOIN kursus kr ON k.KodeKursus = kr.KodeKursus " & _
                                     "LEFT JOIN pembayaran p ON p.IDUser = pk.IDUser AND p.IDKelas = pk.IDKelas " & _
                                     "ORDER BY pk.TanggalDaftar DESC", CONN)
            DS = New DataSet
            DS.Clear()
            DA.Fill(DS, "enrollment_pembayaran")
            DataGridView1.DataSource = DS.Tables("enrollment_pembayaran")
            atur_grid()
        Catch ex As Exception
            MessageBox.Show("Error menampilkan data: " & ex.Message)
        End Try
    End Sub

    Sub atur_grid()
        Try
            With DataGridView1
                .Columns(0).HeaderText = "ID Kelas"
                .Columns(1).HeaderText = "ID Peserta"
                .Columns(2).HeaderText = "Nama Peserta"
                .Columns(3).HeaderText = "Kelas"
                .Columns(4).HeaderText = "Biaya"
                .Columns(5).HeaderText = "Tanggal Pendaftaran"
                .Columns(6).HeaderText = "ID Pembayaran"
                .Columns(7).HeaderText = "Metode Pembayaran"
                .Columns(8).HeaderText = "Keterangan"

                .Columns(4).DefaultCellStyle.Format = "N0"
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                .Columns(0).Width = 60
                .Columns(1).Width = 80
                .Columns(2).Width = 150
                .Columns(3).Width = 200
                .Columns(4).Width = 100
                .Columns(5).Width = 120
                .Columns(6).Width = 100
                .Columns(7).Width = 120
                .Columns(8).Width = 150
            End With
        Catch ex As Exception
            MessageBox.Show("Error mengatur grid: " & ex.Message)
        End Try
    End Sub

    Sub isiKelas()
        Try
            cbKelas.Items.Clear()
            CMD = New MySqlCommand("SELECT k.IDKelas, CONCAT(kr.NamaKursus, ' - ', k.Hari, ' ', k.JamMulai) AS InfoKelas, " & _
                                  "k.Biaya, k.TanggalMulai, k.Hari, k.JamMulai, k.Durasi, " & _
                                  "(k.MaksimalPeserta - k.JumlahPeserta) AS KuotaTersisa " & _
                                  "FROM kelas k " & _
                                  "JOIN kursus kr ON k.KodeKursus = kr.KodeKursus " & _
                                  "WHERE k.TanggalSelesai >= CURDATE() AND (k.MaksimalPeserta - k.JumlahPeserta) > 0 " & _
                                  "ORDER BY kr.NamaKursus, k.Hari", CONN)
            RD = CMD.ExecuteReader()

            While RD.Read()
                Dim item As New KelasItem With {
                    .IDKelas = Convert.ToInt32(RD("IDKelas")),
                    .InfoKelas = RD("InfoKelas").ToString(),
                    .Biaya = Decimal.Parse(RD("Biaya").ToString()),
                    .KuotaTersisa = Convert.ToInt32(RD("KuotaTersisa"))
                }
                cbKelas.Items.Add(item)
            End While
            RD.Close()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data kelas: " & ex.Message)
        End Try
    End Sub

    Sub isiPeserta()
        Try
            cbPeserta.Items.Clear()
            CMD = New MySqlCommand("SELECT IDUser, NamaLengkap " & _
                                  "FROM user " & _
                                  "WHERE Role = 'Peserta' AND Status = 'Aktif' " & _
                                  "ORDER BY NamaLengkap", CONN)
            RD = CMD.ExecuteReader()

            While RD.Read()
                Dim item As New PesertaItem With {
                    .IDUser = RD("IDUser").ToString(),
                    .Nama = RD("NamaLengkap").ToString()
                }
                cbPeserta.Items.Add(item)
            End While
            RD.Close()
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data peserta: " & ex.Message)
        End Try
    End Sub

    Function cekEnrollment(idKelas As Integer, idUser As String) As Boolean
        CMD = New MySqlCommand("SELECT COUNT(*) FROM peserta_kelas " & _
                              "WHERE IDKelas = @idKelas AND IDUser = @idUser", CONN)
        CMD.Parameters.AddWithValue("@idKelas", idKelas)
        CMD.Parameters.AddWithValue("@idUser", idUser)

        Dim count As Integer = Convert.ToInt32(CMD.ExecuteScalar())
        Return count > 0
    End Function

    Private Sub FormEnrollBayar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            koneksi()

            cbMetodePembayaran.Items.Clear()
            cbMetodePembayaran.Items.Add("Cash")
            cbMetodePembayaran.Items.Add("Transfer Bank")
            cbMetodePembayaran.Items.Add("QRIS")
            cbMetodePembayaran.Items.Add("Credit Card")

            isiKelas()
            isiPeserta()

            tampilEnrollmentPembayaran()

            Kosong()
        Catch ex As Exception
            MessageBox.Show("Error saat memuat form: " & ex.Message)
        End Try
    End Sub

    Private Sub cbKelas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbKelas.SelectedIndexChanged
        If cbKelas.SelectedIndex = -1 Then
            Return
        End If

        Dim selectedKelas As KelasItem = DirectCast(cbKelas.SelectedItem, KelasItem)
        selectedKelasID = selectedKelas.IDKelas

        CMD = New MySqlCommand("SELECT k.Biaya, k.TanggalMulai, k.Hari, k.JamMulai, " & _
                              "k.Durasi, (k.MaksimalPeserta - k.JumlahPeserta) AS KuotaTersisa " & _
                              "FROM kelas k WHERE k.IDKelas = @idKelas", CONN)
        CMD.Parameters.AddWithValue("@idKelas", selectedKelasID)
        RD = CMD.ExecuteReader()

        If RD.Read() Then
            lblBiayaValue.Text = "" & Decimal.Parse(RD("Biaya").ToString()).ToString("N0")
            lblTanggalMulaiValue.Text = Convert.ToDateTime(RD("TanggalMulai")).ToString("dd MMMM yyyy")
            Dim jamMulai As DateTime = DateTime.Parse(RD("JamMulai").ToString())
            lblHariJamValue.Text = RD("Hari").ToString() & ", " & jamMulai.ToString("HH:mm")
            lblDurasiValue.Text = RD("Durasi").ToString() & " menit"
            lblKuotaTersisaValue.Text = RD("KuotaTersisa").ToString() & " orang"
        End If
        RD.Close()

        If cbPeserta.SelectedIndex <> -1 Then
            Dim selectedPeserta As PesertaItem = DirectCast(cbPeserta.SelectedItem, PesertaItem)
            validateEnrollButton(selectedKelasID, selectedPeserta.IDUser)
        End If
    End Sub

    Private Sub cbPeserta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPeserta.SelectedIndexChanged
        If cbPeserta.SelectedIndex = -1 Then
            Return
        End If

        Dim selectedPeserta As PesertaItem = DirectCast(cbPeserta.SelectedItem, PesertaItem)
        selectedUserID = selectedPeserta.IDUser

        If cbKelas.SelectedIndex <> -1 Then
            Dim selectedKelas As KelasItem = DirectCast(cbKelas.SelectedItem, KelasItem)
            validateEnrollButton(selectedKelas.IDKelas, selectedUserID)
        End If
    End Sub

    Private Sub validateEnrollButton(idKelas As Integer, idUser As String)
        btnEnroll.Enabled = Not cekEnrollment(idKelas, idUser) AndAlso cbMetodePembayaran.SelectedIndex <> -1

        If cekEnrollment(idKelas, idUser) Then
            MessageBox.Show("Peserta ini sudah terdaftar di kelas yang dipilih.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cbMetodePembayaran_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMetodePembayaran.SelectedIndexChanged
        If cbKelas.SelectedIndex <> -1 AndAlso cbPeserta.SelectedIndex <> -1 Then
            Dim selectedKelas As KelasItem = DirectCast(cbKelas.SelectedItem, KelasItem)
            Dim selectedPeserta As PesertaItem = DirectCast(cbPeserta.SelectedItem, PesertaItem)
            btnEnroll.Enabled = Not cekEnrollment(selectedKelas.IDKelas, selectedPeserta.IDUser) AndAlso cbMetodePembayaran.SelectedIndex <> -1
        End If
    End Sub

    Private Sub btnEnroll_Click(sender As Object, e As EventArgs) Handles btnEnroll.Click
        If cbKelas.SelectedIndex = -1 OrElse cbPeserta.SelectedIndex = -1 OrElse cbMetodePembayaran.SelectedIndex = -1 Then
            MsgBox("Silakan pilih kelas, peserta, dan metode pembayaran terlebih dahulu.", vbExclamation, "Peringatan")
            Return
        End If

        Dim selectedKelas As KelasItem = DirectCast(cbKelas.SelectedItem, KelasItem)
        Dim selectedPeserta As PesertaItem = DirectCast(cbPeserta.SelectedItem, PesertaItem)
        Dim metodePembayaran As String = cbMetodePembayaran.SelectedItem.ToString()

        Dim result As DialogResult = MessageBox.Show("Anda akan mendaftarkan dan melakukan pembayaran untuk " & _
                                                  selectedPeserta.Nama & " ke kelas " & selectedKelas.InfoKelas & "." & vbCrLf & vbCrLf & _
                                                  "Biaya kelas: Rp " & selectedKelas.Biaya.ToString("N0") & vbCrLf & _
                                                  "Metode Pembayaran: " & metodePembayaran & vbCrLf & vbCrLf & _
                                                  "Lanjutkan pendaftaran dan pembayaran?", "Konfirmasi Pendaftaran dan Pembayaran", _
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then
            Return
        End If

        Dim transaction As MySqlTransaction = Nothing

        Try
            transaction = CONN.BeginTransaction()
            Dim tanggalSekarang As DateTime = DateTime.Now
            Dim tanggalString As String = tanggalSekarang.ToString("yyyy-MM-dd")

            ' 1. Insert ke tabel peserta_kelas
            CMD = New MySqlCommand("INSERT INTO peserta_kelas (IDKelas, IDUser, TanggalDaftar) " & _
                                  "VALUES (@idKelas, @idUser, @tanggalDaftar)", CONN)
            With CMD.Parameters
                .AddWithValue("@idKelas", selectedKelas.IDKelas)
                .AddWithValue("@idUser", selectedPeserta.IDUser)
                .AddWithValue("@tanggalDaftar", tanggalString)
            End With
            CMD.Transaction = transaction
            CMD.ExecuteNonQuery()

            ' 2. Insert ke tabel pembayaran
            CMD = New MySqlCommand("INSERT INTO pembayaran (IDUser, IDKelas, TanggalBayar, Nominal, MetodePembayaran, Keterangan) " & _
                                  "VALUES (@idUser, @idKelas, @tanggalBayar, @nominal, @metodePembayaran, @keterangan)", CONN)
            With CMD.Parameters
                .AddWithValue("@idUser", selectedPeserta.IDUser)
                .AddWithValue("@idKelas", selectedKelas.IDKelas)
                .AddWithValue("@tanggalBayar", tanggalString)
                .AddWithValue("@nominal", selectedKelas.Biaya)
                .AddWithValue("@metodePembayaran", metodePembayaran)
                .AddWithValue("@keterangan", txtKeterangan.Text)
            End With
            CMD.Transaction = transaction
            CMD.ExecuteNonQuery()

            ' 3. Update jumlah peserta di tabel kelas
            CMD = New MySqlCommand("UPDATE kelas SET JumlahPeserta = JumlahPeserta + 1 " & _
                                  "WHERE IDKelas = @idKelas", CONN)
            CMD.Parameters.AddWithValue("@idKelas", selectedKelas.IDKelas)
            CMD.Transaction = transaction
            CMD.ExecuteNonQuery()

            transaction.Commit()

            MsgBox("Pendaftaran dan pembayaran kelas berhasil dilakukan.", vbInformation, "Sukses")

            tampilEnrollmentPembayaran()
            isiKelas()
            Kosong()

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            MessageBox.Show("Error saat mendaftarkan peserta dan melakukan pembayaran: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Kosong()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Silakan pilih data yang ingin dihapus terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim row As DataGridViewRow = DataGridView1.SelectedRows(0)
        Dim idKelas As Integer = Convert.ToInt32(row.Cells("IDKelas").Value)
        Dim idUser As String = row.Cells("IDUser").Value.ToString()
        Dim idPembayaran As Object = row.Cells("IDPembayaran").Value

        Dim namaPeserta As String = row.Cells("NamaLengkap").Value.ToString()
        Dim namaKelas As String = row.Cells("InfoKelas").Value.ToString()

        Dim message As String = "Apakah Anda yakin ingin menghapus pendaftaran " & namaPeserta & " dari kelas " & namaKelas & "?"
        If Not IsDBNull(idPembayaran) AndAlso Not String.IsNullOrEmpty(idPembayaran.ToString()) Then
            message += vbCrLf & "Data pembayaran terkait juga akan dihapus."
        End If

        Dim result As DialogResult = MessageBox.Show(message, "Konfirmasi Penghapusan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If

        Dim transaction As MySqlTransaction = Nothing
        Try
            transaction = CONN.BeginTransaction()

            ' 1. Hapus pembayaran (jika ada)
            If Not IsDBNull(idPembayaran) AndAlso Not String.IsNullOrEmpty(idPembayaran.ToString()) Then
                CMD = New MySqlCommand("DELETE FROM pembayaran WHERE IDPembayaran = @idPembayaran", CONN)
                CMD.Parameters.AddWithValue("@idPembayaran", idPembayaran)
                CMD.Transaction = transaction
                CMD.ExecuteNonQuery()
            End If

            ' 2. Hapus dari peserta_kelas
            CMD = New MySqlCommand("DELETE FROM peserta_kelas WHERE IDKelas = @idKelas AND IDUser = @idUser", CONN)
            CMD.Parameters.AddWithValue("@idKelas", idKelas)
            CMD.Parameters.AddWithValue("@idUser", idUser)
            CMD.Transaction = transaction
            CMD.ExecuteNonQuery()

            ' 3. Kurangi jumlah peserta
            CMD = New MySqlCommand("UPDATE kelas SET JumlahPeserta = JumlahPeserta - 1 WHERE IDKelas = @idKelas AND JumlahPeserta > 0", CONN)
            CMD.Parameters.AddWithValue("@idKelas", idKelas)
            CMD.Transaction = transaction
            CMD.ExecuteNonQuery()

            transaction.Commit()

            tampilEnrollmentPembayaran()
            Kosong()

            MessageBox.Show("Data berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            MessageBox.Show("Terjadi kesalahan saat menghapus data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        If txtCari.Text <> "" Then
            DA = New MySqlDataAdapter("SELECT pk.IDKelas, pk.IDUser, u.NamaLengkap, " & _
                                     "CONCAT(kr.NamaKursus, ' - ', k.Hari, ' ', k.JamMulai) AS InfoKelas, " & _
                                     "k.Biaya, pk.TanggalDaftar, p.IDPembayaran, p.MetodePembayaran, p.Keterangan " & _
                                     "FROM peserta_kelas pk " & _
                                     "JOIN user u ON pk.IDUser = u.IDUser " & _
                                     "JOIN kelas k ON pk.IDKelas = k.IDKelas " & _
                                     "JOIN kursus kr ON k.KodeKursus = kr.KodeKursus " & _
                                     "LEFT JOIN pembayaran p ON p.IDUser = pk.IDUser AND p.IDKelas = pk.IDKelas " & _
                                     "WHERE pk.IDKelas LIKE '%" & txtCari.Text & "%' OR " & _
                                     "pk.IDUser LIKE '%" & txtCari.Text & "%' OR " & _
                                     "u.NamaLengkap LIKE '%" & txtCari.Text & "%' OR " & _
                                     "kr.NamaKursus LIKE '%" & txtCari.Text & "%'", CONN)
            DS = New DataSet
            DS.Clear()
            DA.Fill(DS, "cari")
            DataGridView1.DataSource = DS.Tables("cari")
        Else
            tampilEnrollmentPembayaran()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Try
                DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                DataGridView1.Rows(e.RowIndex).Selected = True

                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim idKelas As Integer = Convert.ToInt32(row.Cells(0).Value)
                Dim idUser As String = row.Cells(1).Value.ToString()
                Dim namaPeserta As String = row.Cells(2).Value.ToString()
                Dim infoKelas As String = row.Cells(3).Value.ToString()
                Dim biaya As Decimal = Convert.ToDecimal(row.Cells(4).Value)
                Dim idPembayaran As Object = row.Cells(6).Value
                Dim metodePembayaran As Object = row.Cells(7).Value
                Dim keterangan As Object = row.Cells(8).Value

                For i As Integer = 0 To cbKelas.Items.Count - 1
                    Dim item As KelasItem = DirectCast(cbKelas.Items(i), KelasItem)
                    If item.IDKelas = idKelas Then
                        cbKelas.SelectedIndex = i
                        Exit For
                    End If
                Next

                For i As Integer = 0 To cbPeserta.Items.Count - 1
                    Dim item As PesertaItem = DirectCast(cbPeserta.Items(i), PesertaItem)
                    If item.IDUser = idUser Then
                        cbPeserta.SelectedIndex = i
                        Exit For
                    End If
                Next

                If Not IsDBNull(metodePembayaran) AndAlso Not String.IsNullOrEmpty(metodePembayaran.ToString()) Then
                    For i As Integer = 0 To cbMetodePembayaran.Items.Count - 1
                        If cbMetodePembayaran.Items(i).ToString() = metodePembayaran.ToString() Then
                            cbMetodePembayaran.SelectedIndex = i
                            Exit For
                        End If
                    Next
                Else
                    cbMetodePembayaran.SelectedIndex = -1
                End If

                If Not IsDBNull(keterangan) Then
                    txtKeterangan.Text = keterangan.ToString()
                Else
                    txtKeterangan.Clear()
                End If

                If Not IsDBNull(idPembayaran) AndAlso Not String.IsNullOrEmpty(idPembayaran.ToString()) Then
                    btnUbah.Enabled = True
                Else
                    btnUbah.Enabled = False
                End If

                btnHapus.Enabled = True
                btnEnroll.Enabled = False

                selectedKelasID = idKelas
                selectedUserID = idUser

            Catch ex As Exception
                MessageBox.Show("Error saat memilih data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Silakan pilih data yang akan diubah terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
        Dim idKelas As Integer = Convert.ToInt32(selectedRow.Cells(0).Value)
        Dim idUser As String = selectedRow.Cells(1).Value.ToString()
        Dim idPembayaran As Integer = If(IsDBNull(selectedRow.Cells(6).Value), 0, Convert.ToInt32(selectedRow.Cells(6).Value))

        If idPembayaran = 0 Then
            MessageBox.Show("Data pembayaran tidak ditemukan. Tidak dapat melakukan update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim metodePembayaranBaru As String = cbMetodePembayaran.SelectedItem.ToString()
        Dim keteranganBaru As String = txtKeterangan.Text

        Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin mengupdate metode pembayaran dan keterangan untuk peserta ini?",
                                                   "Konfirmasi Update",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If

        Dim transaction As MySqlTransaction = Nothing
        Try
            transaction = CONN.BeginTransaction()

            CMD = New MySqlCommand("UPDATE pembayaran SET MetodePembayaran = @metode, Keterangan = @keterangan " &
                                  "WHERE IDPembayaran = @idPembayaran", CONN)
            With CMD.Parameters
                .AddWithValue("@metode", metodePembayaranBaru)
                .AddWithValue("@keterangan", keteranganBaru)
                .AddWithValue("@idPembayaran", idPembayaran)
            End With
            CMD.Transaction = transaction
            CMD.ExecuteNonQuery()

            transaction.Commit()

            tampilEnrollmentPembayaran()
            MessageBox.Show("Data pembayaran berhasil diupdate.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            MessageBox.Show("Error saat mengupdate data pembayaran: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class