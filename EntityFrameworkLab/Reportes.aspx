<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="EntityFrameworkLab.Reportes" %>

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
        <asp:Label ID="Label2" runat="server" Text="Desde:" CssClass="label"></asp:Label>
        <br />
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Hasta:" CssClass="label"></asp:Label>
        <br />
        <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="menuButton"/>

    </div>

    <div class="column" style="text-align: center">
    <asp:Label ID="Label5" runat="server" Text="Factura" CssClass="label"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="menuButton"></asp:DropDownList>
        <br />
    <asp:ListBox ID="ListBox1" runat="server" CssClass="textBox"></asp:ListBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Total: " CssClass="label"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" CssClass="smallBox"></asp:TextBox>
    </div>
    </form>
</body>
</html>
