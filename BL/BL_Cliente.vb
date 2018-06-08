
Imports DAO
Imports [TO]
Public Class BL_Cliente
    Property Cedula As String
    Property Nombre As String
    Property Apellido As String
    Property Correo As String
    Property Telefono As String
    Property listaClientes As List(Of BL_Cliente)

    Public Sub insertClient()
        Dim tocliente As TO_Cliente = igualarTOaBL()
        Dim daoClients As New DAO_Clientes
        daoClients.insertClient(tocliente)
    End Sub

    Public Sub modifyClient()
        Dim tocliente As TO_Cliente = igualarTOaBL()
        Dim daoClients As New DAO_Clientes
        daoClients.modifyClient(tocliente)
    End Sub

    Public Sub deleteClient()
        Dim tocliente As New TO_Cliente()
        tocliente.Cedula = Me.Cedula
        Dim daoClients As New DAO_Clientes()
        daoClients.deleteClient(tocliente)
    End Sub

    Public Sub loadClient()
        Dim tocliente As New TO_Cliente()
        tocliente.Cedula = Me.Cedula
        Dim daoClients As New DAO_Clientes()
        daoClients.deleteClient(tocliente)

    End Sub

    Public Sub loadClients()
        Dim toclientlist As New TO_ClienteList()
        Dim daoClientes As New DAO_Clientes()
        daoClientes.selectClientes(toclientlist)
        listaClientes = New List(Of BL_Cliente)
        If (toclientlist.listaClientes.Count > 0) Then
            For Each tocliente As TO_Cliente In toclientlist.listaClientes
                Dim cliente As New BL_Cliente()
                igualarBLaTO(tocliente)
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
        tocliente.Telefono = Me.Telefono
        Return tocliente
    End Function

    Public Sub igualarBLaTO(tocliente As TO_Cliente)
        Me.Cedula = tocliente.Cedula
        Me.Nombre = tocliente.Nombre
        Me.Apellido = tocliente.Apellido
        Me.Correo = tocliente.Correo
        Me.Telefono = tocliente.Telefono
    End Sub
End Class