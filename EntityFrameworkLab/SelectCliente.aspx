<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectCliente.aspx.cs" Inherits="EntityFrameworkLab.SelectCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <div style="overflow: hidden">
            <form id="form1" runat="server">

                        <div class="MainDiv">
                            <br />
                            <br />
                            <h1 style="text-align:center">Datos del cliente</h1>
                            <br />
                            <br />
                            <asp:Label ID="lblCed" runat="server" Text="Cedula:" CssClass="label"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="ddlCedulas" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="ddlCedulas_SelectedIndexChanged" Width="173px">
                            </asp:DropDownList>
                            <br />
                            <asp:Label ID="lblName" runat="server" Text="Nombre:" CssClass="label"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;     
                            <asp:TextBox ID="txtName" runat="server" CssClass="textBox"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblLastName" runat="server" Text="Apellido:" CssClass="label"></asp:Label>
            &nbsp;&nbsp;&nbsp;     
                            <asp:TextBox ID="txtLastName" runat="server" CssClass="textBox"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblMail" runat="server" Text="Correo:" CssClass="label"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;     
                            <asp:TextBox ID="txtMail" runat="server" CssClass="textBox"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblTelefono" runat="server" Text="Telefono:" CssClass="label"></asp:Label>
            &nbsp;&nbsp;&nbsp;     
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="textBox"></asp:TextBox>
                            <br />
                            <br />
        </div>
            <br />
        </form>
    </div>
</body>
</html>
