<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackup
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBackup))
        Me.devTree = New System.Windows.Forms.TreeView()
        Me.lblDevFound = New System.Windows.Forms.Label()
        Me.optBox = New System.Windows.Forms.GroupBox()
        Me.txtDateFormat = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtBackupFile = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.txtDevFormat = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkAutoRestore = New System.Windows.Forms.CheckBox()
        Me.chkOverwrite = New System.Windows.Forms.CheckBox()
        Me.txtFormat = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdBrowse = New System.Windows.Forms.Button()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdBackup = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdContinue = New System.Windows.Forms.Button()
        Me.cmdLog = New System.Windows.Forms.Button()
        Me.infoBox = New System.Windows.Forms.GroupBox()
        Me.lblFilename = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.backupBar = New System.Windows.Forms.ProgressBar()
        Me.deviceBar = New System.Windows.Forms.ProgressBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblOutputPath = New System.Windows.Forms.Label()
        Me.optBox.SuspendLayout()
        Me.infoBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'devTree
        '
        Me.devTree.Location = New System.Drawing.Point(12, 49)
        Me.devTree.Name = "devTree"
        Me.devTree.Size = New System.Drawing.Size(590, 278)
        Me.devTree.TabIndex = 0
        '
        'lblDevFound
        '
        Me.lblDevFound.AutoSize = True
        Me.lblDevFound.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDevFound.Location = New System.Drawing.Point(12, 20)
        Me.lblDevFound.Name = "lblDevFound"
        Me.lblDevFound.Size = New System.Drawing.Size(45, 13)
        Me.lblDevFound.TabIndex = 1
        Me.lblDevFound.Text = "Label1"
        '
        'optBox
        '
        Me.optBox.Controls.Add(Me.txtDateFormat)
        Me.optBox.Controls.Add(Me.Label10)
        Me.optBox.Controls.Add(Me.txtBackupFile)
        Me.optBox.Controls.Add(Me.Label7)
        Me.optBox.Controls.Add(Me.Label6)
        Me.optBox.Controls.Add(Me.txtDesc)
        Me.optBox.Controls.Add(Me.txtDevFormat)
        Me.optBox.Controls.Add(Me.Label5)
        Me.optBox.Controls.Add(Me.chkAutoRestore)
        Me.optBox.Controls.Add(Me.chkOverwrite)
        Me.optBox.Controls.Add(Me.txtFormat)
        Me.optBox.Controls.Add(Me.Label2)
        Me.optBox.Controls.Add(Me.cmdBrowse)
        Me.optBox.Controls.Add(Me.txtPath)
        Me.optBox.Controls.Add(Me.Label1)
        Me.optBox.Location = New System.Drawing.Point(12, 368)
        Me.optBox.Name = "optBox"
        Me.optBox.Size = New System.Drawing.Size(590, 234)
        Me.optBox.TabIndex = 2
        Me.optBox.TabStop = False
        Me.optBox.Text = "Configurazione backup"
        '
        'txtDateFormat
        '
        Me.txtDateFormat.Location = New System.Drawing.Point(163, 147)
        Me.txtDateFormat.Name = "txtDateFormat"
        Me.txtDateFormat.Size = New System.Drawing.Size(335, 20)
        Me.txtDateFormat.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 150)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Date format"
        '
        'txtBackupFile
        '
        Me.txtBackupFile.Location = New System.Drawing.Point(164, 67)
        Me.txtBackupFile.Name = "txtBackupFile"
        Me.txtBackupFile.Size = New System.Drawing.Size(334, 20)
        Me.txtBackupFile.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Backup file name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Description"
        '
        'txtDesc
        '
        Me.txtDesc.Location = New System.Drawing.Point(163, 42)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(335, 20)
        Me.txtDesc.TabIndex = 20
        Me.txtDesc.Text = "[Insert a description here]"
        '
        'txtDevFormat
        '
        Me.txtDevFormat.Location = New System.Drawing.Point(164, 118)
        Me.txtDevFormat.Name = "txtDevFormat"
        Me.txtDevFormat.Size = New System.Drawing.Size(335, 20)
        Me.txtDevFormat.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Device path format"
        '
        'chkAutoRestore
        '
        Me.chkAutoRestore.AutoSize = True
        Me.chkAutoRestore.Location = New System.Drawing.Point(19, 211)
        Me.chkAutoRestore.Name = "chkAutoRestore"
        Me.chkAutoRestore.Size = New System.Drawing.Size(240, 17)
        Me.chkAutoRestore.TabIndex = 16
        Me.chkAutoRestore.Text = "Create files for automatic restoration of drivers"
        Me.chkAutoRestore.UseVisualStyleBackColor = True
        '
        'chkOverwrite
        '
        Me.chkOverwrite.AutoSize = True
        Me.chkOverwrite.Location = New System.Drawing.Point(19, 188)
        Me.chkOverwrite.Name = "chkOverwrite"
        Me.chkOverwrite.Size = New System.Drawing.Size(387, 17)
        Me.chkOverwrite.TabIndex = 15
        Me.chkOverwrite.Text = "Enable overwrite, if necessary, of the files on the backup path, (discouraged)"
        Me.chkOverwrite.UseVisualStyleBackColor = True
        '
        'txtFormat
        '
        Me.txtFormat.Location = New System.Drawing.Point(164, 92)
        Me.txtFormat.Name = "txtFormat"
        Me.txtFormat.Size = New System.Drawing.Size(335, 20)
        Me.txtFormat.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Path format"
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Location = New System.Drawing.Point(512, 16)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(69, 27)
        Me.cmdBrowse.TabIndex = 12
        Me.cmdBrowse.Text = "Browse.."
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(163, 16)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(335, 20)
        Me.txtPath.TabIndex = 11
        Me.txtPath.Text = "[Click browse to select a path]"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Path"
        '
        'cmdBackup
        '
        Me.cmdBackup.Location = New System.Drawing.Point(498, 609)
        Me.cmdBackup.Name = "cmdBackup"
        Me.cmdBackup.Size = New System.Drawing.Size(104, 29)
        Me.cmdBackup.TabIndex = 3
        Me.cmdBackup.Text = "Start backup"
        Me.cmdBackup.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(387, 609)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(105, 29)
        Me.cmdOk.TabIndex = 4
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(54, 608)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(105, 28)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdContinue
        '
        Me.cmdContinue.Location = New System.Drawing.Point(165, 608)
        Me.cmdContinue.Name = "cmdContinue"
        Me.cmdContinue.Size = New System.Drawing.Size(105, 28)
        Me.cmdContinue.TabIndex = 6
        Me.cmdContinue.Text = "Continuе"
        Me.cmdContinue.UseVisualStyleBackColor = True
        '
        'cmdLog
        '
        Me.cmdLog.Location = New System.Drawing.Point(276, 608)
        Me.cmdLog.Name = "cmdLog"
        Me.cmdLog.Size = New System.Drawing.Size(105, 30)
        Me.cmdLog.TabIndex = 7
        Me.cmdLog.Text = "Save log file"
        Me.cmdLog.UseVisualStyleBackColor = True
        Me.cmdLog.Visible = False
        '
        'infoBox
        '
        Me.infoBox.Controls.Add(Me.lblFilename)
        Me.infoBox.Controls.Add(Me.Label8)
        Me.infoBox.Controls.Add(Me.backupBar)
        Me.infoBox.Controls.Add(Me.deviceBar)
        Me.infoBox.Controls.Add(Me.Label4)
        Me.infoBox.Controls.Add(Me.Label3)
        Me.infoBox.Location = New System.Drawing.Point(622, 349)
        Me.infoBox.Name = "infoBox"
        Me.infoBox.Size = New System.Drawing.Size(590, 195)
        Me.infoBox.TabIndex = 8
        Me.infoBox.TabStop = False
        Me.infoBox.Text = "Operations state"
        Me.infoBox.Visible = False
        '
        'lblFilename
        '
        Me.lblFilename.Location = New System.Drawing.Point(162, 105)
        Me.lblFilename.Name = "lblFilename"
        Me.lblFilename.Size = New System.Drawing.Size(393, 20)
        Me.lblFilename.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Copy file"
        '
        'backupBar
        '
        Me.backupBar.Location = New System.Drawing.Point(165, 68)
        Me.backupBar.Name = "backupBar"
        Me.backupBar.Size = New System.Drawing.Size(390, 20)
        Me.backupBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.backupBar.TabIndex = 3
        '
        'deviceBar
        '
        Me.deviceBar.Location = New System.Drawing.Point(165, 29)
        Me.deviceBar.Name = "deviceBar"
        Me.deviceBar.Size = New System.Drawing.Size(390, 20)
        Me.deviceBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.deviceBar.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Total"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Actual device"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 341)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Full path"
        '
        'lblOutputPath
        '
        Me.lblOutputPath.AutoSize = True
        Me.lblOutputPath.Location = New System.Drawing.Point(124, 341)
        Me.lblOutputPath.Name = "lblOutputPath"
        Me.lblOutputPath.Size = New System.Drawing.Size(45, 13)
        Me.lblOutputPath.TabIndex = 10
        Me.lblOutputPath.Text = "Label10"
        '
        'frmBackup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(611, 650)
        Me.Controls.Add(Me.lblOutputPath)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.infoBox)
        Me.Controls.Add(Me.cmdLog)
        Me.Controls.Add(Me.cmdContinue)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdBackup)
        Me.Controls.Add(Me.optBox)
        Me.Controls.Add(Me.lblDevFound)
        Me.Controls.Add(Me.devTree)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmBackup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Backup selected devices"
        Me.optBox.ResumeLayout(False)
        Me.optBox.PerformLayout()
        Me.infoBox.ResumeLayout(False)
        Me.infoBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents devTree As System.Windows.Forms.TreeView
    Friend WithEvents lblDevFound As System.Windows.Forms.Label
    Friend WithEvents optBox As System.Windows.Forms.GroupBox
    Friend WithEvents cmdBackup As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdContinue As System.Windows.Forms.Button
    Friend WithEvents txtDevFormat As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkAutoRestore As System.Windows.Forms.CheckBox
    Friend WithEvents chkOverwrite As System.Windows.Forms.CheckBox
    Friend WithEvents txtFormat As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdLog As System.Windows.Forms.Button
    Friend WithEvents deviceBar As System.Windows.Forms.ProgressBar
    Friend WithEvents infoBox As System.Windows.Forms.GroupBox
    Friend WithEvents backupBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtBackupFile As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblFilename As System.Windows.Forms.Label
    Friend WithEvents txtDateFormat As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblOutputPath As System.Windows.Forms.Label
End Class
