<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEnrollBayar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEnrollBayar))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtCari = New System.Windows.Forms.TextBox()
        Me.cbKelas = New System.Windows.Forms.ComboBox()
        Me.cbPeserta = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblBiayaValue = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTanggalMulaiValue = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblHariJamValue = New System.Windows.Forms.Label()
        Me.lblDurasiValue = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblKuotaTersisaValue = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbMetodePembayaran = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtKeterangan = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBatal = New System.Windows.Forms.Button()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.btnUbah = New System.Windows.Forms.Button()
        Me.btnEnroll = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(54, 367)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(807, 191)
        Me.DataGridView1.TabIndex = 67
        '
        'txtCari
        '
        Me.txtCari.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCari.Location = New System.Drawing.Point(52, 335)
        Me.txtCari.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(808, 27)
        Me.txtCari.TabIndex = 62
        '
        'cbKelas
        '
        Me.cbKelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbKelas.FormattingEnabled = True
        Me.cbKelas.Location = New System.Drawing.Point(150, 20)
        Me.cbKelas.Margin = New System.Windows.Forms.Padding(4)
        Me.cbKelas.Name = "cbKelas"
        Me.cbKelas.Size = New System.Drawing.Size(259, 31)
        Me.cbKelas.TabIndex = 95
        '
        'cbPeserta
        '
        Me.cbPeserta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeserta.FormattingEnabled = True
        Me.cbPeserta.Location = New System.Drawing.Point(150, 59)
        Me.cbPeserta.Margin = New System.Windows.Forms.Padding(4)
        Me.cbPeserta.Name = "cbPeserta"
        Me.cbPeserta.Size = New System.Drawing.Size(259, 31)
        Me.cbPeserta.TabIndex = 93
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(27, 62)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 25)
        Me.Label7.TabIndex = 92
        Me.Label7.Text = "Peserta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(492, 146)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 25)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "Nominal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(27, 26)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 25)
        Me.Label1.TabIndex = 88
        Me.Label1.Text = "Kelas"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(641, 148)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 25)
        Me.Label12.TabIndex = 110
        Me.Label12.Text = "Rp."
        '
        'lblBiayaValue
        '
        Me.lblBiayaValue.AutoSize = True
        Me.lblBiayaValue.BackColor = System.Drawing.Color.Transparent
        Me.lblBiayaValue.ForeColor = System.Drawing.Color.White
        Me.lblBiayaValue.Location = New System.Drawing.Point(678, 146)
        Me.lblBiayaValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBiayaValue.Name = "lblBiayaValue"
        Me.lblBiayaValue.Size = New System.Drawing.Size(0, 25)
        Me.lblBiayaValue.TabIndex = 112
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(492, 26)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 25)
        Me.Label5.TabIndex = 113
        Me.Label5.Text = "Tanggal Mulai"
        '
        'lblTanggalMulaiValue
        '
        Me.lblTanggalMulaiValue.AutoSize = True
        Me.lblTanggalMulaiValue.ForeColor = System.Drawing.Color.White
        Me.lblTanggalMulaiValue.Location = New System.Drawing.Point(641, 26)
        Me.lblTanggalMulaiValue.Name = "lblTanggalMulaiValue"
        Me.lblTanggalMulaiValue.Size = New System.Drawing.Size(57, 25)
        Me.lblTanggalMulaiValue.TabIndex = 114
        Me.lblTanggalMulaiValue.Text = "Label6"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(492, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 25)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "Hari Jam"
        '
        'lblHariJamValue
        '
        Me.lblHariJamValue.AutoSize = True
        Me.lblHariJamValue.ForeColor = System.Drawing.Color.White
        Me.lblHariJamValue.Location = New System.Drawing.Point(641, 58)
        Me.lblHariJamValue.Name = "lblHariJamValue"
        Me.lblHariJamValue.Size = New System.Drawing.Size(56, 25)
        Me.lblHariJamValue.TabIndex = 116
        Me.lblHariJamValue.Text = "Label3"
        '
        'lblDurasiValue
        '
        Me.lblDurasiValue.AutoSize = True
        Me.lblDurasiValue.ForeColor = System.Drawing.Color.White
        Me.lblDurasiValue.Location = New System.Drawing.Point(641, 88)
        Me.lblDurasiValue.Name = "lblDurasiValue"
        Me.lblDurasiValue.Size = New System.Drawing.Size(56, 25)
        Me.lblDurasiValue.TabIndex = 118
        Me.lblDurasiValue.Text = "Label3"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(492, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 25)
        Me.Label6.TabIndex = 117
        Me.Label6.Text = "Durasi"
        '
        'lblKuotaTersisaValue
        '
        Me.lblKuotaTersisaValue.AutoSize = True
        Me.lblKuotaTersisaValue.ForeColor = System.Drawing.Color.White
        Me.lblKuotaTersisaValue.Location = New System.Drawing.Point(641, 117)
        Me.lblKuotaTersisaValue.Name = "lblKuotaTersisaValue"
        Me.lblKuotaTersisaValue.Size = New System.Drawing.Size(56, 25)
        Me.lblKuotaTersisaValue.TabIndex = 120
        Me.lblKuotaTersisaValue.Text = "Label3"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(492, 117)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 25)
        Me.Label8.TabIndex = 119
        Me.Label8.Text = "Kuota Tersisa"
        '
        'cbMetodePembayaran
        '
        Me.cbMetodePembayaran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMetodePembayaran.FormattingEnabled = True
        Me.cbMetodePembayaran.Location = New System.Drawing.Point(150, 98)
        Me.cbMetodePembayaran.Margin = New System.Windows.Forms.Padding(4)
        Me.cbMetodePembayaran.Name = "cbMetodePembayaran"
        Me.cbMetodePembayaran.Size = New System.Drawing.Size(259, 31)
        Me.cbMetodePembayaran.TabIndex = 122
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(27, 101)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 25)
        Me.Label3.TabIndex = 121
        Me.Label3.Text = "Metode Bayar"
        '
        'txtKeterangan
        '
        Me.txtKeterangan.Location = New System.Drawing.Point(150, 136)
        Me.txtKeterangan.Multiline = True
        Me.txtKeterangan.Name = "txtKeterangan"
        Me.txtKeterangan.Size = New System.Drawing.Size(259, 44)
        Me.txtKeterangan.TabIndex = 123
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(27, 139)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 25)
        Me.Label9.TabIndex = 124
        Me.Label9.Text = "Keterangan"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(605, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(15, 25)
        Me.Label10.TabIndex = 125
        Me.Label10.Text = ":"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(605, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(15, 25)
        Me.Label11.TabIndex = 126
        Me.Label11.Text = ":"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(605, 88)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(15, 25)
        Me.Label13.TabIndex = 127
        Me.Label13.Text = ":"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(605, 148)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(15, 25)
        Me.Label14.TabIndex = 129
        Me.Label14.Text = ":"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(605, 117)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(15, 25)
        Me.Label15.TabIndex = 128
        Me.Label15.Text = ":"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtKeterangan)
        Me.GroupBox1.Controls.Add(Me.cbMetodePembayaran)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblKuotaTersisaValue)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblDurasiValue)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblHariJamValue)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblTanggalMulaiValue)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblBiayaValue)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.cbKelas)
        Me.GroupBox1.Controls.Add(Me.cbPeserta)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(79, 75)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(756, 190)
        Me.GroupBox1.TabIndex = 134
        Me.GroupBox1.TabStop = False
        '
        'btnBatal
        '
        Me.btnBatal.BackColor = System.Drawing.Color.Red
        Me.btnBatal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBatal.FlatAppearance.BorderSize = 0
        Me.btnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBatal.Font = New System.Drawing.Font("Poppins SemiBold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnBatal.ForeColor = System.Drawing.Color.White
        Me.btnBatal.Location = New System.Drawing.Point(583, 284)
        Me.btnBatal.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(109, 36)
        Me.btnBatal.TabIndex = 139
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
        Me.btnHapus.Location = New System.Drawing.Point(475, 284)
        Me.btnHapus.Margin = New System.Windows.Forms.Padding(4)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(100, 36)
        Me.btnHapus.TabIndex = 138
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
        Me.btnUbah.Location = New System.Drawing.Point(367, 284)
        Me.btnUbah.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUbah.Name = "btnUbah"
        Me.btnUbah.Size = New System.Drawing.Size(100, 36)
        Me.btnUbah.TabIndex = 137
        Me.btnUbah.Text = "Ubah"
        Me.btnUbah.UseVisualStyleBackColor = False
        '
        'btnEnroll
        '
        Me.btnEnroll.BackColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnEnroll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEnroll.FlatAppearance.BorderSize = 0
        Me.btnEnroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnroll.Font = New System.Drawing.Font("Poppins SemiBold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnEnroll.ForeColor = System.Drawing.Color.White
        Me.btnEnroll.Location = New System.Drawing.Point(246, 284)
        Me.btnEnroll.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEnroll.Name = "btnEnroll"
        Me.btnEnroll.Size = New System.Drawing.Size(113, 35)
        Me.btnEnroll.TabIndex = 136
        Me.btnEnroll.Text = "Enroll"
        Me.btnEnroll.UseVisualStyleBackColor = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.BackgroundImage = Global.kursus.My.Resources.Resources.Ellipse_50
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Location = New System.Drawing.Point(823, 12)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(48, 42)
        Me.PictureBox3.TabIndex = 141
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = Global.kursus.My.Resources.Resources.Ellipse_49
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Location = New System.Drawing.Point(863, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(48, 42)
        Me.PictureBox2.TabIndex = 140
        Me.PictureBox2.TabStop = False
        '
        'FormEnrollBayar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.kursus.My.Resources.Resources.Desain_tanpa_judul__2_
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(913, 634)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.btnBatal)
        Me.Controls.Add(Me.btnHapus)
        Me.Controls.Add(Me.btnUbah)
        Me.Controls.Add(Me.btnEnroll)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtCari)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormEnrollBayar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Data Pembayaran"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtCari As System.Windows.Forms.TextBox
    Friend WithEvents cbKelas As System.Windows.Forms.ComboBox
    Friend WithEvents cbPeserta As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblBiayaValue As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTanggalMulaiValue As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblHariJamValue As System.Windows.Forms.Label
    Friend WithEvents lblDurasiValue As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblKuotaTersisaValue As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbMetodePembayaran As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtKeterangan As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBatal As System.Windows.Forms.Button
    Friend WithEvents btnHapus As System.Windows.Forms.Button
    Friend WithEvents btnUbah As System.Windows.Forms.Button
    Friend WithEvents btnEnroll As System.Windows.Forms.Button
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
