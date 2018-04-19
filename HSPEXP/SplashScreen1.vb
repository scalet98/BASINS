﻿Imports MapWinUtility
Public NotInheritable Class SplashScreen1

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        'Application title
        'If My.Application.Info.Title <> "" Then
        '    ApplicationTitle.Text = My.Application.Info.Title
        'Else
        '    'If the application title is missing, use the application name, without the extension
        '    ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        'End If

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        With My.Application.Info.Version
            Version.Text = "Version " & .Major & "." & .Minor & " beta3"
            Logger.Dbg("Software Verion:" & Version.Text)
            If .MajorRevision > 0 OrElse .MinorRevision > 0 Then
                Version.Text &= "." & .MajorRevision & "." & .MinorRevision
            End If
        End With
        'Copyright info
        'Copyright.Text = My.Application.Info.Copyright
    End Sub

    Private Sub MainLayoutPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MainLayoutPanel.Paint

    End Sub
End Class
