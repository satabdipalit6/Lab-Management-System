Imports System.Data.OleDb
Imports System.Data
Public Class SystemDetails


    Sub update()
        Dim B, M, I As String

        If (RadioButton1.Checked = True) Then
            B = "YES"
        Else
            B = "NO"
        End If


        If (RadioButton3.Checked = True) Then
            M = "YES"
        Else
            M = "NO"
        End If

        If (RadioButton5.Checked = True) Then
            I = "YES"
        Else
            I = "NO"
        End If

        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\PROJECT_PORTFOLIO\LAB Mangement System\Lab Management System\sysdtl_db.accdb")
        con.Open()
        Dim cmd As New OleDbCommand()
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "UPDATE [sysdtl_Table] SET [brand] = '" & TextBox2.Text & "',[cpu]='" & TextBox3.Text & "',[mon]='" & TextBox4.Text & "',[ram]='" & ComboBox1.SelectedItem & "', [hdd]='" & ComboBox2.SelectedItem & "',[ssd]='" & ComboBox3.SelectedItem & "',[os]='" & ComboBox4.SelectedItem & "',[proc]='" & ComboBox5.SelectedItem & "',[lab]='" & ComboBox8.SelectedItem & "',[cur]='" & ComboBox6.SelectedItem & "',[notwork]='" & ComboBox7.SelectedItem & "',[des]='" & TextBox5.Text & "',[backup]='" & B & "',[ups]='" & TextBox6.Text & "',[main]='" & M & "',[dom]='" & DateTimePicker1.Text & "',[interet]='" & I & "' where [sysid]='" & TextBox1.Text & "'"
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Your Data has been updated successfully")
    End Sub
    Sub reset()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""

        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        ComboBox4.SelectedIndex = -1
        ComboBox5.SelectedIndex = -1
        ComboBox8.SelectedIndex = -1
        ComboBox6.SelectedIndex = -1
        ComboBox7.SelectedIndex = -1
        TextBox5.Text = ""
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        TextBox6.Text = ""
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        DateTimePicker1.Text = ""
        RadioButton5.Checked = False
        RadioButton6.Checked = False

    End Sub


    Sub view()
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\PROJECT_PORTFOLIO\LAB Mangement System\Lab Management System\sysdtl_db.accdb")
        con.Open()
        Dim adp As New OleDbDataAdapter("select * from sysdtl_Table ", con)
        Dim ds As New DataSet
        adp.Fill(ds, "sysdtl_Table")
        DataGridView1.DataSource = ds.Tables("sysdtl_Table")
        con.Close()

    End Sub



    Private Sub add_btn_Click(sender As Object, e As EventArgs) Handles add_btn.Click

        Dim B, M, I As String

        If (RadioButton1.Checked = True) Then
            B = "YES"
        Else
            B = "NO"
        End If


        If (RadioButton3.Checked = True) Then
            M = "YES"
        Else
            M = "NO"
        End If

        If (RadioButton5.Checked = True) Then
            I = "YES"
        Else
            I = "NO"
        End If
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\PROJECT_PORTFOLIO\LAB Mangement System\Lab Management System\sysdtl_db.accdb")
        con.Open()
        Dim cmd As New OleDbCommand()
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into Sysdtl_Table values ('" & TextBox1.Text & "', '" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & ComboBox4.Text & "','" & ComboBox5.Text & "','" & ComboBox8.Text & "','" & ComboBox6.Text & "','" & ComboBox7.Text & "','" & TextBox5.Text & "','" & B & "','" & TextBox6.Text & "','" & M & "','" & DateTimePicker1.Text & "','" & I & "')"
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Your Data has been saved successfully")
        reset()
    End Sub

    Private Sub SystemDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TextBox8.Text = Format(Now, "dd/MM/yyyy")
        TextBox9.Text = Format(Now, " hh:mm:ss")
    End Sub

    Private Sub Show_btn_Click(sender As Object, e As EventArgs) Handles Show_btn.Click
        view()
    End Sub

    Private Sub update_btn_Click(sender As Object, e As EventArgs) Handles update_btn.Click
        update()
        view()
        reset()

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
        TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
        TextBox3.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
        TextBox4.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString
        ComboBox1.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
        ComboBox2.Text = DataGridView1.CurrentRow.Cells(5).Value.ToString
        ComboBox3.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString
        ComboBox4.Text = DataGridView1.CurrentRow.Cells(7).Value.ToString
        ComboBox5.Text = DataGridView1.CurrentRow.Cells(8).Value.ToString
        ComboBox8.Text = DataGridView1.CurrentRow.Cells(9).Value.ToString
        ComboBox6.Text = DataGridView1.CurrentRow.Cells(10).Value.ToString
        ComboBox7.Text = DataGridView1.CurrentRow.Cells(11).Value.ToString
        TextBox5.Text = DataGridView1.CurrentRow.Cells(12).Value.ToString

        If (DataGridView1.CurrentRow.Cells(13).Value = "Yes") Then

            RadioButton1.Checked = True
        Else
            RadioButton2.Checked = True
        End If



        TextBox6.Text = DataGridView1.CurrentRow.Cells(14).Value.ToString


        If (DataGridView1.CurrentRow.Cells(15).Value = "Yes") Then
            RadioButton3.Checked = True
        Else
            RadioButton4.Checked = True
        End If

        DateTimePicker1.Text = DataGridView1.CurrentRow.Cells(16).Value.ToString


        If (DataGridView1.CurrentRow.Cells(17).Value = "Yes") Then
            RadioButton5.Checked = True
        Else
            RadioButton6.Checked = True
        End If


    End Sub



    Private Sub ComboBox6_TextChanged(sender As Object, e As EventArgs) Handles ComboBox6.TextChanged
        If (ComboBox6.Text = "WORKING") Then
            ComboBox7.Enabled = False
            TextBox5.Enabled = False
        Else
            ComboBox7.Enabled = True
            TextBox5.Enabled = True
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If (RadioButton2.Checked) Then
            TextBox6.Enabled = False
        Else
            TextBox6.Enabled = True
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If (RadioButton3.Checked) Then
            DateTimePicker1.Enabled = True
        Else
            DateTimePicker1.Enabled = False
        End If
    End Sub

    Private Sub Exit_btn_Click(sender As Object, e As EventArgs) Handles Exit_btn.Click
        Application.Exit()
    End Sub

    Private Sub dlt_btn_Click(sender As Object, e As EventArgs) Handles dlt_btn.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\PROJECT_PORTFOLIO\LAB Mangement System\Lab Management System\sysdtl_db.accdb")
        con.Open()
        Dim cmd As New OleDbCommand()
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "delete from sysdtl_Table where sysid='" & TextBox1.Text & "'"
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Your Data has been Deleted successfully")
        reset()
    End Sub

    Sub display_datagrid()
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\PROJECT_PORTFOLIO\LAB Mangement System\Lab Management System\sysdtl_db.accdb")
        con.Open()
        Dim cmd As New OleDbCommand()
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from  sysdtl_Table where brand like '%" + ComboBox9.Text + "%'"
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

    Private Sub ComboBox9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox9.SelectedIndexChanged
        display_datagrid()



    End Sub



    Private Sub next_btn_Click_1(sender As Object, e As EventArgs) Handles next_btn.Click
        LabDetails.Show()
    End Sub
End Class