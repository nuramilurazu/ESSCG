Imports System.IO
Imports System.IO.Directory

Public Class ConfigGenerator
    Dim esSystemCFG As String = Environ("homedrive") & Environ("homepath") & "\.emulationstation\es_systems.cfg"
    Dim CFGReader As StreamReader
    Dim CFGWriter As StreamWriter
    Dim currentESSC, libRetroCore, sysbuilder(), baseRomDirectory As String
    Dim txtBios As New TextBox()
    Dim cmdBiosBrowser As New Button()
    Dim lblBios, lblLibRetro As New Label()
    Dim ddlCores As New ComboBox()
    Dim sysArray, holder As New List(Of iArray)
    Dim Platforms As pArray()
    Dim RomDirectory, EmuDirectory, BiosDirectory, coreDirectory As DirectoryInfo

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        

        Me.Size = New Size(698, 390)

        If File.Exists(esSystemCFG) Then
            CFGReader = File.OpenText(esSystemCFG)
            currentESSC = CFGReader.ReadToEnd()
            CFGReader.Dispose()
        Else
            MessageBox.Show("Unable to Locate es_systems.cfg. Make sure you have installed Emulation Station first before using this app.", "Error")
            Me.Close()
        End If

        ReDim Platforms(54)

        intalizeControls()
        readSystemCFG()
        buildDDLFullNames()
        buildDDLSysNames()
        buildExtenionsList()

    End Sub

    Private Sub buildDDLFullNames()
        Dim temp As String

        Dim executing_assembly As System.Reflection.Assembly = _
    Reflection.Assembly.GetEntryAssembly()

        ' Get our namespace.
        Dim my_namespace As String = _
            executing_assembly.GetName().Name.ToString()

        'build fullnames ddl
        Dim text_stream As Stream = _
            executing_assembly.GetManifestResourceStream(my_namespace _
            + ".fullnames.txt")
        If Not (text_stream Is Nothing) Then
            Dim stream_reader As New StreamReader(text_stream)

            Dim i As Integer = 0

            Do
                Try
                    temp = stream_reader.ReadLine
                    ddlFullNames.Items.Add(temp)
                    Platforms(i) = New pArray With {.fullname = temp}
                Catch ex As Exception
                    Exit Do
                End Try
                i += 1
            Loop
            stream_reader.Close()
        End If
    End Sub

    Private Sub buildDDLSysNames()
        Dim temp As String

        Dim executing_assembly As System.Reflection.Assembly = _
    Reflection.Assembly.GetEntryAssembly()

        ' Get our namespace.
        Dim my_namespace As String = _
            executing_assembly.GetName().Name.ToString()

        'build fullnames ddl
        Dim text_stream As Stream = _
            executing_assembly.GetManifestResourceStream(my_namespace _
            + ".platforms.txt")
        If Not (text_stream Is Nothing) Then
            Dim stream_reader As New StreamReader(text_stream)
            Dim i As Integer = 0
            Do
                Try
                    temp = stream_reader.ReadLine
                    Platforms(i).name = temp
                Catch ex As Exception
                    Exit Do
                End Try
                i += 1
            Loop
            stream_reader.Close()
        End If
    End Sub

    Private Sub buildExtenionsList()
        Dim temp As String

        Dim executing_assembly As System.Reflection.Assembly = _
    Reflection.Assembly.GetEntryAssembly()

        ' Get our namespace.
        Dim my_namespace As String = _
            executing_assembly.GetName().Name.ToString()

        'build fullnames ddl
        Dim text_stream As Stream = _
            executing_assembly.GetManifestResourceStream(my_namespace _
            + ".extensions.txt")
        If Not (text_stream Is Nothing) Then
            Dim stream_reader As New StreamReader(text_stream)
            Dim i As Integer = 0
            Do
                Try
                    temp = stream_reader.ReadLine
                    Platforms(i).extensions = temp
                Catch ex As Exception
                    Exit Do
                End Try
                i += 1
            Loop
            stream_reader.Close()
        End If
    End Sub

    Private Sub ePSXeBiosOption() 'ePSXe controls
        txtBios.Show()
        cmdBiosBrowser.Show()
        lblBios.Show()
    End Sub

    Private Sub intalizeControls()
        'epsxe
        'text box
        gBSystem.Controls.Add(txtBios)
        txtBios.Location = New Point(6, 209)
        txtBios.Size = New Size(135, 20)
        txtBios.ReadOnly = True
        txtBios.Hide()
        'button
        gBSystem.Controls.Add(cmdBiosBrowser)
        cmdBiosBrowser.Text = "Browse"
        AddHandler cmdBiosBrowser.Click, AddressOf biosBrowseClick
        cmdBiosBrowser.Location = New Point(151, 207)
        cmdBiosBrowser.Hide()
        'label
        gBSystem.Controls.Add(lblBios)
        lblBios.Text = "Perfered ePSXe Bios"
        lblBios.AutoSize = True
        lblBios.Location = New Point(6, 193)
        lblBios.Hide()
        'Retroarch cores controls
        'combobox
        gBSystem.Controls.Add(ddlCores)
        ddlCores.Location = New Point(6, 210)
        ddlCores.Size = New Size(135, 20)
        ddlCores.Hide()
        'label
        gBSystem.Controls.Add(lblLibRetro)
        lblLibRetro.Location = New Point(6, 194)
        lblLibRetro.AutoSize = True
        lblLibRetro.Text = "Retroarch Core"
        lblLibRetro.Hide()
    End Sub

    Private Sub libretroCoresOption() 'Retroarch cores controls
        'combobox
        ddlCores.Show()
        'label
        lblLibRetro.Show()
    End Sub

    Private Sub coreLoader(ByVal src As String) 'only runs if user selects retroarch as emulator
        If ddlCores.Items.Count = 0 Then
            Dim tempinfo As FileInfo()
            Dim tempdir As DirectoryInfo
            Dim co As FileInfo
            'Get all the objects in the folder
            Dim Files() As String = Directory.GetFileSystemEntries(src)
            'Check each item in the folder
            For Each element As String In Files
                If Directory.Exists(element) = True Then
                    'Current FileSystemEntry is a directory, call this function recursively
                    Try
                        tempdir = New DirectoryInfo(element)
                        If tempdir.ToString.ToLower.Contains("cores") Or tempdir.ToString.ToLower.Contains("libretro") Then
                            tempinfo = tempdir.GetFiles("*.dll")
                            coreDirectory = New DirectoryInfo(element)
                            For Each co In tempinfo
                                ddlCores.Items.Add(co)
                            Next
                            Exit Sub
                        End If
                        Call coreLoader(element)
                    Catch ex As Exception
                        'This causes the AccessDenied folders to be gracefully skipped
                    End Try
                Else
                    'This is a file, ignore this

                End If
            Next element
        End If
    End Sub

    Private Sub extraControlsHider()
        txtBios.Hide()
        txtBios.Clear()
        cmdBiosBrowser.Hide()
        lblBios.Hide()
        lblLibRetro.Hide()
        ddlCores.Hide()
    End Sub

    Private Sub cmdRomBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdRomBrowse.Click

        Dim instance As New FolderBrowserDialog()
        instance.ShowNewFolderButton = False
        If baseRomDirectory IsNot Nothing Then
            instance.SelectedPath = baseRomDirectory
            instance.RootFolder = Environment.SpecialFolder.MyComputer
        End If


        If instance.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                If (instance.SelectedPath IsNot Nothing) Then
                    RomDirectory = New DirectoryInfo(instance.SelectedPath.ToString)
                    txtRoms.Text = RomDirectory.ToString
                    baseRomDirectory = RomDirectory.ToString.Remove(RomDirectory.ToString.LastIndexOf("\") - 1)
                End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            End Try
        End If

    End Sub

    Private Sub readSystemCFG()

        Dim temp, tempName, tempPlatform, tempFullName, tempRomPath, tempTheme, tempExtensions, tempEmuPath, tempBios, tempCore As String

        Dim delim As String() = New String() {"<system>"}
        sysbuilder = currentESSC.Split(delim, StringSplitOptions.None) 'break the es_system.cfg string into more readable chunks

        Dim loopcount As Integer = sysbuilder.Count - 1
        'first entry in the array is useless as it contains only the systemlist open tag
        Dim i As Integer = 0

        For c = 1 To loopcount

            'name
            temp = sysbuilder(c)
            temp = temp.Remove(temp.ToLower.IndexOf("</name>"))
            tempName = temp.Substring(temp.LastIndexOf(">") + 1)

            'fullname
            temp = sysbuilder(c)
            temp = temp.Remove(temp.ToLower.IndexOf("</fullname>"))
            tempFullName = temp.Substring(temp.LastIndexOf(">") + 1)

            'rom path
            temp = sysbuilder(c)
            temp = temp.Remove(temp.ToLower.IndexOf("</path>"))
            tempRomPath = temp.Substring(temp.LastIndexOf(">") + 1)

            'platform
            temp = sysbuilder(c)
            temp = temp.Remove(temp.ToLower.IndexOf("</platform>"))
            tempPlatform = temp.Substring(temp.LastIndexOf(">") + 1)

            'theme
            temp = sysbuilder(c)
            temp = temp.Remove(temp.ToLower.IndexOf("</theme>"))
            tempTheme = temp.Substring(temp.LastIndexOf(">") + 1)

            'extenstions
            temp = sysbuilder(c)
            temp = temp.Remove(temp.ToLower.IndexOf("</extension>"))
            tempExtensions = temp.Substring(temp.LastIndexOf(">") + 1)

            'emupath, core for retroarch, bios for ePSXe
            temp = sysbuilder(c)
            temp = temp.Remove(temp.ToLower.IndexOf("</command>"))
            temp = temp.Substring(temp.LastIndexOf(">") + 1)

            If temp.ToLower.Contains("epsxe.exe") Then
                tempEmuPath = temp.Remove(temp.IndexOf(".") + 4)
                temp = temp.Remove(temp.LastIndexOf(".") + 4)
                tempBios = temp.Remove(0, temp.LastIndexOf(":") - 1)
                sysArray.Add(New iArray With {.name = tempName, .fullname = tempFullName, .romPath = tempRomPath, .extensions = tempExtensions, .emuPath = tempEmuPath, .platform = tempPlatform, .theme = tempTheme, .bios = tempBios, .core = Nothing})

            ElseIf temp.ToLower.Contains("retroarch.exe") Then
                tempEmuPath = temp.Remove(temp.IndexOf(".") + 4)
                temp = temp.Remove(temp.LastIndexOf(".") + 4)
                tempCore = temp.Remove(0, temp.LastIndexOf(":") - 1)
                sysArray.Add(New iArray With {.name = tempName, .fullname = tempFullName, .romPath = tempRomPath, .extensions = tempExtensions, .emuPath = tempEmuPath, .platform = tempPlatform, .theme = tempTheme, .bios = Nothing, .core = tempCore})

            Else
                tempEmuPath = temp.Remove(temp.LastIndexOf(".") + 4)
                sysArray.Add(New iArray With {.name = tempName, .fullname = tempFullName, .romPath = tempRomPath, .extensions = tempExtensions, .emuPath = tempEmuPath, .platform = tempPlatform, .theme = tempTheme, .bios = Nothing, .core = Nothing})

            End If
            lBSystemList.Items.Add(sysArray(i).fullname)
            i += 1
        Next c

    End Sub

    Private Sub biosBrowseClick()

        Dim instance As New OpenFileDialog()

        With instance

            .Filter = "Bios (ps*.bin)|ps*.bin|Bios (scph*.bin)|scph*.bin"
            .FilterIndex = 1
            .Multiselect = False
            .RestoreDirectory = True

            If .ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Try
                    BiosDirectory = New DirectoryInfo(.FileName)
                    txtBios.Text = BiosDirectory.ToString
                Catch Ex As Exception
                    MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
                End Try
            End If
        End With
    End Sub

    Private Sub cmdEmulationBrowser_Click(sender As System.Object, e As System.EventArgs) Handles cmdEmulationBrowser.Click

        Dim instance As New OpenFileDialog()

        With instance

            .Filter = "executable (*.exe)|*.exe"
            .FilterIndex = 1
            .Multiselect = False
            .RestoreDirectory = True

            If .ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Try
                    EmuDirectory = New DirectoryInfo(.FileName)
                    txtemulator.Text = .FileName
                    extraControlsHider()

                    If .FileName.ToLower.Contains("epsxe.exe") Then
                        ePSXeBiosOption()
                    ElseIf .FileName.ToLower.ToString.Contains("retroarch.exe") Then
                        libretroCoresOption()
                        coreLoader(.FileName.Remove(.FileName.Length - .SafeFileName.Length))
                    End If

                Catch Ex As Exception
                    MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
                End Try

            End If
        End With

    End Sub

    Private Sub cmdSet_Click(sender As System.Object, e As System.EventArgs) Handles cmdSet.Click
        If txtemulator.Text = String.Empty Or txtRoms.Text = String.Empty Or ddlFullNames.Text = String.Empty Then Exit Sub

        Dim temp As String = Platforms(ddlFullNames.SelectedIndex).name
        Dim tNum As Integer = sysArray.Count

        If txtemulator.Text.ToLower.Contains("epsxe.exe") Then
            sysArray.Add(New iArray With {.name = temp, .fullname = ddlFullNames.Items.Item(ddlFullNames.SelectedIndex), .theme = temp, .platform = temp, .romPath = RomDirectory.ToString, .emuPath = EmuDirectory.ToString, .extensions = Platforms(ddlFullNames.SelectedIndex).extensions, .core = Nothing, .bios = BiosDirectory.ToString})
        ElseIf txtemulator.Text.ToLower.Contains("retroarch.exe") Then
            Dim dllLoc As String = coreDirectory.ToString & "\" & ddlCores.Text
            sysArray.Add(New iArray With {.name = temp, .fullname = ddlFullNames.Items.Item(ddlFullNames.SelectedIndex), .theme = temp, .platform = temp, .romPath = RomDirectory.ToString, .emuPath = EmuDirectory.ToString, .extensions = Platforms(ddlFullNames.SelectedIndex).extensions, .core = dllLoc, .bios = Nothing})
        Else
            sysArray.Add(New iArray With {.name = temp, .fullname = ddlFullNames.Items.Item(ddlFullNames.SelectedIndex), .theme = temp, .platform = temp, .romPath = RomDirectory.ToString, .emuPath = EmuDirectory.ToString, .extensions = Platforms(ddlFullNames.SelectedIndex).extensions, .core = Nothing, .bios = Nothing})
        End If

        If cmdSet.Tag = "new" Then
            lBSystemList.Items.Add(sysArray(tNum).fullname)
            cmdSet.Tag = "edit"
        Else
            Dim tempint As Integer = lBSystemList.SelectedIndex
            lBSystemList.Items.RemoveAt(tempint)
            lBSystemList.Items.Insert(tempint, sysArray(tNum).fullname)
        End If
    End Sub

    Private Sub cmdRemove_Click(sender As System.Object, e As System.EventArgs) Handles cmdRemove.Click
        If lBSystemList.Items.Count = 0 Then Exit Sub
        Dim temp As Integer = lBSystemList.SelectedIndex

        lBSystemList.Items.RemoveAt(temp)
        sysArray.RemoveAt(temp)

        If temp = lBSystemList.Items.Count Then
            lBSystemList.SelectedIndex = lBSystemList.Items.Count - 1
        Else
            lBSystemList.SelectedIndex = temp
        End If
    End Sub

    Private Sub cmdNew_Click(sender As System.Object, e As System.EventArgs) Handles cmdNew.Click
        txtRoms.Clear()
        txtemulator.Clear()
        extraControlsHider()
        cmdSet.Tag = "new"
    End Sub

    Private Sub lBSystemList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lBSystemList.SelectedIndexChanged
        Dim i As Integer = lBSystemList.SelectedIndex

        If i < 0 Then Exit Sub

        ddlFullNames.SelectedIndex() = ddlFullNames.FindStringExact(lBSystemList.Items.Item(i))
        extraControlsHider()
        With sysArray(i)
            RomDirectory = New DirectoryInfo(.romPath)
            EmuDirectory = New DirectoryInfo(.emuPath)

            If EmuDirectory.ToString.ToLower.Contains("epsxe.exe") Then
                BiosDirectory = New DirectoryInfo(.bios)
                txtBios.Text = BiosDirectory.ToString
                ePSXeBiosOption()
            ElseIf EmuDirectory.ToString.ToLower.Contains("retroarch.exe") Then
                If .core.Contains("cores") Then
                    coreLoader(.core.Remove(.core.LastIndexOf("cores")))
                Else
                    coreLoader(.core.Remove(.core.LastIndexOf("libretro")))
                End If
                libretroCoresOption()
                ddlCores.SelectedIndex = ddlCores.FindStringExact(.core.Remove(0, .core.LastIndexOf("\") + 1))
            End If
        End With

        txtRoms.Text = RomDirectory.ToString
        txtemulator.Text = EmuDirectory.ToString

    End Sub

    Private Sub ddlFullNames_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddlFullNames.SelectedIndexChanged
        gBSystem.Text = ddlFullNames.Items.Item(ddlFullNames.SelectedIndex)
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click

        Dim nfile As String = "new_es_systems.cfg"

        CFGWriter = File.CreateText(nfile)
        CFGWriter.WriteLine("<systemList>" & vbCrLf)

        For i = 0 To sysArray.Count - 1
            saveCFG(i)
        Next i

        CFGWriter.WriteLine("</systemList>")
        CFGWriter.Close()
        File.Delete(esSystemCFG)
        My.Computer.FileSystem.MoveFile(nfile, esSystemCFG)

    End Sub

    Private Sub saveCFG(ByVal i As Integer)
        Dim command As String
        CFGWriter.WriteLine(vbTab & "<system>")
        CFGWriter.WriteLine(vbTab & vbTab & "<name>" & sysArray(i).name & "</name>")
        CFGWriter.WriteLine(vbTab & vbTab & "<fullname>" & sysArray(i).fullname & "</fullname>")
        CFGWriter.WriteLine(vbTab & vbTab & "<path>" & sysArray(i).romPath & "</path>")
        CFGWriter.WriteLine(vbTab & vbTab & "<extension>" & sysArray(i).extensions & "</extension>")

        If sysArray(i).emuPath.ToLower.Contains("dolphin.exe") Then
            command = sysArray(i).emuPath & " ""/e"" ""%ROM_RAW%"" ""/b"""
        ElseIf sysArray(i).emuPath.ToLower.Contains("epsxe.exe") Then
            command = sysArray(i).emuPath & " -nogui -bios """ & sysArray(i).bios & """ -loadbin ""%ROM_RAW%"""
        ElseIf sysArray(i).emuPath.ToLower.Contains("retroarch.exe") Then
            command = sysArray(i).emuPath & " -L """ & sysArray(i).core & """ ""%ROM_RAW%"""
        Else
            command = sysArray(i).emuPath & " ""%ROM_RAW%"""
        End If
        CFGWriter.WriteLine(vbTab & vbTab & "<command>" & command & "</command>")
        CFGWriter.WriteLine(vbTab & vbTab & "<platform>" & sysArray(i).platform & "</platform>")
        CFGWriter.WriteLine(vbTab & vbTab & "<theme>" & sysArray(i).theme & "</theme>")
        CFGWriter.WriteLine(vbTab & "</system>" & vbCrLf)
    End Sub

    Private Sub cmdMoveUp_Click(sender As System.Object, e As System.EventArgs) Handles cmdMoveUp.Click
        Dim i As Integer = lBSystemList.SelectedIndex
        Dim insertPoint As Integer = lBSystemList.SelectedIndex - 1
        Dim entry As String = lBSystemList.SelectedItem

        If i = 0 Or Nothing Then
            Exit Sub
        Else
            tempIArray(i)
            lBSystemList.Items.RemoveAt(i)
            lBSystemList.Items.Insert(insertPoint, entry)
            sysArray.RemoveAt(i)
            sysArrayInsert(insertPoint)
        End If
    End Sub

    Private Sub cmdMoveDown_Click(sender As System.Object, e As System.EventArgs) Handles cmdMoveDown.Click
        Dim i As Integer = lBSystemList.SelectedIndex
        Dim insertPoint As Integer = lBSystemList.SelectedIndex + 2

        If i = lBSystemList.Items.Count - 1 Or Nothing Then
            Exit Sub
        Else
            tempIArray(i)
            lBSystemList.Items.Insert(insertPoint, lBSystemList.SelectedItem)
            lBSystemList.Items.RemoveAt(i)
            sysArrayInsert(insertPoint)
            sysArray.RemoveAt(i)
        End If
    End Sub

    Private Sub tempIArray(ByVal index As Integer)
        holder.Clear()

        holder.Add(New iArray With {.name = sysArray(index).name, .fullname = sysArray(index).fullname, .bios = sysArray(index).bios, .core = sysArray(index).core, .emuPath = sysArray(index).emuPath, .romPath = sysArray(index).romPath, .extensions = sysArray(index).extensions, .theme = sysArray(index).theme, .platform = sysArray(index).platform})

    End Sub

    Private Sub sysArrayInsert(ByVal index As Integer)
        sysArray.Insert(index, New iArray With {.name = holder(0).name, .fullname = holder(0).fullname, .bios = holder(0).bios, .core = holder(0).core, .emuPath = holder(0).emuPath, .romPath = holder(0).romPath, .extensions = holder(0).extensions, .theme = holder(0).theme, .platform = holder(0).platform})
    End Sub

End Class
