<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Traslado.aspx.cs" Inherits="WebTrasladista_consumeWCF.Traslado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btnCargarOperador" runat="server" OnClick="btnCargarOperador_Click" Text="Mostrar Operadores" />
        <br />
        <asp:DropDownList ID="cmbOperador" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lbConexion" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
