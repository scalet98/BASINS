Imports System.IO
Imports MapWinUtility

Module swmm5_iface

    ' SWMM5_IFACE.BAS
    '
    ' Example code for interfacing SWMM 5
    ' with Visual Basic Applications
    '
    Dim pBinaryFileStream As FileStream
    Dim pBinaryReader As BinaryReader

    '
    Private Const SUBCATCH = 0
    Private Const NODE = 1
    Private Const LINK = 2
    Private Const SYS = 3
    Private Const INFINITE = -1&
    Private Const SW_SHOWNORMAL = 1&
    Private Const RECORDSIZE = 4           ' number of bytes per file record

    Private SubcatchVars As Integer        ' number of subcatch reporting variable
    Private SubcatchPropCodes() As Integer
    Private SubcatchPropValues(,) As Single

    Private NodeVars As Integer            ' number of node reporting variables
    Private NodePropCodes() As Integer
    Private NodePropValues(,) As Single

    Private LinkVars As Integer            ' number of link reporting variables
    Private LinkPropCodes() As Integer
    Private LinkPropValues(,) As Single

    Private SysVars As Integer             ' number of system reporting variables
    Private Fout As Integer                ' file handle
    Private StartPos As Integer            ' file position where results start
    Private BytesPerPeriod As Integer      ' number of bytes used for storing
    ' results in file each reporting period

    Public SWMM_Nperiods As Integer        ' number of reporting periods
    Public SWMM_FlowUnits As Integer       ' flow units code
    Public SWMM_Nsubcatch As Integer       ' number of subcatchments
    Public SWMM_SubcatchId() As String
    Public SWMM_Nnodes As Integer          ' number of drainage system nodes
    Public SWMM_NodeId() As String
    Public SWMM_Nlinks As Integer          ' number of drainage system links
    Public SWMM_LinkId() As String
    Public SWMM_Npolluts As Integer        ' number of pollutants tracked
    Public SWMM_PollutId() As String
    Public SWMM_PollutConcCode() As String
    Public SWMM_StartDate As Double        ' start date of simulation
    Public SWMM_ReportStep As Integer      ' reporting time step (seconds)

    Function OpenSwmmOutFile(ByVal OutFile As String) As Integer
        '------------------------------------------------------------------------------
        '  Input:   outFile = name of binary output file
        '  Output:  returns 0 if successful, 1 if binary file invalid because
        '           SWMM 5 ran with errors, or 2 if the file cannot be opened
        '  Purpose: opens the binary output file created by a SWMM 5 run and
        '           retrieves the following simulation data that can be
        '           accessed by the application:
        '           SWMM_Nperiods = number of reporting periods
        '           SWMM_FlowUnits = flow units code
        '           SWMM_Nsubcatch = number of subcatchments
        '           SWMM_Nnodes = number of drainage system nodes
        '           SWMM_Nlinks = number of drainage system links
        '           SWMM_Npolluts = number of pollutants tracked
        '           SWMM_StartDate = start date of simulation
        '           SWMM_ReportStep = reporting time step (seconds)
        '------------------------------------------------------------------------------

        ' --- open the output file
        pBinaryFileStream = New FileStream(OutFile, FileMode.Open, FileAccess.Read)
        pBinaryReader = New BinaryReader(pBinaryFileStream)

        Dim lReturnCode As Integer
        ' --- check that file contains at least 14 records
        If pBinaryFileStream.Length < 14 * RECORDSIZE Then
            pBinaryFileStream.Close()
            Return lReturnCode
        End If

        With pBinaryReader
            Try
                'debug code to look at bytes read from current position
                pBinaryFileStream.Seek(pBinaryFileStream.Length - (5 * RECORDSIZE), SeekOrigin.Begin)
                Dim lFilePosition As Integer = pBinaryFileStream.Position
                Dim lBytes() As Byte = .ReadBytes(20)

                ' --- read parameters from end of file
                pBinaryFileStream.Seek(pBinaryFileStream.Length - (5 * RECORDSIZE), SeekOrigin.Begin)
                Dim offset0 As Integer = .ReadInt32
                StartPos = .ReadInt32
                SWMM_Nperiods = .ReadInt32
                Dim errCode As Integer = .ReadInt32
                Dim magic2 As Integer = .ReadInt32

                ' --- read magic number from beginning of file
                pBinaryFileStream.Seek(0, SeekOrigin.Begin)
                Dim magic1 As Integer = .ReadInt32

                ' --- perform error checks
                If magic1 <> magic2 Then
                    lReturnCode = 1
                ElseIf errCode <> 0 Then
                    lReturnCode = 1
                ElseIf SWMM_Nperiods = 0 Then
                    lReturnCode = 1
                Else
                    lReturnCode = 0
                End If

                ' --- quit if errors found
                If lReturnCode > 0 Then
                    CloseSwmmOutFile()
                    Return lReturnCode
                End If

                ' --- otherwise read additional parameters from start of file
                Dim version As Integer = .ReadInt32
                SWMM_FlowUnits = .ReadInt32
                SWMM_Nsubcatch = .ReadInt32
                SWMM_Nnodes = .ReadInt32
                SWMM_Nlinks = .ReadInt32
                SWMM_Npolluts = .ReadInt32

                ' --- save details about output locations
                Dim lLength As Integer
                If SWMM_Nsubcatch > 0 Then
                    ReDim SWMM_SubcatchId(SWMM_Nsubcatch - 1)
                    For lIndex As Integer = 0 To SWMM_Nsubcatch - 1
                        lLength = .ReadInt32
                        Dim lChars() As Char = New String(.ReadChars(lLength))
                        SWMM_SubcatchId(lIndex) = New String(lChars)
                    Next
                End If
                If SWMM_Nnodes > 0 Then
                    ReDim SWMM_NodeId(SWMM_Nnodes - 1)
                    For lIndex As Integer = 0 To SWMM_Nnodes - 1
                        lLength = .ReadInt32
                        SWMM_NodeId(lIndex) = New String(.ReadChars(lLength))
                    Next
                End If
                If SWMM_Nlinks > 0 Then
                    ReDim SWMM_LinkId(SWMM_Nlinks - 1)
                    For lIndex As Integer = 0 To SWMM_Nlinks - 1
                        lLength = .ReadInt32
                        SWMM_LinkId(lIndex) = New String(.ReadChars(lLength))
                    Next
                End If
                If SWMM_Npolluts > 0 Then
                    ReDim SWMM_PollutId(SWMM_Npolluts - 1)
                    For lIndex As Integer = 0 To SWMM_Npolluts - 1
                        lLength = .ReadInt32
                        SWMM_PollutId(lIndex) = New String(.ReadChars(lLength))
                    Next
                    ReDim SWMM_PollutConcCode(SWMM_Npolluts - 1)
                    For lIndex As Integer = 0 To SWMM_Npolluts - 1
                        lLength = .ReadInt32
                        SWMM_PollutConcCode(lIndex) = New String(.ReadChars(lLength))
                    Next
                End If

                ' --- read number & codes of computed variables
                SubcatchVars = .ReadInt32
                ReDim SubcatchPropCodes(SubcatchVars - 1)
                For lVarIndex As Integer = 0 To SubcatchVars - 1
                    SubcatchPropCodes(lVarIndex) = .ReadInt32
                Next
                If SWMM_Nsubcatch > 0 Then
                    ReDim SubcatchPropValues(SubcatchVars - 1, SWMM_Nsubcatch - 1)
                    For lVarIndex As Integer = 0 To SubcatchVars - 1
                        For lSubcatchIndex As Integer = 0 To SWMM_Nsubcatch - 1
                            NodePropValues(lVarIndex, lSubcatchIndex) = .ReadSingle
                        Next
                    Next
                End If

                NodeVars = .ReadInt32
                ReDim NodePropCodes(NodeVars - 1)
                For lVarIndex As Integer = 0 To NodeVars - 1
                    NodePropCodes(lVarIndex) = .ReadInt32
                Next

                If SWMM_Nnodes > 0 Then
                    ReDim NodePropValues(NodeVars - 1, SWMM_Nnodes - 1)
                    For lVarIndex As Integer = 0 To NodeVars - 1
                        For lNodeIndex As Integer = 0 To SWMM_Nnodes - 1
                            NodePropValues(lVarIndex, lNodeIndex) = .ReadSingle
                        Next
                    Next
                End If

                LinkVars = .ReadInt32
                ReDim LinkPropCodes(LinkVars - 1)
                For lVarIndex As Integer = 0 To LinkVars - 1
                    LinkPropCodes(lVarIndex) = .ReadInt32
                Next
                If SWMM_Nlinks > 0 Then
                    ReDim LinkPropValues(LinkVars - 1, SWMM_Nlinks - 1)
                End If
                For lVarIndex As Integer = 0 To LinkVars - 1
                    For lLinkIndex As Integer = 0 To SWMM_Nlinks - 1
                        LinkPropValues(lVarIndex, lLinkIndex) = .ReadSingle
                    Next
                Next

                SysVars = .ReadInt32

                ' --- read data just before start of output results
                '
                'TODO: update and test the rest!
                '
                'FileSeek(Fout, StartPos - 3 * RECORDSIZE + 1)
                FileGet(Fout, SWMM_StartDate)
                FileGet(Fout, SWMM_ReportStep)

                ' --- compute number of bytes stored per reporting period
                BytesPerPeriod = RECORDSIZE * 2
                BytesPerPeriod = BytesPerPeriod + RECORDSIZE * SWMM_Nsubcatch * SubcatchVars
                BytesPerPeriod = BytesPerPeriod + RECORDSIZE * SWMM_Nnodes * NodeVars
                BytesPerPeriod = BytesPerPeriod + RECORDSIZE * SWMM_Nlinks * LinkVars
                BytesPerPeriod = BytesPerPeriod + RECORDSIZE * SysVars

                ' --- return with file left open
                Return lReturnCode
                Exit Function
            Catch ex As Exception
                Logger.Dbg("SWMMOutputFileProblem " & ex.Message & vbCrLf & ex.StackTrace)
                CloseSwmmOutFile()
                Return lReturnCode
            End Try
        End With
    End Function

    Function GetSwmmResult(ByVal iType As Integer, ByVal iIndex As Integer, _
             ByVal vIndex As Integer, ByVal period As Integer, ByVal Value As Single) As Integer
        '------------------------------------------------------------------------------
        '  Input:   iType = type of object whose value is being sought
        '                   (0 = subcatchment, 1 = node, 2 = link, 3 = system
        '           iIndex = index of item being sought (starting from 0)
        '           vIndex = index of variable being sought (see Interfacing Guide)
        '           period = reporting period index (starting from 1)
        '  Output:  value = value of variable being sought;
        '           function returns 1 if successful, 0 if not
        '  Purpose: finds the result of a specific variable for a given object
        '           at a specified time period.
        '------------------------------------------------------------------------------
        Dim offset As Integer
        Dim offset1 As Integer
        Dim offset2 As Integer
        Dim X As Single

        '// --- compute offset into output file
        Value = 0.0#
        GetSwmmResult = 0
        offset1 = StartPos + (period - 1) * BytesPerPeriod + 2 * RECORDSIZE + 1
        offset2 = 0
        If iType = SUBCATCH Then
            offset2 = iIndex * SubcatchVars + vIndex
        ElseIf iType = NODE Then
            offset2 = SWMM_Nsubcatch * SubcatchVars + iIndex * NodeVars + vIndex
        ElseIf iType = LINK Then
            offset2 = SWMM_Nsubcatch * SubcatchVars + SWMM_Nnodes * NodeVars + iIndex * LinkVars + vIndex
        ElseIf iType = SYS Then
            offset2 = SWMM_Nsubcatch * SubcatchVars + SWMM_Nnodes * NodeVars + SWMM_Nlinks * LinkVars + vIndex
        Else : Exit Function
        End If

        '// --- re-position the file and read result
        offset = offset1 + RECORDSIZE * offset2
        'FileSeek #Fout, offset
        FileGet(Fout, X)
        Value = X
        Return 1
    End Function

    Public Sub CloseSwmmOutFile()
        '------------------------------------------------------------------------------
        '  Input:   none
        '  Output:  none
        '  Purpose: closes the binary output file.
        '------------------------------------------------------------------------------
        pBinaryReader.Close()
        pBinaryFileStream.Close()
    End Sub
End Module

