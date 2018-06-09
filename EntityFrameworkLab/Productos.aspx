<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="EntityFrameworkLab.Productos" %>

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
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="Radios" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                <asp:ListItem Text="Insertar" Value="1"></asp:ListItem>
                <asp:ListItem Text="Modificar" Value="2"></asp:ListItem>
                <asp:ListItem Text="Consultar" Value="3"></asp:ListItem>
                <asp:ListItem Text="Eliminar" Value="4"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
                        <div class="column">
            <asp:Label ID="lblCod" runat="server" Text="Codigo:" CssClass="label"></asp:Label>
            &nbsp;
            <asp:TextBox ID="TextBox1" runat="server" CssClass="textBox" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <br />  
            <asp:Label ID="lblDesc" runat="server" Text="Descripcion:" CssClass="label"></asp:Label>     
            &nbsp;
            <asp:TextBox ID="TextBox2" runat="server" CssClass="textBox"></asp:TextBox>
            <br />
            <asp:Label ID="lblPrice" runat="server" Text="Precio:" CssClass="label"></asp:Label>     
            &nbsp;
            <asp:TextBox ID="TextBox3" runat="server" CssClass="textBox"></asp:TextBox>
            <br />
            <asp:Label ID="lblCantidad" runat="server" Text="Cantidad:" CssClass="label"></asp:Label>     
            &nbsp;
            <asp:TextBox ID="TextBox4" runat="server" CssClass="textBox"></asp:TextBox>
      <br />
                            <asp:Button ID="btnExecute" runat="server" Text="Ejecutar" CssClass="menuButton" OnClick="btnExecute_Click"/>
       
        </div>

            <br />
                <br />
                <div class="midDiv">
                    <asp:Label ID="Label2" runat="server" Text="Aqui va el grid"></asp:Label>
                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
        </form>
    </div>
    
</body>
</html>

