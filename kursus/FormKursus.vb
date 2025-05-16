Imports MySql.Data.MySqlClient

Public Class FormKursus
    Sub AutoKodeKursus()
        CMD = New MySqlCommand("SELECT KodeKursus FROM kursus ORDER BY KodeKursus DESC LIMIT 1", CONN)
        RD = CMD.ExecuteReader
        Dim kodeBaru As String
        If RD.Read Then
            Dim kodeLama As String = RD("KodeKursus").ToString()
            Dim angka As Integer = CInt(kodeLama.Substring(2)) + 1
            kodeBaru = "KU" & angka.ToString("D3")
        Else
            kodeBaru = "KU001"
        End If
        RD.Close()
        txtKode.Text = kodeBaru
    End Sub

    Sub Kosong()
        txtNamaKursus.Clear()
        cbJenisKursus.SelectedIndex = -1
        cbTingkat.SelectedIndex = -1
        txtDeskripsi.Clear()
        txtDurasi.Clear()
        txtNamaKursus.Focus()
    End Sub

    Sub tampilKursus()
        If FormUtama.roleAkses.ToLower() = "tutor" Then
            Dim query As String = "SELECT DISTINCT k.KodeKursus, k.NamaKursus, k.JenisKursus, k.Tingkat, k.DurasiTotal " & _
                                 "FROM kursus k " & _
                                 "INNER JOIN kelas kl ON k.KodeKursus = kl.KodeKursus " & _
                                 "WHERE kl.IDUser = @tutorID"

            CMD = New MySqlCommand(query, CONN)
            CMD.Parameters.AddWithValue("@tutorID", FormUtama.userID)

        ElseIf FormUtama.roleAkses.ToLower() = "peserta" Then
            Dim query As String = "SELECT DISTINCT k.KodeKursus, k.NamaKursus, k.JenisKursus, k.Tingkat, k.DurasiTotal " & _
                                 "FROM kursus k " & _
                                 "INNER JOIN kelas kl ON k.KodeKursus = kl.KodeKursus " & _
                                 "INNER JOIN peserta_kelas pk ON kl.IDKelas = pk.IDKelas " & _
                                 "WHERE pk.IDUser = @pesertaID"

            CMD = New MySqlCommand(query, CONN)
            CMD.Parameters.AddWithValue("@pesertaID", FormUtama.userID)

        Else
            CMD = New MySqlCommand("SELECT KodeKursus, NamaKursus, JenisKursus, Tingkat, DurasiTotal FROM kursus", CONN)
        End If

        DA = New MySqlDataAdapter(CMD)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "kursus")
        DataGridView1.DataSource = DS.Tables("kursus")
        DataGridView1.Refresh()
    End Sub


    Sub atur_grid()
        DataGridView1.Columns(0).HeaderText = "Kode Kursus"
        DataGridView1.Columns(1).HeaderText = "Nama Kursus"
        DataGridView1.Columns(2).HeaderText = "Jenis Kursus"
        DataGridView1.Columns(3).HeaderText = "Tingkat"
        DataGridView1.Columns(4).HeaderText = "Durasi Total"
    End Sub

    Private Sub FormKursus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        lblJudul.Text = "Data Kursus"
        If FormUtama.roleAkses = "Front Office" Then
            gbInputKursus.Visible = False
        Else
            gbInputKursus.Visible = True
        End If

        cbJenisKursus.DropDownStyle = ComboBoxStyle.DropDownList
        cbJenisKursus.Items.AddRange(New String() {"Bahasa", "Musik", "Olahraga", "Keterampilan", "Seni", "Teknologi", "Memasak", "Baking", "Menjahit", "Lainnya"})

        cbTingkat.DropDownStyle = ComboBoxStyle.DropDownList
        cbTingkat.Items.AddRange(New String() {"Pemula", "Menengah", "Lanjutan", "Profesional"})

        tampilKursus()
        atur_grid()
        Kosong()

        btnHapus.Enabled = False
        btnUbah.Enabled = False

        If FormUtama.roleAkses.ToLower() <> "tutor" Then
            AutoKodeKursus()
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(txtNamaKursus.Text) OrElse
           cbJenisKursus.SelectedIndex = -1 OrElse
           cbTingkat.SelectedIndex = -1 OrElse
           String.IsNullOrEmpty(txtDurasi.Text) Then
            MsgBox("Harap lengkapi semua data!")
            Return
        End If

        If Not IsNumeric(txtDurasi.Text) Then
            MsgBox("Durasi harus berupa angka!")
            txtDurasi.Focus()
            Return
        End If

        CMD = New MySqlCommand("SELECT * FROM kursus WHERE KodeKursus=@kode", CONN)
        CMD.Parameters.AddWithValue("@kode", txtKode.Text)
        RD = CMD.ExecuteReader()

        If Not RD.HasRows Then
            RD.Close()
            CMD = New MySqlCommand("INSERT INTO kursus (KodeKursus, NamaKursus, JenisKursus, Tingkat, Deskripsi, DurasiTotal) " &
                                   "VALUES (@kode, @nama, @jenis, @tingkat, @deskripsi, @durasi)", CONN)
            With CMD.Parameters
                .AddWithValue("@kode", txtKode.Text)
                .AddWithValue("@nama", txtNamaKursus.Text)
                .AddWithValue("@jenis", cbJenisKursus.Text)
                .AddWithValue("@tingkat", cbTingkat.Text)
                .AddWithValue("@deskripsi", txtDeskripsi.Text)
                .AddWithValue("@durasi", CInt(txtDurasi.Text))
            End With
            CMD.ExecuteNonQuery()
            MsgBox("Data kursus berhasil disimpan.")
            AutoKodeKursus()
        Else
            RD.Close()
            MsgBox("Kode Kursus sudah terdaftar!")
        End If
        tampilKursus()
        Kosong()
    End Sub

    Private Sub btnUbah_Click(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(txtKode.Text) Then
            MsgBox("Pilih data yang akan diubah terlebih dahulu!")
            Return
        End If

        CMD = New MySqlCommand("UPDATE kursus SET NamaKursus=@nama, JenisKursus=@jenis, Tingkat=@tingkat, " &
                              "Deskripsi=@deskripsi, DurasiTotal=@durasi WHERE KodeKursus=@kode", CONN)
        With CMD.Parameters
            .AddWithValue("@kode", txtKode.Text)
            .AddWithValue("@nama", txtNamaKursus.Text)
            .AddWithValue("@jenis", cbJenisKursus.Text)
            .AddWithValue("@tingkat", cbTingkat.Text)
            .AddWithValue("@deskripsi", txtDeskripsi.Text)
            .AddWithValue("@durasi", txtDurasi.Text)
        End With
        CMD.ExecuteNonQuery()
        MsgBox("Data kursus berhasil diubah.")
        tampilKursus()
        Kosong()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(txtKode.Text) Then
            MsgBox("Pilih data yang akan dihapus terlebih dahulu!")
            Return
        End If

        CMD = New MySqlCommand("SELECT COUNT(*) FROM kelas WHERE KodeKursus=@kode", CONN)
        CMD.Parameters.AddWithValue("@kode", txtKode.Text)
        Dim count As Integer = Convert.ToInt32(CMD.ExecuteScalar())

        If count > 0 Then
            MsgBox("Kursus tidak dapat dihapus karena sudah digunakan dalam kelas!")
            Return
        End If

        If MsgBox("Apakah Anda yakin ingin menghapus data ini?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            CMD = New MySqlCommand("DELETE FROM kursus WHERE KodeKursus=@kode", CONN)
            CMD.Parameters.AddWithValue("@kode", txtKode.Text)
            CMD.ExecuteNonQuery()
            MsgBox("Data kursus berhasil dihapus.")
            tampilKursus()
            Kosong()
        End If
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs)
        Kosong()
        tampilKursus()
        AutoKodeKursus()
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        If txtCari.Text <> "" Then
            If FormUtama.roleAkses.ToLower() = "tutor" Then
                Dim query As String = "SELECT DISTINCT k.KodeKursus, k.NamaKursus, k.JenisKursus, k.Tingkat, k.DurasiTotal " & _
                                     "FROM kursus k " & _
                                     "INNER JOIN kelas kl ON k.KodeKursus = kl.KodeKursus " & _
                                     "WHERE kl.IDUser = @tutorID AND " & _
                                     "(k.NamaKursus LIKE @search OR k.JenisKursus LIKE @search)"

                CMD = New MySqlCommand(query, CONN)
                CMD.Parameters.AddWithValue("@tutorID", FormUtama.userID)
                CMD.Parameters.AddWithValue("@search", "%" & txtCari.Text & "%")

            ElseIf FormUtama.roleAkses.ToLower() = "peserta" Then
                Dim query As String = "SELECT DISTINCT k.KodeKursus, k.NamaKursus, k.JenisKursus, k.Tingkat, k.DurasiTotal " & _
                                     "FROM kursus k " & _
                                     "INNER JOIN kelas kl ON k.KodeKursus = kl.KodeKursus " & _
                                     "INNER JOIN peserta_kelas pk ON kl.IDKelas = pk.IDKelas " & _
                                     "WHERE pk.IDUser = @pesertaID AND " & _
                                     "(k.NamaKursus LIKE @search OR k.JenisKursus LIKE @search)"

                CMD = New MySqlCommand(query, CONN)
                CMD.Parameters.AddWithValue("@pesertaID", FormUtama.userID)
                CMD.Parameters.AddWithValue("@search", "%" & txtCari.Text & "%")

            Else
                CMD = New MySqlCommand("SELECT KodeKursus, NamaKursus, JenisKursus, Tingkat, DurasiTotal " & _
                                       "FROM kursus WHERE NamaKursus LIKE @search OR JenisKursus LIKE @search", CONN)
                CMD.Parameters.AddWithValue("@search", "%" & txtCari.Text & "%")
            End If

            DA = New MySqlDataAdapter(CMD)
            DS = New DataSet
            DS.Clear()
            DA.Fill(DS, "cari")
            DataGridView1.DataSource = DS.Tables("cari")
        Else
            tampilKursus()
        End If
    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            txtKode.Text = row.Cells("KodeKursus").Value.ToString()
            txtNamaKursus.Text = row.Cells("NamaKursus").Value.ToString()
            cbJenisKursus.Text = row.Cells("JenisKursus").Value.ToString()
            cbTingkat.Text = row.Cells("Tingkat").Value.ToString()

            CMD = New MySqlCommand("SELECT Deskripsi, DurasiTotal FROM kursus WHERE KodeKursus=@kode", CONN)
            CMD.Parameters.AddWithValue("@kode", txtKode.Text)
            RD = CMD.ExecuteReader()
            If RD.Read Then
                txtDeskripsi.Text = RD("Deskripsi").ToString()
                txtDurasi.Text = RD("DurasiTotal").ToString()
            End If
            RD.Close()

            btnHapus.Enabled = True
            btnUbah.Enabled = True

        End If
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class