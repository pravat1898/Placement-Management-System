Imports System.Data.SqlClient
Imports System.IO


Public Class Form15
    Dim cnn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Pravat\Documents\Visual Studio 2010\Projects\1.Placement System\Placement System\Database1.mdf;Integrated Security=True;User Instance=True")
    Dim cmd As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim dt As New DataTable
    Dim i As Integer




    Private Sub Form15_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database1DataSet.tblCompany' table. You can move, or remove it, as needed.
        Me.TblCompanyTableAdapter.Fill(Me.Database1DataSet.tblCompany)
        showrecord()

    End Sub

    Sub showrecord()
        cnn.Open()
        With cmd
            .Connection = cnn
            .CommandText = "SELECT * FROM tblCompany"
        End With
        da.SelectCommand = cmd
        dt.Clear()
        da.Fill(dt)
        dg2.DataSource = dt
        cnn.Close()

    End Sub


    Sub clear()
        txtCompanyName.Clear()
        txtCompanyName.Focus()

    End Sub

    Private Sub llSignOut_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSignOut.LinkClicked
        Me.Hide()
        Form11.Close()
        Form13.Close()
        form8.Show()
    End Sub

    Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Close()
        Form13.Show()
    End Sub

    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        txtCompanyName.Clear()
        txtCompanyName.Focus()
        showrecord()
    End Sub

    Private Sub btnSearch_Click_1(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        cnn.Open()
        cmd.CommandText = "SELECT * FROM tblCompany WHERE CompanyName='" + txtCompanyName.Text + "'"
        cmd.ExecuteNonQuery()
        dt = New DataTable()
        da = New SqlDataAdapter(cmd)
        da.Fill(dt)
        dg2.DataSource = dt
        cnn.Close()
    End Sub

    Private Sub dg2_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg2.CellContentClick
        Try
            txtCompanyName.Text = dg2.Item(0, e.RowIndex).Value
        Catch ex As Exception
        End Try
    End Sub
End Class