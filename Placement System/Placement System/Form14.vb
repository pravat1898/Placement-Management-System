Imports System.Data.SqlClient
Imports System.IO


Public Class Form14
    Dim cnn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Pravat\Documents\Visual Studio 2010\Projects\1.Placement System\Placement System\Database1.mdf;Integrated Security=True;User Instance=True")
    Dim cmd As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim dt As New DataTable
    Dim i As Integer




    Private Sub Form6_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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

        txtRegNo.Clear()
        txtRegNo.Focus()

    End Sub

    Private Sub llSignOut_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSignOut.LinkClicked
        Me.Hide()
        Form13.Hide()
        Form11.Hide()
        form8.Show()
    End Sub

    Private Sub btnBack_Click_1(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        Me.Close()
        Form13.Show()
    End Sub

    Private Sub btnSearch_Click_1(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        cnn.Open()
        cmd.CommandText = "SELECT * FROM tblStudent WHERE RegistrationNo='" + txtRegNo.Text + "'"
        cmd.ExecuteNonQuery()
        dt = New DataTable()
        da = New SqlDataAdapter(cmd)
        da.Fill(dt)
        dg1.DataSource = dt
        cnn.Close()
    End Sub

    Private Sub btnClear_Click_1(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        txtRegNo.Clear()

        txtRegNo.Focus()
        showrecord()
    End Sub

    Private Sub dg1_CellContentClick_1(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellContentClick
        Try
            txtRegNo.Text = dg1.Item(6, e.RowIndex).Value
        Catch ex As Exception

        End Try
    End Sub
End Class