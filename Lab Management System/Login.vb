Imports System.Data.OleDb
Imports System.Data

Public Class Form1
    Private Sub txtUser_MouseEnter(sender As Object, e As EventArgs) Handles txtUser.MouseEnter
        If txtUser.Text = "Enter Your Username" Then
            txtUser.Text = ""
            txtUser.ForeColor = Color.Black
        End If
    End Sub ' THIS FUNCTION IS USED FOR WATERMARK

    Private Sub txtUser_MouseLeave(sender As Object, e As EventArgs) Handles txtUser.MouseLeave
        If txtUser.Text = "" Then
            txtUser.Text = "Enter Your Username"
            txtUser.ForeColor = Color.Gray
        End If
    End Sub ' THIS FUNCTION IS USED FOR WATERMARK
    Private Sub txtPass_MouseEnter(sender As Object, e As EventArgs) Handles txtPass.MouseEnter
        If txtPass.Text = "Enter Your Password" Then
            txtPass.Text = ""
            txtPass.ForeColor = Color.Black
        End If
    End Sub ' THIS FUNCTION IS USED FOR WATERMARK
    Private Sub txtPass_MouseLeave(sender As Object, e As EventArgs) Handles txtPass.MouseLeave
        If txtPass.Text = "" Then
            txtPass.Text = "Enter Your Password"
            txtPass.ForeColor = Color.Gray

        End If
    End Sub ' THIS FUNCTION IS USED FOR WATERMARK

    'THIS BELOW CODE IS USED FOR LOGIN 
    Private Sub login_btn_Click(sender As Object, e As EventArgs) Handles login_btn.Click
        Dim uname As String
        Dim pword As String
        Dim pass As String

        If txtUser.Text = " " Or txtPass.Text = "" Then
            MsgBox("Please Fill all Information")
        Else
            uname = txtUser.Text
            pword = txtPass.Text

            Dim querry As String = "Select Password From login where Username = '" & uname & "' ;"
            Dim dbsource As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\PROJECT_PORTFOLIO\LAB Mangement System\Lab Management System\Login_DB.accdb"
            Dim conn = New OleDbConnection(dbsource)
            Dim cmd As New OleDbCommand(querry, conn)
            conn.Open()
            Try
                pass = cmd.ExecuteScalar().ToString

            Catch ex As Exception
                MsgBox("Usernma Does not Exist")

            End Try
            If (pword = pass) Then
                MsgBox("Login Successful")
                Home.Show()
                If Home.Visible Then
                    Me.Hide()
                End If
            Else
                MsgBox("Login Failed")
                txtUser.Clear()
                txtPass.Clear()
            End If
        End If

    End Sub



    'THIS BELOW CODE IS USED FOR CLEAR 
    Private Sub clr_btn_Click_1(sender As Object, e As EventArgs) Handles clr_btn.Click
        txtUser.Clear()
        txtPass.Clear()
    End Sub

    Private Sub txtUser_TextChanged(sender As Object, e As EventArgs) Handles txtUser.TextChanged

    End Sub
End Class
