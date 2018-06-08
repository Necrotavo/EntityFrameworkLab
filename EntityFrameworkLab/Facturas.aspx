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
        <asp:Label ID="Label1" runat="server" Text="Clientes" CssClass="label"></asp:Label>
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="menuButton"></asp:DropDownList>
        <div style="border-bottom: solid black">
        </div>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Producto" CssClass="label"></asp:Label>
        <br />
        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="menuButton"></asp:DropDownList>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Disponibles: " CssClass="label"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="smallBox"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Cantidad a agregar: " CssClass="label"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="smallBox"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Add" CssClass="menuButton"/>

    </div>

    <div class="column" style="text-align: center">
    <asp:Label ID="Label5" runat="server" Text="FACTURA" CssClass="label"></asp:Label>
        <br />
    <asp:ListBox ID="ListBox1" runat="server" CssClass="textBox"></asp:ListBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Total: " CssClass="label"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" CssClass="smallBox"></asp:TextBox>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Remover producto" CssClass="menuButton"/>
        <br />
        <asp:Button ID="Button3" runat="server" Text="Guardar" CssClass="menuButton"/>
    </div>
    </form>
</body>
</html>
