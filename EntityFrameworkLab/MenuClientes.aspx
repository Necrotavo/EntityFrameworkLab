<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuClientes.aspx.cs" Inherits="EntityFrameworkLab.MenuClientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="MainDiv">
        <br />
        <br />
        <h1>Administrar Clientes</h1>
<br />
    <asp:Button ID="btnInsertar" runat="server" Text="Insertar" OnClick="btnInsertar_Click" CssClass="menuButton" />
<br />
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="menuButton" OnClick="btnModificar_Click"/>
<br />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="menuButton" OnClick="btnEliminar_Click"/>
<br />
        <asp:Button ID="btnConsultar" runat="server" Text="Consultar"  CssClass="menuButton" OnClick="btnConsultar_Click"/>
        <br />
        <br />
        <br />
        <asp:Button ID="btnSalir" runat="server" Text="Regresar" CssClass="menuButton" OnClick="btnSalir_Click"/>
<br />
        <br />
        <br />

    </div>
    </form>
</body>
</html>
