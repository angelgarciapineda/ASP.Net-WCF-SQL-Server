<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Traslado.aspx.cs" Inherits="WebTrasladista_consumeWCF.Traslado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous" />

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-row">
            <div class="form-group col-md-4">
                <asp:Button ID="btnCargarOperador" runat="server" OnClick="btnCargarOperador_Click" class="btn btn-primary" Text="Mostrar Operadores" />
                <br />
                <asp:DropDownList ID="cmbOperador" runat="server" class="form-control">
                </asp:DropDownList>
                <asp:Label ID="lbConexion" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="Label1" runat="server" Text="Duracion"></asp:Label>
                <asp:TextBox ID="txtduracion" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="Label2" runat="server" Text="Kilometros"></asp:Label>
                <asp:TextBox ID="txtkm" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label for="inputAddress" ID="Label3" runat="server" Text="Tiempo de transporte"></asp:Label>
            <asp:TextBox ID="txttiempotrans" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="Label4" runat="server" Text="Costo de transporte" class="form-control"></asp:Label>
            <asp:TextBox ID="txtcontroltrans" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-row">
            <div class="form-group col-md-6">
                <asp:Label ID="Label5" runat="server" Text="Sueldo" class="form-control"></asp:Label>
                <asp:TextBox ID="txtsueldo" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="Label6" runat="server" Text="Salario" class="form-control"></asp:Label>
                <asp:TextBox ID="txtsalario" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label7" runat="server" Text="Costo de casetas" class="form-control"></asp:Label>
            <asp:TextBox ID="txtcostocaseta" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="Label8" runat="server" Text="Restricciones" class="form-control"></asp:Label>
            <asp:TextBox ID="txtrestri" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="Label9" runat="server" Text="Necesidades" class="form-control"></asp:Label>
            <asp:TextBox ID="txtneces" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="Label10" runat="server" Text="Vehiculo" class="form-control"></asp:Label>
            <asp:DropDownList ID="cmbVehiculo" runat="server" class="form-control"></asp:DropDownList>
            <asp:Button ID="btnagregar" runat="server" Text="Añadir" class="btn btn-primary" OnClick="btnagregar_Click"/>
        </div>
        <div class="form-row">
            <div class="form-group col-md-6">
                <asp:Label ID="Label11" runat="server" Text="Cantidad" class="form-control"></asp:Label>
                <asp:TextBox ID="txtcantidad" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="Label12" runat="server" Text="Precio" class="form-control"></asp:Label>
                <asp:TextBox ID="txtprecio" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Button ID="btnguardar" runat="server" Text="Guardar" class="btn btn-primary"/>
        </div>
    </form>
</body>
</html>
