﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Facturas.aspx.cs" Inherits="EntityFrameworkLab.Facturas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
        #form1 {
            height: 696px;
            width: 789px;
        }
    </style>
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
        <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="textBox" Width="256px" ReadOnly="True"></asp:TextBox>
        <br />
        <div style="border-bottom: solid black">
        </div>
        <br />
        <asp:Label ID="lblProducto" runat="server" Text="Producto" CssClass="label"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlProductos" runat="server" CssClass="menuButton" AutoPostBack="True" OnSelectedIndexChanged="ddlProductos_SelectedIndexChanged"></asp:DropDownList>
        <br />
        <asp:Label ID="lblDisponibles" runat="server" Text="Disponibles: " CssClass="label"></asp:Label>
        <asp:TextBox ID="txtCantDisponibles" runat="server" CssClass="smallBox" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;
        <asp:Label ID="lblPrecio" runat="server" Text="Precio:" CssClass="label"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtPrecio" runat="server" CssClass="smallBox" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:Label ID="lblCantidad" runat="server" Text="Cantidad a agregar: " CssClass="label"></asp:Label>
        <asp:TextBox ID="txtCantComprar" runat="server" CssClass="smallBox"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCantComprar" ErrorMessage="La cantidad debe ser un numerico"></asp:RequiredFieldValidator>
        <br />
        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtCantComprar" ErrorMessage="Debe ser una cantidad disponible" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="AgregarProducto" CssClass="menuButton" OnClick="btnAdd_Click"/>

        <br />
        <br />
        &nbsp;&nbsp;
        <asp:Label ID="lblContinue" runat="server" Text="A continuacioin los detalles de la factura" CssClass="labelError"></asp:Label>

    </div>

    <div class="column" style="text-align:center">
    <asp:Label ID="lblFactura" runat="server" Text="FACTURA" CssClass="label"></asp:Label>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Cod " CssClass="label"></asp:Label>
        <asp:TextBox ID="txtCodigo" runat="server" CssClass="textBox"></asp:TextBox>
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
        <asp:Button ID="btnAddFactura" runat="server" Text="Guardar" CssClass="menuButton" OnClick="btnAddFactura_Click"/>
        <br />
        <br />
        <asp:Label ID="lblError" runat="server" CssClass="labelError"></asp:Label>
    </div>
    </form>
</body>
</html>
