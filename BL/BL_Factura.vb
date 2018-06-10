Imports DAO
Imports [TO]
Public Class BL_Factura
    Property Codigo As String
    Property Cedula_Cliente As String
    Property Total As Int16
    Property Fecha As DateTime
    Property ListaProductos As List(Of BL_Producto)

    Public Sub addFactura()
        Dim toFactura As New TO_Factura()
        toFactura.Codigo = Me.Codigo
        toFactura.Cedula_Cliente = Me.Cedula_Cliente
        For Each producto As BL_Producto In Me.ListaProductos
            Dim toProdAux As New TO_Producto()
            toProdAux = producto.igualarTOProducto()
            'Hay un problema aqui
            toFactura.lista_Productos.toProductList.Add(toProdAux)
        Next
        Dim daoFactura As New DAO_Facturas()
        daoFactura.addFactura(toFactura)
    End Sub

    Public Sub selectAFactura()
        Dim daoFactura As New DAO_Facturas()
        Dim toFactura As New TO_Factura()
        toFactura.Codigo = Me.Codigo
        daoFactura.selectAFactura(toFactura)
        Me.Cedula_Cliente = toFactura.Cedula_Cliente
        Me.Fecha = toFactura.Fecha
        For Each toProd As TO_Producto In toFactura.lista_Productos.toProductList
            Dim blProdAux As New BL_Producto
            blProdAux.igualarDesdeTOProducto(toProd)
            Me.ListaProductos.Add(blProdAux)
        Next
    End Sub
End Class
