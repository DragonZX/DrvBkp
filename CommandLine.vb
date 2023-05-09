Namespace CommandLineManager


    Public Class CommandLineBuilder
        Dim regxFilter As String = "(?<NAME>\w+)\s*\=\s*\x22(?<VALUE>.+?)\x22"
        'General
        Public Filter As DeviceFilter
        Public Mode As Integer = -1
        Public Logging As Boolean = True
        Public LogFileName As String
        'Information BACKUP
        Public BackupPath As String = ""
        Public BackupPathFormat As String = ""
        Public BackupDevFormat As String = ""
        Public BackupFileName As String = ""
        Public BackupDescription As String = ""
        Public BackupDateFormat As String = ""
        Public SystemDirectory As String = ""
        Public UseOfflineComputerName As Boolean = False
        Public OverwriteFile As Boolean = False
        Public GenerateAutorun As Boolean = False
        'Information RESTORE
        Public RestoreFileName As String = ""
        'Public RestorePath As String = ""
        Public UpdateOEMInf As Boolean = False
        Public EnabledPnPRescan As Boolean = False
        Public DisableInteraction As Boolean = False


        Public Sub New()
            Filter = New DeviceFilter(False, DeviceFilter.DeviceFilterProviders.Prov_All, -1, Nothing) 'Impostazioni di filtro standard
        End Sub

        Public Function Read(ByVal cmdArgs As String) As Boolean
            'Loads settings from cmd Args' 
            'recognizes the commands sent to the command line
            Dim parsed As Integer = 0
            Dim value As String

            Try
                For Each arg As Match In Regex.Matches(cmdArgs, Me.regxFilter)
                    value = arg.Groups("VALUE").Value   'Value of current property
                    If value Is Nothing Then value = ""

                    Select Case arg.Groups("NAME").Value
                        Case Is = "MODE"
                            'Imposta la modalit�
                            Select Case value
                                Case Is = "BACKUP"
                                    Me.Mode = 0
                                Case Is = "RESTORE"
                                    Me.Mode = 1
                                Case Else
                                    Me.Mode = -1
                            End Select
                        Case Is = "SYSPATH"
                            Me.SystemDirectory = value
                        Case Is = "BKDESC"
                            Me.BackupDescription = value
                        Case Is = "BKPATH"
                            Me.BackupPath = value
                        Case Is = "BKFILE"
                            Me.RestoreFileName = value
                            Me.BackupFileName = value
                        Case Is = "BKPATHFMT"
                            Me.BackupPathFormat = value
                        Case Is = "BKDEVFMT"
                            Me.BackupDevFormat = value
                        Case Is = "BKDATEFMT"
                            Me.BackupDateFormat = value
                        Case Is = "OPT" 'OPTIONAL
                            'Extracts from the options to enable string
                            'Producer
                            If value.Contains("A") Then
                                Me.Filter.ProviderType = DeviceFilter.DeviceFilterProviders.Prov_All
                            End If

                            If value.Contains("M") Then
                                Me.Filter.ProviderType = DeviceFilter.DeviceFilterProviders.Prov_OEM
                            End If

                            If value.Contains("H") Then
                                Me.Filter.ProviderType = DeviceFilter.DeviceFilterProviders.Prov_Others
                            End If

                            If value.Contains("D") Then
                                Me.Filter.ProviderType = -1
                            End If
                            '�ompany digital
                            If value.Contains("S") Then
                                Me.Filter.MustSigned = True
                            Else
                                Me.Filter.MustSigned = False
                            End If
                            'Portabilit�
                            If value.Contains("P") Then
                                Me.Filter.Portability = DevicePortability.DCmp_Full
                            Else
                                Me.Filter.Portability = -1
                            End If

                            If value.Contains("R") Then
                                Me.GenerateAutorun = True
                            Else
                                Me.GenerateAutorun = False
                            End If

                            If value.Contains("U") Then
                                Me.UpdateOEMInf = True
                            Else
                                Me.UpdateOEMInf = False
                            End If

                            If value.Contains("L") Then
                                Me.Logging = True
                            Else
                                Me.Logging = False
                            End If

                            If value.Contains("W") Then
                                Me.OverwriteFile = True
                            Else
                                Me.OverwriteFile = False
                            End If

                            If value.Contains("N") Then
                                Me.EnabledPnPRescan = True
                            Else
                                Me.EnabledPnPRescan = False
                            End If

                            If value.Contains("V") Then
                                Me.DisableInteraction = True
                            Else
                                Me.DisableInteraction = False
                            End If

                            If value.Contains("O") Then
                                Me.UseOfflineComputerName = True
                            Else
                                Me.UseOfflineComputerName = False
                            End If
                        Case Is = "LOG"
                            Me.LogFileName = value
                    End Select
                    parsed += 1
                Next

                If parsed = 0 Then Return False

                Return True

            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Build() As String
            'It builds on current settings for a valid command line
            Try
                Dim sBuild As New StringBuilder

                'Inserts the operating modes
                Select Case Me.Mode
                    Case Is = 0
                        sBuild.Append(" MODE=""BACKUP""")
                        'Path
                        sBuild.Append(" BKPATH=""" & Me.BackupPath & """")
                        'Description
                        sBuild.Append(" BKDESC=""" & Me.BackupDescription & """")
                        'File
                        sBuild.Append(" BKFILE=""" & Me.BackupFileName & """")
                        'Path format
                        sBuild.Append(" BKPATHFTM=""" & Me.BackupPathFormat & """")
                        'Device format
                        sBuild.Append(" BKDEVFMT=""" & Me.BackupDevFormat & """")
                        'Date format
                        sBuild.Append(" BKDATEFMT=""" & Me.BackupDateFormat & """")
                        'Offline modality
                        If Not [String].IsNullOrEmpty(Me.SystemDirectory) Then
                            sBuild.Append(" SYSPATH=""" & Me.SystemDirectory & """")
                        End If
                    Case Is = 1
                        sBuild.Append(" MODE=""RESTORE""")
                        'File
                        sBuild.Append(" BKFILE=""" & Me.RestoreFileName & """")
                        'PErcorso
                        'sBuild.Append(" RSPATH=""" & Me.RestorePath & """ ")
                End Select

                'Inserts options
                sBuild.Append(" OPT=""")
                Select Case Me.Filter.ProviderType
                    Case Is = DeviceFilter.DeviceFilterProviders.Prov_All
                        sBuild.Append("A")
                    Case Is = DeviceFilter.DeviceFilterProviders.Prov_OEM
                        sBuild.Append("M")
                    Case Is = DeviceFilter.DeviceFilterProviders.Prov_Others
                        sBuild.Append("H")
                    Case Is = -1
                        sBuild.Append("D")
                End Select

                If Me.Filter.MustSigned Then sBuild.Append("S")
                If Me.Filter.Portability = DevicePortability.DCmp_Full Then sBuild.Append("P")
                If Me.GenerateAutorun Then sBuild.Append("R")
                If Me.UpdateOEMInf Then sBuild.Append("U")
                If Me.Logging Then sBuild.Append("L")
                If Me.OverwriteFile Then sBuild.Append("W")
                If Me.EnabledPnPRescan Then sBuild.Append("N")
                If Me.DisableInteraction Then sBuild.Append("V")
                If Me.UseOfflineComputerName Then sBuild.Append("O")
                'End the string options
                sBuild.Append(""" ")

                'FILE log
                If Not [String].IsNullOrEmpty(Me.LogFileName) Then
                    sBuild.Append(" LOG=""" & Me.LogFileName & """")
                End If

                Return sBuild.ToString

            Catch ex As Exception
                Return [String].Empty
            End Try
        End Function

    End Class

    Public Class CommandLine
        'It handles command line
        Dim conHandle As Integer
        Dim args As String

        'Main items
        Dim WithEvents devBackup As DeviceBackup
        Dim WithEvents devRestore As DeviceRestore

        'Settings
        Dim regxFilter As String = "(?<NAME>\w+)\s*\=\s*\x22(?<VALUE>.+?)\x22"
        Dim cReader As CommandLineBuilder
        Dim currList As DeviceCollection
        Dim totalDevices As Integer
        Dim logFile As New TextFormatters.TXTFormatter
        Dim verboseMode As Boolean

        Public Sub New(ByVal commandArgs As String)
            Me.cReader = New CommandLineBuilder
            Me.args = commandArgs
        End Sub


        Private Function Validate() As Boolean
            'Correct the command line, or possibly triggers an error
            With Me.cReader
                Select Case .Mode
                    Case Is = 0
                        'Backup mode
                        If [String].IsNullOrEmpty(.BackupPath) Then
                            Console.WriteLine(GetLangStr("CONSOLE_DIRECTORY"))
                            Return False
                        End If

                        'Create the home directory if it does Not exist
                        If Not Directory.Exists(.BackupPath) Then
                            Try
                                Directory.CreateDirectory(.BackupPath)
                            Catch ex As Exception
                                Console.WriteLine(GetLangStr("CONSOLE_CANTCREATEDIR"))
                                Return False
                            End Try
                        End If
                        'Correct any optional parameters
                        If [String].IsNullOrEmpty(.BackupPathFormat) Then .BackupPathFormat = My.Settings.StdBackupPathFormat
                        If [String].IsNullOrEmpty(.BackupDevFormat) Then .BackupDevFormat = My.Settings.StdDevicePathFormat
                        If [String].IsNullOrEmpty(.BackupFileName) Then .BackupFileName = My.Settings.StdBackupInfoFile
                        If [String].IsNullOrEmpty(.BackupDateFormat) Then .BackupDateFormat = My.Settings.DateTimePattern
                        'Set a default log file if required
                        If .Logging = True And [String].IsNullOrEmpty(.LogFileName) Then
                            .LogFileName = Path.Combine(.BackupPath, My.Settings.StdLogFileName)
                        End If

                    Case Is = 1
                        'Restore Mode
                        'Failure to include the BKF files
                        If [String].IsNullOrEmpty(.RestoreFileName) Then
                            Console.WriteLine(GetLangStr("CONSOLE:FILE"))
                            Return False
                        End If

                        'Set a default log file if required
                        If .Logging = True And [String].IsNullOrEmpty(.LogFileName) Then
                            .LogFileName = Path.Combine(My.Application.Info.DirectoryPath, My.Settings.StdLogFileName)
                        End If

                    Case Else
                        'Error inserting the modalities
                        Console.WriteLine(GetLangStr("CONSOLE:BADCOMMAND"))
                        Return False
                End Select
            End With
            Return True

        End Function

        Public Function Execute() As Boolean
            Dim offLineObj As DeviceBackupOffline = Nothing

            Try
                Dim tempList As DeviceCollection

                If cReader.Read(Me.args) = False Then
                    Return False
                End If

                'Create your console
                Utils.AllocConsole()

                'Show your greeting
                Console.WriteLine("DriverBackup! " & My.Application.Info.Version.ToString & " by Giuseppe Greco 2009-2011")
                Console.WriteLine("Free driver management software. GPL License")

                Console.WriteLine()

                If Validate() = False Then
                    Console.WriteLine(GetLangStr("CONSOLE:MISSINGINFO"))
                    Return True
                End If

                With cReader
                    Select Case .Mode
                        Case Is = 0
                            'Set the configuration for backup
                            Console.WriteLine(GetLangStr("CONSOLE:INFOCOLLECT"))

                            logFile = New TextFormatters.TXTFormatter

                            If Not [String].IsNullOrEmpty(.SystemDirectory) Then
                                'Configure the offline mode
                                offLineObj = DeviceBackupOffline.Create(.SystemDirectory)
                                If offLineObj Is Nothing Then
                                    logFile.AddMsgError(GetLangStr("FRMOFFLINE_GENERIC"), False)
                                    Console.WriteLine(GetLangStr("FRMOFFLINE_GENERIC"))
                                    Return False
                                End If

                                If offLineObj.HasPathError Then
                                    logFile.AddMsgError(GetLangStr("FRMOFFLINE_PATH"), False)
                                    Console.WriteLine(GetLangStr("FRMOFFLINE_PATH"))
                                    Return False
                                End If

                                If offLineObj.HasPrivilegeError Then
                                    logFile.AddMsgError(GetLangStr("FRMOFFLINE_PRIVILEGE"), False)
                                    Console.WriteLine(GetLangStr("FRMOFFLINE_PRIVILEGE"))
                                    Return False
                                End If
                               
                                offLineObj.UseOfflinePCName = .UseOfflineComputerName
                            End If


                            tempList = DeviceCollection.Create(Nothing)

                            If tempList Is Nothing Then Throw New ArgumentNullException 'Unexpected error

                            If tempList.Count <= 0 Then  'Could not access log
                                Console.WriteLine(GetLangStr("ERROR:RegistryAccess"))
                                Return True
                            End If

                            If .Filter.ProviderType = -1 Then .Filter.ProviderType = DeviceFilter.DeviceFilterProviders.Prov_Others
                            tempList.SetDevicesProperties(.Filter, "Selected", GetType(Boolean), True, False)
                            currList = DeviceCollection.Create(tempList, "Selected", True)

                            If currList Is Nothing Then Throw New ArgumentNullException 'Unexpected error

                            If currList.Count <= 0 Then 'No Device selected
                                Console.WriteLine(GetLangStr(GetLangStr("FRMMAIN:NODEVICES")))
                                Return True
                            End If
                            totalDevices = currList.Count
                            'Reset the log file

                            devBackup = New DeviceBackup(currList, .BackupPath, My.Settings.DateTimePattern)
                            devBackup.FileManager = New BRStdFileManager(.BackupPath)
                            devBackup.BackupPathFormat = .BackupPathFormat
                            devBackup.BackupDateFormat = .BackupDateFormat
                            devBackup.DevicePathFormat = .BackupDevFormat
                            devBackup.BackupInfoFile = .BackupFileName
                            devBackup.CanOverwrite = .OverwriteFile
                            devBackup.Description = .BackupDescription
                            Console.WriteLine("Ok.")
                            'Proceed with the actual backup
                            devBackup.Backup()
                            'Generate if required autorun
                            If .GenerateAutorun Then
                                Utils.GenerateAutorun(.BackupPath, [String].Format(My.Settings.StdRestoreCmdLine, devBackup.BackupInfoFile, My.Settings.StdRestorePath), Path.GetDirectoryName(Application.ExecutablePath), CommonVariables.GetLanguageFiles)
                            End If

                        Case Is = 1
                            'Prepare the Restore Configuration
                            Console.WriteLine(GetLangStr("CONSOLE:INFOCOLLECT"))
                            devRestore = DeviceRestore.Create(.RestoreFileName)

                            If devRestore Is Nothing Then
                                Console.WriteLine(GetLangStr("CONSOLE:FILE"))
                                Return False
                            End If

                            logFile = New TextFormatters.TXTFormatter

                            If .Filter.ProviderType <> -1 Then
                                'Apply a filter only if the user chooses a specific category
                                totalDevices = devRestore.DeviceList.SetDevicesProperties(.Filter, "Selected", GetType(Boolean), True, False)
                            End If
                            devRestore.UpdateDeviceInfo = .UpdateOEMInf
                            Console.WriteLine("Ok.")
                            'Restores the selected devices
                            devRestore.RestoreDevices()
                    End Select
                End With

                Console.WriteLine(GetLangStr("CONSOLE:OPEND"))
                If Not cReader.DisableInteraction Then
                    Console.ReadLine()
                End If

                Return True
            Catch ex As Exception
                Console.WriteLine(GetLangStr("ERROR:BERR"))
                Return True
            Finally
                'Releases the resources used
                If offLineObj IsNot Nothing Then offLineObj.Dispose()
                If logFile IsNot Nothing And Not [String].IsNullOrEmpty(cReader.LogFileName) Then
                    logFile.Write(cReader.LogFileName)
                    logFile.Dispose()
                End If
            End Try
        End Function


        Private Sub devBackup_BackupBeginDevice(ByVal sender As Object, ByVal e As DeviceBackupRestore.DeviceEventArgs) Handles devBackup.BackupBeginDevice
            logFile.AddDevice(e.Source)
            'Notification on the console
            Console.WriteLine(e.Source.Description)
        End Sub

        Private Sub devBackup_BackupDeviceError(ByVal sender As Object, ByVal e As DeviceBackupRestore.ExceptionEventArgs) Handles devBackup.BackupDeviceError
            Dim errNotify As Boolean = False

            If e.Code = BackupRestoreErrorCodes.BRE_FileOverwiting Then
                'Adds the name of the file that caused the error
                logFile.AddMsgError(ControlChars.Tab & GetLangStr(e.Code) & ": " & e.Data("Filename"), True)
                errNotify = True
            End If

            If e.Code = BackupRestoreErrorCodes.BRE_FileIOError Then
                'Adds more information
                logFile.AddMsgError(ControlChars.Tab & e.Data("Msg"), True)
                errNotify = True
            End If

            If Not errNotify Then logFile.AddError(e.Code, True)
        End Sub

        Private Sub devBackup_BackupEndDevice(ByVal sender As Object, ByVal e As DeviceBackupRestore.DeviceEventArgs) Handles devBackup.BackupEndDevice
            logFile.EndDevice(e.HasErrors)
            'Notification on the console
            If e.HasErrors Then
                Console.WriteLine(GetLangStr("LOG_DeviceError"))
            Else
                Console.WriteLine(GetLangStr("LOG_DeviceOK"))
            End If
        End Sub

        Private Sub devBackup_BackupEnded(ByVal sender As Object, ByVal e As DeviceBackupRestore.OperationEventArgs) Handles devBackup.BackupEnded
            logFile.EndOperation([String].Format(GetLangStr("FRMBACK:ENDBACKUP"), e.TotalDevices, totalDevices))
            'Notification on the console
            Console.WriteLine([String].Format(GetLangStr("FRMBACK:ENDBACKUP"), e.TotalDevices, totalDevices))
        End Sub

        Private Sub devBackup_BackupError(ByVal sender As Object, ByVal e As DeviceBackupRestore.ExceptionEventArgs) Handles devBackup.BackupError
            logFile.AddError(e.Code, False)
        End Sub

        Private Sub devBackup_BackupFile(ByVal sender As Object, ByVal e As DeviceBackupRestore.FileEventArgs) Handles devBackup.BackupFile
            logFile.AddFile(e.FileName)
        End Sub

        Private Sub devBackup_BackupStarted(ByVal sender As Object, ByVal e As DeviceBackupRestore.OperationEventArgs) Handles devBackup.BackupStarted
            logFile.BeginOperation([String].Format(GetLangStr("FRMBACK:BEGINBACKUP"), e.TotalDevices))
            'Notification on the console
            Console.WriteLine([String].Format(GetLangStr("FRMBACK:BEGINBACKUP"), e.TotalDevices))
        End Sub


        Private Sub devRestore_RestoreBegin(ByVal sender As Object, ByVal e As DeviceBackupRestore.OperationEventArgs) Handles devRestore.RestoreBegin
            logFile.BeginOperation([String].Format(GetLangStr("FRMRESTORE:BEGINRESTORE"), e.TotalDevices))
            Console.WriteLine([String].Format(GetLangStr("FRMRESTORE:BEGINRESTORE"), e.TotalDevices))

        End Sub

        Private Sub devRestore_RestoreBeginDevice(ByVal sender As Object, ByVal e As DeviceBackupRestore.DeviceEventArgs) Handles devRestore.RestoreBeginDevice

            logFile.AddDevice(e.Source)
            Console.WriteLine(e.Source.Description)

            If cReader.DisableInteraction Then
                e.Cancel = False
            Else
                Console.Write(ControlChars.Tab & GetLangStr("CONSOLE_RESTORECONFIRM"))
                If Console.ReadKey.Key = ConsoleKey.Y Then
                    e.Cancel = False
                Else
                    e.Cancel = True
                End If
                Console.WriteLine()
            End If
        End Sub

        Private Sub devRestore_RestoreDeviceError(ByVal sender As Object, ByVal e As DeviceBackupRestore.ExceptionEventArgs) Handles devRestore.RestoreDeviceError
            If e.Code = BackupRestoreErrorCodes.BRE_ForceUpdate And Not cReader.DisableInteraction Then
                'Manages forcing
                Dim msg As String = ControlChars.Tab & [String].Format(GetLangStr(e.Code.ToString), DirectCast(e.Data("Device"), Device).Description) & " (y/n)"
                Console.Write(msg)
                If Console.ReadKey.Key = ConsoleKey.Y Then
                    e.Cancel = False
                Else
                    e.Cancel = True
                End If
                Console.WriteLine()
                Return
            End If

            If e.Code = BackupRestoreErrorCodes.BRE_Generic Then
                'Adds more information
                logFile.AddMsgError(ControlChars.Tab & e.Data("Msg"), True)
                Return
            End If

            Console.WriteLine(ControlChars.Tab & GetLangStr(e.Code.ToString))

            logFile.AddError(e.Code, True)
        End Sub

        Private Sub devRestore_RestoreEnd(ByVal sender As Object, ByVal e As DeviceBackupRestore.OperationEventArgs) Handles devRestore.RestoreEnd
            logFile.EndOperation([String].Format(GetLangStr("FRMRESTORE:ENDRESTORE"), e.TotalDevices, totalDevices))
            Console.WriteLine([String].Format(GetLangStr("FRMRESTORE:ENDRESTORE"), e.TotalDevices, totalDevices))

            If Me.cReader.EnabledPnPRescan Then
                'Refresh the PNP configuration
                If DeviceRestore.PnPConfigUpdate = True Then
                    'Configuration updated
                    Console.WriteLine(GetLangStr("FRMRESTORE:PNPRESCAN"))
                Else
                    'Unable to update configuration
                    Console.WriteLine(GetLangStr("FRMRESTORE:PNPRESCANFAILED"))
                End If
            End If
        End Sub

        Private Sub devRestore_RestoreEndDevice(ByVal sender As Object, ByVal e As DeviceBackupRestore.DeviceEventArgs) Handles devRestore.RestoreEndDevice
            If e.Data.ContainsKey("OEMINF") AndAlso Not [String].IsNullOrEmpty(e.Data.Item("OEMINF")) Then
                logFile.AddMsg([String].Format(ControlChars.Tab & GetLangStr("FRMRESTORE:OEMINF"), e.Data("OEMINF")), True)
            End If

            logFile.EndDevice(e.HasErrors)
            'Notification on the console
            If e.HasErrors Then
                Console.WriteLine(ControlChars.Tab & GetLangStr("LOG_DeviceError"))
            Else
                Console.WriteLine(ControlChars.Tab & GetLangStr("LOG_DeviceOK"))
            End If
        End Sub

        Private Sub devRestore_RestoreError(ByVal sender As Object, ByVal e As DeviceBackupRestore.ExceptionEventArgs) Handles devRestore.RestoreError
            logFile.AddMsgError(e.Data.Item("Msg"), False)
        End Sub
    End Class

End Namespace