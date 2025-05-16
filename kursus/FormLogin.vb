Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class FormLogin
    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        Label3.Select()
        If txtUsername.Text = "" Then
            txtUsername.Text = "Username"
            txtUsername.ForeColor = Color.DarkGray
        End If

        If txtPassword.Text = "" Then
            txtPassword.Text = "Password"
            txtPassword.ForeColor = Color.DarkGray
            txtPassword.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub cbLihatPassword_CheckedChanged(sender As Object, e As EventArgs) Handles cbLihatPassword.CheckedChanged
        txtPassword.UseSystemPasswordChar = Not cbLihatPassword.Checked
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

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            MsgBox("Username dan Password tidak boleh kosong!", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Try
            koneksi()
            Dim query As String = "SELECT * FROM user WHERE Username=@user AND Password=@pass AND Status='Aktif'"
            CMD = New MySqlCommand(query, CONN)
            CMD.Parameters.AddWithValue("@user", txtUsername.Text)
            CMD.Parameters.AddWithValue("@pass", GetMD5(txtPassword.Text))
            RD = CMD.ExecuteReader()

            If RD.Read() Then
                MsgBox("Login berhasil. Selamat datang, " & RD("NamaLengkap"))

                FormUtama.lblUser.Text = RD("NamaLengkap").ToString()
                FormUtama.lblRole.Text = RD("Role").ToString()
                FormUtama.roleAkses = RD("Role").ToString()
                FormUtama.userID = RD("IDUser").ToString()

                Me.Hide()
                FormUtama.Show()
            Else
                MsgBox("Username atau Password salah!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan koneksi: " & ex.Message)
        Finally
            If CONN.State = ConnectionState.Open Then CONN.Close()
        End Try
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub txtUsername_GotFocus(sender As Object, e As EventArgs) Handles txtUsername.GotFocus
        If txtUsername.Text = "Username" Then
            txtUsername.Text = ""
            txtUsername.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtUsername_LostFocus(sender As Object, e As EventArgs) Handles txtUsername.LostFocus
        If txtUsername.Text = "" Then
            txtUsername.Text = "Username"
            txtUsername.ForeColor = Color.DarkGray
        End If
    End Sub

    Private Sub txtPassword_GotFocus(sender As Object, e As EventArgs) Handles txtPassword.GotFocus
        If txtPassword.Text = "Password" Then
            txtPassword.UseSystemPasswordChar = True
            txtPassword.Text = ""
            txtPassword.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtPassword_LostFocus(sender As Object, e As EventArgs) Handles txtPassword.LostFocus
        If txtPassword.Text = "" Then
            txtPassword.UseSystemPasswordChar = False
            txtPassword.Text = "Password"
            txtPassword.ForeColor = Color.DarkGray
        End If
    End Sub
End Class
