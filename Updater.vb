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

Imports System.IO
Imports System.Net
Imports Ionic.Zip

Public Class Updater

    Private rvn_ZipFile As String = "zipfile"
    Private rvn_ExtractDir As String = "extractdir"
    Private Delegate Sub ZipProgress(ByVal e As ExtractProgressEventArgs)
    Private totalEntriesToProcess As Integer
    Dim WithEvents WC As New WebClient
    Dim URL As StreamReader
    Dim webRequest2 As WebRequest
    Dim webresponse2 As WebResponse
    Dim FileName As StreamReader
    Dim webRequest3 As WebRequest
    Dim webresponse3 As WebResponse

    Private Sub Updater_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Check what is the last available version for download.
        Dim inStream As StreamReader
        Dim webRequest As WebRequest
        Dim webresponse As WebResponse
        webRequest = webRequest.Create("http://rockbox-psgroove.com/Download/RockBox-PSGroove_Installer-Plug-In_Creator/update/version.txt")
        webresponse = webRequest.GetResponse()
        inStream = New StreamReader(webresponse.GetResponseStream())
        Label5.Text = inStream.ReadToEnd
    End Sub

    Private Sub PictureBox1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.Image = My.Resources.DownloadO
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.Image = My.Resources.Download
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        PictureBox1.Image = My.Resources.DownloadP
        FolderBrowserDialog1.ShowDialog()

        ProgressBar1.Visible = True

        webRequest2 = WebRequest.Create("http://rockbox-psgroove.com/Download/RockBox-PSGroove_Installer-Plug-In_Creator/update/Download.txt")
        webresponse2 = webRequest2.GetResponse()
        URL = New StreamReader(webresponse2.GetResponseStream())
        webRequest3 = WebRequest.Create("http://rockbox-psgroove.com/Download/RockBox-PSGroove_Installer-Plug-In_Creator/update/FileName.txt")
        webresponse3 = webRequest3.GetResponse()
        FileName = New StreamReader(webresponse3.GetResponseStream())

        'Download the last available version.
        WC.DownloadFileAsync(New Uri(URL.ReadToEnd), My.Computer.FileSystem.SpecialDirectories.Temp & "\" & FileName.ReadToEnd & ".zip")
        Label6.Text = "Downloading..."

    End Sub

    Private Sub WC_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged

        'Show the download progress in a progress bar.
        ProgressBar1.Value = e.ProgressPercentage

    End Sub

    Private Sub wc_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles WC.DownloadFileCompleted
        webRequest3 = WebRequest.Create("http://rockbox-psgroove.com/Download/RockBox-PSGroove_Installer-Plug-In_Creator/update/FileName.txt")
        webresponse3 = webRequest3.GetResponse()
        FileName = New StreamReader(webresponse3.GetResponseStream())
        Dim ZipToUnpack As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\" & FileName.ReadToEnd & ".zip"
        Dim TargetDir As String = FolderBrowserDialog1.SelectedPath & "\" & FileName.ReadToEnd

        Label6.Text = "Download Complete"

        'Unzip the downloaded zip.
        My.Computer.FileSystem.CreateDirectory(FolderBrowserDialog1.SelectedPath & "\" & FileName.ReadToEnd)
        Console.WriteLine(ZipToUnpack, TargetDir)
        Using zip1 As ZipFile = ZipFile.Read(ZipToUnpack)
            For Each ZipEntry In zip1
                ZipEntry.Extract(TargetDir, ExtractExistingFileAction.OverwriteSilently)
            Next
        End Using

        'Open the directory where the downloaded file uzipped to.
        System.Diagnostics.Process.Start(FolderBrowserDialog1.SelectedPath)

    End Sub
End Class