Public Class Form11

    Private Sub Form11_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSearch_Click_1(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Form16.Show()
    End Sub

    Private Sub btnView_Click_1(sender As System.Object, e As System.EventArgs) Handles btnView.Click
        Form13.Show()
    End Sub

    Private Sub btnBack_Click_1(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        Me.Close()
        form8.Show()
    End Sub

    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        Dim peaceout As String
        peaceout = MsgBox("ARE YOU SURE YOU WANT TO QUIT", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ALL SYSTEM OUT")
        If peaceout = vbYes Then
            MsgBox("ALL SYSTEM OUT", MsgBoxStyle.Information)
            Application.Exit()
        ElseIf peaceout = vbNo Then
            MsgBox("ALL SYSTEM STANDBY FOR FURTHER INSTRUCTION", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub llSignOut_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSignOut.LinkClicked
        Me.Hide()
        Form10.Close()
        Form9.Close()
        form8.Show()
    End Sub
End Class