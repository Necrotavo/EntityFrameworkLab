<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productInsert.aspx.cs" Inherits="EntityFrameworkLab.productInsert" %>

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
                            <asp:Label ID="lblError" runat="server" CssClass="labelError"></asp:Label>
                            <br />
                            <h1 style="text-align:center">Datos del producto</h1>
                            <br />
                            <br />
            <asp:Label ID="lblCod" runat="server" Text="Codigo:" CssClass="label"></asp:Label>
            &nbsp;
            <asp:TextBox ID="TextBox1" runat="server" CssClass="textBox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="***"></asp:RequiredFieldValidator>
            <br />  
            <asp:Label ID="lblDesc" runat="server" Text="Descripcion:" CssClass="label"></asp:Label>     
            &nbsp;
            <asp:TextBox ID="TextBox2" runat="server" CssClass="textBox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="***"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblPrice" runat="server" Text="Precio:" CssClass="label"></asp:Label>     
            &nbsp;
            <asp:TextBox ID="TextBox3" runat="server" CssClass="textBox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="***"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblCantidad" runat="server" Text="Cantidad:" CssClass="label"></asp:Label>     
            &nbsp;
            <asp:TextBox ID="TextBox4" runat="server" CssClass="textBox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="***"></asp:RequiredFieldValidator>
      <br />
                            <asp:Button ID="btnExecute" runat="server" Text="Agregar" CssClass="menuButton" OnClick="btnExecute_Click"/>
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
