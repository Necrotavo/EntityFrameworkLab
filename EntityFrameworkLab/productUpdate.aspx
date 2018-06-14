<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productUpdate.aspx.cs" Inherits="EntityFrameworkLab.productUpdate" %>

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
                            <h1 style="text-align:center">&nbsp;</h1>
                            <h1 style="text-align:center">Datos del producto</h1>
                            <asp:Label ID="lblError" runat="server" CssClass="labelError"></asp:Label>
                            <br />
                            <br />
            <asp:Label ID="lblCod" runat="server" Text="Codigo:" CssClass="label"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="dropClients" runat="server" CssClass="menuButton" AutoPostBack="True" OnSelectedIndexChanged="dropClients_SelectedIndexChanged"></asp:DropDownList>
            <br />  
            <asp:Label ID="lblDesc" runat="server" Text="Descripcion:" CssClass="label"></asp:Label>     
            &nbsp;
            <asp:TextBox ID="TextBox2" runat="server" CssClass="textBox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblPrice" runat="server" Text="Precio:" CssClass="label"></asp:Label>     
            &nbsp;
            <asp:TextBox ID="TextBox3" runat="server" CssClass="textBox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="Numerico requerido"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblCantidad" runat="server" Text="Cantidad:" CssClass="label"></asp:Label>     
            &nbsp;
            <asp:TextBox ID="TextBox4" runat="server" CssClass="textBox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox4" ErrorMessage="Numerico requerido"></asp:RequiredFieldValidator>
      <br />
                            <asp:Button ID="btnExecute" runat="server" Text="Actualizar" CssClass="menuButton" OnClick="btnExecute_Click"/>
                            <br />
                            <br />
                            <asp:Button ID="BtnSalir" runat="server" Text="Regresar" CssClass="menuButton" OnClick="BtnSalir_Click" />
                            <br />
                            <br />
        </div>
            <br />
        </form>
    </div>
</body>
</html>
