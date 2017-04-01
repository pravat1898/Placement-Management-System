Imports System.Data.SqlClient
Imports System.IO

Public Class Form16
    Dim cnn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Pravat\Documents\Visual Studio 2010\Projects\1.Placement System\Placement System\Database1.mdf;Integrated Security=True;User Instance=True")
    Dim cmd As New SqlCommand
    Dim cmd1 As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim dt As New DataTable
    Dim i As Integer
    Private Sub Form16_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        showrecord()
    End Sub
    Sub showrecord()
        cnn.Open()
        With cmd
            .Connection = cnn
            .CommandText = "SELECT * FROM tblStudent"
        End With
        da.SelectCommand = cmd
        dt.Clear()
        da.Fill(dt)
        dg1.DataSource = dt
        cnn.Close()

    End Sub



    Sub clear()
        txtStudentName.Clear()
        txtCollegeName.Clear()
        txtDOB.Clear()
        txtGender.Clear()
        txtBranch.Clear()
        txtSem.Clear()
        txtRegistrationNo.Clear()
        txtSession.Clear()
        txtSGPA1.Clear()
        txtSecondary.Clear()
        txtHS.Clear()
        txtMobile.Clear()
        txtEmail.Clear()
        txtRegistrationNo.Focus()

    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        cnn.Open()
        cmd.CommandText = "SELECT * FROM tblStudent WHERE RegistrationNo='" + txtRegistrationNo.Text + "'"
        cmd.ExecuteNonQuery()
        Form17.showrecord()
        cnn.Close()
        Form17.Show()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        txtStudentName.Clear()
        txtCollegeName.Clear()
        txtDOB.Clear()
        txtGender.Clear()
        txtBranch.Clear()
        txtSem.Clear()
        txtRegistrationNo.Clear()
        txtSession.Clear()
        txtSGPA1.Clear()
        txtSecondary.Clear()
        txtHS.Clear()
        txtMobile.Clear()
        txtEmail.Clear()
        txtRegistrationNo.Focus()
        showrecord()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Close()
        Form11.Show()
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

    Private Sub llSignOut_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSignOut.LinkClicked
        Me.Hide()
        Form15.Hide()
        Form14.Hide()
        Form13.Hide()
        Form11.Hide()
        Form10.Hide()
        Form9.Hide()

        form8.Show()
    End Sub

    Private Sub dg1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellContentClick
        Try
            txtStudentName.Text = dg1.Item(0, e.RowIndex).Value
            txtCollegeName.Text = dg1.Item(1, e.RowIndex).Value
            txtDOB.Text = dg1.Item(2, e.RowIndex).Value
            txtGender.Text = dg1.Item(3, e.RowIndex).Value
            txtSem.Text = dg1.Item(4, e.RowIndex).Value
            txtBranch.Text = dg1.Item(5, e.RowIndex).Value
            txtRegistrationNo.Text = dg1.Item(6, e.RowIndex).Value
            txtSession.Text = dg1.Item(7, e.RowIndex).Value
            txtSGPA1.Text = dg1.Item(8, e.RowIndex).Value
            txtSecondary.Text = dg1.Item(9, e.RowIndex).Value
            txtHS.Text = dg1.Item(10, e.RowIndex).Value
            txtMobile.Text = dg1.Item(11, e.RowIndex).Value
            txtEmail.Text = dg1.Item(12, e.RowIndex).Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        cnn.Open()
        cmd.CommandText = "SELECT * FROM tblStudent WHERE RegistrationNo='" + txtRegistrationNo.Text + "'"
        cmd.ExecuteNonQuery()
        dt = New DataTable()
        da = New SqlDataAdapter(cmd)
        da.Fill(dt)
        dg1.DataSource = dt
        cnn.Close()
    End Sub
End Class