
Imports System.Data.SqlClient
Imports System.IO
Public Class Form17
    Sub showrecord()
        
        Dim cnn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Pravat\Documents\Visual Studio 2010\Projects\1.Placement System\Placement System\Database1.mdf;Integrated Security=True;User Instance=True")
        Dim cmd1 As New SqlCommand(" SELECT * from tblStudent WHERE RegistrationNo = @rn ", cnn)
        cmd1.Parameters.Add("@rn", SqlDbType.VarChar).Value = Form16.txtRegistrationNo.Text
        Dim da1 As New SqlDataAdapter(cmd1)
        Dim dt1 As New DataTable()
        da1.Fill(dt1)

        Dim SGPA As Integer = CInt(dt1.Rows(0)(8).ToString())
        Dim SM As Integer = CInt(dt1.Rows(0)(9).ToString())
        Dim HS As Integer = CInt(dt1.Rows(0)(10).ToString())


        Dim cmd As New SqlCommand("SELECT distinct CompanyName,CID,CompanyType,MinQualification,Package FROM tblCompany WHERE C_SGPA <= @SGPA and C_SecondaryMarks <= @SecondaryMarks and C_HSMarks <= @HSMarks ", cnn)
        cmd.Parameters.Add("@SGPA", SqlDbType.Int).Value = SGPA
        cmd.Parameters.Add("@SecondaryMarks", SqlDbType.Int).Value = SM
        cmd.Parameters.Add("@HSMarks", SqlDbType.Int).Value = HS
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        da.Fill(dt)
        dg1.DataSource = dt
        cnn.Close()
    End Sub

    Private Sub Form17_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Form16.Show()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim peaceout As String
        peaceout = MsgBox("ARE YOU SURE YOU WANT TO QUIT", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "ALL SYSTEM OUT")
        If peaceout = vbYes Then
            MsgBox("ALL SYSTEM OUT", MsgBoxStyle.Information)
            Application.Exit()
        ElseIf peaceout = vbNo Then
            MsgBox("ALL SYSTEM STANDBY FOR FURTHER INSTRUCTION", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub llSignOut_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSignOut.LinkClicked
        Me.Hide()
        Form16.Hide()
        Form15.Hide()
        Form14.Hide()
        Form13.Hide()
        Form11.Hide()
        Form10.Hide()
        Form9.Hide()

        form8.Show()
    End Sub

    Private Sub dg1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub
End Class