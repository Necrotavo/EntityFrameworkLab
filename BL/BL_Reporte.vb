Imports [TO]
Imports DAO
Public Class BL_Reporte
    Property listaFacturas As List(Of BL_Factura)
    Property desde As DateTime
    Property hasta As DateTime
    Property client As String

    Public Sub getFacturasConRango()
        Dim report As TOReporte = New TOReporte()
        Dim daoReport As DAO_Facturas = New DAO_Facturas()
        report.client = Me.client
        report.desde = Me.desde
        report.hasta = Me.hasta
        report.listaFacturas = New List(Of TO_Factura)
        daoReport.selectFacturasFromClient(report)
        For Each element As TO_Factura In report.listaFacturas
            Dim blFact As New BL_Factura
            blFact.Codigo = element.Codigo
            listaFacturas.Add(New BL_Factura)
        Next


        'daoReport.selectFacturasConRango(report)

        'For Each element In report.listaFacturas
        '    Dim factura As New BL_Factura
        '    factura.Cedula_Cliente = element.Cedula_Cliente
        '    factura.Fecha = element.Fecha
        '    'Hacer metodo para calcular total.
        '    factura.Total = element.Total
        '    'Hacer metodo para calcular total.

        '    'Hacer metodo para pasar los productos BL a productos TO
        '    'factura.ListaProductos = element.lista_Productos
        '    'Hacer metodo para pasar los productos BL a productos TO


        '    Me.listaFacturas.Add(factura)
        'Next



    End Sub


End Class
