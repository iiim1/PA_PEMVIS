<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKelas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormKelas))
        Me.txtRuangan = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtCari = New System.Windows.Forms.TextBox()
        Me.cbHari = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbKursus = New System.Windows.Forms.ComboBox()
        Me.cbInstruktur = New System.Windows.Forms.ComboBox()
        Me.dtpJamMulai = New System.Windows.Forms.DateTimePicker()
        Me.txtDurasi = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBiaya = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMaksimalPeserta = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpTanggalMulai = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpTanggalSelesai = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtKebutuhanAlat = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnBatal = New System.Windows.Forms.Button()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.btnUbah = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtRuangan
        '
        Me.txtRuangan.Location = New System.Drawing.Point(562, 78)
        Me.txtRuangan.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRuangan.Name = "txtRuangan"
        Me.txtRuangan.Size = New System.Drawing.Size(259, 27)
        Me.txtRuangan.TabIndex = 71
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(52, 87)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(794, 194)
        Me.DataGridView1.TabIndex = 67
        '
        'txtCari
        '
        Me.txtCari.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCari.Location = New System.Drawing.Point(52, 58)
        Me.txtCari.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(794, 27)
        Me.txtCari.TabIndex = 62
        '
        'cbHari
        '
        Me.cbHari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbHari.FormattingEnabled = True
        Me.cbHari.Location = New System.Drawing.Point(142, 51)
        Me.cbHari.Margin = New System.Windows.Forms.Padding(4)
        Me.cbHari.Name = "cbHari"
        Me.cbHari.Size = New System.Drawing.Size(259, 31)
        Me.cbHari.TabIndex = 61
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(20, 54)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 25)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "Hari"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(425, 48)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 25)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Jam"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(425, 81)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 25)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "Ruangan"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(425, 17)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 25)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Instruktur"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(20, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 25)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Kursus"
        '
        'cbKursus
        '
        Me.cbKursus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbKursus.FormattingEnabled = True
        Me.cbKursus.Location = New System.Drawing.Point(142, 14)
        Me.cbKursus.Margin = New System.Windows.Forms.Padding(4)
        Me.cbKursus.Name = "cbKursus"
        Me.cbKursus.Size = New System.Drawing.Size(259, 31)
        Me.cbKursus.TabIndex = 72
        '
        'cbInstruktur
        '
        Me.cbInstruktur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbInstruktur.FormattingEnabled = True
        Me.cbInstruktur.Location = New System.Drawing.Point(562, 14)
        Me.cbInstruktur.Margin = New System.Windows.Forms.Padding(4)
        Me.cbInstruktur.Name = "cbInstruktur"
        Me.cbInstruktur.Size = New System.Drawing.Size(259, 31)
        Me.cbInstruktur.TabIndex = 73
        '
        'dtpJamMulai
        '
        Me.dtpJamMulai.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpJamMulai.Location = New System.Drawing.Point(562, 48)
        Me.dtpJamMulai.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpJamMulai.Name = "dtpJamMulai"
        Me.dtpJamMulai.Size = New System.Drawing.Size(259, 27)
        Me.dtpJamMulai.TabIndex = 75
        '
        'txtDurasi
        '
        Me.txtDurasi.Location = New System.Drawing.Point(142, 88)
        Me.txtDurasi.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDurasi.Name = "txtDurasi"
        Me.txtDurasi.Size = New System.Drawing.Size(259, 27)
        Me.txtDurasi.TabIndex = 77
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(20, 91)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 25)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Durasi (Menit)"
        '
        'txtBiaya
        '
        Me.txtBiaya.Location = New System.Drawing.Point(142, 123)
        Me.txtBiaya.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBiaya.Name = "txtBiaya"
        Me.txtBiaya.Size = New System.Drawing.Size(259, 27)
        Me.txtBiaya.TabIndex = 79
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(18, 126)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 25)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "Biaya"
        '
        'txtMaksimalPeserta
        '
        Me.txtMaksimalPeserta.Location = New System.Drawing.Point(562, 108)
        Me.txtMaksimalPeserta.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMaksimalPeserta.Name = "txtMaksimalPeserta"
        Me.txtMaksimalPeserta.Size = New System.Drawing.Size(259, 27)
        Me.txtMaksimalPeserta.TabIndex = 81
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(425, 110)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 25)
        Me.Label8.TabIndex = 80
        Me.Label8.Text = "Maksimal Peserta"
        '
        'dtpTanggalMulai
        '
        Me.dtpTanggalMulai.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalMulai.Location = New System.Drawing.Point(142, 158)
        Me.dtpTanggalMulai.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpTanggalMulai.Name = "dtpTanggalMulai"
        Me.dtpTanggalMulai.Size = New System.Drawing.Size(259, 27)
        Me.dtpTanggalMulai.TabIndex = 83
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(18, 162)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(108, 25)
        Me.Label9.TabIndex = 82
        Me.Label9.Text = "Tanggal Mulai"
        '
        'dtpTanggalSelesai
        '
        Me.dtpTanggalSelesai.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTanggalSelesai.Location = New System.Drawing.Point(562, 138)
        Me.dtpTanggalSelesai.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpTanggalSelesai.Name = "dtpTanggalSelesai"
        Me.dtpTanggalSelesai.Size = New System.Drawing.Size(259, 27)
        Me.dtpTanggalSelesai.TabIndex = 85
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(425, 140)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 25)
        Me.Label10.TabIndex = 84
        Me.Label10.Text = "Tanggal Selesai"
        '
        'txtKebutuhanAlat
        '
        Me.txtKebutuhanAlat.Location = New System.Drawing.Point(144, 193)
        Me.txtKebutuhanAlat.Margin = New System.Windows.Forms.Padding(4)
        Me.txtKebutuhanAlat.Multiline = True
        Me.txtKebutuhanAlat.Name = "txtKebutuhanAlat"
        Me.txtKebutuhanAlat.Size = New System.Drawing.Size(677, 44)
        Me.txtKebutuhanAlat.TabIndex = 87
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(18, 193)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(118, 25)
        Me.Label11.TabIndex = 86
        Me.Label11.Text = "Kebutuhan Alat"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtKebutuhanAlat)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.dtpTanggalSelesai)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.dtpTanggalMulai)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtMaksimalPeserta)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtBiaya)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtDurasi)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtpJamMulai)
        Me.GroupBox1.Controls.Add(Me.cbInstruktur)
        Me.GroupBox1.Controls.Add(Me.cbKursus)
        Me.GroupBox1.Controls.Add(Me.txtRuangan)
        Me.GroupBox1.Controls.Add(Me.cbHari)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(29, 332)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(838, 243)
        Me.GroupBox1.TabIndex = 93
        Me.GroupBox1.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.BackgroundImage = Global.kursus.My.Resources.Resources.Ellipse_50
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Location = New System.Drawing.Point(819, 6)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(48, 42)
        Me.PictureBox3.TabIndex = 105
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = Global.kursus.My.Resources.Resources.Ellipse_49
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Location = New System.Drawing.Point(859, 6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(48, 42)
        Me.PictureBox2.TabIndex = 104
        Me.PictureBox2.TabStop = False
        '
        'btnBatal
        '
        Me.btnBatal.BackColor = System.Drawing.Color.Red
        Me.btnBatal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBatal.FlatAppearance.BorderSize = 0
        Me.btnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBatal.Font = New System.Drawing.Font("Poppins SemiBold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnBatal.ForeColor = System.Drawing.Color.White
        Me.btnBatal.Location = New System.Drawing.Point(589, 296)
        Me.btnBatal.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(109, 36)
        Me.btnBatal.TabIndex = 103
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
        Me.btnHapus.Location = New System.Drawing.Point(481, 296)
        Me.btnHapus.Margin = New System.Windows.Forms.Padding(4)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(100, 36)
        Me.btnHapus.TabIndex = 102
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
        Me.btnUbah.Location = New System.Drawing.Point(373, 296)
        Me.btnUbah.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUbah.Name = "btnUbah"
        Me.btnUbah.Size = New System.Drawing.Size(100, 36)
        Me.btnUbah.TabIndex = 101
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
        Me.btnSimpan.Location = New System.Drawing.Point(252, 296)
        Me.btnSimpan.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(113, 35)
        Me.btnSimpan.TabIndex = 100
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = False
        '
        'FormKelas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.kursus.My.Resources.Resources.Desain_tanpa_judul__2_
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(913, 597)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.btnBatal)
        Me.Controls.Add(Me.btnHapus)
        Me.Controls.Add(Me.btnUbah)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtCari)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormKelas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Data Kelas"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRuangan As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtCari As System.Windows.Forms.TextBox
    Friend WithEvents cbHari As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbKursus As System.Windows.Forms.ComboBox
    Friend WithEvents cbInstruktur As System.Windows.Forms.ComboBox
    Friend WithEvents dtpJamMulai As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDurasi As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBiaya As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMaksimalPeserta As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpTanggalMulai As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpTanggalSelesai As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtKebutuhanAlat As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnBatal As System.Windows.Forms.Button
    Friend WithEvents btnHapus As System.Windows.Forms.Button
    Friend WithEvents btnUbah As System.Windows.Forms.Button
    Friend WithEvents btnSimpan As System.Windows.Forms.Button
End Class
