Public Class Form1

    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        form2.Show()
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        form8.Show()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim peaceout As String
        peaceout = MsgBox("ARE YOU SURE YOU WANT TO QUIT", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ALL SYSTEM OUT")
        If peaceout = vbYes Then
            MsgBox("ALL SYSTEM OUT", MsgBoxStyle.Information)
            Application.Exit()
        ElseIf peaceout = vbNo Then
            MsgBox("ALL SYSTEM STANDBY FOR FURTHER INSTRUCTION", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Button4_Click_1(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        MsgBox("Hi!!This is a Placement Management System Project.Here students can get the information about the companies..and they can also search for their eligible companies....", vbOKOnly)
    End Sub
End Class
