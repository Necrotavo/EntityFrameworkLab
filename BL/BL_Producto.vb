﻿Imports [TO]
Imports DAO
<Serializable>
Public Class BL_Producto
    Property Codigo As String
    Property Descripcion As String
    Property Precio As Int16
    Property Cantidad_Inventario As Int16
    Property Cantidad_En_Factura As Int16
    Property listaProductos As New List(Of BL_Producto)

    Public Sub selectProductos()
        Try
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
        Catch ex As Exception
            Throw New Exception("Error al obtener producto la lista de productos")
        End Try

    End Sub

    Public Sub selectAProduct()
        Try
            Dim toProduct As New TO_Producto
            Dim daoProducto As New DAO_Productos
            toProduct = igualarTOProducto()
            daoProducto.selectAProduct(toProduct)
            igualarDesdeTOProducto(toProduct)

        Catch ex As Exception
            Throw New Exception("Error al obtener producto")
        End Try
    End Sub

    Public Sub insertProduct()
        Try
            Dim toProduct As New TO_Producto
            toProduct = igualarTOProducto()
            Dim daoProducto As New DAO_Productos
            daoProducto.insertProduct(toProduct)
        Catch ex As Exception
            Throw New Exception("Error al insertar producto")
        End Try
    End Sub

    Public Sub modifyProduct()
        Try
            Dim toProduct As New TO_Producto
            toProduct = igualarTOProducto()
            Dim daoProducto As New DAO_Productos
            daoProducto.modifyProduct(toProduct)
        Catch ex As Exception
            Throw New Exception("Error al modificar producto")
        End Try

    End Sub

    Public Sub deleteProduct()
        Try
            Dim toProduct As New TO_Producto
            toProduct.Codigo = Me.Codigo
            Dim daoProducto As New DAO_Productos
            daoProducto.deleteProduct(toProduct)
        Catch ex As Exception
            Throw New Exception("Error al eliminar producto")
        End Try

    End Sub

    Public Sub igualarDesdeTOProducto(toProducto As TO_Producto)
        Me.Codigo = toProducto.Codigo
        Me.Descripcion = toProducto.Descripcion
        Me.Precio = toProducto.Precio
        Me.Cantidad_Inventario = toProducto.Cantidad_Inventario
        Me.Cantidad_En_Factura = toProducto.Cantidad_En_Factura
    End Sub

    Public Function igualarTOProducto() As TO_Producto
        Dim toProducto As New TO_Producto
        toProducto.Codigo = Me.Codigo
        toProducto.Descripcion = Me.Descripcion
        toProducto.Precio = Me.Precio
        toProducto.Cantidad_Inventario = Me.Cantidad_Inventario
        toProducto.Cantidad_En_Factura = Me.Cantidad_En_Factura
        Return toProducto
    End Function
End Class
