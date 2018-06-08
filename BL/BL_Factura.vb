Imports DAO
Imports [TO]
Public Class BL_Factura
    Property Cedula_Cliente As String
    Property Codigo_Producto As String
    Property Cantidad As Int16
    Property Total As Int16
    Property Fecha As DateTime
    Property ListaProductos As List(Of BL_Producto)

    Public Sub addFactura()
        Dim daoFact As New DAO_Facturas();

    End Sub
End Class
