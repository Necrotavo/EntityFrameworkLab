Imports [TO]
Imports DAO
Public Class BL_Producto
    Property Codigo As String
    Property Descripcion As String
    Property Precio As Int16
    Property Cantidad_Inventario As Int16
    Property listaProductos As List(Of BL_Producto)

    Public Sub selectClientes()
        Dim toProductList As New TO_ProductList
        toProductList.toProductList = New List(Of TO_Producto)
        Dim daoProducto As New DAO_Productos
        daoProducto.selectProducts(toProductList)
        If toProductList.toProductList.Count() > 0 Then
            For Each toProducto As TO_Producto In toProductList.toProductList
                Dim blProducto As New BL_Producto
                blProducto.igualarDesdeTOProducto(toProducto)
                Me.listaProductos.Add(blProducto)
            Next
        End If
    End Sub

    Public Sub selectAProduct()
        Dim toProduct As New TO_Producto
        Dim daoProducto As New DAO_Productos
        toProduct = igualarTOProducto()
        daoProducto.selectAProduct(toProduct)
        igualarDesdeTOProducto(toProduct)
    End Sub

    Public Sub insertProduct()
        Dim toProduct As New TO_Producto
        toProduct = igualarTOProducto()
        Dim daoProducto As New DAO_Productos
        daoProducto.insertProduct(toProduct)
    End Sub

    Public Sub modifyProduct()
        Dim toProduct As New TO_Producto
        toProduct = igualarTOProducto()
        Dim daoProducto As New DAO_Productos
        daoProducto.modifyProduct(toProduct)
    End Sub

    Public Sub deleteProduct()
        Dim toProduct As New TO_Producto
        toProduct.Codigo = Me.Codigo
        Dim daoProducto As New DAO_Productos
        daoProducto.deleteProduct(toProduct)
    End Sub

    Public Sub igualarDesdeTOProducto(toProducto As TO_Producto)
        Me.Codigo = toProducto.Codigo
        Me.Descripcion = toProducto.Descripcion
        Me.Precio = toProducto.Precio
        Me.Cantidad_Inventario = Convert.ToInt16(toProducto.Cantidad_Inventario)
    End Sub

    Public Function igualarTOProducto() As TO_Producto
        Dim toProducto As New TO_Producto
        toProducto.Codigo = Me.Codigo
        toProducto.Descripcion = Me.Descripcion
        toProducto.Precio = Me.Precio
        toProducto.Cantidad_Inventario = Me.Cantidad_Inventario.ToString()
        Return toProducto
    End Function
End Class
