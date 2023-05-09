﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.5.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Error in function {0}. {1}")>  _
        Public ReadOnly Property DebugStringFormat() As String
            Get
                Return CType(Me("DebugStringFormat"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("SYSTEM\CurrentControlSet\Control\Class")>  _
        Public ReadOnly Property MainRegKey() As String
            Get
                Return CType(Me("MainRegKey"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("(?:@|,)\s*(?<arg>.[^,]*)\s*")>  _
        Public ReadOnly Property RGXClassDescSplitter() As String
            Get
                Return CType(Me("RGXClassDescSplitter"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("520")>  _
        Public ReadOnly Property MaxStrBufferSize() As Integer
            Get
                Return CType(Me("MaxStrBufferSize"),Integer)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("mm-dd-yyyy")>  _
        Public ReadOnly Property DateTimePattern() As String
            Get
                Return CType(Me("DateTimePattern"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("%windir%\inf\,%windir%\system32\,%windir%\system32\spool,%windir%\system32\CatRoo"& _ 
            "t\,%windir%\system\,%windir%\fonts\,%windir%\Help\")>  _
        Public ReadOnly Property FindingPaths() As String
            Get
                Return CType(Me("FindingPaths"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("CatalogFile,CatalogFile.nt,CatalogFile.ntx86,CatalogFile.ntia64,CatalogFile.ntamd"& _ 
            "64")>  _
        Public ReadOnly Property CatalogSections() As String
            Get
                Return CType(Me("CatalogSections"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Include,CopyINF")>  _
        Public ReadOnly Property CopyFilesSections() As String
            Get
                Return CType(Me("CopyFilesSections"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Drivers %COMPUTERNAME% %NOW%")>  _
        Public ReadOnly Property StdBackupPathFormat() As String
            Get
                Return CType(Me("StdBackupPathFormat"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("[\\\/\<\>\:\?\x22\*\|]+")>  _
        Public ReadOnly Property PathFilter() As String
            Get
                Return CType(Me("PathFilter"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("en-US.xml")>  _
        Public ReadOnly Property DefaultLanguage() As String
            Get
                Return CType(Me("DefaultLanguage"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Backup %NOW%  %COMPUTERNAME%.bki")>  _
        Public ReadOnly Property StdBackupInfoFile() As String
            Get
                Return CType(Me("StdBackupInfoFile"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("""%windir%\system32\setupapi.dll""")>  _
        Public ReadOnly Property StdResourceFile() As String
            Get
                Return CType(Me("StdResourceFile"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("%DEVNAME%")>  _
        Public ReadOnly Property StdDevicePathFormat() As String
            Get
                Return CType(Me("StdDevicePathFormat"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute(".bki")>  _
        Public ReadOnly Property StdBackupInfoExt() As String
            Get
                Return CType(Me("StdBackupInfoExt"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("260")>  _
        Public ReadOnly Property MaxPath() As Integer
            Get
                Return CType(Me("MaxPath"),Integer)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("DrvBackLogFile.txt")>  _
        Public ReadOnly Property StdLogFileName() As String
            Get
                Return CType(Me("StdLogFileName"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("%windir%\DriverBackupRestore")>  _
        Public ReadOnly Property StdRestorePath() As String
            Get
                Return CType(Me("StdRestorePath"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("MODE=""RESTORE"" BKFILE=""{0}"" OPT=""AL""")>  _
        Public ReadOnly Property StdRestoreCmdLine() As String
            Get
                Return CType(Me("StdRestoreCmdLine"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("DriverBackup! 2.application;DriverBackup! 2.exe.config;DriverBackup! 2.exe.manife"& _ 
            "st;DrvBK.exe;DriverBackup! 2.xml")>  _
        Public ReadOnly Property ExecutableFiles() As String
            Get
                Return CType(Me("ExecutableFiles"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute(" MODE=""BACKUP""  BKPATH=""R:\"" BKDESC=""This is a backup"" BKFILE=""Backup %DATE% su %"& _ 
            "COMPUTERNAME%.bki"" BKPATHFTM=""Drivers %COMPUTERNAME%_%DATE%"" BKDEVFMT=""Device %D"& _ 
            "EVNAME%"" OPT=""HL""")>  _
        Public ReadOnly Property TempCmd() As String
            Get
                Return CType(Me("TempCmd"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("pci.ids")>  _
        Public ReadOnly Property PCIDatabase() As String
            Get
                Return CType(Me("PCIDatabase"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("system32\config\SYSTEM")>  _
        Public ReadOnly Property OfflineRegistryPath() As String
            Get
                Return CType(Me("OfflineRegistryPath"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("DRVBACKTEMP")>  _
        Public ReadOnly Property OfflineKeyName() As String
            Get
                Return CType(Me("OfflineKeyName"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Software\DriverBackup!")>  _
        Public ReadOnly Property RegistryKey() As String
            Get
                Return CType(Me("RegistryKey"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Software\DriverBackup!\RestoredDevs")>  _
        Public ReadOnly Property RegistryRestoreKey() As String
            Get
                Return CType(Me("RegistryRestoreKey"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property CheckDonate() As Boolean
            Get
                Return CType(Me("CheckDonate"),Boolean)
            End Get
            Set
                Me("CheckDonate") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0.8")>  _
        Public ReadOnly Property ScaleFactor() As Single
            Get
                Return CType(Me("ScaleFactor"),Single)
            End Get
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.DriverBackup__2.My.MySettings
            Get
                Return Global.DriverBackup__2.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
