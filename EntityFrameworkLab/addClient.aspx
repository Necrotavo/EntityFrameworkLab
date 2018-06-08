<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddClient.aspx.cs" Inherits="EntityFrameworkLab.Clientes" %>

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
                            <h1 style="text-align:center">Datos del cliente</h1>
                            <br />
                            <br />
                            <asp:Label ID="lblCed" runat="server" Text="Cedula:" CssClass="label"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="textBox" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblName" runat="server" Text="Nombre:" CssClass="label"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;     
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="textBox"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblLastName" runat="server" Text="Apellido:" CssClass="label"></asp:Label>
            &nbsp;&nbsp;&nbsp;     
                            <asp:TextBox ID="TextBox3" runat="server" CssClass="textBox"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblMail" runat="server" Text="Correo:" CssClass="label"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;     
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="textBox"></asp:TextBox>
                            <br />
                            <asp:Label ID="Label1" runat="server" Text="Telefono:" CssClass="label"></asp:Label>
            &nbsp;&nbsp;&nbsp;     
                            <asp:TextBox ID="TextBox5" runat="server" CssClass="textBox"></asp:TextBox>
                            <br />
                            <br />
                            <br />
                            <asp:Button ID="btnAdd" runat="server" Text="Agregar" CssClass="menuButton"/>
                            <br />
                            <br />
        </div>
            <br />
        </form>
    </div>
    
</body>
</html>
