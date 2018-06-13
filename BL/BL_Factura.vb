Imports DAO
Imports [TO]
Public Class BL_Factura
    Property Codigo As String
    Property Cedula_Cliente As String
    Property Total As Int16
    Property Fecha As DateTime
    Property ListaProductos As List(Of BL_Producto)

    Public Sub addFactura()
        Try
            Dim toFactura As New TO_Factura()
            toFactura.Codigo = Me.Codigo
            toFactura.Cedula_Cliente = Me.Cedula_Cliente
            toFactura.lista_Productos = New TO_ProductList()
            toFactura.lista_Productos.toProductList = New List(Of TO_Producto)
            For Each producto As BL_Producto In Me.ListaProductos
                Dim toProdAux As New TO_Producto()
                toProdAux = producto.igualarTOProducto()
                toFactura.lista_Productos.toProductList.Add(toProdAux)
            Next
            Dim daoFactura As New DAO_Facturas()
            daoFactura.addFactura(toFactura)
        Catch ex As Exception
            Throw New Exception("Error al insertar factura")
        End Try

    End Sub

    Public Sub selectAFactura()
        Try
            Dim daoFactura As New DAO_Facturas()
            Dim toFactura As New TO_Factura()
            toFactura.Codigo = Me.Codigo
            toFactura.lista_Productos = New TO_ProductList()
            toFactura.lista_Productos.toProductList = New List(Of TO_Producto)

            daoFactura.selectAFactura(toFactura)
            Me.Cedula_Cliente = toFactura.Cedula_Cliente
            Me.Fecha = toFactura.Fecha
            For Each toProd As TO_Producto In toFactura.lista_Productos.toProductList
                Dim blProdAux As New BL_Producto
                blProdAux.igualarDesdeTOProducto(toProd)
                Me.ListaProductos.Add(blProdAux)
            Next
        Catch ex As Exception
            Throw New Exception("Error al obtener factura")
        End Try

    End Sub
End Class
