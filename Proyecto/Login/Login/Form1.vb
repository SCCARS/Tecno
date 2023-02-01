Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class Form1
    Dim fu As New Fusuario
    Dim eu As New Eusuario

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        txt_Contra.Text = ""
        txt_Usuario.Text = ""
        txt_Usuario.Focus()
    End Sub

    Private Sub btn_Ingresar_Click(sender As Object, e As EventArgs) Handles btn_Ingresar.Click
        Try
            If txt_Contra.Text <> "" And txt_Usuario.Text <> "" Then
                Dim dt As New DataTable

                eu._nombre_usuario = txt_Usuario.Text
                eu._contraseña = txt_Contra.Text
                dt = fu.validausuario(eu)
                If dt.Rows.Count > 0 Then

                    Dim nivel As String
                    nivel = dt.Rows(0)("rol")
                    If nivel = "Cliente" Then
                        Me.Hide()
                        Form3.Show()
                        txt_Contra.Text = ""
                        txt_Usuario.Text = ""
                    ElseIf nivel = "Admin" Then
                        Me.Hide()
                        Form2.Show()
                        txt_Contra.Text = ""
                        txt_Usuario.Text = ""
                    ElseIf nivel = "Secretaria" Then
                        Me.Hide()
                        Form4.Show()
                        txt_Contra.Text = ""
                        txt_Usuario.Text = ""
                    End If
                End If
            Else
                MsgBox("Coloque un usuario y/o una contraseña", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class


Public Class conexion

    Public con As New SqlConnection
    Public cmd As New SqlCommand

    Public Function conectado()
        Try
            con = New SqlConnection(My.Settings.Connection)
            con.Open()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
End Class

Public Class Fusuario
    Inherits conexion

    Public Function validausuario(ByVal dts As Eusuario) As DataTable

        conectado()
        cmd = New SqlCommand("Iniciosesion")
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = con

        cmd.Parameters.AddWithValue("@nombre_Usuario", dts._nombre_usuario)
        cmd.Parameters.AddWithValue("@contraseña", dts._contraseña)

        If cmd.ExecuteNonQuery Then
            Using dt As New DataTable
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                    Return dt
                End Using
            End Using
        Else
            Return Nothing
        End If
    End Function
End Class

Public Class Eusuario
    Private nombre_usuario As String
    Private contraseña As String
    Private rol As String

    Public Property _nombre_usuario
        Get
            Return nombre_usuario
        End Get
        Set(value)
            nombre_usuario = value
        End Set
    End Property

    Public Property _contraseña
        Get
            Return contraseña
        End Get
        Set(value)
            contraseña = value
        End Set
    End Property

    Public Property _rol
        Get
            Return rol
        End Get
        Set(value)
            rol = value
        End Set
    End Property
End Class
