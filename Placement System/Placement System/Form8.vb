Imports System.Data.SqlClient

Public Class form8
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim connection As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Pravat\Documents\Visual Studio 2010\Projects\1.Placement System\Placement System\Database1.mdf;Integrated Security=True;User Instance=True")
        Dim command As New SqlCommand("select * from tblLoginDetails where UserName = @UserName and EmailID = @EmailID and Password = @Password", connection)
        command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = txtUsername.Text
        command.Parameters.Add("@EmailID", SqlDbType.VarChar).Value = txtEmailid.Text
        command.Parameters.Add("@Password", SqlDbType.VarChar).Value = txtPassword.Text

        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If table.Rows.Count() <= 0 Then
            MsgBox("Invalid Username or EmailID or Password", MsgBoxStyle.Exclamation)
            clear()
        Else
            MsgBox("LOGIN SUCCESSFULL ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            clear()
            Form11.Show()


        End If
    End Sub

    Sub clear()
        txtEmailid.Clear()
        txtPassword.Clear()
        txtUsername.Clear()
        txtUsername.Focus()
    End Sub

    Private Sub form8_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

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

    Private Sub BtnForget_Click(sender As System.Object, e As System.EventArgs) Handles BtnForget.Click
        Form10.Show()
    End Sub

    Private Sub BtnCreate_Click(sender As System.Object, e As System.EventArgs) Handles BtnCreate.Click
        Form9.Show()
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        txtEmailid.Clear()
        txtUsername.Clear()
        txtPassword.Clear()
        txtUsername.Focus()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Form7.Hide()
        Form6.Hide()
        Form5.Hide()
        Form4.Hide()
        Form3.Hide()
        form2.Hide()
        Form1.Show()


    End Sub
End Class
