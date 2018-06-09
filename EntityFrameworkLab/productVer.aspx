<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productVer.aspx.cs" Inherits="EntityFrameworkLab.productVer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
<div style="overflow: hidden">
            <form id="form1" runat="server">

                        <div class="MainDiv">
                            <br />
                            <br />
                            <h1 style="text-align:center">Datos del producto</h1>
                            <br />
                            <br />
            <asp:Label ID="lblCod" runat="server" Text="Codigo:" CssClass="label"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="dropClients" runat="server" CssClass="menuButton" AutoPostBack="True" OnSelectedIndexChanged="dropClients_SelectedIndexChanged"></asp:DropDownList>
            <br />  
            <asp:Label ID="lblDesc" runat="server" Text="Descripcion:" CssClass="label"></asp:Label>     
            &nbsp;
            <asp:TextBox ID="TextBox2" runat="server" CssClass="textBox" ReadOnly="True"></asp:TextBox>
            <br />
            <asp:Label ID="lblPrice" runat="server" Text="Precio:" CssClass="label"></asp:Label>     
            &nbsp;
            <asp:TextBox ID="TextBox3" runat="server" CssClass="textBox" ReadOnly="True"></asp:TextBox>
            <br />
            <asp:Label ID="lblCantidad" runat="server" Text="Cantidad:" CssClass="label"></asp:Label>     
            &nbsp;
            <asp:TextBox ID="TextBox4" runat="server" CssClass="textBox" ReadOnly="True"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Button ID="btnSalir" runat="server" Text="Regresar" CssClass="menuButton" OnClick="btnSalir_Click"/>
                            <br />
                            <br />
        </div>
            <br />
        </form>
    </div>
</body>
</html>
