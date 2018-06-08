
Imports DAO
Imports [TO]
Public Class BL_Cliente
    Property Cedula As String
    Property Nombre As String
    Property Apellido As String
    Property Correo As String
    Property telefono As String

    Public Sub insertClient()
        Dim daoClients As New DAO_Clientes
        daoClients.insertClient(New TO_Cliente)

    End Sub
End Class