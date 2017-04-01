Imports System.Data.SqlClient
Public Class Form3
    Dim cnn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Pravat\Documents\Visual Studio 2010\Projects\1.Placement System\Placement System\Database1.mdf;Integrated Security=True;User Instance=True")
    Dim cmd As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim dt As New DataTable
    Dim i As Integer
    Private Sub btnVerify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerify.Click
        cnn.Open()
        If (txtEmail.Text = "" And txtDOB.Text = "") Then
            MsgBox("INVALID EMAILID OR DOB", MsgBoxStyle.Exclamation)
        Else
            Using command As New SqlClient.SqlCommand(" SELECT * FROM tblAdmin WHERE EmailID='" & txtEmail.Text & "' and DOB = '" & txtDOB.Text & "' ", cnn)
                i = command.ExecuteNonQuery
            End Using
            If (i > 0) Then
                MsgBox("Incorrect Information", MsgBoxStyle.Exclamation)
            Else
                MsgBox("Verify Sucessfull", MsgBoxStyle.Information)
                Label3.Visible = True
                Label4.Visible = True
                txtNewpass.Visible = True
                txtConpass.Visible = True
                btnOk.Visible = True

            End If
        End If
        cnn.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        cnn.Open()
        If txtNewpass.Text = txtConpass.Text Then
            Using cmd As New SqlClient.SqlCommand("UPDATE tblAdmin SET Password = '" & txtNewpass.Text & "' WHERE EmailID = '" & txtEmail.Text & "' and DOB = '" & txtDOB.Text & "'", cnn)
                i = cmd.ExecuteNonQuery
            End Using
            If (i > 0) Then
                MsgBox("Password Saved")
            Else
                MsgBox("Passwords are not matching ")
            End If
        End If
        cnn.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Hide()
        form2.Show()
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        txtEmail.Clear()
        txtDOB.Clear()
        txtNewpass.Clear()
        txtConpass.Clear()
        txtEmail.Focus()
    End Sub
End Class