Public NotInheritable Class startupSplash

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub MainLayoutPanel_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MainLayoutPanel.Paint
        Me.TopMost = True
        Threading.Thread.Sleep(1000)
        mod1.startup()
    End Sub
End Class
