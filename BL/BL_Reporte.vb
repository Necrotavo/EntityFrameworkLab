Imports [TO]
Imports DAO
Public Class BL_Reporte
    Property listaFacturas As List(Of BL_Factura)
    Property desde As DateTime
    Property hasta As DateTime
    Property client As BL_Cliente

    Public Sub getFacturasConRango()
        Dim toListFact As TO_FacturaList = New TO_FacturaList()
        Dim report As TOReporte = New TOReporte()
        Dim daoReport As DAO_Facturas = New DAO_Facturas()

        'Para client hay q hacer una consulta de un client singular y asignarlo aqui.
        report.client.Apellido = client.Apellido
        report.client.Cedula = client.Cedula
        report.client.Correo = client.Correo
        report.client.Nombre = client.Nombre
        report.client.Telefono = client.Telefono

        report.desde = Me.desde
        report.hasta = Me.hasta

        daoReport.selectFacturasConRango(report)

        For Each element In report.listaFacturas
            Dim factura As New BL_Factura
            factura.Cedula_Cliente = element.Cedula_Cliente
            factura.Fecha = element.Fecha
            'Hacer metodo para calcular total.
            factura.Total = element.Total
            'Hacer metodo para calcular total.

            'Hacer metodo para pasar los productos BL a productos TO
            'factura.ListaProductos = element.lista_Productos
            'Hacer metodo para pasar los productos BL a productos TO


            Me.listaFacturas.Add(factura)
        Next



    End Sub


End Class
