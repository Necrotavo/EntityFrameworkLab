Imports [TO]
Imports DAO
Public Class BL_Reporte
    Property listaFacturas As List(Of BL_Factura)
    Property desde As DateTime
    Property hasta As DateTime
    Property client As String

    Public Sub getFacturasConRango()
        Try
            Dim report As TOReporte = New TOReporte()
            Dim daoReport As DAO_Facturas = New DAO_Facturas()
            report.client = Me.client
            report.desde = Me.desde
            report.hasta = Me.hasta
            report.listaFacturas = New List(Of TO_Factura)
            daoReport.selectFromClient(report)
            For Each element As TO_Factura In report.listaFacturas
                Dim blFact As New BL_Factura
                blFact.Codigo = element.Codigo
                listaFacturas.Add(blFact)
            Next
        Catch ex As Exception
            Throw New Exception("Error al obtener facturas del cliente")
        End Try

    End Sub


End Class
