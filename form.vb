'mdi form
Public Class Form1
    Private Sub GroceryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GroceryToolStripMenuItem.Click
        Form2.ShowDialog()
    End Sub
    Private Sub StockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockToolStripMenuItem.Click
        Form3.ShowDialog()
    End Sub
End Class

''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'main 
Imports System.Data.SqlClient
Imports System.Data
Public Class Form2
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\study\sem - 4\4 .net\journal\prac\prac\Database1.mdf;Integrated Security=True")
    Private Sub FillData()
        Dim cmd As New SqlCommand
        Dim strSQL As String
        Dim ds As New DataSet : Dim da As New SqlDataAdapter
        strSQL = "Select * from market"
        cmd.CommandText = strSQL
        cmd.Connection = cn
        da.SelectCommand = cmd
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        ds.Dispose() : da.Dispose() : cmd.Dispose()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim strSQL As String
        Dim cmd As New SqlCommand
        'strSQL = "insert into emp values(1,'AJAY','1234567890',15000)"
        strSQL = "insert into market values(" & TextBox1.Text & ",'" & TextBox2.Text & "'," & TextBox3.Text & "," & TextBox4.Text & "," & TextBox5.Text & ")"
        cmd.CommandText = strSQL
        cmd.Connection = cn
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        MsgBox("Record Saved Successfully")
        ClearForm()
        FillData()
        TextBox1.Focus()
    End Sub
    Private Sub ClearForm()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn.Open()
        FillData()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim cmd As New SqlCommand
        Dim strSQL As String
        strSQL = "UPDATE market SET name='" & TextBox2.Text & "',mrp=" & TextBox3.Text & ",price=" & TextBox4.Text & ",quantity=" & TextBox5.Text & " where itemno=" & Val(TextBox1.Text) & ""
        cmd.CommandText = strSQL
        cmd.Connection = cn
        cmd.ExecuteNonQuery()
        MsgBox("Record Update successfully")
        cmd.Dispose()
        ClearForm()
        FillData()
        TextBox1.Focus()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim cmd As New SqlCommand
        Dim strSQL As String
        If MsgBox("Are you sure, want to delete?", MsgBoxStyle.YesNo +
                  vbDefaultButton2 + vbCritical, "Record Delete") = vbYes Then
            'strSQL = "DELETE FROM EMP WHERE EMPNO=1"
            strSQL = "DELETE FROM market where itemno=" & Val(TextBox1.Text) & ""
            cmd.CommandText = strSQL
            cmd.Connection = cn
            cmd.ExecuteNonQuery()
            MsgBox("Record Deleted successfully", vbInformation)
            cmd.Dispose()
            ClearForm()
            FillData()
            TextBox1.Focus()
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim cmd As New SqlCommand : Dim strSQL As String
        Dim dr As SqlDataReader
        strSQL = "Select * from market where itemno=" & TextBox1.Text & ""
        cmd.CommandText = strSQL : cmd.Connection = cn
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            dr.Read()  'Move BOF to first record
            TextBox2.Text = dr.Item("name").ToString
            TextBox3.Text = dr.Item("mrp").ToString
            TextBox4.Text = dr.Item("price").ToString
            TextBox5.Text = dr.Item("quantity").ToString
        Else
            ClearForm() : MsgBox("No Record found", vbInformation)
        End If
        dr.Close()
        cmd.Dispose()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ClearForm()
        TextBox1.Focus()
    End Sub
End Class
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
