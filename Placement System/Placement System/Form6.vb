Imports System.Data.SqlClient
Imports System.IO


Public Class Form6
    Dim cnn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Pravat\Documents\Visual Studio 2010\Projects\1.Placement System\Placement System\Database1.mdf;Integrated Security=True;User Instance=True")
    Dim cmd As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim dt As New DataTable
    Dim i As Integer




    Private Sub Form6_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        showrecord()

    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        cnn.Open()
        Using cmd As New SqlClient.SqlCommand("INSERT INTO tblStudent (StudentName,CollegeName,DOB,Branch,RegistrationNo,Session,SGPA,SecondaryMarks,HSMarks,MobileNo,EmailID,Gender,Semester) VALUES ('" & txtStudentName.Text & "','" & txtCollegeName.Text & "','" & txtDOB.Text & "','" & txtBranch.Text & "','" & txtRegistrationNo.Text & "','" & txtSession.Text & "'," & txtSGPA1.Text & "," & txtSecondary.Text & "," & txtHS.Text & ",'" & txtMobile.Text & "','" & txtEmail.Text & "','" & txtGender.Text & "','" & txtSem.Text & "')", cnn)
            i = cmd.ExecuteNonQuery
        End Using
        If (i > 0) Then
            MsgBox("Save" & i & "Record Successfully")
            clear()
        End If
        cnn.Close()
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

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        cnn.Open()
        Using cmd As New SqlClient.SqlCommand("UPDATE tblStudent SET StudentName ='" & txtStudentName.Text & "' ,CollegeName ='" & txtCollegeName.Text & "' ,DOB ='" & txtDOB.Text & "',Gender = '" & txtGender.Text & "',Semester ='" & txtSem.Text & "' ,Branch ='" & txtBranch.Text & "' ,RegistrationNo ='" & txtRegistrationNo.Text & "' ,Session ='" & txtSession.Text & "' ,SGPA = " & txtSGPA1.Text & ",SecondaryMarks = " & txtSecondary.Text & ",HSMarks = " & txtHS.Text & ",MobileNo = '" & txtMobile.Text & "',EmailID = '" & txtEmail.Text & "'WHERE RegistrationNo='" & txtRegistrationNo.Text & "' ", cnn)
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
            .CommandText = "DELETE FROM tblStudent WHERE RegistrationNo='" & txtRegistrationNo.Text & "'"
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
        cmd.CommandText = "SELECT * FROM tblStudent WHERE RegistrationNo='" + txtRegistrationNo.Text + "'"
        cmd.ExecuteNonQuery()
        dt = New DataTable()
        da = New SqlDataAdapter(cmd)
        da.Fill(dt)
        dg1.DataSource = dt
        cnn.Close()
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
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

    Private Sub Label13_Click(sender As System.Object, e As System.EventArgs) Handles Label13.Click

    End Sub
End Class