﻿Imports DAO
Imports [TO]
<Serializable>
Public Class BL_Cliente
    Property Cedula As String
    Property Nombre As String
    Property Apellido As String
    Property Correo As String
    Property Telefono As String
    Property listaClientes As List(Of BL_Cliente)

    Public Sub insertClient()
        Try
            Dim tocliente As TO_Cliente = igualarTOaBL()
            Dim daoClients As New DAO_Clientes
            daoClients.insertClient(tocliente)
        Catch ex As Exception
            Throw New Exception("Element cliente ya existe")
        End Try
    End Sub

    Public Sub modifyClient()

        Dim tocliente As TO_Cliente = igualarTOaBL()
        Dim daoClients As New DAO_Clientes
        daoClients.modifyClient(tocliente)
    End Sub

    Public Sub deleteClient()
        Try
            Dim tocliente As New TO_Cliente()
            tocliente.Cedula = Me.Cedula
            Dim daoClients As New DAO_Clientes()
            daoClients.deleteClient(tocliente)
        Catch ex As Exception
            Throw New System.Exception("El cliente tiene facturas")
        End Try
    End Sub

    Public Sub loadClient()
        If Me.Cedula = "Seleccionar" Then
            Me.Cedula = ""
            Me.Nombre = ""
            Me.Apellido = ""
            Me.Correo = ""
            Me.Telefono = ""
        Else
            Dim tocliente As New TO_Cliente()
            tocliente.Cedula = Me.Cedula
            Dim daoClients As New DAO_Clientes()
            daoClients.selectACliente(tocliente)
            igualarBLaTO(tocliente)
        End If
    End Sub

    Public Sub loadClients()
        Dim toclientlist As New TO_ClienteList()
        toclientlist.listaClientes = New List(Of TO_Cliente)
        Dim daoClientes As New DAO_Clientes()
        daoClientes.selectClientes(toclientlist)
        listaClientes = New List(Of BL_Cliente)
        If (toclientlist.listaClientes.Count > 0) Then
            For Each tocliente As TO_Cliente In toclientlist.listaClientes
                Dim cliente As New BL_Cliente()
                cliente.igualarBLaTO(tocliente)
                listaClientes.Add(cliente)
            Next
        End If
    End Sub

    Public Function igualarTOaBL() As TO_Cliente
        Dim tocliente As New TO_Cliente()
        tocliente.Cedula = Me.Cedula
        tocliente.Nombre = Me.Nombre
        tocliente.Apellido = Me.Apellido
        tocliente.Correo = Me.Correo
        tocliente.telefono = Me.Telefono
        Return tocliente
    End Function

    Public Sub igualarBLaTO(tocliente As TO_Cliente)
        Me.Cedula = tocliente.Cedula
        Me.Nombre = tocliente.Nombre
        Me.Apellido = tocliente.Apellido
        Me.Correo = tocliente.Correo
        Me.Telefono = tocliente.telefono
    End Sub

    Public Function hasEmpty() As Boolean
        If Me.Cedula <> Nothing Or Me.Nombre <> Nothing Or Me.Apellido <> Nothing Or
            Me.Correo <> Nothing Or Me.Telefono <> Nothing Then

            If Me.Cedula.Trim() <> "" Or Me.Nombre.Trim() <> "" Or Me.Apellido.Trim() <> "" Or
                Me.Correo.Trim() <> "" Or Me.Telefono.Trim() <> "" Then

                Return False
            End If
        Else
        End If
        Return True
    End Function
End Class