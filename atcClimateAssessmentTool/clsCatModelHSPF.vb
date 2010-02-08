Imports atcData
Imports atcUtility
Imports MapWinUtility

Public Class clsCatModelHSPF
    Implements clsCatModel

    Public Event BaseScenarioSet(ByVal aBaseScenario As String) Implements clsCatModel.BaseScenarioSet

    Private pBaseScenario As String = ""

    Public Property BaseScenario() As String Implements clsCatModel.BaseScenario
        Get
            Return pBaseScenario
        End Get
        Set(ByVal newValue As String)
            OpenBaseScenario(newValue)
        End Set
    End Property

    ''' <summary>
    ''' Open data files referred to in this UCI file
    ''' </summary>
    ''' <param name="aFilename">Full path of UCI file</param>
    ''' <remarks></remarks>
    Friend Sub OpenBaseScenario(Optional ByVal aFilename As String = "")
        If Not aFilename Is Nothing And Not IO.File.Exists(aFilename) Then
            If IO.File.Exists(aFilename & ".uci") Then aFilename &= ".uci"
        End If

        If aFilename Is Nothing OrElse Not IO.File.Exists(aFilename) Then
            Dim cdlg As New Windows.Forms.OpenFileDialog
            cdlg.Title = "Open UCI file containing base scenario"
            cdlg.Filter = "UCI files|*.uci|All Files|*.*"
            If cdlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                aFilename = cdlg.FileName
            End If
        End If

        If IO.File.Exists(aFilename) Then
            Dim lUciFolder As String = PathNameOnly(aFilename)
            ChDriveDir(lUciFolder)
            pBaseScenario = aFilename
            RaiseEvent BaseScenarioSet(aFilename)
            Dim lFullText As String = WholeFileString(aFilename)
            For Each lWDMfilename As String In UCIFilesBlockFilenames(lFullText, "WDM")
                lWDMfilename = AbsolutePath(Trim(lWDMfilename), lUciFolder)
                clsCat.OpenDataSource(lWDMfilename)
            Next
            For Each lBinOutFilename As String In UCIFilesBlockFilenames(lFullText, "BINO")
                lBinOutFilename = AbsolutePath(Trim(lBinOutFilename), lUciFolder)
                clsCat.OpenDataSource(lBinOutFilename)
            Next
        End If
    End Sub

    Private Sub CreateModifiedUCI(ByVal aNewScenarioName As String, ByVal aNewUciFilename As String)
        Dim lUciContents As String = WholeFileString(BaseScenario)
        Dim lStartFilesPos As Integer = lUciContents.IndexOf(vbLf & "FILES") + 1
        Dim lEndFilesPos As Integer = lUciContents.IndexOf(vbLf & "END FILES", lStartFilesPos) + 1
        Dim lOriginalFilesBlock As String = lUciContents.Substring(lStartFilesPos, lEndFilesPos - lStartFilesPos)
        Dim lNewFilesBlock As String = ""
        Dim lSaveLineEnd As String = ""
        Dim lCurrentLine As String
        'Dim lPathname As String
        Dim lFilename As String

        For Each lCurrentLine In lOriginalFilesBlock.Split(vbLf)
            Select Case lCurrentLine.Length
                Case 0 'Ignore empty lines (last will be empty)
                Case Is < 16
                    lNewFilesBlock &= lCurrentLine & vbLf
                Case Else
                    lSaveLineEnd = Right(lCurrentLine, 1)
                    If lSaveLineEnd = vbCr Then
                        lCurrentLine = lCurrentLine.Substring(0, lCurrentLine.Length - 1)
                    Else
                        lSaveLineEnd = ""
                    End If
                    lFilename = lCurrentLine.Substring(16)
                    If lFilename.StartsWith("<") Then 'Not a file name
                        lNewFilesBlock &= lCurrentLine & lSaveLineEnd & vbLf
                    Else
                        'Commented out code preserves path of original file, we are putting Modified files in same folder as modified UCI
                        'lPathname = PathNameOnly(lFilename)
                        'If lPathname.Length > 0 Then lPathname &= g_PathChar
                        'lFilename = lPathname & aNewScenarioName & "." & FilenameNoPath(lFilename)
                        lFilename = aNewScenarioName & "." & FilenameNoPath(lFilename)
                        lNewFilesBlock &= lCurrentLine.Substring(0, 16) & lFilename & lSaveLineEnd & vbLf
                    End If
            End Select
        Next

        SaveFileString(aNewUciFilename, lUciContents.Substring(0, lStartFilesPos) & lNewFilesBlock & lUciContents.Substring(lEndFilesPos))
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="aNewScenarioName"></param>
    ''' <param name="aModifiedData"></param>
    ''' <param name="aPreparedInput"></param>
    ''' <param name="aRunModel"></param>
    ''' <param name="aShowProgress"></param>
    ''' <param name="aKeepRunning"></param>
    ''' <returns>atcCollection of atcDataSource</returns>
    ''' <remarks></remarks>
    Public Function ScenarioRun(ByVal aNewScenarioName As String, _
                                ByVal aModifiedData As atcTimeseriesGroup, _
                                ByVal aPreparedInput As String, _
                                ByVal aRunModel As Boolean, _
                                ByVal aShowProgress As Boolean, _
                                ByVal aKeepRunning As Boolean) As atcCollection Implements clsCatModel.ScenarioRun
        'Copy base UCI and change scenario name within it
        'Copy WDM
        'Change data to be modified in new WDM
        'Change scenario attribute in new WDM
        'Run WinHSPFlt with the new UCI

        Dim lModified As New atcCollection
        Dim lCurrentTimeseries As atcTimeseries

        If aModifiedData Is Nothing Then
            aModifiedData = New atcTimeseriesGroup
        End If

        If IO.File.Exists(pBaseScenario) Then
            Dim lNewBaseFilename As String = AbsolutePath(pBaseScenario, CurDir)
            Dim lNewFolder As String = PathNameOnly(lNewBaseFilename) & g_PathChar
            lNewBaseFilename = lNewFolder & aNewScenarioName & "."
            Dim lNewUCIfilename As String = ""

            Dim lWDMFilenames As ArrayList = UCIFilesBlockFilenames(WholeFileString(pBaseScenario), "WDM")
            Select aNewScenarioName.ToLower
                Case "base"
                    lNewUCIfilename = pBaseScenario
                    For Each lWDMfilename As String In lWDMFilenames
                        lWDMfilename = AbsolutePath(lWDMfilename, CurDir)
                        lModified.Add(IO.Path.GetFileName(lWDMfilename).ToLower.Trim, lWDMfilename.Trim)
                    Next
                Case "modifyoriginal"
                    lNewUCIfilename = pBaseScenario
                    For Each lWDMfilename As String In lWDMFilenames
                        lWDMfilename = AbsolutePath(lWDMfilename, CurDir)
                        lModified.Add(IO.Path.GetFileName(lWDMfilename).ToLower.Trim, lWDMfilename.Trim)
                    Next
                    For Each lWDMfilename As String In lWDMFilenames
                        lWDMfilename = AbsolutePath(lWDMfilename, CurDir).Trim()
                        Dim lWDMResults As atcWDM.atcDataSourceWDM = atcData.atcDataManager.DataSources(0) 'TODO: is it a good assumption that (0) is the results?
                        For Each lCurrentTimeseries In aModifiedData
                            If Not lCurrentTimeseries Is Nothing _
                               AndAlso lCurrentTimeseries.Attributes.GetValue("History 1").ToString.ToLower.Equals("read from " & lWDMfilename.ToLower) Then
                                lWDMResults.AddDataset(lCurrentTimeseries)
                            End If
                        Next
                        lWDMResults.DataSets.Clear()
                    Next
                Case Else
                    lNewUCIfilename = lNewBaseFilename & FilenameNoPath(pBaseScenario)
                    'Copy base UCI, changing base to new scenario name within it
                    CreateModifiedUCI(aNewScenarioName, lNewUCIfilename)

                    For Each lWDMfilename As String In lWDMFilenames
                        lWDMfilename = AbsolutePath(lWDMfilename, CurDir).Trim()
                        If FilenameNoPath(lWDMfilename).ToLower = FilenameNoPath(aPreparedInput).ToLower Then
                            lWDMfilename = aPreparedInput
                        End If
                        'Copy each base WDM to new WDM only if simulation is to be rerun
                        Dim lNewWDMfilename As String = lNewFolder & aNewScenarioName & "." & IO.Path.GetFileName(lWDMfilename)
                        If aRunModel Then
                            FileCopy(lWDMfilename, lNewWDMfilename)
                        End If
                        Dim lWDMResults As New atcWDM.atcDataSourceWDM
                        If Not lWDMResults.Open(lNewWDMfilename) Then
                            Logger.Msg("Could not open new scenario WDM file '" & lNewWDMfilename & "'", MsgBoxStyle.Critical, "Could not run model")
                            Return Nothing
                        End If

                        'Key is base file name, value is modified file name
                        lModified.Add(IO.Path.GetFileName(lWDMfilename).ToLower.Trim, lNewWDMfilename.Trim)

                        'Update scenario name in new WDM
                        For Each lCurrentTimeseries In aModifiedData
                            If Not lCurrentTimeseries Is Nothing _
                               AndAlso lCurrentTimeseries.Attributes.GetValue("History 1").ToString.ToLower.Equals("read from " & lWDMfilename.ToLower) Then
                                lCurrentTimeseries.Attributes.SetValue("scenario", aNewScenarioName)
                                lWDMResults.AddDataset(lCurrentTimeseries)
                            End If
                        Next
                        For Each lCurrentTimeseries In lWDMResults.DataSets
                            Dim lScenario As atcDefinedValue = lCurrentTimeseries.Attributes.GetDefinedValue("scenario")
                            If lScenario.Value.ToLower = "base" Then
                                lWDMResults.WriteAttribute(lCurrentTimeseries, lScenario, aNewScenarioName)
                            End If
                            If Not aModifiedData.Contains(lCurrentTimeseries) Then
                                lCurrentTimeseries.ValuesNeedToBeRead = True
                                lCurrentTimeseries.Attributes.DiscardCalculated()
                            End If
                        Next
                        lWDMResults.DataSets.Clear()
                    Next
            End Select

            Dim lRunExitCode As Integer = 0
            If aRunModel Then
                'Run scenario
                Dim lWinHspfLtExeName As String = FindFile("Please locate WinHspfLt.exe", g_PathChar & "BASINS\models\HSPF\bin\WinHspfLt.exe")

                Dim lPipeHandles As String = " -1 -1 "
                If aShowProgress Then lPipeHandles = " "

                'Shell(lWinHspfLtExeName & lPipeHandles & lNewBaseFilename & "uci", AppWinStyle.NormalFocus, True)

                ''don't let winhspflt bring up message boxes
                'Dim lBaseFolder As String = PathNameOnly(AbsolutePath(BaseScenario, CurDir))
                'SaveFileString(lBaseFolder & g_PathChar & "WinHSPFLtError.Log", "WinHSPFMessagesFollow:" & vbCrLf)

                AppendFileString(lNewFolder & "WinHSPFLtError.Log", "Start log for " & lNewBaseFilename & vbCrLf)
                Dim lArgs As String = lPipeHandles & lNewUCIfilename
                Logger.Dbg("Start " & lWinHspfLtExeName & " with Arguments '" & lArgs & "'")
                Dim lHspfProcess As Diagnostics.Process
                lHspfProcess = Diagnostics.Process.Start(lWinHspfLtExeName, lArgs)
                While Not lHspfProcess.HasExited
                    If Not g_Running And Not aKeepRunning Then
                        lHspfProcess.Kill()
                    End If
                    Windows.Forms.Application.DoEvents()
                    Threading.Thread.Sleep(50)
                End While
                lRunExitCode = lHspfProcess.ExitCode
                Logger.Dbg("Model exit code " & lRunExitCode)
                If lRunExitCode <> 0 Then
                    Logger.Dbg("****************** Problem *********************")
                End If
            Else
                Logger.Dbg("Skipping running model")
            End If

            If g_Running Then
                If lRunExitCode <> 0 Then 'hspf run failed, don't send any timeseries back to cat
                    lModified.Clear()
                Else
                    For Each lBinOutFilename As String In UCIFilesBlockFilenames(WholeFileString(pBaseScenario), "BINO")
                        lBinOutFilename = AbsolutePath(lBinOutFilename, CurDir)
                        Dim lNewFilename As String
                        If aNewScenarioName.ToLower = "base" Then
                            lNewFilename = lBinOutFilename
                        Else
                            lNewFilename = PathNameOnly(lBinOutFilename) & g_PathChar & aNewScenarioName & "." & IO.Path.GetFileName(lBinOutFilename)
                        End If
                        If IO.File.Exists(lNewFilename) Then
                            'Dim lHBNResults As New atcHspfBinOut.atcTimeseriesFileHspfBinOut
                            'If lHBNResults.Open(lNewFilename) Then
                            lModified.Add(IO.Path.GetFileName(lBinOutFilename).ToLower.Trim, lNewFilename.Trim)
                            'Else
                            '    Logger.Dbg("Could not open HBN file '" & lNewFilename & "'")
                            'End If
                        Else
                            Logger.Dbg("Could not find HBN file '" & lNewFilename & "'")
                        End If
                    Next
                End If
            End If
        Else
            Logger.Msg("Could not find base UCI file '" & pBaseScenario & "'" & vbCrLf & "Could not run model", "Scenario Run")
        End If
        Return lModified
    End Function

    ''' <summary>
    ''' Given the filename of a UCI file and a file type, return the file names, if any, of that type in the UCI
    ''' </summary>
    ''' <param name="aUCIfileContents">Full text of UCI file</param>
    ''' <param name="aFileType">WDM or MESSU or BINO</param>
    ''' <returns>ArrayList of file name(s) of the requested type appearing in the FILES block</returns>
    Private Shared Function UCIFilesBlockFilenames(ByVal aUCIfileContents As String, ByVal aFileType As String) As ArrayList
        UCIFilesBlockFilenames = New ArrayList
        Dim lFilesBlock As String = StrFindBlock(aUCIfileContents, vbLf & "FILES", vbLf & "END FILES")
        Dim lNextPosition As Integer = lFilesBlock.IndexOf(vbLf & aFileType)
        Dim lEOL As Integer
        Dim lEOLchars() As Char = {ChrW(10), ChrW(13)}
        While lNextPosition >= 0
            lEOL = lFilesBlock.IndexOfAny(lEOLchars, lNextPosition + 1)
            UCIFilesBlockFilenames.Add(lFilesBlock.Substring(lNextPosition + 17, lEOL - lNextPosition - 17))
            lNextPosition = lFilesBlock.IndexOf(vbLf & aFileType, lEOL)
        End While
    End Function

    Public Property XML() As String Implements clsCatModel.XML
        Get
            Dim lXML As String = ""
            lXML &= "<UCI>" & vbCrLf
            lXML &= "  <FileName>" & pBaseScenario & "</FileName>" & vbCrLf
            lXML &= "</UCI>" & vbCrLf
            Return lXML
        End Get
        Set(ByVal value As String)

        End Set
    End Property
End Class
