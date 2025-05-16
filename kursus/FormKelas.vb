Imports MySql.Data.MySqlClient

Public Class FormKelas
    Dim selectedID As Integer = -1
    Dim isGeneratingSchedule As Boolean = False

    Private Sub txtDurasi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDurasi.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtBiaya_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBiaya.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRuangan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRuangan.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMaksimalPeserta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMaksimalPeserta.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Sub Kosong()
        cbKursus.SelectedIndex = -1
        cbInstruktur.SelectedIndex = -1
        cbHari.SelectedIndex = -1
        dtpJamMulai.Value = DateTime.Now
        txtRuangan.Clear()
        txtDurasi.Clear()
        txtBiaya.Clear()
        txtMaksimalPeserta.Clear()
        dtpTanggalMulai.Value = DateTime.Now
        dtpTanggalSelesai.Value = DateTime.Now
        txtKebutuhanAlat.Clear()
        selectedID = -1
        cbKursus.Focus()
    End Sub

    Sub tampilKelas()
        DA = New MySqlDataAdapter("SELECT K.IDKelas, K.KodeKursus, KR.NamaKursus, K.IDUser, " & _
                                  "IFNULL(U.NamaLengkap, 'Belum Ditentukan') AS NamaLengkap, " & _
                                  "K.Hari, K.JamMulai, K.Durasi, K.Ruangan, K.Biaya, K.MaksimalPeserta, K.JumlahPeserta, " & _
                                  "K.TanggalMulai, K.TanggalSelesai, K.KebutuhanAlat " & _
                                  "FROM Kelas K " & _
                                  "JOIN Kursus KR ON K.KodeKursus = KR.KodeKursus " & _
                                  "LEFT JOIN User U ON K.IDUser = U.IDUser", CONN)
        DS = New DataSet
        DA.Fill(DS, "kelas")
        DataGridView1.DataSource = DS.Tables("kelas")
        DataGridView1.ReadOnly = True

        With DataGridView1
            .Columns("IDKelas").HeaderText = "ID"
            .Columns("KodeKursus").HeaderText = "Kode Kursus"
            .Columns("NamaKursus").HeaderText = "Nama Kursus"
            .Columns("IDUser").HeaderText = "ID Tutor"
            .Columns("NamaLengkap").HeaderText = "Nama Tutor"
            .Columns("Hari").HeaderText = "Hari"
            .Columns("JamMulai").HeaderText = "Jam Mulai"
            .Columns("Durasi").HeaderText = "Durasi (menit)"
            .Columns("Ruangan").HeaderText = "Ruangan"
            .Columns("Biaya").HeaderText = "Biaya"
            .Columns("MaksimalPeserta").HeaderText = "Maks Peserta"
            .Columns("JumlahPeserta").HeaderText = "Peserta Terdaftar"
            .Columns("TanggalMulai").HeaderText = "Tanggal Mulai"
            .Columns("TanggalSelesai").HeaderText = "Tanggal Selesai"
            .Columns("KebutuhanAlat").HeaderText = "Kebutuhan Alat"

            .Columns("IDKelas").Width = 50
            .Columns("KodeKursus").Width = 80
            .Columns("NamaKursus").Width = 150
            .Columns("IDUser").Width = 80
            .Columns("NamaLengkap").Width = 150
            .Columns("KebutuhanAlat").Width = 200
        End With
    End Sub

    Sub isiCombo()
        cbKursus.Items.Clear()
        CMD = New MySqlCommand("SELECT * FROM kursus ORDER BY NamaKursus", CONN)
        RD = CMD.ExecuteReader()
        While RD.Read()
            cbKursus.Items.Add(New With {.Text = RD("KodeKursus") & " - " & RD("NamaKursus"), .Value = RD("KodeKursus")})
        End While
        RD.Close()
        cbKursus.DisplayMember = "Text"
        cbKursus.ValueMember = "Value"

        cbInstruktur.Items.Clear()
        CMD = New MySqlCommand("SELECT u.IDUser, u.NamaLengkap, dt.Keahlian, dt.TarifPersesi " & _
                               "FROM user u " & _
                               "JOIN detailtutor dt ON u.IDUser = dt.IDUser " & _
                               "WHERE u.Role = 'Tutor' AND u.Status = 'Aktif' " & _
                               "ORDER BY u.NamaLengkap", CONN)
        RD = CMD.ExecuteReader()
        While RD.Read()
            Dim tarif As String = "N/A"
            If Not IsDBNull(RD("TarifPersesi")) Then
                tarif = Convert.ToDecimal(RD("TarifPersesi")).ToString("N0")
            End If

            Dim keahlian As String = If(IsDBNull(RD("Keahlian")), "N/A", RD("Keahlian").ToString())
            Dim display As String = RD("IDUser") & " - " & RD("NamaLengkap") & " (" & keahlian & ", Tarif: " & tarif & ")"

            cbInstruktur.Items.Add(New With {.Text = display, .Value = RD("IDUser")})
        End While
        RD.Close()
        cbInstruktur.DisplayMember = "Text"
        cbInstruktur.ValueMember = "Value"

        cbHari.Items.Clear()
        cbHari.Items.AddRange(New String() {"Senin", "Selasa", "Rabu", "Kamis", "Jumat", "Sabtu", "Minggu"})
    End Sub

    Private Sub FormKelas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        isiCombo()
        tampilKelas()
        Kosong()
        dtpJamMulai.CustomFormat = "HH:mm"
        dtpJamMulai.ShowUpDown = True
        dtpJamMulai.Format = DateTimePickerFormat.Custom
        dtpTanggalMulai.MinDate = Today.Date
        dtpTanggalMulai.Format = DateTimePickerFormat.Short
        dtpTanggalSelesai.MinDate = dtpTanggalMulai.Value
        dtpTanggalSelesai.Format = DateTimePickerFormat.Short
        btnHapus.Enabled = False
        btnUbah.Enabled = False
        If FormUtama.roleAkses = "Front Office" Or FormUtama.roleAkses = "Tutor" Or FormUtama.roleAkses = "Peserta" Then
            GroupBox1.Visible = False
            btnSimpan.Visible = False
            btnUbah.Visible = False
            btnBatal.Visible = False
            btnHapus.Visible = False
        End If
    End Sub

    Private Sub dtpTanggalMulai_ValueChanged(sender As Object, e As EventArgs) Handles dtpTanggalMulai.ValueChanged
        dtpTanggalSelesai.MinDate = dtpTanggalMulai.Value

        If dtpTanggalSelesai.Value < dtpTanggalMulai.Value Then
            dtpTanggalSelesai.Value = dtpTanggalMulai.Value
        End If
    End Sub

    Private Function ValidateInput() As Boolean
        If cbKursus.SelectedIndex = -1 Then
            MessageBox.Show("Pilih kursus terlebih dahulu!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cbKursus.Focus()
            Return False
        End If

        If cbInstruktur.SelectedIndex = -1 Then
            MessageBox.Show("Pilih instruktur terlebih dahulu!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cbInstruktur.Focus()
            Return False
        End If

        If cbHari.SelectedIndex = -1 Then
            MessageBox.Show("Pilih hari terlebih dahulu!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cbHari.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtRuangan.Text) Then
            MessageBox.Show("Ruangan tidak boleh kosong!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRuangan.Focus()
            Return False
        End If

        Dim durasi As Integer
        If Not Integer.TryParse(txtDurasi.Text, durasi) OrElse durasi <= 0 Then
            MessageBox.Show("Durasi harus berupa angka positif!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDurasi.Focus()
            Return False
        End If

        Dim biaya As Decimal
        If Not Decimal.TryParse(txtBiaya.Text, biaya) OrElse biaya < 0 Then
            MessageBox.Show("Biaya harus berupa angka positif!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBiaya.Focus()
            Return False
        End If

        Dim maksimalPeserta As Integer
        If Not Integer.TryParse(txtMaksimalPeserta.Text, maksimalPeserta) OrElse maksimalPeserta <= 0 Then
            MessageBox.Show("Maksimal peserta harus berupa angka positif!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMaksimalPeserta.Focus()
            Return False
        End If

        If dtpTanggalMulai.Value > dtpTanggalSelesai.Value Then
            MessageBox.Show("Tanggal mulai tidak boleh lebih besar dari tanggal selesai!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpTanggalMulai.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If Not ValidateInput() Then
            Exit Sub
        End If

        Dim transaction As MySqlTransaction = Nothing

        Try
            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If

            transaction = CONN.BeginTransaction()

            CMD = New MySqlCommand("INSERT INTO kelas (KodeKursus, IDUser, Hari, JamMulai, Durasi, Ruangan, " & _
                                  "Biaya, MaksimalPeserta, JumlahPeserta, TanggalMulai, TanggalSelesai, KebutuhanAlat) " & _
                                  "VALUES (@kursus, @instruktur, @hari, @jam, @durasi, @ruangan, @biaya, @maksimalPeserta, 0, " & _
                                  "@tanggalMulai, @tanggalSelesai, @kebutuhanAlat); SELECT LAST_INSERT_ID();", CONN, transaction)
            With CMD.Parameters
                .AddWithValue("@kursus", DirectCast(cbKursus.SelectedItem, Object).Value)
                .AddWithValue("@instruktur", DirectCast(cbInstruktur.SelectedItem, Object).Value)
                .AddWithValue("@hari", cbHari.Text)
                .AddWithValue("@jam", dtpJamMulai.Value.ToString("HH:mm"))
                .AddWithValue("@durasi", Integer.Parse(txtDurasi.Text))
                .AddWithValue("@ruangan", txtRuangan.Text)
                .AddWithValue("@biaya", Decimal.Parse(txtBiaya.Text))
                .AddWithValue("@maksimalPeserta", Integer.Parse(txtMaksimalPeserta.Text))
                .AddWithValue("@tanggalMulai", dtpTanggalMulai.Value.ToString("yyyy-MM-dd"))
                .AddWithValue("@tanggalSelesai", dtpTanggalSelesai.Value.ToString("yyyy-MM-dd"))
                .AddWithValue("@kebutuhanAlat", txtKebutuhanAlat.Text)
            End With

            Dim newClassId As Integer = Convert.ToInt32(CMD.ExecuteScalar())

            transaction.Commit()

            MessageBox.Show("Data kelas berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tampilKelas()
            Kosong()

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            MessageBox.Show("Error saat menyimpan data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try
    End Sub

    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click
        If selectedID = -1 Then
            MessageBox.Show("Pilih data terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not ValidateInput() Then
            Exit Sub
        End If

        Dim transaction As MySqlTransaction = Nothing

        Try
            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If

            transaction = CONN.BeginTransaction()

            CMD = New MySqlCommand("UPDATE kelas SET KodeKursus=@kursus, IDUser=@instruktur, Hari=@hari, " & _
                                  "JamMulai=@jam, Durasi=@durasi, Ruangan=@ruangan, Biaya=@biaya, " & _
                                  "MaksimalPeserta=@maksimalPeserta, TanggalMulai=@tanggalMulai, " & _
                                  "TanggalSelesai=@tanggalSelesai, KebutuhanAlat=@kebutuhanAlat " & _
                                  "WHERE IDKelas=@id", CONN, transaction)
            With CMD.Parameters
                .AddWithValue("@kursus", DirectCast(cbKursus.SelectedItem, Object).Value)
                .AddWithValue("@instruktur", DirectCast(cbInstruktur.SelectedItem, Object).Value)
                .AddWithValue("@hari", cbHari.Text)
                .AddWithValue("@jam", dtpJamMulai.Value.ToString("HH:mm"))
                .AddWithValue("@durasi", Integer.Parse(txtDurasi.Text))
                .AddWithValue("@ruangan", txtRuangan.Text)
                .AddWithValue("@biaya", Decimal.Parse(txtBiaya.Text))
                .AddWithValue("@maksimalPeserta", Integer.Parse(txtMaksimalPeserta.Text))
                .AddWithValue("@tanggalMulai", dtpTanggalMulai.Value.ToString("yyyy-MM-dd"))
                .AddWithValue("@tanggalSelesai", dtpTanggalSelesai.Value.ToString("yyyy-MM-dd"))
                .AddWithValue("@kebutuhanAlat", txtKebutuhanAlat.Text)
                .AddWithValue("@id", selectedID)
            End With
            CMD.ExecuteNonQuery()

            transaction.Commit()

            MessageBox.Show("Data kelas dan jadwal berhasil diubah.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tampilKelas()
            Kosong()

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            MessageBox.Show("Error saat mengubah data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If selectedID = -1 Then
            MessageBox.Show("Pilih data terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim result As DialogResult = MessageBox.Show(
            "Yakin ingin menghapus data ini? Semua data terkait seperti jadwal dan absensi juga akan terhapus.",
            "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                CMD = New MySqlCommand("SELECT JumlahPeserta FROM kelas WHERE IDKelas = @id", CONN)
                CMD.Parameters.AddWithValue("@id", selectedID)
                Dim jumlahPeserta As Integer = Convert.ToInt32(CMD.ExecuteScalar())

                If jumlahPeserta > 0 Then
                    Dim confirm As DialogResult = MessageBox.Show(
                        "Terdapat " & jumlahPeserta & " peserta terdaftar di kelas ini. " &
                        "Penghapusan kelas akan menghapus data pendaftaran peserta. Tetap lanjutkan?",
                        "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                    If confirm = DialogResult.No Then
                        Exit Sub
                    End If
                End If

                CMD = New MySqlCommand("DELETE FROM kelas WHERE IDKelas = @id", CONN)
                CMD.Parameters.AddWithValue("@id", selectedID)
                CMD.ExecuteNonQuery()

                MessageBox.Show("Data kelas berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tampilKelas()
                Kosong()

            Catch ex As Exception
                MessageBox.Show("Error saat menghapus data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Kosong()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row = DataGridView1.Rows(e.RowIndex)

            selectedID = Convert.ToInt32(row.Cells("IDKelas").Value)

            For i As Integer = 0 To cbKursus.Items.Count - 1
                If DirectCast(cbKursus.Items(i), Object).Value.ToString() = row.Cells("KodeKursus").Value.ToString() Then
                    cbKursus.SelectedIndex = i
                    Exit For
                End If
            Next

            If Not IsDBNull(row.Cells("IDUser").Value) Then
                For i As Integer = 0 To cbInstruktur.Items.Count - 1
                    If DirectCast(cbInstruktur.Items(i), Object).Value.ToString() = row.Cells("IDUser").Value.ToString() Then
                        cbInstruktur.SelectedIndex = i
                        Exit For
                    End If
                Next
            Else
                cbInstruktur.SelectedIndex = -1
            End If

            cbHari.Text = row.Cells("Hari").Value.ToString()

            If Not IsDBNull(row.Cells("JamMulai").Value) Then
                Dim jamStr As String = row.Cells("JamMulai").Value.ToString()
                Dim jamParts As String() = jamStr.Split(":")

                If jamParts.Length >= 2 Then
                    Dim jam As Integer = Integer.Parse(jamParts(0))
                    Dim menit As Integer = Integer.Parse(jamParts(1))

                    Dim dtValue As DateTime = DateTime.Today
                    dtValue = dtValue.AddHours(jam)
                    dtValue = dtValue.AddMinutes(menit)
                    dtpJamMulai.Value = dtValue
                End If
            End If

            txtDurasi.Text = row.Cells("Durasi").Value.ToString()
            txtRuangan.Text = row.Cells("Ruangan").Value.ToString()
            txtBiaya.Text = row.Cells("Biaya").Value.ToString()
            txtMaksimalPeserta.Text = row.Cells("MaksimalPeserta").Value.ToString()

            If Not IsDBNull(row.Cells("TanggalMulai").Value) Then
                dtpTanggalMulai.Value = Convert.ToDateTime(row.Cells("TanggalMulai").Value)
            End If

            If Not IsDBNull(row.Cells("TanggalSelesai").Value) Then
                dtpTanggalSelesai.Value = Convert.ToDateTime(row.Cells("TanggalSelesai").Value)
            End If

            txtKebutuhanAlat.Text = If(IsDBNull(row.Cells("KebutuhanAlat").Value), "",
                                    row.Cells("KebutuhanAlat").Value.ToString())
        End If
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        Try
            Dim keyword As String = txtCari.Text.Trim()

            DA = New MySqlDataAdapter("SELECT K.IDKelas, K.KodeKursus, KR.NamaKursus, K.IDUser, " & _
                                   "IFNULL(U.NamaLengkap, 'Belum Ditentukan') AS NamaLengkap, " & _
                                   "K.Hari, K.JamMulai, K.Durasi, K.Ruangan, K.Biaya, K.MaksimalPeserta, K.JumlahPeserta, " & _
                                   "K.TanggalMulai, K.TanggalSelesai, K.KebutuhanAlat " & _
                                   "FROM Kelas K " & _
                                   "JOIN Kursus KR ON K.KodeKursus = KR.KodeKursus " & _
                                   "LEFT JOIN User U ON K.IDUser = U.IDUser " & _
                                   "WHERE KR.NamaKursus LIKE @keyword OR U.NamaLengkap LIKE @keyword OR " & _
                                   "K.Hari LIKE @keyword OR K.Ruangan LIKE @keyword", CONN)
            DA.SelectCommand.Parameters.AddWithValue("@keyword", "%" & keyword & "%")

            DS = New DataSet
            DA.Fill(DS, "kelas")
            DataGridView1.DataSource = DS.Tables("kelas")

        Catch ex As Exception
            MessageBox.Show("Error saat mencari data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class