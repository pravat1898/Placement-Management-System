Imports System.Data.SqlClient
Public Class Form9

    Private Sub btnSignup_Click(sender As Object, e As EventArgs) Handles btnSignup.Click
        Dim connection As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Pravat\Documents\Visual Studio 2010\Projects\1.Placement System\Placement System\Database1.mdf;Integrated Security=True;User Instance=True")
        Dim command As New SqlCommand("insert into tblLoginDetails(UserName,EmailID,DOB,Password) values(@UserName,@EmailID,@DOB,@Password)", connection)
        If (txtUsername.Text = "" And txtEmail.Text = "" And txtDOB.Text = "" And txtPassword.Text = "") Then
            MsgBox("INVALID INPUT", MsgBoxStyle.Exclamation)
        Else
            command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = txtUsername.Text
            command.Parameters.Add("@EmailID", SqlDbType.VarChar).Value = txtEmail.Text
            command.Parameters.Add("@DOB", SqlDbType.VarChar).Value = txtDOB.Text
            command.Parameters.Add("@Password", SqlDbType.VarChar).Value = txtPassword.Text
            connection.Open()
            If command.ExecuteNonQuery() = 1 Then
                MsgBox("SIGNED UP SUCCESSFULLY", MsgBoxStyle.Information)

            End If
        End If
    End Sub

    Private Sub Form9_load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    Sub clear()
        txtUsername.Clear()
        txtEmail.Clear()
        txtDOB.Clear()
        txtPassword.Clear()
        txtUsername.Focus()

    End Sub
    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        clear()

        ' txtUsername.Text = " "
        '  txtEmail.Text = " "
        '  txtDOB.Text = " "
        '  txtPassword.Text = " "
    End Sub

    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        Me.Close()
        form8.Show()
    End Sub
End Class