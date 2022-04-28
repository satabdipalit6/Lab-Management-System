Imports System.Data.OleDb
Imports System.Data

Public Class LabDetails


    Sub view()
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\PROJECT_PORTFOLIO\LAB Mangement System\Lab Management System\sysdtl_db.accdb")
        con.Open()
        Dim adp As New OleDbDataAdapter("select * from sysdtl_Table ", con)
        Dim ds As New DataSet
        adp.Fill(ds, "sysdtl_Table")
        DataGridView1.DataSource = ds.Tables("sysdtl_Table")
        con.Close()

    End Sub
    Sub display_datagrid()
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\PROJECT_PORTFOLIO\LAB Mangement System\Lab Management System\sysdtl_db.accdb")
        con.Open()
        Dim cmd As New OleDbCommand()
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from  sysdtl_Table where lab like '%" + ComboBox1.Text + "%'"
        Dim da As New OleDbDataAdapter
        Dim dt As New DataTable
        da.SelectCommand = cmd
        dt.Clear()
        da.Fill(dt)
        DataGridView1.DataSource = dt
        'cmd.ExecuteNonQuery()
        con.Close()
        ' MsgBox("Your Data has been updated successfully")
    End Sub

    Private Sub LabDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display_datagrid()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        display_datagrid()

        TextBox1.Text = DataGridView1.Rows.Count - 1
    End Sub


    Private Sub view_btn_Click(sender As Object, e As EventArgs) Handles view_btn.Click
        ComboBox1.SelectedIndex = -1
        view()
    End Sub

    Private Sub exit_btn_Click(sender As Object, e As EventArgs) Handles exit_btn.Click
        Application.Exit()

    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TextBox2.Text = Format(Now, "dd/MM/yyyy")
        TextBox3.Text = Format(Now, " hh:mm:ss")
    End Sub



    Private Sub back_btn_Click(sender As Object, e As EventArgs) Handles back_btn.Click
        SystemDetails.Show()
    End Sub
End Class