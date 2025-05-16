Imports MySql.Data.MySqlClient

Public Class FormPesertaKelas
    Dim selectedID As Integer = -1

    Private Class PesertaItem
        Public Property IDUser As String
        Public Property Nama As String

        Public Overrides Function ToString() As String
            Return IDUser & " - " & Nama
        End Function
    End Class

    Private Class KelasItem
        Public Property IDKelas As String
        Public Property InfoKelas As String

        Public Overrides Function ToString() As String
            Return InfoKelas
        End Function
    End Class


    Sub Kosong()
        cbKelas.SelectedIndex = -1
        selectedID = -1
    End Sub

    Sub isiComboKelas()
        Try
            Dim query As String

            If FormUtama.roleAkses = "tutor" Then
                query = "SELECT K.IDKelas, CONCAT(KR.NamaKursus, ' - ', K.Hari, ' ', K.JamMulai) AS InfoKelas " &
                        "FROM Kelas K JOIN Kursus KR ON K.KodeKursus = KR.KodeKursus " &
                        "WHERE K.TanggalSelesai >= CURDATE() AND K.IDTutor = @idTutor " &
                        "ORDER BY KR.NamaKursus, K.Hari"
            Else
                query = "SELECT K.IDKelas, CONCAT(KR.NamaKursus, ' - ', K.Hari, ' ', K.JamMulai) AS InfoKelas " &
                        "FROM Kelas K JOIN Kursus KR ON K.KodeKursus = KR.KodeKursus " &
                        "WHERE K.TanggalSelesai >= CURDATE() " &
                        "ORDER BY KR.NamaKursus, K.Hari"
            End If

            DA = New MySqlDataAdapter(query, CONN)

            If FormUtama.roleAkses = "tutor" Then
                DA.SelectCommand.Parameters.AddWithValue("@idTutor", FormUtama.userID)
            End If

            DS = New DataSet
            DA.Fill(DS, "kelas")

            cbKelas.Items.Clear()
            For Each row As DataRow In DS.Tables("kelas").Rows
                Dim item As New KelasItem With {
                    .IDKelas = row("IDKelas").ToString(),
                    .InfoKelas = row("InfoKelas").ToString()
                }
                cbKelas.Items.Add(item)
            Next

            If cbKelas.Items.Count = 0 Then
                MessageBox.Show("Tidak ada kelas yang tersedia.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error saat memuat data kelas: " & ex.Message)
        End Try
    End Sub


    Sub tampilDataPeserta()
        If cbKelas.SelectedIndex = -1 Then
            DataGridView1.DataSource = Nothing
            Exit Sub
        End If

        Try
            Dim selectedKelas As KelasItem = DirectCast(cbKelas.SelectedItem, KelasItem)
            Dim idKelas As Integer = Convert.ToInt32(selectedKelas.IDKelas)

            If FormUtama.roleAkses = "tutor" Then
                Dim cmd As New MySqlCommand("SELECT COUNT(*) FROM Kelas WHERE IDKelas = @idKelas AND IDTutor = @idTutor", CONN)
                cmd.Parameters.AddWithValue("@idKelas", idKelas)
                cmd.Parameters.AddWithValue("@idTutor", FormUtama.userID)

                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                If count = 0 Then
                    MessageBox.Show("Anda tidak memiliki akses untuk melihat data peserta kelas ini.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    DataGridView1.DataSource = Nothing
                    Exit Sub
                End If
            End If

            Dim query As String = "SELECT pk.IDKelas, pk.IDUser, u.NamaLengkap, u.NoHP, u.Email, " &
                                  "CONCAT(u.TempatLahir, ', ', DATE_FORMAT(u.TanggalLahir, '%d-%m-%Y')) AS TTL, " &
                                  "u.Status, DATE_FORMAT(u.TanggalDaftar, '%d-%m-%Y') AS TglDaftar, " &
                                  "k.Hari, k.JamMulai, k.Durasi, kr.NamaKursus, " &
                                  "DATE_FORMAT(pk.TanggalDaftar, '%d-%m-%Y') AS TglDaftarKelas " &
                                  "FROM peserta_kelas pk " &
                                  "JOIN user u ON pk.IDUser = u.IDUser " &
                                  "JOIN kelas k ON pk.IDKelas = k.IDKelas " &
                                  "JOIN kursus kr ON k.KodeKursus = kr.KodeKursus " &
                                  "WHERE pk.IDKelas = @idkelas "

            If FormUtama.roleAkses = "tutor" Then
                query &= "AND k.IDTutor = @idTutor "
            End If

            query &= "ORDER BY u.NamaLengkap"

            DA = New MySqlDataAdapter(query, CONN)
            DA.SelectCommand.Parameters.AddWithValue("@idkelas", idKelas)
            If FormUtama.roleAkses = "tutor" Then
                DA.SelectCommand.Parameters.AddWithValue("@idTutor", FormUtama.userID)
            End If
            DS = New DataSet
            DA.Fill(DS, "peserta_kelas")

            DataGridView1.DataSource = DS.Tables("peserta_kelas")
            aturGrid()
        Catch ex As Exception
            MessageBox.Show("Error saat menampilkan data peserta: " & ex.Message)
        End Try
    End Sub

    Sub aturGrid()
        With DataGridView1
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            If .Columns.Contains("IDKelas") Then .Columns("IDKelas").Visible = False

            If .Columns.Contains("IDUser") Then
                .Columns("IDUser").HeaderText = "ID Peserta"
                .Columns("IDUser").Width = 80
            End If

            If .Columns.Contains("NamaLengkap") Then .Columns("NamaLengkap").HeaderText = "Nama Lengkap"
            If .Columns.Contains("NoHP") Then .Columns("NoHP").HeaderText = "No. HP"
            If .Columns.Contains("Email") Then .Columns("Email").HeaderText = "Email"
            If .Columns.Contains("TTL") Then .Columns("TTL").HeaderText = "Tempat/Tgl Lahir"
            If .Columns.Contains("Status") Then .Columns("Status").HeaderText = "Status"
            If .Columns.Contains("TglDaftar") Then .Columns("TglDaftar").HeaderText = "Tgl Daftar"
            If .Columns.Contains("Hari") Then .Columns("Hari").HeaderText = "Hari"
            If .Columns.Contains("JamMulai") Then .Columns("JamMulai").HeaderText = "Jam Mulai"
            If .Columns.Contains("Durasi") Then .Columns("Durasi").HeaderText = "Durasi (menit)"
            If .Columns.Contains("NamaKursus") Then .Columns("NamaKursus").HeaderText = "Nama Kursus"
            If .Columns.Contains("TglDaftarKelas") Then .Columns("TglDaftarKelas").HeaderText = "Tgl Daftar Kelas"
        End With
    End Sub

    Private Sub FormPesertaKelas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        isiComboKelas()
        Kosong()
    End Sub

    Private Sub cbKelas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbKelas.SelectedIndexChanged
        tampilDataPeserta()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 AndAlso DataGridView1.Rows.Count > 0 Then
            selectedID = e.RowIndex

            If Not DataGridView1.Columns.Contains("IDUser") Then Return

            Dim idUser As String = DataGridView1.Rows(e.RowIndex).Cells("IDUser").Value.ToString()
        End If
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        If cbKelas.SelectedIndex = -1 Then Exit Sub

        Try
            Dim keyword As String = txtCari.Text.Trim()
            Dim selectedKelas As KelasItem = DirectCast(cbKelas.SelectedItem, KelasItem)
            Dim idKelas As Integer = Convert.ToInt32(selectedKelas.IDKelas)

            Dim query As String = "SELECT pk.IDKelas, pk.IDUser, u.NamaLengkap, u.NoHP, u.Email, " &
                                  "CONCAT(u.TempatLahir, ', ', DATE_FORMAT(u.TanggalLahir, '%d-%m-%Y')) AS TTL, " &
                                  "u.Status, DATE_FORMAT(u.TanggalDaftar, '%d-%m-%Y') AS TglDaftar, " &
                                  "k.Hari, k.JamMulai, k.Durasi, kr.NamaKursus, " &
                                  "DATE_FORMAT(pk.TanggalDaftar, '%d-%m-%Y') AS TglDaftarKelas " &
                                  "FROM peserta_kelas pk " &
                                  "JOIN user u ON pk.IDUser = u.IDUser " &
                                  "JOIN kelas k ON pk.IDKelas = k.IDKelas " &
                                  "JOIN kursus kr ON k.KodeKursus = kr.KodeKursus " &
                                  "WHERE pk.IDKelas = @idkelas AND u.NamaLengkap LIKE @keyword "

            If FormUtama.roleAkses = "tutor" Then
                query &= "AND k.IDTutor = @idTutor "
            End If

            query &= "ORDER BY u.NamaLengkap"

            DA = New MySqlDataAdapter(query, CONN)
            DA.SelectCommand.Parameters.AddWithValue("@idkelas", idKelas)
            DA.SelectCommand.Parameters.AddWithValue("@keyword", "%" & keyword & "%")
            If FormUtama.roleAkses = "tutor" Then
                DA.SelectCommand.Parameters.AddWithValue("@idTutor", FormUtama.userID)
            End If

            DS = New DataSet
            DA.Fill(DS, "cari")

            DataGridView1.DataSource = DS.Tables("cari")
            aturGrid()
        Catch ex As Exception
            MessageBox.Show("Error saat mencari data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class