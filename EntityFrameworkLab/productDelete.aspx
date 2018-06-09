<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productDelete.aspx.cs" Inherits="EntityFrameworkLab.productDelete" %>

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
                            <h1 style="text-align:center">Eliminar producto</h1>
                            <br />
            <asp:Label ID="lblCod" runat="server" Text="Codigo:" CssClass="label"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="dropClients" runat="server" CssClass="menuButton" AutoPostBack="True" ></asp:DropDownList>
            <br />  
      <br />
                            <asp:Button ID="btnExecute" runat="server" Text="Eliminar" CssClass="menuButton" OnClick="btnExecute_Click"/>
        </div>
            <br />
        </form>
    </div>
</body>
</html>
