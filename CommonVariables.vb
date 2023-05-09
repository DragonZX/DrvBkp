
Imports DriverBackup__2.LanguageManager

Module CommonVariables
    Private Const V As Boolean = False

    'Contiene variabili condivise dall'applicazione

    Private langStrs As New Dictionary(Of String, String)
    Private lang As String

    Public Enum HelpGuideSection
        index
        Backup
        Restore
        CommandLine
        PathFormat
        Builder
        Remote
        Info
    End Enum
    Public Function OpenHelpGuide(ByVal section As HelpGuideSection) As Process
        Try
            'Tenta di aprire la sezione guida specificata
            'Carica il percorso principale
            Dim pt As String = My.Application.Info.DirectoryPath & "\help\"

            'Il nome del file in particolare
            pt = Path.Combine(pt, "Help_" & lang & ".htm")
            Return Process.Start(pt)

        Catch ex As Exception
            'Dim pt As String = My.Application.Info.DirectoryPath & "\help\"
            'MsgBox("Unable to load the file " & "Help_" & lang & ".htm#" & section.ToString & " Maybe it was deleted?" )
            Return Process.GetCurrentProcess 'Fake exit

        End Try
    End Function

    Public Function CheckDonate() As Boolean
        Dim regKey As RegistryKey = Nothing
        Dim value As Object

        Try

            regKey = Registry.LocalMachine.CreateSubKey(My.Settings.RegistryKey)
            value = regKey.GetValue("Donate")

            If value Is Nothing Then
                'Il messaggio non � stato ancora visualizzato
                regKey.SetValue("Donate", True)
                Return True
            Else
                Return CBool(value)
            End If

            regKey.Close()
            regKey = Nothing
        Catch ex As Exception
        Finally
            If regKey IsNot Nothing Then regKey.Close()
        End Try
    End Function


    Public Function GetLanguageFiles() As Dictionary(Of String, String)
        Dim lst As New Dictionary(Of String, String)

        Try

            Dim langMn As LanguageFileReader

            Dim d As New DirectoryInfo(My.Application.Info.DirectoryPath)

            For Each f As FileInfo In d.GetFiles("l10n/*.xml")
                langMn = LanguageFileReader.LoadLanguageFile(f.FullName)
                If langMn Is Nothing OrElse langMn.IsValid = False Then Continue For 'File non valido
                If Not lst.ContainsKey(f.Name) Then lst.Add(f.Name, langMn.Author)
            Next

            Return lst
        Catch ex As Exception
            Return lst
        End Try

    End Function

    Public Function GenerateLanguageFile(ByVal languageFile As String, Optional ByVal updateMode As Boolean = False) As Boolean
        Try
            Dim fw As New LanguageManager.LanguageFileWriter(languageFile)
            
            Dim memberFilter As String = ""
            Dim propertyFilter As String = "^Text$"

            With My.Forms
                fw.AddObject(.frmBackup, LanguageManager.StdBindingFlags, New Type() {GetType(Control), GetType(ToolStripItem)}, memberFilter, propertyFilter, False)
                fw.AddObject(.frmCmdBuilder, LanguageManager.StdBindingFlags, New Type() {GetType(Control), GetType(ToolStripItem)}, memberFilter, propertyFilter, False)
                fw.AddObject(.frmMain, LanguageManager.StdBindingFlags, New Type() {GetType(Control), GetType(ToolStripItem)}, memberFilter, propertyFilter, False)
                'fw.AddObject(.frmRemove, LanguageManager.StdBindingFlags, New Type() {GetType(Control), GetType(ToolStripItem)}, memberFilter, propertyFilter, False)
                fw.AddObject(.frmRestore, LanguageManager.StdBindingFlags, New Type() {GetType(Control), GetType(ToolStripItem)}, memberFilter, propertyFilter, False)
                fw.AddObject(.frmOffline, LanguageManager.StdBindingFlags, New Type() {GetType(Control), GetType(ToolStripItem)}, memberFilter, propertyFilter, False)
            End With

            If updateMode Then
                'Aggiornamento del file lingua
                Dim dbgList As Dictionary(Of String, String) = GetDebugLangStrs()
                For Each k As KeyValuePair(Of String, String) In dbgList
                    If Not langStrs.ContainsKey(k.Key) Then langStrs.Add(k.Key, k.Value)
                Next

            End If
            fw.AddCustomArr("CommonVariables", "langStrs", langStrs)

            fw.WriteToFile(languageFile)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetLangStr(ByVal name As String) As String

        name = name.Replace(":", "_")

        If langStrs.ContainsKey(name) = False Then Return [String].Empty

        Dim result As String = langStrs(name).Replace("\n", ControlChars.NewLine)
        result = result.Replace("\t", ControlChars.Tab)

        Return result
    End Function


    Private Function GetDebugLangStrs() As Dictionary(Of String, String)
        Dim lst As New Dictionary(Of String, String)

        With lst
            .Add("GENERIC", "Unknown error")
            .Add("YES", "Yes")
            .Add("NO", "No")
            .Add("ERROR_FLD", "Selected directory does not exist. Select a valid directory")
            .Add("ERROR_BERR", "An error occurred during program's execution. Restart DriverBackup!")
            .Add("ERROR_FileWrite", "Cannot save file.")
            .Add("ERROR_FileOpen", "Can't open file. File could be damaged.")
            .Add("ERROR_RegistryAccess", "DriverBackup! can't open system registry. Check for administrative privileges.")
            .Add("ERROR_Admin", "DriverBackup! requires administrative privileges. Restart program with required privileges or contact system administrator.")
            .Add("ERROR_BadSystem", "DriverBackup! can't run under this operating system. Program will be closed.")
            .Add("BRE_Generic", "Unknown error occurred during operation.")
            .Add("BRE_InvalidDevice", "Information about devices are damaged or incorrect.")
            .Add("BRE_UnformattablePath", "Invalid path format.")
            .Add("BRE_NoDevices", "No devices selected.")
            .Add("BRE_FileOverwiting", "Cannot overwrite file")
            .Add("BRE_LackOfSpace", "Destination disk is full.")
            .Add("BRE_CantReadWriteBkInfo", "Cannot read\write backup file.")
            .Add("BRE_FileIOError", "File access denied. Check for administrative privileges..")
            .Add("BRE_OpCanceled", "Operation canceled from user.")
            .Add("BRE_OEMInfExist", "Driver is already installed on this computer.")
            .Add("BRE_OEMInfAlreadyUsed", "Driver is already used by one or more devices and it is unremoveable.")
            .Add("BRE_MissingInfFile", "Cannot locate installation file.")
            .Add("BRE_CantCopyDriver", "Can't copy driver's files in restoration path.")
            .Add("DCmp_None", "None")
            .Add("DCmp_Partial", "Partial")
            .Add("DCmp_Full", "Full")
            .Add("LOG_Framework", "Microsoft Framework .NET version: ")
            .Add("LOG_Memory", "Available memory: {0} of {1} Kbytes.")
            .Add("LOG_Device", "\n{0}\n\tClass: {1}\n\tProvider:  {2}\n\tVersion: {3}\n\tRelease date: {4}\n\tInf file:  {5}\n\tTotal files:  {6}\n\n")
            .Add("LOG_DeviceOK", "Device processed successfully!")
            .Add("LOG_DeviceError", "An error occurred during device processing.")
            .Add("FRMMAIN_NOPCIDTB", "Database file pci.ids not found. Cannot retrieve pci devices info.")
            .Add("FRMMAIN_NODEVICES", "No devices found. Check for administrative privileges or change listing options.")
            .Add("FRMMAIN_COMPFULL", "Driver is compatible for Backup and Restore.")
            .Add("FRMMAIN_COMPPARTIAL", "Driver should be used on current Windows version only.")
            .Add("FRMMAIN_RCOMPPARTIAL", "Driver should not be compatible with this operating system.")
            .Add("FRMMAIN_COMPNONE", "Driver will not be restoreable.")
            .Add("FRMMAIN_RCOMPNONE", "Driver is not restoreable.")
            .Add("FRMMAIN_FILES", "All files found.")
            .Add("FRMMAIN_NOFILES", "Some files missing.")
            .Add("FRMMAIN_NORESTDEVICES", "Open a Backup file or change listing options.")
            .Add("FRMMAIN_DEVFOUND", "Listed devices: {0} of {1}")
            .Add("FRMMAIN_DIFFERENTSYSTEMS", "Drivers' original system is different from current one.They should be incompatible with this system.")
            .Add("FRMMAIN_TREENODEDEV", "{0}   ({1} Devices)")
            .Add("FRMMAIN_DRIVERREQUIRED", "Selected driver is required by an hardware device connected to computer but not installed.")
            .Add("FRMMAIN_DRIVERUPDATE", "Driver is already installed with an older version.Proceed with Restore to update driver.")
            .Add("FRMMAIN_DRIVERNOTREQUIRED", "Driver is required by any hardware device but it could be restored.")
            .Add("FRMBACK_DEVFOUND", "Selected devices: {0}   Size: {1} Mbytes")
            .Add("FRMBACK_BEGINBACKUP", "Backup started. {0} selected devices.")
            .Add("FRMBACK_ENDBACKUP", "Backup completed. Backuped devices: {0} of {1}.")
            .Add("FRMBACK_ENDBACKUPERR", "Backup canceled because an unknown error occurred.")
            .Add("FRMBACK_ENDDEVICE", "Device completed. Copied files: {0} of {1}")
            .Add("FRMBACK_FILECOPIED", "File copy: {0}")
            .Add("FRMBACK_LOGSAVED", "Log file saved!")
            .Add("FRMBACK_BACKUPTIME", "Elapsed time: {0} sec.")
            .Add("FRMRESTORE_BEGINRESTORE", "Restoration started. {0} selected devices.")
            .Add("FRMRESTORE_ENDRESTORE", "Restoration completed.")
            .Add("FRMRESTORE_PNPRESCAN", "Plug n Play scanning completed successfully.")
            .Add("FRMRESTORE_PNPRESCANFAILED", "Can't start scanning for new Plug n Play devices.")
            .Add("FRMRESTORE_ENDDEVICE", "Device completed.")
            .Add("FRMRESTORE_OEMINF", "OEM installation file: {0}")
            .Add("FRMREMOVE_USERFORCE", "Driver is already used by one or more devices. Remove it?")
            .Add("FRMREMOVE_REMOVED", "{0} drivers removed of {1}")
            .Add("FRMBUILDER_BADSETTINGS", "Some options or information are incorrect. Can't generate a valid command line.")
            .Add("FRMREMOVE_BETAVERSION", "Warning: Remove function isn't fully tested and it is a BETA version. Use it at you own risk.")
            .Add("CONSOLE_BADCOMMAND", "Command line syntax error. Check for all parameters.")
            .Add("CONSOLE_BADPARAMETER", "Syntax error in: {0}")
            .Add("CONSOLE_USAGE", "Read command line Help guide for more information")
            .Add("CONSOLE_DIRECTORY", "Specified directory is not available.")
            .Add("CONSOLE_FILE", "Can't open backup file.")
            .Add("CONSOLE_INFOCOLLECT", "Collecting information....")
            .Add("CONSOLE_WELCOME", "DriverBackup! 2.0 by Giuseppe Greco  2007-2016\n\nReleased with GPL license\n\nCommand line mode\n\n")
            .Add("CONSOLE_OPEND", "Completed.")
            .Add("CONSOLE_REGISTRYUPDATE", "System registry configuration completed successfully.")
            .Add("CONSOLE_MISSINGINFO", "Some options or information are missing.")
            .Add("ERROR_LANGUAGE", "Can't read language file.")
            .Add("BRE_ForceUpdate", "Driver for {0} is already installed. Force installation of backuped driver?")
            .Add("BRE_CantForceUpdating", "Current driver is more suitable for device than backup one.Update is aborted.")
            .Add("LOG_OperationStarted", "Process started: {0}")
            .Add("LOG_OperationEnded", "Process ended: {0}")
            .Add("FRMRESTORE_FORCEUPDATE", "Driver for device {0} is already installed on system. Try to force installation of backuped driver ?. WARNING:Backuped driver will be installed though its version is older.")
            .Add("FRMOFFLINE_GENERIC", "Can't initialize offline backup.")
            .Add("FRMOFFLINE_PRIVILEGE", "Program can't load offline system registry settings.Administrative privileges are required.")
            .Add("FRMOFFLINE_PATH", "Selected path don't contains a valid Windows installation.")
            .Add("CONSOLE_CANTCREATEDIR", "Can't create specified directory.")
            .Add("CONSOLE_RESTORECONFIRM", "Restore driver (y/n)?")
        End With
        Return lst

    End Function

    Private Sub DebugInitializeLanguage()
        langStrs.Clear()
        lang = "English"
        langStrs = GetDebugLangStrs()
    End Sub

    Private Sub LoadStdLanguage()
        Try
            Dim langFile As String = ""
            Dim langReader As LanguageFileReader = Nothing

            langFile = Path.Combine(My.Application.Info.DirectoryPath, "l10n/English.xml")
            'Carica il file
            langReader = LanguageFileReader.LoadLanguageFile(langFile)

            If langReader Is Nothing Then
                'File linguaggio non trovato carica le risorse in italiano
                DebugInitializeLanguage()
                MsgBox(GetLangStr("ERROR:LANGUAGE"), MsgBoxStyle.Exclamation)
            End If

            If LoadLanguageOnForms(langReader) = False Then
                DebugInitializeLanguage()
                MsgBox(GetLangStr("ERROR:LANGUAGE"), MsgBoxStyle.Exclamation)
            Else
                lang = "English"
            End If

        Catch ex As Exception
            DebugInitializeLanguage()
            MsgBox(GetLangStr("ERROR:LANGUAGE"), MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Function LoadLanguageOnForms(ByVal langReader As LanguageFileReader) As Boolean
        Try

            With langReader
                .LoadLanguageOnForm(frmBackup, LanguageManager.StdBindingFlags, New Type() {GetType(Control), GetType(ToolStripItem)}, "", "^Text$", False)
                .LoadLanguageOnForm(frmCmdBuilder, LanguageManager.StdBindingFlags, New Type() {GetType(Control), GetType(ToolStripItem)}, "", "^Text$", False)
                .LoadLanguageOnForm(frmMain, LanguageManager.StdBindingFlags, New Type() {GetType(Control), GetType(ToolStripItem)}, "", "^Text$", False)
                .LoadLanguageOnForm(frmOffline, LanguageManager.StdBindingFlags, New Type() {GetType(Control), GetType(ToolStripItem)}, "", "^Text$", False)
                .LoadLanguageOnForm(frmRestore, LanguageManager.StdBindingFlags, New Type() {GetType(Control), GetType(ToolStripItem)}, "", "^Text$", False)

                Dim objCont As ObjectContainer = .ReadContainer("CommonVariables")
                Dim tempArr As New Dictionary(Of String, String)
                If objCont IsNot Nothing Then
                    langStrs = objCont.StringArrays("langStrs")
                    If langStrs Is Nothing OrElse langStrs.Count <= 0 Then Return False
                Else
                    Return False
                End If

            End With
            Return True
        Catch ex As Exception
            Return False
        Finally
            frmMain.Text = "DriverBackup! " & My.Application.Info.Version.ToString
        End Try

    End Function


    Public Sub ChangeLanguage(ByVal file As String)
        Dim regKey As RegistryKey = Nothing

        Try

            regKey = Registry.LocalMachine.CreateSubKey(My.Settings.RegistryKey)
            regKey.SetValue("LanguageFile", file)
            regKey.Close()
            regKey = Nothing

            InitializeLanguage()
        Catch ex As Exception
        Finally
            If regKey IsNot Nothing Then regKey.Close()
        End Try


    End Sub

    Public Sub InitializeLanguage()
        'Inizializza le risorse linguaggio
        Dim langFile As String = ""
        Dim langReader As LanguageFileReader = Nothing
        Dim regKey As RegistryKey = Nothing
        Dim regValue As String = ""

        Try

            '#If DEBUG Then
            'Inizializzazione provvisoria della lingua
            '           DebugInitializeLanguage()
            '          Return
            '#End If

            'Carica la lingua inglese per impedire che file di linguaggio con
            'campi mancanti lascino inalterata ta text di alcuni controlli

            LoadStdLanguage()


            regKey = Registry.LocalMachine.CreateSubKey(My.Settings.RegistryKey)

            If regKey Is Nothing Then
                'Impossibile accedere al registro, carica la lingua di default "English.xml"
            Else
                'L'utente ha scelto precedentemente il file
                regValue = regKey.GetValue("LanguageFile", "")

                If [String].IsNullOrEmpty(regValue) Then
                    'Crea il valore di default
                    regKey.SetValue("LanguageFile", "l10n/English.xml")
                    Return
                End If

                langFile = Path.Combine(My.Application.Info.DirectoryPath, "l10n/" & regValue)
                'Carica i form
                langReader = LanguageFileReader.LoadLanguageFile(langFile)

                If langReader Is Nothing Then
                    Exit Sub
                End If

                lang = langReader.LanguageName
                If LoadLanguageOnForms(langReader) = False Then
                    DebugInitializeLanguage()
                    MsgBox(GetLangStr("ERROR_LANGUAGE"), MsgBoxStyle.Exclamation)
                End If
            End If

        Catch ex As Exception
            DebugInitializeLanguage()
            MsgBox(GetLangStr("ERROR_LANGUAGE"), MsgBoxStyle.Exclamation)
        Finally
            'Scrive la versione del programma su frmMain.Text
            frmMain.Text = "DriverBackup! " & My.Application.Info.Version.ToString
            If regKey IsNot Nothing Then regKey.Close()
        End Try
    End Sub
End Module
