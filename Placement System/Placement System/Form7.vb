Imports System.Data.SqlClient
Imports System.IO


Public Class Form7
    Dim cnn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Pravat\Documents\Visual Studio 2010\Projects\1.Placement System\Placement System\Database1.mdf;Integrated Security=True;User Instance=True")
    Dim cmd As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim dt As New DataTable
    Dim i As Integer




    Private Sub Form7_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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
        txtCID.Clear()
        txtCompanyType.Clear()
        txtMinQual.Clear()
        txtSGPA.Clear()
        txtSecondary.Clear()
        txtHS.Clear()
        txtPackage.Clear()
        txtCompanyName.Focus()

    End Sub

    Private Sub dg2_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg2.CellContentClick
        Try
            txtCompanyName.Text = dg2.Item(0, e.RowIndex).Value
            txtCID.Text = dg2.Item(1, e.RowIndex).Value
            txtCompanyType.Text = dg2.Item(2, e.RowIndex).Value
            txtMinQual.Text = dg2.Item(3, e.RowIndex).Value
            txtSGPA.Text = dg2.Item(4, e.RowIndex).Value
            txtSecondary.Text = dg2.Item(5, e.RowIndex).Value
            txtHS.Text = dg2.Item(6, e.RowIndex).Value
            txtPackage.Text = dg2.Item(7, e.RowIndex).Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        cnn.Open()
        Using cmd As New SqlClient.SqlCommand("UPDATE tblCompany SET CompanyName ='" & txtCompanyName.Text & "' ,CID ='" & txtCID.Text & "' ,CompanyType ='" & txtCompanyType.Text & "' ,MinQualification='" & txtMinQual.Text & "' ,C_SGPA = " & txtSGPA.Text & ",C_SecondaryMarks = " & txtSecondary.Text & ",C_HSMarks = " & txtHS.Text & ",Package = '" & txtPackage.Text & "'WHERE CompanyName='" & txtCompanyName.Text & "' ", cnn)
            i = cmd.ExecuteNonQuery
        End Using
        If (i > 0) Then
            MsgBox("Record Updated Successfully", MsgBoxStyle.Information)
            clear()
        End If
        cnn.Close()
        showrecord()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        cnn.Open()
        With cmd
            .Connection = cnn
            .CommandText = "DELETE FROM tblCompany WHERE CompanyName='" & txtCompanyName.Text & "'"
            i = .ExecuteNonQuery

        End With
        If (i > 0) Then
            MsgBox("Row Deleted Successfully", MsgBoxStyle.Information)
            clear()

        End If
        cnn.Close()
        showrecord()

    End Sub

    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        Me.Close()
        Form5.Show()
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        cnn.Open()
        cmd.CommandText = "SELECT * FROM tblCompany WHERE CompanyName='" + txtCompanyName.Text + "'"
        cmd.ExecuteNonQuery()
        dt = New DataTable()
        da = New SqlDataAdapter(cmd)
        da.Fill(dt)
        dg2.DataSource = dt
        cnn.Close()
    End Sub

    Private Sub btnSave_Click_1(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        cnn.Open()
        Using cmd As New SqlClient.SqlCommand("INSERT INTO tblCompany(CompanyName,CID,CompanyType,MinQualification,C_SGPA,C_SecondaryMarks,C_HSMarks,Package)VALUES('" & txtCompanyName.Text & "','" & txtCID.Text & "','" & txtCompanyType.Text & "','" & txtMinQual.Text & "','" & txtSGPA.Text & "','" & txtSecondary.Text & "'," & txtHS.Text & ",'" & txtPackage.Text & "')", cnn)
            i = cmd.ExecuteNonQuery
        End Using
        If (i > 0) Then
            MsgBox("RECORD SUCCESSFULLY SAVED ! ", MsgBoxStyle.Information)
            clear()
        End If
        cnn.Close()
        showrecord()
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        txtCompanyName.Clear()
        txtCompanyType.Clear()
        txtCID.Clear()
        txtMinQual.Clear()
        txtSGPA.Clear()
        txtSecondary.Clear()
        txtHS.Clear()
        txtPackage.Clear()
        txtCompanyName.Focus()
        showrecord()
    End Sub
End Class