Imports System.IO
Imports System.Net

'RockBox-PSGroove Installer - Plug-In Creator
'Official site: http://rockbox-psgroove.com/

'Copyright (C) 2010 DanyL

'This program is free software: you can redistribute it and/or modify
'it under the terms of the GNU General Public License as published by
'the Free Software Foundation, either version 3 of the License, or
'(at your option) any later version.

'This program is distributed in the hope that it will be useful,
'but WITHOUT ANY WARRANTY; without even the implied warranty of
'MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'GNU General Public License for more details.

'You should have received a copy of the GNU General Public License
'along with this program.  If not, see http://www.gnu.org/licenses/.

Public Class Plug_In_Creator

    Private Sub Plug_In_Creator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PictureBox1.Image = My.Resources.PlugInPreview
        PictureBox2.Image = My.Resources.PlugInPreview
        PictureBox3.Image = My.Resources.PlugInPreview

        Dim inStream As StreamReader
        Dim webRequest As WebRequest
        Dim webresponse As WebResponse
        webRequest = webRequest.Create("http://rockbox-psgroove.com/Download/RockBox-PSGroove_Installer-Plug-In_Creator/update/version.txt")
        webresponse = webRequest.GetResponse()
        inStream = New StreamReader(webresponse.GetResponseStream())

        If inStream.ReadToEnd() > "1.1" Then
            Updater.Show(Me)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FolderBrowserDialog2.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        FolderBrowserDialog4.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If FolderBrowserDialog3.ShowDialog() = DialogResult.OK Then
            Dim foundfile As String
            For Each foundfile In My.Computer.FileSystem.GetFiles(FolderBrowserDialog3.SelectedPath & "\", FileIO.SearchOption.SearchTopLevelOnly, "*.png")
                PictureBox1.Load(FolderBrowserDialog3.SelectedPath & "\" & My.Computer.FileSystem.GetName(foundfile))
            Next
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            TextBox3.Text = FolderBrowserDialog1.SelectedPath
            If My.Computer.FileSystem.DirectoryExists(FolderBrowserDialog1.SelectedPath & "\" & TextBox1.Text) Then
                MsgBox("Folder already exists")
            Else
                My.Computer.FileSystem.CreateDirectory(FolderBrowserDialog1.SelectedPath & "\" & TextBox1.Text & "\" & "PlugIn\PSGroove")
                Dim foundfile As String
                For Each foundfile In My.Computer.FileSystem.GetFiles(FolderBrowserDialog2.SelectedPath, FileIO.SearchOption.SearchTopLevelOnly, "*.ipod")
                    My.Computer.FileSystem.CopyFile(foundfile, FolderBrowserDialog1.SelectedPath & "\" & TextBox1.Text & "\" & "PlugIn\PSGroove" & "\" & My.Computer.FileSystem.GetName(foundfile))
                Next
            End If
            If FolderBrowserDialog4.SelectedPath = "" Then
            Else
                Dim foundfile2
                For Each foundfile2 In My.Computer.FileSystem.GetFiles(FolderBrowserDialog4.SelectedPath, FileIO.SearchOption.SearchTopLevelOnly, "*.cfg")
                    My.Computer.FileSystem.CopyFile(foundfile2, FolderBrowserDialog1.SelectedPath & "\" & TextBox1.Text & "\" & "PlugIn" & "\" & My.Computer.FileSystem.GetName(foundfile2))
                Next
            End If
            If FolderBrowserDialog3.SelectedPath = "" Then
            Else
                Dim foundfile3
                For Each foundfile3 In My.Computer.FileSystem.GetFiles(FolderBrowserDialog3.SelectedPath, FileIO.SearchOption.SearchTopLevelOnly, "*.png")
                    My.Computer.FileSystem.CopyFile(foundfile3, FolderBrowserDialog1.SelectedPath & "\" & TextBox1.Text & "\" & My.Computer.FileSystem.GetName(foundfile3))
                    My.Computer.FileSystem.RenameFile(FolderBrowserDialog1.SelectedPath & "\" & TextBox1.Text & "\" & My.Computer.FileSystem.GetName(foundfile3), "PREVIEW.png")
                Next
            End If
            If FolderBrowserDialog5.SelectedPath = "" Then
            Else
                My.Computer.FileSystem.WriteAllText(FolderBrowserDialog1.SelectedPath & "\" & TextBox1.Text & "\" & "PKG.txt", String.Empty, False)
                My.Computer.FileSystem.CreateDirectory(FolderBrowserDialog1.SelectedPath & "\" & TextBox1.Text & "\" & "PlugIn\PKG")
                Dim foundfile4 As String
                For Each foundfile4 In My.Computer.FileSystem.GetFiles(FolderBrowserDialog5.SelectedPath, FileIO.SearchOption.SearchTopLevelOnly, "*.PKG", "*.pkg")
                    My.Computer.FileSystem.CopyFile(foundfile4, FolderBrowserDialog1.SelectedPath & "\" & TextBox1.Text & "\" & "PlugIn\PKG" & "\" & My.Computer.FileSystem.GetName(foundfile4))
                Next
            End If
            If CheckBox1.Checked = True Then
                My.Computer.FileSystem.WriteAllText(FolderBrowserDialog1.SelectedPath & "\" & TextBox1.Text & "\" & "ipodpatcher.txt", String.Empty, False)
            End If
            My.Computer.FileSystem.WriteAllText(FolderBrowserDialog1.SelectedPath & "\" & TextBox1.Text & "\" & "Details.txt", String.Empty, False)
            My.Computer.FileSystem.WriteAllText(FolderBrowserDialog1.SelectedPath & "\" & TextBox1.Text & "\" & "Details.txt", TextBox2.Text, False)
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        FolderBrowserDialog2.ShowDialog()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If FolderBrowserDialog3.ShowDialog() = DialogResult.OK Then
            Dim foundfile As String
            For Each foundfile In My.Computer.FileSystem.GetFiles(FolderBrowserDialog3.SelectedPath & "\", FileIO.SearchOption.SearchTopLevelOnly, "*.png")
                PictureBox2.Load(FolderBrowserDialog3.SelectedPath & "\" & My.Computer.FileSystem.GetName(foundfile))
            Next
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            TextBox9.Text = FolderBrowserDialog1.SelectedPath
            If My.Computer.FileSystem.DirectoryExists(FolderBrowserDialog1.SelectedPath & "\" & TextBox5.Text) Then
                MsgBox("Folder already exists")
            Else
                My.Computer.FileSystem.CreateDirectory(FolderBrowserDialog1.SelectedPath & "\" & TextBox5.Text & "\" & "PlugIn\.rockbox")
                Dim foundfile As String
                For Each foundfile In My.Computer.FileSystem.GetFiles(FolderBrowserDialog2.SelectedPath, FileIO.SearchOption.SearchTopLevelOnly, "*.mi4")
                    My.Computer.FileSystem.CopyFile(foundfile, FolderBrowserDialog1.SelectedPath & "\" & TextBox5.Text & "\" & "PlugIn\.rockbox" & "\" & My.Computer.FileSystem.GetName(foundfile))
                Next
            End If
            If FolderBrowserDialog4.SelectedPath = "" Then
            Else
                Dim foundfile2
                For Each foundfile2 In My.Computer.FileSystem.GetFiles(FolderBrowserDialog4.SelectedPath, FileIO.SearchOption.SearchTopLevelOnly, "*.cfg")
                    My.Computer.FileSystem.CopyFile(foundfile2, FolderBrowserDialog1.SelectedPath & "\" & TextBox5.Text & "\" & "PlugIn" & "\" & My.Computer.FileSystem.GetName(foundfile2))
                Next
            End If
            If FolderBrowserDialog3.SelectedPath = "" Then
            Else
                Dim foundfile3
                For Each foundfile3 In My.Computer.FileSystem.GetFiles(FolderBrowserDialog3.SelectedPath, FileIO.SearchOption.SearchTopLevelOnly, "*.png")
                    My.Computer.FileSystem.CopyFile(foundfile3, FolderBrowserDialog1.SelectedPath & "\" & TextBox5.Text & "\" & My.Computer.FileSystem.GetName(foundfile3))
                    My.Computer.FileSystem.RenameFile(FolderBrowserDialog1.SelectedPath & "\" & TextBox5.Text & "\" & My.Computer.FileSystem.GetName(foundfile3), "PREVIEW.png")
                Next
            End If
            If FolderBrowserDialog5.SelectedPath = "" Then
            Else
                My.Computer.FileSystem.WriteAllText(FolderBrowserDialog1.SelectedPath & "\" & TextBox1.Text & "\" & "PKG.txt", String.Empty, False)
                My.Computer.FileSystem.CreateDirectory(FolderBrowserDialog1.SelectedPath & "\" & TextBox5.Text & "\" & "PlugIn\PKG")
                Dim foundfile4 As String
                For Each foundfile4 In My.Computer.FileSystem.GetFiles(FolderBrowserDialog5.SelectedPath, FileIO.SearchOption.SearchTopLevelOnly, "*.PKG", "*.pkg")
                    My.Computer.FileSystem.CopyFile(foundfile4, FolderBrowserDialog1.SelectedPath & "\" & TextBox1.Text & "\" & "PlugIn\PKG" & "\" & My.Computer.FileSystem.GetName(foundfile4))
                Next
            End If
            If CheckBox2.Checked = True Then
                My.Computer.FileSystem.WriteAllText(FolderBrowserDialog1.SelectedPath & "\" & TextBox5.Text & "\" & "sansapatcher.txt", String.Empty, False)
            End If
            If CheckBox3.Checked = True Then
                My.Computer.FileSystem.WriteAllText(FolderBrowserDialog1.SelectedPath & "\" & TextBox5.Text & "\" & "e200rpatcher.txt", String.Empty, False)
            End If
            If CheckBox6.Checked = True Then
                My.Computer.FileSystem.WriteAllText(FolderBrowserDialog1.SelectedPath & "\" & TextBox5.Text & "\" & "CBLv0.3.txt", String.Empty, False)
            End If
            My.Computer.FileSystem.WriteAllText(FolderBrowserDialog1.SelectedPath & "\" & TextBox5.Text & "\" & "Details.txt", String.Empty, False)
            My.Computer.FileSystem.WriteAllText(FolderBrowserDialog1.SelectedPath & "\" & TextBox5.Text & "\" & "Details.txt", TextBox4.Text, False)
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        FolderBrowserDialog2.ShowDialog()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If FolderBrowserDialog3.ShowDialog() = DialogResult.OK Then
            Dim foundfile As String
            For Each foundfile In My.Computer.FileSystem.GetFiles(FolderBrowserDialog3.SelectedPath & "\", FileIO.SearchOption.SearchTopLevelOnly, "*.png")
                PictureBox3.Load(FolderBrowserDialog3.SelectedPath & "\" & My.Computer.FileSystem.GetName(foundfile))
            Next
        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        FolderBrowserDialog5.ShowDialog()
        TextBox10.Text = FolderBrowserDialog5.SelectedPath
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            TextBox9.Text = FolderBrowserDialog1.SelectedPath
            If My.Computer.FileSystem.DirectoryExists(FolderBrowserDialog1.SelectedPath & "\" & TextBox8.Text) Then
                MsgBox("Folder already exists")
            Else
                My.Computer.FileSystem.CreateDirectory(FolderBrowserDialog1.SelectedPath & "\" & TextBox8.Text & "\" & "PlugIn\.rockbox")
                Dim foundfile As String
                For Each foundfile In My.Computer.FileSystem.GetFiles(FolderBrowserDialog2.SelectedPath, FileIO.SearchOption.SearchTopLevelOnly, "*.mi4", "*.gigabeat")
                    My.Computer.FileSystem.CopyFile(foundfile, FolderBrowserDialog1.SelectedPath & "\" & TextBox8.Text & "\" & "PlugIn\.rockbox" & "\" & My.Computer.FileSystem.GetName(foundfile))
                Next
            End If
            If FolderBrowserDialog3.SelectedPath = "" Then
            Else
                Dim foundfile3
                For Each foundfile3 In My.Computer.FileSystem.GetFiles(FolderBrowserDialog3.SelectedPath, FileIO.SearchOption.SearchTopLevelOnly, "*.png")
                    My.Computer.FileSystem.CopyFile(foundfile3, FolderBrowserDialog1.SelectedPath & "\" & TextBox8.Text & "\" & My.Computer.FileSystem.GetName(foundfile3))
                    My.Computer.FileSystem.RenameFile(FolderBrowserDialog1.SelectedPath & "\" & TextBox8.Text & "\" & My.Computer.FileSystem.GetName(foundfile3), "PREVIEW.png")
                Next
            End If
            If FolderBrowserDialog5.SelectedPath = "" Then
            Else
                My.Computer.FileSystem.WriteAllText(FolderBrowserDialog1.SelectedPath & "\" & TextBox8.Text & "\" & "PKG.txt", String.Empty, False)
                My.Computer.FileSystem.CreateDirectory(FolderBrowserDialog1.SelectedPath & "\" & TextBox8.Text & "\" & "PlugIn\PKG")
                Dim foundfile4 As String
                For Each foundfile4 In My.Computer.FileSystem.GetFiles(FolderBrowserDialog5.SelectedPath, FileIO.SearchOption.SearchTopLevelOnly, "*.PKG", "*.pkg")
                    My.Computer.FileSystem.CopyFile(foundfile4, FolderBrowserDialog1.SelectedPath & "\" & TextBox1.Text & "\" & "PlugIn\PKG" & "\" & My.Computer.FileSystem.GetName(foundfile4))
                Next
            End If
            If CheckBox5.Checked = True Then
                My.Computer.FileSystem.CreateDirectory(FolderBrowserDialog1.SelectedPath & "\" & TextBox8.Text & "\" & "PlugIn\BL")
                Dim foundfile As String
                For Each foundfile In My.Computer.FileSystem.GetFiles(FolderBrowserDialog2.SelectedPath, FileIO.SearchOption.SearchTopLevelOnly)
                    My.Computer.FileSystem.CopyFile(foundfile, FolderBrowserDialog1.SelectedPath & "\" & TextBox8.Text & "\" & "PlugIn\BL" & "\" & My.Computer.FileSystem.GetName(foundfile))
                Next
            End If
            If CheckBox4.Checked = True Then
                My.Computer.FileSystem.WriteAllText(FolderBrowserDialog1.SelectedPath & "\" & TextBox8.Text & "\" & "BL.txt", String.Empty, False)
                My.Computer.FileSystem.WriteAllText(FolderBrowserDialog1.SelectedPath & "\" & TextBox8.Text & "\" & "BL.txt", TextBox11.Text, False)
            End If
            My.Computer.FileSystem.WriteAllText(FolderBrowserDialog1.SelectedPath & "\" & TextBox8.Text & "\" & "Details.txt", String.Empty, False)
            My.Computer.FileSystem.WriteAllText(FolderBrowserDialog1.SelectedPath & "\" & TextBox8.Text & "\" & "Details.txt", TextBox7.Text, False)
        End If
    End Sub

    Private Sub PictureBox15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox15.Click
        PictureBox15.Image = My.Resources.DonateP
        System.Diagnostics.Process.Start("https://sourceforge.net/donate/index.php?group_id=357229")
    End Sub

    Private Sub PictureBox15_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox15.MouseEnter
        PictureBox15.Image = My.Resources.DonateO
    End Sub

    Private Sub PictureBox15_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox15.MouseLeave
        PictureBox15.Image = My.Resources.Donate
    End Sub

    Private Sub PictureBox13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox13.Click
        PictureBox13.Image = My.Resources.Official_SiteP
        System.Diagnostics.Process.Start("http://wordpress.rockbox-psgroove.com/")
    End Sub

    Private Sub PictureBox13_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox13.MouseEnter
        PictureBox13.Image = My.Resources.Official_SiteO
    End Sub

    Private Sub PictureBox13_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox13.MouseLeave
        PictureBox13.Image = My.Resources.Official_Site
    End Sub

    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox11.Click
        PictureBox11.Image = My.Resources.PSX_SceneP
        System.Diagnostics.Process.Start("http://psx-scene.com/forums/showthread.php?t=67353")
    End Sub

    Private Sub PictureBox11_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox11.MouseEnter
        PictureBox11.Image = My.Resources.PSX_SceneO
    End Sub

    Private Sub PictureBox11_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox11.MouseLeave
        PictureBox11.Image = My.Resources.PSX_Scene
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        FolderBrowserDialog5.ShowDialog()
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        FolderBrowserDialog4.ShowDialog()
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        FolderBrowserDialog5.ShowDialog()
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        FolderBrowserDialog5.ShowDialog()
    End Sub
End Class
