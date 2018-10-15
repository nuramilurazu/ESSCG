<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigGenerator
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
        Me.ddlFullNames = New System.Windows.Forms.ComboBox()
        Me.txtRoms = New System.Windows.Forms.TextBox()
        Me.cmdRemove = New System.Windows.Forms.Button()
        Me.lBSystemList = New System.Windows.Forms.ListBox()
        Me.gBSystem = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdEmulationBrowser = New System.Windows.Forms.Button()
        Me.txtemulator = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdRomBrowse = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdSet = New System.Windows.Forms.Button()
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdMoveUp = New System.Windows.Forms.Button()
        Me.cmdMoveDown = New System.Windows.Forms.Button()
        Me.gBSystem.SuspendLayout()
        Me.SuspendLayout()
        '
        'ddlFullNames
        '
        Me.ddlFullNames.FormattingEnabled = True
        Me.ddlFullNames.Location = New System.Drawing.Point(6, 47)
        Me.ddlFullNames.Name = "ddlFullNames"
        Me.ddlFullNames.Size = New System.Drawing.Size(135, 21)
        Me.ddlFullNames.TabIndex = 0
        '
        'txtRoms
        '
        Me.txtRoms.Location = New System.Drawing.Point(6, 97)
        Me.txtRoms.Name = "txtRoms"
        Me.txtRoms.ReadOnly = True
        Me.txtRoms.Size = New System.Drawing.Size(135, 20)
        Me.txtRoms.TabIndex = 1
        '
        'cmdRemove
        '
        Me.cmdRemove.Location = New System.Drawing.Point(430, 318)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(75, 23)
        Me.cmdRemove.TabIndex = 3
        Me.cmdRemove.Text = "Remove"
        Me.cmdRemove.UseVisualStyleBackColor = True
        '
        'lBSystemList
        '
        Me.lBSystemList.FormattingEnabled = True
        Me.lBSystemList.Location = New System.Drawing.Point(12, 12)
        Me.lBSystemList.Name = "lBSystemList"
        Me.lBSystemList.Size = New System.Drawing.Size(331, 329)
        Me.lBSystemList.TabIndex = 4
        '
        'gBSystem
        '
        Me.gBSystem.Controls.Add(Me.Label3)
        Me.gBSystem.Controls.Add(Me.cmdEmulationBrowser)
        Me.gBSystem.Controls.Add(Me.txtemulator)
        Me.gBSystem.Controls.Add(Me.Label2)
        Me.gBSystem.Controls.Add(Me.cmdRomBrowse)
        Me.gBSystem.Controls.Add(Me.Label1)
        Me.gBSystem.Controls.Add(Me.cmdSet)
        Me.gBSystem.Controls.Add(Me.ddlFullNames)
        Me.gBSystem.Controls.Add(Me.txtRoms)
        Me.gBSystem.Location = New System.Drawing.Point(374, 12)
        Me.gBSystem.Name = "gBSystem"
        Me.gBSystem.Size = New System.Drawing.Size(300, 291)
        Me.gBSystem.TabIndex = 5
        Me.gBSystem.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Emulator location"
        '
        'cmdEmulationBrowser
        '
        Me.cmdEmulationBrowser.Location = New System.Drawing.Point(151, 152)
        Me.cmdEmulationBrowser.Name = "cmdEmulationBrowser"
        Me.cmdEmulationBrowser.Size = New System.Drawing.Size(75, 23)
        Me.cmdEmulationBrowser.TabIndex = 12
        Me.cmdEmulationBrowser.Text = "Browse"
        Me.cmdEmulationBrowser.UseVisualStyleBackColor = True
        '
        'txtemulator
        '
        Me.txtemulator.Location = New System.Drawing.Point(6, 154)
        Me.txtemulator.Name = "txtemulator"
        Me.txtemulator.ReadOnly = True
        Me.txtemulator.Size = New System.Drawing.Size(135, 20)
        Me.txtemulator.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Rom Location"
        '
        'cmdRomBrowse
        '
        Me.cmdRomBrowse.Location = New System.Drawing.Point(151, 95)
        Me.cmdRomBrowse.Name = "cmdRomBrowse"
        Me.cmdRomBrowse.Size = New System.Drawing.Size(75, 23)
        Me.cmdRomBrowse.TabIndex = 9
        Me.cmdRomBrowse.Text = "Browse"
        Me.cmdRomBrowse.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Systems"
        '
        'cmdSet
        '
        Me.cmdSet.Location = New System.Drawing.Point(220, 262)
        Me.cmdSet.Name = "cmdSet"
        Me.cmdSet.Size = New System.Drawing.Size(75, 23)
        Me.cmdSet.TabIndex = 7
        Me.cmdSet.Text = "Set"
        Me.cmdSet.UseVisualStyleBackColor = True
        '
        'cmdNew
        '
        Me.cmdNew.Location = New System.Drawing.Point(349, 318)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(75, 23)
        Me.cmdNew.TabIndex = 6
        Me.cmdNew.Text = "New"
        Me.cmdNew.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(599, 318)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 7
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdMoveUp
        '
        Me.cmdMoveUp.Location = New System.Drawing.Point(349, 134)
        Me.cmdMoveUp.Name = "cmdMoveUp"
        Me.cmdMoveUp.Size = New System.Drawing.Size(19, 23)
        Me.cmdMoveUp.TabIndex = 14
        Me.cmdMoveUp.Text = "˄"
        Me.cmdMoveUp.UseVisualStyleBackColor = True
        '
        'cmdMoveDown
        '
        Me.cmdMoveDown.Location = New System.Drawing.Point(349, 163)
        Me.cmdMoveDown.Name = "cmdMoveDown"
        Me.cmdMoveDown.Size = New System.Drawing.Size(19, 23)
        Me.cmdMoveDown.TabIndex = 15
        Me.cmdMoveDown.Text = "˅"
        Me.cmdMoveDown.UseVisualStyleBackColor = True
        '
        'ConfigGenerator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 351)
        Me.Controls.Add(Me.cmdMoveDown)
        Me.Controls.Add(Me.cmdMoveUp)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdNew)
        Me.Controls.Add(Me.gBSystem)
        Me.Controls.Add(Me.lBSystemList)
        Me.Controls.Add(Me.cmdRemove)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "ConfigGenerator"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "EmulationStation Systems Config Generator"
        Me.gBSystem.ResumeLayout(False)
        Me.gBSystem.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ddlFullNames As System.Windows.Forms.ComboBox
    Friend WithEvents txtRoms As System.Windows.Forms.TextBox
    Friend WithEvents cmdRemove As System.Windows.Forms.Button
    Friend WithEvents lBSystemList As System.Windows.Forms.ListBox
    Friend WithEvents gBSystem As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdRomBrowse As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdSet As System.Windows.Forms.Button
    Friend WithEvents cmdNew As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdEmulationBrowser As System.Windows.Forms.Button
    Friend WithEvents txtemulator As System.Windows.Forms.TextBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdMoveUp As System.Windows.Forms.Button
    Friend WithEvents cmdMoveDown As System.Windows.Forms.Button

End Class
