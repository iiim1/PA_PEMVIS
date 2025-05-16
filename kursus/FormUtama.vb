Imports MySql.Data.MySqlClient
Public Class FormUtama
    Public roleAkses As String
    Public userID As String
    Private Sub FormUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUser.Text = lblUser.Text
        lblRole.Text = lblRole.Text
        Select Case roleAkses
            Case "Admin"
                lblTutor.Visible = False
                PictureBoxTutor.Visible = False
                btnKelasAnda.Visible = False
            Case "Front Office"
                btnKelasAnda.Visible = False
                labelBtnUser.Text = "Peserta"
                lblTutor.Visible = False
                PictureBoxTutor.Visible = False
            Case "Tutor"
                btnMaster.Visible = False
                btnBayar.Visible = False
                btnLaporan.Visible = False
                btnUser.Visible = False
                btnKursus.Visible = False
                btnKelas.Visible = False
                labelBtnUser.Visible = False
                labelBtnKursus.Visible = False
                labelBtnKelas.Visible = False
            Case "Peserta"
                btnPeserta.Visible = False
                btnMaster.Visible = False
                btnBayar.Visible = False
                btnLaporan.Visible = False
                btnUser.Visible = False
                btnKursus.Visible = False
                btnKelas.Visible = False
                labelBtnUser.Visible = False
                labelBtnKursus.Visible = False
                labelBtnKelas.Visible = False
            Case Else
                MsgBox("Role tidak dikenali, akses ditolak.")
                Me.Close()
        End Select
    End Sub
    Private Sub btnLogoutClick(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin keluar dari aplikasi?",
                                            "Konfirmasi Logout",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            lblUser.Text = ""
            lblRole.Text = ""
            roleAkses = ""
            userID = ""
            Me.Hide()
            Dim frmLogin As New FormLogin()
            frmLogin.txtUsername.Clear()
            frmLogin.txtPassword.Clear()
            frmLogin.Show()
        End If
    End Sub
    Private Sub btnProfile_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        FormSettings.Show()
    End Sub
    Private Sub btnBayar_Click(sender As Object, e As EventArgs) Handles btnBayar.Click
        FormEnrollBayar.Show()
    End Sub
    Private Sub btnPeserta_Click(sender As Object, e As EventArgs) Handles btnPeserta.Click
        FormPesertaKelas.Show()
    End Sub
    Private Sub btnLaporan_Click(sender As Object, e As EventArgs) Handles btnLaporan.Click
        FormLaporanPembayaran.Show()
    End Sub
    Private Sub btnUser_Click(sender As Object, e As EventArgs) Handles btnUser.Click
        FormUser.Show()
    End Sub
    Private Sub btnKursus_Click(sender As Object, e As EventArgs) Handles btnKursus.Click
        FormKursus.Show()
    End Sub
    Private Sub btnKelas_Click(sender As Object, e As EventArgs) Handles btnKelas.Click
        FormKelas.Show()
    End Sub
    Private Sub btnPesertaKelas_Click(sender As Object, e As EventArgs)
        FormPesertaKelas.Show()
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnKelasAnda_Click(sender As Object, e As EventArgs) Handles btnKelasAnda.Click
        FormKelas.Show()
    End Sub
End Class