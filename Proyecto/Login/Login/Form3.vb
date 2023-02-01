Imports System.Data.SqlClient
Public Class Form3

    Dim con As New sqlconnection(My.Settings.Connection)
    Dim mensaje, sentencia As String

    Sub EjecutarSql(ByVal sql As String, ByVal msg As String)
        Try
            Dim cmd As New SqlCommand(sql, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            MsgBox(msg)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btn_Regresar_Click(sender As Object, e As EventArgs) Handles btn_Regresar.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub btn_limpiar_Click(sender As Object, e As EventArgs) Handles btn_limpiar.Click
        txt_id.Text = ""
        txt_nombre.Text = ""
        txt_apellido.Text = ""
        txt_edad.Text = ""
        txt_telefono.Text = ""
        txt_id.Focus()
    End Sub

    Private Sub btn_Mostrar_Click(sender As Object, e As EventArgs) Handles btn_Mostrar.Click
        Try
            Dim da As New SqlDataAdapter("select * from Persona", con)
            Dim ds As New DataSet
            da.Fill(ds)
            Me.dtgv.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_Insertar_Click(sender As Object, e As EventArgs) Handles btn_Insertar.Click
        sentencia = "insert into Persona values('" + txt_id.Text + "','" + txt_nombre.Text + "','" + txt_apellido.Text + "', '" + txt_edad.Text + "', '" + txt_telefono.Text + "')"
        mensaje = "Datos Insertados Correctamente"
        EjecutarSql(sentencia, mensaje)
        Try
            Dim da As New SqlDataAdapter("select * from Persona", con)
            Dim ds As New DataSet
            da.Fill(ds)
            Me.dtgv.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_Editar_Click(sender As Object, e As EventArgs) Handles btn_Editar.Click
        sentencia = "update Persona set nombre = '" + txt_nombre.Text + "', apellido = '" + txt_apellido.Text + "', edad = '" + txt_edad.Text + "', telefono = '" + txt_telefono.Text + "'where Id = '" + txt_id.Text + "'"
        mensaje = "Datos Actualizados Correctamente"
        EjecutarSql(sentencia, mensaje)
        Try
            Dim da As New SqlDataAdapter("select * from Persona", con)
            Dim ds As New DataSet
            da.Fill(ds)
            Me.dtgv.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_Buscar_Click(sender As Object, e As EventArgs) Handles btn_Buscar.Click
        Dim da As New SqlDataAdapter("Select * from Persona where id = '" + txt_id.Text + "'", con)
        Dim ds As New DataSet
        da.Fill(ds)
        Me.dtgv.DataSource = ds.Tables(0)
    End Sub
End Class