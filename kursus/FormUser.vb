Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class FormUser
    Private Sub FormUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupRoleComboBox()

        gbTutor.Visible = False
        gbNonTutor.Visible = False
        txtPassword.UseSystemPasswordChar = True
        koneksi()
        tampilUser()
        atur_grid()
        Kosong()
        dtpTanggalDaftar.Visible = False
        dtpTanggalLahir.Value = Today
        dtpTanggalDaftar.Value = Today

        cbStatus.Items.Clear()
        cbStatus.Items.AddRange(New String() {"Aktif", "Non-Aktif"})
        cbStatus.SelectedItem = "Aktif"
        cbStatus.Visible = False
        lblStatus.Visible = False
        SetButtonState(True, False, False, True)
        If FormUtama.roleAkses = "Front Office" Then
            btnHapus.Visible = False
        End If
    End Sub

    Private Sub SetButtonState(isSimpan As Boolean, isUbah As Boolean, isHapus As Boolean, isBatal As Boolean)
        btnSimpan.Enabled = isSimpan
        btnUbah.Enabled = isUbah
        btnHapus.Enabled = isHapus
        btnBatal.Enabled = isBatal
    End Sub

    Private Sub SetupRoleComboBox()
        cbRole.Items.Clear()

        If FormUtama.roleAkses = "Admin" Then
            cbRole.Items.AddRange(New String() {"Admin", "Front Office", "Tutor", "Peserta"})
            cbRole.Visible = True
            lblRole.Visible = True
            Me.Text = "Form User"
        ElseIf FormUtama.roleAkses = "Front Office" Then
            cbRole.Items.Add("Peserta")
            cbRole.SelectedItem = "Peserta"
            lblRole.Visible = False
            cbRole.Visible = False
            Me.Text = "Form Peserta"

            gbNonTutor.Visible = True
        Else
            MsgBox("Anda tidak memiliki akses ke Form User!", MsgBoxStyle.Critical)
            Me.Close()
        End If
    End Sub

    Private Sub cbRole_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbRole.SelectedIndexChanged
        If cbRole.Text = "Tutor" Then
            gbTutor.Visible = True
            gbNonTutor.Visible = True
        Else
            gbTutor.Visible = False
            gbNonTutor.Visible = True
        End If
    End Sub

    Function GetMD5(ByVal str As String) As String
        Dim md5 As MD5 = MD5.Create()
        Dim inputBytes As Byte() = Encoding.ASCII.GetBytes(str)
        Dim hashBytes As Byte() = md5.ComputeHash(inputBytes)
        Dim sb As New StringBuilder()
        For i As Integer = 0 To hashBytes.Length - 1
            sb.Append(hashBytes(i).ToString("x2"))
        Next
        Return sb.ToString()
    End Function

    Sub Kosong()
        txtID.Clear()
        txtUsername.Clear()
        txtPassword.Clear()
        txtNama.Clear()
        txtTempatLahir.Clear()
        dtpTanggalLahir.Value = Today
        txtAlamat.Clear()
        txtNoHP.Clear()
        txtEmail.Clear()
        txtPekerjaan.Clear()
        dtpTanggalDaftar.Value = Today
        cbStatus.SelectedItem = "Aktif"
        cbRole.SelectedIndex = -1
        txtPassword.UseSystemPasswordChar = True

        txtKeahlian.Clear()
        txtBiografi.Clear()
        txtTarif.Clear()

        GenerateID()

        SetButtonState(True, False, False, True)
    End Sub


    Sub GenerateID()
        Try
            CMD = New MySqlCommand("SELECT MAX(RIGHT(IDUser, 4)) AS maxID FROM user", CONN)
            RD = CMD.ExecuteReader
            If RD.Read Then
                If Not IsDBNull(RD("maxID")) Then
                    Dim angka As Integer = CInt(RD("maxID")) + 1
                    txtID.Text = "USR" & angka.ToString("D4")
                Else
                    txtID.Text = "USR0001"
                End If
            End If
            RD.Close()
        Catch ex As Exception
            MsgBox("Gagal generate ID: " & ex.Message)
        End Try
    End Sub

    Sub tampilUser()
        Dim query As String = "SELECT u.IDUser, u.Username, u.NamaLengkap, u.Email, u.NoHP, " & _
                              "u.TempatLahir, u.TanggalLahir, u.Alamat, u.Pekerjaan, " & _
                              "u.TanggalDaftar, u.Role, u.Status " & _
                              "FROM user u"

        If FormUtama.roleAkses = "Front Office" Then
            query &= " WHERE u.Role = 'Peserta'"
        End If

        DA = New MySqlDataAdapter(query, CONN)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "user")
        DataGridView1.DataSource = DS.Tables("user")
        DataGridView1.Refresh()
    End Sub

    Sub atur_grid()
        Try
            DataGridView1.Columns(0).HeaderText = "ID User"
            DataGridView1.Columns(1).HeaderText = "Username"
            DataGridView1.Columns(2).HeaderText = "Nama Lengkap"
            DataGridView1.Columns(3).HeaderText = "Email"
            DataGridView1.Columns(4).HeaderText = "No HP"
            DataGridView1.Columns(5).HeaderText = "Tempat Lahir"
            DataGridView1.Columns(6).HeaderText = "Tanggal Lahir"
            DataGridView1.Columns(7).HeaderText = "Alamat"
            DataGridView1.Columns(8).HeaderText = "Pekerjaan"
            DataGridView1.Columns(9).HeaderText = "Tanggal Daftar"
            DataGridView1.Columns(10).HeaderText = "Role"
            DataGridView1.Columns(11).HeaderText = "Status"

            DataGridView1.Columns(0).Width = 80
            DataGridView1.Columns(2).Width = 150
            DataGridView1.Columns(7).Width = 150
        Catch ex As Exception
            MsgBox("Error saat mengatur grid: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If String.IsNullOrEmpty(txtID.Text) OrElse String.IsNullOrEmpty(txtUsername.Text) OrElse _
           String.IsNullOrEmpty(txtPassword.Text) OrElse String.IsNullOrEmpty(txtNama.Text) Then
            MsgBox("Data utama (ID, Username, Password, Nama) harus diisi!", MsgBoxStyle.Exclamation)
            Return
        End If

        If cbRole.SelectedIndex = -1 Then
            MsgBox("Silakan pilih Role terlebih dahulu!", MsgBoxStyle.Exclamation)
            Return
        End If

        If Not String.IsNullOrEmpty(txtEmail.Text) AndAlso Not IsValidEmail(txtEmail.Text) Then
            MsgBox("Format email tidak valid!", MsgBoxStyle.Exclamation)
            txtEmail.Focus()
            Return
        End If


        If cbRole.Text = "Tutor" Then
            If String.IsNullOrEmpty(txtKeahlian.Text) OrElse String.IsNullOrEmpty(txtTarif.Text) Then
                MsgBox("Data Tutor (Keahlian dan Tarif) harus diisi!", MsgBoxStyle.Exclamation)
                Return
            End If
        End If

        Using transaction As MySqlTransaction = CONN.BeginTransaction()
            Try
                CMD = New MySqlCommand("SELECT * FROM user WHERE IDUser = @id", CONN)
                CMD.Parameters.AddWithValue("@id", txtID.Text)
                CMD.Transaction = transaction
                RD = CMD.ExecuteReader()

                Dim isNewData As Boolean = Not RD.HasRows
                RD.Close()

                If isNewData Then
                    CMD = New MySqlCommand("INSERT INTO user (IDUser, Username, Password, NamaLengkap, TempatLahir, TanggalLahir, Alamat, NoHP, Email, Pekerjaan, TanggalDaftar, Status, Role) " & _
                                         "VALUES(@id, @username, @password, @nama, @tempat, @tgl, @alamat, @nohp, @email, @pekerjaan, @tgldaftar, @status, @role)", CONN)
                    With CMD.Parameters
                        .AddWithValue("@id", txtID.Text)
                        .AddWithValue("@username", txtUsername.Text)
                        .AddWithValue("@password", GetMD5(txtPassword.Text))
                        .AddWithValue("@nama", txtNama.Text)
                        .AddWithValue("@tempat", txtTempatLahir.Text)
                        .AddWithValue("@tgl", dtpTanggalLahir.Value.ToString("yyyy-MM-dd"))
                        .AddWithValue("@alamat", txtAlamat.Text)
                        .AddWithValue("@nohp", txtNoHP.Text)
                        .AddWithValue("@email", txtEmail.Text)
                        .AddWithValue("@pekerjaan", txtPekerjaan.Text)
                        .AddWithValue("@tgldaftar", dtpTanggalDaftar.Value.ToString("yyyy-MM-dd"))
                        .AddWithValue("@status", cbStatus.Text)
                        .AddWithValue("@role", cbRole.Text)
                    End With
                    CMD.Transaction = transaction
                    CMD.ExecuteNonQuery()

                    If cbRole.Text = "Tutor" Then
                        CMD = New MySqlCommand("INSERT INTO detailtutor (IDUser, Keahlian, Biografi, TarifPersesi) " & _
                                             "VALUES(@id, @keahlian, @biografi, @tarif)", CONN)
                        With CMD.Parameters
                            .AddWithValue("@id", txtID.Text)
                            .AddWithValue("@keahlian", txtKeahlian.Text)
                            .AddWithValue("@biografi", txtBiografi.Text)
                            .AddWithValue("@tarif", If(String.IsNullOrEmpty(txtTarif.Text), 0, Decimal.Parse(txtTarif.Text)))
                        End With
                        CMD.Transaction = transaction
                        CMD.ExecuteNonQuery()
                    End If

                    transaction.Commit()
                    MsgBox("Data berhasil disimpan.")
                Else
                    RD.Close()
                    MsgBox("ID User sudah terdaftar!")
                    transaction.Rollback()
                End If
            Catch ex As Exception
                transaction.Rollback()
                MsgBox("Error saat menyimpan data: " & ex.Message, MsgBoxStyle.Critical)
            End Try
        End Using

        tampilUser()
        Kosong()
    End Sub

    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click
        If txtID.Text = "" Then
            MsgBox("ID User belum diisi!")
            Return
        End If

        If cbRole.SelectedIndex = -1 Then
            MsgBox("Silakan pilih Role terlebih dahulu!", MsgBoxStyle.Exclamation)
            Return
        End If

        If Not String.IsNullOrEmpty(txtEmail.Text) AndAlso Not IsValidEmail(txtEmail.Text) Then
            MsgBox("Format email tidak valid!", MsgBoxStyle.Exclamation)
            txtEmail.Focus()
            Return
        End If

        If cbRole.Text = "Tutor" Then
            If String.IsNullOrEmpty(txtKeahlian.Text) OrElse String.IsNullOrEmpty(txtTarif.Text) Then
                MsgBox("Data Tutor (Keahlian dan Tarif) harus diisi!", MsgBoxStyle.Exclamation)
                Return
            End If
        End If

        Using transaction As MySqlTransaction = CONN.BeginTransaction()
            Try
                Dim passwordClause As String = ""
                If Not String.IsNullOrEmpty(txtPassword.Text) Then
                    passwordClause = "Password=@password, "
                End If

                CMD = New MySqlCommand("UPDATE user SET Username=@username, " & passwordClause & _
                                     "NamaLengkap=@nama, TempatLahir=@tempat, TanggalLahir=@tgl, " & _
                                     "Alamat=@alamat, NoHP=@nohp, Email=@email, Pekerjaan=@pekerjaan, " & _
                                     "TanggalDaftar=@tgldaftar, Status=@status, Role=@role " & _
                                     "WHERE IDUser=@id", CONN)

                With CMD.Parameters
                    .AddWithValue("@id", txtID.Text)
                    .AddWithValue("@username", txtUsername.Text)
                    If Not String.IsNullOrEmpty(txtPassword.Text) Then
                        .AddWithValue("@password", GetMD5(txtPassword.Text))
                    End If
                    .AddWithValue("@nama", txtNama.Text)
                    .AddWithValue("@tempat", txtTempatLahir.Text)
                    .AddWithValue("@tgl", dtpTanggalLahir.Value.ToString("yyyy-MM-dd"))
                    .AddWithValue("@alamat", txtAlamat.Text)
                    .AddWithValue("@nohp", txtNoHP.Text)
                    .AddWithValue("@email", txtEmail.Text)
                    .AddWithValue("@pekerjaan", txtPekerjaan.Text)
                    .AddWithValue("@tgldaftar", dtpTanggalDaftar.Value.ToString("yyyy-MM-dd"))
                    .AddWithValue("@status", cbStatus.Text)
                    .AddWithValue("@role", cbRole.Text)
                End With

                CMD.Transaction = transaction
                CMD.ExecuteNonQuery()

                CMD = New MySqlCommand("SELECT COUNT(*) FROM detailtutor WHERE IDUser = @id", CONN)
                CMD.Parameters.AddWithValue("@id", txtID.Text)
                CMD.Transaction = transaction
                Dim tutorDataExists As Integer = Convert.ToInt32(CMD.ExecuteScalar())

                If cbRole.Text = "Tutor" Then
                    If tutorDataExists > 0 Then
                        CMD = New MySqlCommand("UPDATE detailtutor SET Keahlian=@keahlian, Biografi=@biografi, " & _
                                             "TarifPersesi=@tarif " & _
                                             "WHERE IDUser=@id", CONN)
                        With CMD.Parameters
                            .AddWithValue("@id", txtID.Text)
                            .AddWithValue("@keahlian", txtKeahlian.Text)
                            .AddWithValue("@biografi", txtBiografi.Text)
                            .AddWithValue("@tarif", If(String.IsNullOrEmpty(txtTarif.Text), 0, Decimal.Parse(txtTarif.Text)))
                        End With
                    Else
                        CMD = New MySqlCommand("INSERT INTO detailtutor (IDUser, Keahlian, Biografi, TarifPersesi) " & _
                                             "VALUES(@id, @keahlian, @biografi, @tarif)", CONN)
                        With CMD.Parameters
                            .AddWithValue("@id", txtID.Text)
                            .AddWithValue("@keahlian", txtKeahlian.Text)
                            .AddWithValue("@biografi", txtBiografi.Text)
                            .AddWithValue("@tarif", If(String.IsNullOrEmpty(txtTarif.Text), 0, Decimal.Parse(txtTarif.Text)))
                        End With
                    End If
                    CMD.Transaction = transaction
                    CMD.ExecuteNonQuery()
                ElseIf tutorDataExists > 0 Then
                    CMD = New MySqlCommand("DELETE FROM detailtutor WHERE IDUser=@id", CONN)
                    CMD.Parameters.AddWithValue("@id", txtID.Text)
                    CMD.Transaction = transaction
                    CMD.ExecuteNonQuery()
                End If

                transaction.Commit()
                MsgBox("Data berhasil diubah.")
            Catch ex As Exception
                transaction.Rollback()
                MsgBox("Error saat mengubah data: " & ex.Message, MsgBoxStyle.Critical)
            End Try
        End Using

        tampilUser()
        Kosong()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If txtID.Text = "" Then
            MsgBox("ID User belum diisi!")
        Else
            If MsgBox("Yakin ingin menghapus data?", MsgBoxStyle.YesNo, "Konfirmasi") = MsgBoxResult.Yes Then
                Using transaction As MySqlTransaction = CONN.BeginTransaction()
                    Try
                        CMD = New MySqlCommand("DELETE FROM detailtutor WHERE IDUser=@id", CONN)
                        CMD.Parameters.AddWithValue("@id", txtID.Text)
                        CMD.Transaction = transaction
                        CMD.ExecuteNonQuery()

                        CMD = New MySqlCommand("DELETE FROM user WHERE IDUser=@id", CONN)
                        CMD.Parameters.AddWithValue("@id", txtID.Text)
                        CMD.Transaction = transaction
                        CMD.ExecuteNonQuery()

                        transaction.Commit()
                        MsgBox("Data berhasil dihapus.")
                    Catch ex As Exception
                        transaction.Rollback()
                        MsgBox("Error saat menghapus data: " & ex.Message, MsgBoxStyle.Critical)
                    End Try
                End Using

                tampilUser()
                Kosong()
            End If
        End If
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Kosong()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            txtID.Text = row.Cells("IDUser").Value.ToString()
            txtUsername.Text = row.Cells("Username").Value.ToString()
            txtPassword.Clear()
            txtNama.Text = row.Cells("NamaLengkap").Value.ToString()

            txtTempatLahir.Text = If(row.Cells("TempatLahir").Value IsNot DBNull.Value, row.Cells("TempatLahir").Value.ToString(), "")
            If row.Cells("TanggalLahir").Value IsNot DBNull.Value Then
                dtpTanggalLahir.Value = CDate(row.Cells("TanggalLahir").Value)
            Else
                dtpTanggalLahir.Value = Today
            End If

            txtAlamat.Text = If(row.Cells("Alamat").Value IsNot DBNull.Value, row.Cells("Alamat").Value.ToString(), "")
            txtNoHP.Text = If(row.Cells("NoHP").Value IsNot DBNull.Value, row.Cells("NoHP").Value.ToString(), "")
            txtEmail.Text = If(row.Cells("Email").Value IsNot DBNull.Value, row.Cells("Email").Value.ToString(), "")
            txtPekerjaan.Text = If(row.Cells("Pekerjaan").Value IsNot DBNull.Value, row.Cells("Pekerjaan").Value.ToString(), "")

            If row.Cells("TanggalDaftar").Value IsNot DBNull.Value Then
                dtpTanggalDaftar.Value = CDate(row.Cells("TanggalDaftar").Value)
            Else
                dtpTanggalDaftar.Value = Today
            End If
            cbStatus.Visible = True
            lblStatus.Visible = True
            cbStatus.Text = If(row.Cells("Status").Value IsNot DBNull.Value, row.Cells("Status").Value.ToString(), "Aktif")
            cbRole.Text = If(row.Cells("Role").Value IsNot DBNull.Value, row.Cells("Role").Value.ToString(), "")

            If cbRole.Text = "Tutor" Then
                Try
                    CMD = New MySqlCommand("SELECT Keahlian, Biografi, TarifPersesi FROM detailtutor WHERE IDUser = @id", CONN)
                    CMD.Parameters.AddWithValue("@id", txtID.Text)
                    RD = CMD.ExecuteReader()

                    If RD.Read() Then
                        txtKeahlian.Text = If(RD.IsDBNull(RD.GetOrdinal("Keahlian")), "", RD("Keahlian").ToString())
                        txtBiografi.Text = If(RD.IsDBNull(RD.GetOrdinal("Biografi")), "", RD("Biografi").ToString())
                        txtTarif.Text = If(RD.IsDBNull(RD.GetOrdinal("TarifPersesi")), "", RD("TarifPersesi").ToString())
                    Else
                        txtKeahlian.Clear()
                        txtBiografi.Clear()
                        txtTarif.Clear()
                    End If
                    RD.Close()
                Catch ex As Exception
                    If Not RD.IsClosed Then RD.Close()
                    MsgBox("Error saat mengambil data tutor: " & ex.Message)
                End Try
            Else
                txtKeahlian.Clear()
                txtBiografi.Clear()
                txtTarif.Clear()
            End If

            SetButtonState(False, True, True, True)
        End If
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        If txtCari.Text <> "" Then
            Dim query As String = "SELECT u.IDUser, u.Username, u.NamaLengkap, u.Email, u.NoHP, " & _
                                  "u.TempatLahir, u.TanggalLahir, u.Alamat, u.Pekerjaan, " & _
                                  "u.TanggalDaftar, u.Role, u.Status " & _
                                  "FROM user u " & _
                                  "WHERE u.IDUser LIKE '%" & txtCari.Text & "%' OR u.NamaLengkap LIKE '%" & txtCari.Text & "%'"

            If FormUtama.roleAkses = "Front Office" Then
                query &= " AND u.Role='Peserta'"
            End If

            DA = New MySqlDataAdapter(query, CONN)
            DS = New DataSet
            DS.Clear()
            DA.Fill(DS, "cari")
            DataGridView1.DataSource = DS.Tables("cari")
        Else
            tampilUser()
        End If
    End Sub

    Private Function IsValidEmail(ByVal email As String) As Boolean
        Try
            Dim addr = New System.Net.Mail.MailAddress(email)
            Return addr.Address = email
        Catch
            Return False
        End Try
    End Function

    Private Sub txtNoHP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoHP.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTarif_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTarif.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        If e.KeyChar = "."c AndAlso CType(sender, TextBox).Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmail.KeyPress
        If e.KeyChar = " "c Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtEmail_Leave(sender As Object, e As EventArgs) Handles txtEmail.Leave
        If Not String.IsNullOrEmpty(txtEmail.Text) AndAlso Not IsValidEmail(txtEmail.Text) Then
            MsgBox("Format email tidak valid!", MsgBoxStyle.Exclamation)
            txtEmail.Focus()
        End If
    End Sub

    Private Sub txtAlphaOnly_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress, txtTempatLahir.KeyPress, txtPekerjaan.KeyPress, txtKeahlian.KeyPress, txtBiografi.KeyPress
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNumeric_TextChanged(sender As Object, e As EventArgs) Handles txtNoHP.TextChanged
        Dim textBox As TextBox = DirectCast(sender, TextBox)
        Dim cursorPos As Integer = textBox.SelectionStart

        Dim cleanText As String = String.Empty
        For Each c As Char In textBox.Text
            If Char.IsDigit(c) Then
                cleanText &= c
            End If
        Next

        If textBox.Text <> cleanText Then
            textBox.Text = cleanText
            textBox.SelectionStart = Math.Min(cursorPos, textBox.Text.Length)
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class