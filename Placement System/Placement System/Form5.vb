Public Class Form5

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Form6.show()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        Dim peaceout As String
        peaceout = MsgBox("ARE YOU SURE YOU WANT TO QUIT", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ALL SYSTEM OUT")
        If peaceout = vbYes Then
            MsgBox("ALL SYSTEM OUT", MsgBoxStyle.Information)
            Application.Exit()
        ElseIf peaceout = vbNo Then
            MsgBox("ALL SYSTEM STANDBY FOR FURTHER INSTRUCTION", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Form5_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Form7.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        Form4.Hide()
        Form3.Hide()
        form2.Show()
    End Sub

    Private Sub lblCreate_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblCreate.LinkClicked
        Form4.Show()
    End Sub
End Class