Imports MySql.Data.MySqlClient

Public Class FormSettings
    Private Sub FormSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        LoadUserData()
        SetupFormBasedOnRole()

        btnUpdate.Enabled = False
    End Sub

    Private Sub AnyControl_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged, txtNamaLengkap.TextChanged, txtEmail.TextChanged, txtNoHP.TextChanged, txtTempatLahir.TextChanged, dtpTanggalLahir.ValueChanged, txtAlamat.TextChanged, txtPekerjaan.TextChanged, txtKeahlian.TextChanged, txtBiografi.TextChanged
        btnUpdate.Enabled = True
    End Sub

    Private Sub LoadUserData()
        Try
            CMD = New MySqlCommand("SELECT * FROM user WHERE IDUser = @IDUser", CONN)
            CMD.Parameters.AddWithValue("@IDUser", FormUtama.userID)
            RD = CMD.ExecuteReader()

            If RD.Read() Then
                txtUsername.Text = RD("Username").ToString()
                txtNamaLengkap.Text = RD("NamaLengkap").ToString()
                txtEmail.Text = RD("Email").ToString()
                txtNoHP.Text = RD("NoHP").ToString()
                txtTempatLahir.Text = RD("TempatLahir").ToString()
                dtpTanggalLahir.Value = If(IsDBNull(RD("TanggalLahir")), DateTime.Now, Convert.ToDateTime(RD("TanggalLahir")))
                dtpTanggalLahir.MaxDate = Date.Today
                txtAlamat.Text = RD("Alamat").ToString()
                txtPekerjaan.Text = RD("Pekerjaan").ToString()
            End If
            RD.Close()

            If FormUtama.roleAkses = "Tutor" Then
                CMD = New MySqlCommand("SELECT * FROM detailtutor WHERE IDUser = @IDUser", CONN)
                CMD.Parameters.AddWithValue("@IDUser", FormUtama.userID)
                RD = CMD.ExecuteReader()

                If RD.Read() Then
                    txtKeahlian.Text = RD("Keahlian").ToString()
                    txtBiografi.Text = RD("Biografi").ToString()
                    If Not IsDBNull(RD("TarifPersesi")) Then
                        lblTarif.Text = Convert.ToDecimal(RD("TarifPersesi")).ToString("N2")
                    End If
                End If
                RD.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading user data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetupFormBasedOnRole()
        Select Case FormUtama.roleAkses
            Case "Admin"
                Me.Text = "Update Profil Admin"
                lblRole.Text = "Admin"
                gbTutorInfo.Visible = False

            Case "Tutor"
                Me.Text = "Update Profil Tutor"
                lblRole.Text = "Tutor"
                gbTutorInfo.Visible = True

            Case "Peserta"
                Me.Text = "Update Profil Peserta"
                lblRole.Text = "Peserta"
                gbTutorInfo.Visible = False
            Case "Front Office"
                Me.Text = "Update Profil Front Office"
                lblRole.Text = "Front Office"
                gbTutorInfo.Visible = False
            Case Else
                Me.Text = "Update Profil"
                lblRole.Text = "Unknown"
                gbTutorInfo.Visible = False
        End Select
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
        If Not ValidateInput() Then Exit Sub

        Try
            CONN.Open()
            Dim transaction As MySqlTransaction = CONN.BeginTransaction()

            Try
                CMD = New MySqlCommand("UPDATE user SET Username = @Username, NamaLengkap = @NamaLengkap, " & _
                                      "Email = @Email, NoHP = @NoHP, TempatLahir = @TempatLahir, " & _
                                      "TanggalLahir = @TanggalLahir, Alamat = @Alamat, Pekerjaan = @Pekerjaan " & _
                                      "WHERE IDUser = @IDUser", CONN, transaction)

                With CMD.Parameters
                    .AddWithValue("@Username", txtUsername.Text)
                    .AddWithValue("@NamaLengkap", txtNamaLengkap.Text)
                    .AddWithValue("@Email", txtEmail.Text)
                    .AddWithValue("@NoHP", txtNoHP.Text)
                    .AddWithValue("@TempatLahir", txtTempatLahir.Text)
                    .AddWithValue("@TanggalLahir", dtpTanggalLahir.Value)
                    .AddWithValue("@Alamat", txtAlamat.Text)
                    .AddWithValue("@Pekerjaan", txtPekerjaan.Text)
                    .AddWithValue("@IDUser", FormUtama.userID)
                End With

                Dim rowsAffected As Integer = CMD.ExecuteNonQuery()

                If FormUtama.roleAkses = "Tutor" Then
                    CMD = New MySqlCommand("SELECT COUNT(*) FROM detailtutor WHERE IDUser = @IDUser", CONN, transaction)
                    CMD.Parameters.AddWithValue("@IDUser", FormUtama.userID)
                    Dim recordExists As Integer = Convert.ToInt32(CMD.ExecuteScalar())

                    If recordExists > 0 Then
                        CMD = New MySqlCommand("UPDATE detailtutor SET Keahlian = @Keahlian, " & _
                                              "Biografi = @Biografi " & _
                                              "WHERE IDUser = @IDUser", CONN, transaction)
                    Else
                        CMD = New MySqlCommand("INSERT INTO detailtutor (IDUser, Keahlian, Biografi) " & _
                                              "VALUES (@IDUser, @Keahlian, @Biografi)", CONN, transaction)
                    End If

                    With CMD.Parameters
                        .AddWithValue("@IDUser", FormUtama.userID)
                        .AddWithValue("@Keahlian", txtKeahlian.Text)
                        .AddWithValue("@Biografi", txtBiografi.Text)
                    End With

                    Dim tutorRowsAffected As Integer = CMD.ExecuteNonQuery()
                    rowsAffected += tutorRowsAffected
                End If

                transaction.Commit()

                If rowsAffected > 0 Then
                    MessageBox.Show("Profil berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Else
                    MessageBox.Show("Tidak ada perubahan data.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                transaction.Rollback()
                Throw
            End Try

        Catch ex As MySqlException
            MessageBox.Show("Error MySQL: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try
    End Sub

    Private Function ValidateInput() As Boolean
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Username tidak boleh kosong!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtNamaLengkap.Text) Then
            MessageBox.Show("Nama lengkap tidak boleh kosong!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNamaLengkap.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtEmail.Text) Then
            MessageBox.Show("Email tidak boleh kosong!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return False
        End If

        If Not IsNumeric(txtNoHP.Text) Then
            MsgBox("No. HP harus berupa angka!")
            txtNoHP.Focus()
            Return False
        End If

        If FormUtama.roleAkses = "Tutor" Then
            If String.IsNullOrWhiteSpace(txtKeahlian.Text) Then
                MessageBox.Show("Keahlian tidak boleh kosong untuk tutor!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtKeahlian.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class