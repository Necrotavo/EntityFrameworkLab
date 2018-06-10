<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Facturas.aspx.cs" Inherits="EntityFrameworkLab.Facturas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="column">
        <asp:Label ID="lblCliente" runat="server" Text="Clientes" CssClass="label"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlClientes" runat="server" CssClass="menuButton" AutoPostBack="True" OnSelectedIndexChanged="ddlClientes_SelectedIndexChanged"></asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="label"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="textBox" Width="256px"></asp:TextBox>
        <br />
        <div style="border-bottom: solid black">
        </div>
        <br />
        <asp:Label ID="lblProducto" runat="server" Text="Producto" CssClass="label"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlProductos" runat="server" CssClass="menuButton" AutoPostBack="True" OnSelectedIndexChanged="ddlProductos_SelectedIndexChanged"></asp:DropDownList>
        <br />
        <asp:Label ID="lblDisponibles" runat="server" Text="Disponibles: " CssClass="label"></asp:Label>
        <asp:TextBox ID="txtCantDisponibles" runat="server" CssClass="smallBox"></asp:TextBox>
        <br />
&nbsp;
        <asp:Label ID="lblPrecio" runat="server" Text="Precio:" CssClass="label"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtPrecio" runat="server" CssClass="smallBox"></asp:TextBox>
        <br />
        <asp:Label ID="lblCantidad" runat="server" Text="Cantidad a agregar: " CssClass="label"></asp:Label>
        <asp:TextBox ID="txtCantComprar" runat="server" CssClass="smallBox"></asp:TextBox>
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="AgregarProducto" CssClass="menuButton" OnClick="btnAdd_Click"/>

    </div>

    <div class="column" style="text-align: center">
    <asp:Label ID="lblFactura" runat="server" Text="FACTURA" CssClass="label"></asp:Label>
        <br />
        <br />&nbsp;&nbsp;<asp:GridView ID="dgvDetalleFactura" runat="server" CssClass="smallBox" HorizontalAlign="Center" SelectedIndex="0">
            <SelectedRowStyle BorderStyle="Dotted" BackColor="#8F7B52" />
        </asp:GridView>
        &nbsp;<asp:Button ID="btnUp" runat="server" Text="^" CssClass="menuButton" OnClick="btnUp_Click"/>
        <asp:Button ID="btnDown" runat="server" Text="v" CssClass="menuButton" OnClick="btnDown_Click"/>
        <br />
        <br />
        <asp:Label ID="lblTotal" runat="server" Text="Total: " CssClass="label"></asp:Label>
        <asp:TextBox ID="txtTotal" runat="server" CssClass="smallBox"></asp:TextBox>
        <br />
        <asp:Button ID="btnRemoveFromList" runat="server" Text="Remover producto" CssClass="menuButton" OnClick="btnRemoveFromList_Click"/>
        <br />
        <asp:Button ID="btnAddFactura" runat="server" Text="Guardar" CssClass="menuButton"/>
    </div>
    </form>
</body>
</html>
