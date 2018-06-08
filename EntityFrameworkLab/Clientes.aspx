<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="EntityFrameworkLab.Clientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>

<body>
    <div style="overflow: hidden">
            <form id="form1" runat="server">

        <div class="column">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="Radios">
                <asp:ListItem Text="Insertar" Value="1"></asp:ListItem>
                <asp:ListItem Text="Modificar" Value="2"></asp:ListItem>
                <asp:ListItem Text="Consultar" Value="3"></asp:ListItem>
                <asp:ListItem Text="Eliminar" Value="4"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
                        <div class="column">
            <asp:Label ID="lblCed" runat="server" Text="Cedula:" CssClass="label"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" CssClass="textBox"></asp:TextBox>
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

        </div>
            <br />
                <div class="midDiv">
                    <asp:Label ID="Label2" runat="server" Text="Aqui va el grid"></asp:Label>
                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
        </form>
    </div>
    
</body>
</html>
