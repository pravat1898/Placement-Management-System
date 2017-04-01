Imports System.Data.SqlClient

Public Class form2
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim connection As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Pravat\Documents\Visual Studio 2010\Projects\1.Placement System\Placement System\Database1.mdf;Integrated Security=True;User Instance=True")
        Dim command As New SqlCommand("select * from tblAdmin where UserName = @UserName and EmailID = @EmailID and Password = @Password", connection)
        command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = txtUsername.Text
        command.Parameters.Add("@EmailID", SqlDbType.VarChar).Value = txtEmail.Text
        command.Parameters.Add("@Password", SqlDbType.VarChar).Value = txtPassword.Text

        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)
        Dim p As String = Nothing
        If table.Rows.Count() <= 0 Then
            MsgBox("Invalid Username or EmailID or Password", MsgBoxStyle.Exclamation)
            clear()
        Else
            MsgBox("LOGIN SUCCESSFULL ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            clear()
            Form5.Show()
        End If

    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtUsername.Visible = True
        txtEmail.Visible = True
        txtPassword.Visible = True

        btnLogin.Visible = True


    End Sub
    Sub clear()
        txtEmail.Clear()
        txtPassword.Clear()
        txtUsername.Clear()
        txtUsername.Focus()
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Dim peaceout As String
        peaceout = MsgBox("ARE YOU SURE YOU WANT TO QUIT", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ALL SYSTEM OUT")
        If peaceout = vbYes Then
            MsgBox("ALL SYSTEM OUT", MsgBoxStyle.Information)
            Application.Exit()
        ElseIf peaceout = vbNo Then
            MsgBox("ALL SYSTEM STANDBY FOR FURTHER INSTRUCTION", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtUsername.Text = ""
        txtEmail.Text = ""
        txtPassword.Text = ""
        txtUsername.Focus()
        btnLogin.Visible = True
    End Sub

    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub lblForgot_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblForgot.LinkClicked
        Form3.Show()
    End Sub
End Class
