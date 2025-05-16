<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUser
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormUser))
        Me.txtNoHP = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbStatus = New System.Windows.Forms.ComboBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnBatal = New System.Windows.Forms.Button()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.btnUbah = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.txtCari = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAlamat = New System.Windows.Forms.TextBox()
        Me.dtpTanggalLahir = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTempatLahir = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtNama = New System.Windows.Forms.TextBox()
        Me.label = New System.Windows.Forms.Label()
        Me.txtPekerjaan = New System.Windows.Forms.TextBox()
        Me.dtpTanggalDaftar = New System.Windows.Forms.DateTimePicker()
        Me.cbRole = New System.Windows.Forms.ComboBox()
        Me.lblRole = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.gbTutor = New System.Windows.Forms.GroupBox()
        Me.txtTarif = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtKeahlian = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtBiografi = New System.Windows.Forms.TextBox()
        Me.gbNonTutor = New System.Windows.Forms.GroupBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTutor.SuspendLayout()
        Me.gbNonTutor.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNoHP
        '
        Me.txtNoHP.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNoHP.Location = New System.Drawing.Point(548, 80)
        Me.txtNoHP.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNoHP.Name = "txtNoHP"
        Me.txtNoHP.Size = New System.Drawing.Size(259, 20)
        Me.txtNoHP.TabIndex = 47
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(426, 80)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 25)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "No. Hp"
        '
        'cbStatus
        '
        Me.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Location = New System.Drawing.Point(548, 149)
        Me.cbStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(259, 31)
        Me.cbStatus.TabIndex = 45
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Location = New System.Drawing.Point(426, 145)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(55, 25)
        Me.lblStatus.TabIndex = 44
        Me.lblStatus.Text = "Status"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(53, 475)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(808, 191)
        Me.DataGridView1.TabIndex = 43
        '
        'btnBatal
        '
        Me.btnBatal.BackColor = System.Drawing.Color.Red
        Me.btnBatal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBatal.FlatAppearance.BorderSize = 0
        Me.btnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBatal.Font = New System.Drawing.Font("Poppins SemiBold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnBatal.ForeColor = System.Drawing.Color.White
        Me.btnBatal.Location = New System.Drawing.Point(590, 399)
        Me.btnBatal.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(109, 36)
        Me.btnBatal.TabIndex = 42
        Me.btnBatal.Text = "Batal"
        Me.btnBatal.UseVisualStyleBackColor = False
        '
        'btnHapus
        '
        Me.btnHapus.BackColor = System.Drawing.Color.Red
        Me.btnHapus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHapus.FlatAppearance.BorderSize = 0
        Me.btnHapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHapus.Font = New System.Drawing.Font("Poppins SemiBold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnHapus.ForeColor = System.Drawing.Color.White
        Me.btnHapus.Location = New System.Drawing.Point(482, 399)
        Me.btnHapus.Margin = New System.Windows.Forms.Padding(4)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(100, 36)
        Me.btnHapus.TabIndex = 41
        Me.btnHapus.Text = "Hapus"
        Me.btnHapus.UseVisualStyleBackColor = False
        '
        'btnUbah
        '
        Me.btnUbah.BackColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnUbah.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUbah.FlatAppearance.BorderSize = 0
        Me.btnUbah.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUbah.Font = New System.Drawing.Font("Poppins SemiBold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnUbah.ForeColor = System.Drawing.Color.White
        Me.btnUbah.Location = New System.Drawing.Point(374, 399)
        Me.btnUbah.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUbah.Name = "btnUbah"
        Me.btnUbah.Size = New System.Drawing.Size(100, 36)
        Me.btnUbah.TabIndex = 40
        Me.btnUbah.Text = "Ubah"
        Me.btnUbah.UseVisualStyleBackColor = False
        '
        'btnSimpan
        '
        Me.btnSimpan.BackColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnSimpan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSimpan.FlatAppearance.BorderSize = 0
        Me.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSimpan.Font = New System.Drawing.Font("Poppins SemiBold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSimpan.ForeColor = System.Drawing.Color.White
        Me.btnSimpan.Location = New System.Drawing.Point(253, 399)
        Me.btnSimpan.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(113, 35)
        Me.btnSimpan.TabIndex = 39
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = False
        '
        'txtCari
        '
        Me.txtCari.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCari.Location = New System.Drawing.Point(53, 443)
        Me.txtCari.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(808, 27)
        Me.txtCari.TabIndex = 38
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(7, 110)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 25)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Pekerjaan"
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtEmail.Location = New System.Drawing.Point(123, 145)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(259, 20)
        Me.txtEmail.TabIndex = 35
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(7, 140)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 25)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Email"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(427, 113)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 25)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Alamat"
        '
        'txtAlamat
        '
        Me.txtAlamat.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAlamat.Location = New System.Drawing.Point(548, 108)
        Me.txtAlamat.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAlamat.Multiline = True
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAlamat.Size = New System.Drawing.Size(259, 33)
        Me.txtAlamat.TabIndex = 30
        '
        'dtpTanggalLahir
        '
        Me.dtpTanggalLahir.Location = New System.Drawing.Point(548, 47)
        Me.dtpTanggalLahir.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpTanggalLahir.Name = "dtpTanggalLahir"
        Me.dtpTanggalLahir.Size = New System.Drawing.Size(259, 27)
        Me.dtpTanggalLahir.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(426, 51)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 25)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Tanggal Lahir"
        '
        'txtTempatLahir
        '
        Me.txtTempatLahir.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTempatLahir.Location = New System.Drawing.Point(123, 81)
        Me.txtTempatLahir.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTempatLahir.Name = "txtTempatLahir"
        Me.txtTempatLahir.Size = New System.Drawing.Size(259, 20)
        Me.txtTempatLahir.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(7, 81)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 25)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Tempat Lahir"
        '
        'txtID
        '
        Me.txtID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtID.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(177, 77)
        Me.txtID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(259, 20)
        Me.txtID.TabIndex = 25
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.BackColor = System.Drawing.Color.Transparent
        Me.label1.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(55, 77)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(59, 25)
        Me.label1.TabIndex = 24
        Me.label1.Text = "ID User"
        '
        'txtNama
        '
        Me.txtNama.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNama.Location = New System.Drawing.Point(123, 51)
        Me.txtNama.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(259, 20)
        Me.txtNama.TabIndex = 49
        '
        'label
        '
        Me.label.AutoSize = True
        Me.label.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label.ForeColor = System.Drawing.Color.White
        Me.label.Location = New System.Drawing.Point(7, 48)
        Me.label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label.Name = "label"
        Me.label.Size = New System.Drawing.Size(116, 25)
        Me.label.TabIndex = 48
        Me.label.Text = "Nama Lengkap"
        '
        'txtPekerjaan
        '
        Me.txtPekerjaan.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPekerjaan.Location = New System.Drawing.Point(123, 113)
        Me.txtPekerjaan.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPekerjaan.Name = "txtPekerjaan"
        Me.txtPekerjaan.Size = New System.Drawing.Size(259, 20)
        Me.txtPekerjaan.TabIndex = 50
        '
        'dtpTanggalDaftar
        '
        Me.dtpTanggalDaftar.Location = New System.Drawing.Point(602, 10)
        Me.dtpTanggalDaftar.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpTanggalDaftar.Name = "dtpTanggalDaftar"
        Me.dtpTanggalDaftar.Size = New System.Drawing.Size(259, 22)
        Me.dtpTanggalDaftar.TabIndex = 51
        Me.dtpTanggalDaftar.Visible = False
        '
        'cbRole
        '
        Me.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbRole.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRole.FormattingEnabled = True
        Me.cbRole.Location = New System.Drawing.Point(602, 69)
        Me.cbRole.Margin = New System.Windows.Forms.Padding(4)
        Me.cbRole.Name = "cbRole"
        Me.cbRole.Size = New System.Drawing.Size(259, 31)
        Me.cbRole.TabIndex = 53
        '
        'lblRole
        '
        Me.lblRole.AutoSize = True
        Me.lblRole.BackColor = System.Drawing.Color.Transparent
        Me.lblRole.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRole.ForeColor = System.Drawing.Color.White
        Me.lblRole.Location = New System.Drawing.Point(480, 72)
        Me.lblRole.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRole.Name = "lblRole"
        Me.lblRole.Size = New System.Drawing.Size(42, 25)
        Me.lblRole.TabIndex = 52
        Me.lblRole.Text = "Role"
        '
        'txtUsername
        '
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUsername.Location = New System.Drawing.Point(123, 21)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(259, 20)
        Me.txtUsername.TabIndex = 55
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(7, 21)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 25)
        Me.Label11.TabIndex = 54
        Me.Label11.Text = "Username"
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPassword.Location = New System.Drawing.Point(548, 21)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(259, 20)
        Me.txtPassword.TabIndex = 57
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(427, 21)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 25)
        Me.Label12.TabIndex = 56
        Me.Label12.Text = "Password"
        '
        'gbTutor
        '
        Me.gbTutor.BackColor = System.Drawing.Color.Transparent
        Me.gbTutor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.gbTutor.Controls.Add(Me.txtTarif)
        Me.gbTutor.Controls.Add(Me.Label15)
        Me.gbTutor.Controls.Add(Me.Label13)
        Me.gbTutor.Controls.Add(Me.txtKeahlian)
        Me.gbTutor.Controls.Add(Me.Label18)
        Me.gbTutor.Controls.Add(Me.Label14)
        Me.gbTutor.Controls.Add(Me.txtBiografi)
        Me.gbTutor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbTutor.Location = New System.Drawing.Point(54, 303)
        Me.gbTutor.Name = "gbTutor"
        Me.gbTutor.Size = New System.Drawing.Size(810, 84)
        Me.gbTutor.TabIndex = 95
        Me.gbTutor.TabStop = False
        '
        'txtTarif
        '
        Me.txtTarif.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTarif.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTarif.Location = New System.Drawing.Point(548, 24)
        Me.txtTarif.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTarif.Name = "txtTarif"
        Me.txtTarif.Size = New System.Drawing.Size(259, 20)
        Me.txtTarif.TabIndex = 112
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(512, 24)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 25)
        Me.Label15.TabIndex = 111
        Me.Label15.Text = "Rp."
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(7, 24)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 25)
        Me.Label13.TabIndex = 84
        Me.Label13.Text = "Keahlian"
        '
        'txtKeahlian
        '
        Me.txtKeahlian.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKeahlian.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKeahlian.Location = New System.Drawing.Point(124, 21)
        Me.txtKeahlian.Margin = New System.Windows.Forms.Padding(4)
        Me.txtKeahlian.Name = "txtKeahlian"
        Me.txtKeahlian.Size = New System.Drawing.Size(259, 20)
        Me.txtKeahlian.TabIndex = 85
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(427, 24)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(42, 25)
        Me.Label18.TabIndex = 91
        Me.Label18.Text = "Tarif"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(7, 51)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 25)
        Me.Label14.TabIndex = 86
        Me.Label14.Text = "Biografi"
        '
        'txtBiografi
        '
        Me.txtBiografi.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBiografi.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBiografi.Location = New System.Drawing.Point(124, 51)
        Me.txtBiografi.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBiografi.Name = "txtBiografi"
        Me.txtBiografi.Size = New System.Drawing.Size(259, 20)
        Me.txtBiografi.TabIndex = 87
        '
        'gbNonTutor
        '
        Me.gbNonTutor.BackColor = System.Drawing.Color.Transparent
        Me.gbNonTutor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.gbNonTutor.Controls.Add(Me.txtNoHP)
        Me.gbNonTutor.Controls.Add(Me.Label2)
        Me.gbNonTutor.Controls.Add(Me.txtPassword)
        Me.gbNonTutor.Controls.Add(Me.txtTempatLahir)
        Me.gbNonTutor.Controls.Add(Me.Label12)
        Me.gbNonTutor.Controls.Add(Me.Label3)
        Me.gbNonTutor.Controls.Add(Me.txtUsername)
        Me.gbNonTutor.Controls.Add(Me.dtpTanggalLahir)
        Me.gbNonTutor.Controls.Add(Me.Label11)
        Me.gbNonTutor.Controls.Add(Me.txtAlamat)
        Me.gbNonTutor.Controls.Add(Me.Label4)
        Me.gbNonTutor.Controls.Add(Me.Label6)
        Me.gbNonTutor.Controls.Add(Me.txtPekerjaan)
        Me.gbNonTutor.Controls.Add(Me.txtEmail)
        Me.gbNonTutor.Controls.Add(Me.txtNama)
        Me.gbNonTutor.Controls.Add(Me.Label7)
        Me.gbNonTutor.Controls.Add(Me.label)
        Me.gbNonTutor.Controls.Add(Me.lblStatus)
        Me.gbNonTutor.Controls.Add(Me.cbStatus)
        Me.gbNonTutor.Controls.Add(Me.Label9)
        Me.gbNonTutor.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbNonTutor.ForeColor = System.Drawing.Color.White
        Me.gbNonTutor.Location = New System.Drawing.Point(54, 105)
        Me.gbNonTutor.Name = "gbNonTutor"
        Me.gbNonTutor.Size = New System.Drawing.Size(810, 192)
        Me.gbNonTutor.TabIndex = 97
        Me.gbNonTutor.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.BackgroundImage = Global.kursus.My.Resources.Resources.Ellipse_50
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Location = New System.Drawing.Point(813, 10)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(48, 42)
        Me.PictureBox3.TabIndex = 99
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = Global.kursus.My.Resources.Resources.Ellipse_49
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Location = New System.Drawing.Point(853, 10)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(48, 42)
        Me.PictureBox2.TabIndex = 98
        Me.PictureBox2.TabStop = False
        '
        'FormUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.kursus.My.Resources.Resources.Desain_tanpa_judul__2_
        Me.ClientSize = New System.Drawing.Size(913, 699)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.gbNonTutor)
        Me.Controls.Add(Me.gbTutor)
        Me.Controls.Add(Me.cbRole)
        Me.Controls.Add(Me.lblRole)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnBatal)
        Me.Controls.Add(Me.btnHapus)
        Me.Controls.Add(Me.btnUbah)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.txtCari)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.dtpTanggalDaftar)
        Me.Controls.Add(Me.label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Data User"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTutor.ResumeLayout(False)
        Me.gbTutor.PerformLayout()
        Me.gbNonTutor.ResumeLayout(False)
        Me.gbNonTutor.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNoHP As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnBatal As System.Windows.Forms.Button
    Friend WithEvents btnHapus As System.Windows.Forms.Button
    Friend WithEvents btnUbah As System.Windows.Forms.Button
    Friend WithEvents btnSimpan As System.Windows.Forms.Button
    Friend WithEvents txtCari As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAlamat As System.Windows.Forms.TextBox
    Friend WithEvents dtpTanggalLahir As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTempatLahir As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txtNama As System.Windows.Forms.TextBox
    Friend WithEvents label As System.Windows.Forms.Label
    Friend WithEvents txtPekerjaan As System.Windows.Forms.TextBox
    Friend WithEvents dtpTanggalDaftar As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbRole As System.Windows.Forms.ComboBox
    Friend WithEvents lblRole As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents gbTutor As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtKeahlian As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtBiografi As System.Windows.Forms.TextBox
    Friend WithEvents txtTarif As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents gbNonTutor As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
