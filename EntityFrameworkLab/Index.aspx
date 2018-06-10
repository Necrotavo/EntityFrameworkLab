<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EntityFrameworkLab.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="MainDiv">
        <img src="welcome.jpg" style="width: 40%" />
<br />
    <asp:Button ID="btnClientes" runat="server" Text="Clientes" OnClick="Button1_Click" CssClass="menuButton" />
<br />
        <asp:Button ID="btnProductos" runat="server" Text="Productos" CssClass="menuButton" OnClick="btnProductos_Click"/>
<br />
        <asp:Button ID="btnFacturas" runat="server" Text="Facturas" CssClass="menuButton" OnClick="btnFacturas_Click"/>
<br />
        <asp:Button ID="btnReportes" runat="server" Text="Reportes"  CssClass="menuButton" OnClick="btnReportes_Click"/>
<br />

    </div>
        
    </form>
</body>
</html>
