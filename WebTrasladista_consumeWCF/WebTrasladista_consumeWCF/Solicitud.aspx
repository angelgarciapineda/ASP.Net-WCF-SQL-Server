<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Solicitud.aspx.cs" Inherits="WebTrasladista_consumeWCF.Solicitud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ho+j7jyWK8fNQe+A12Hb8AhRq26LrZ/JpcUGGOn+Y7RsweNrtN/tE3MoK7ZeZDyx" crossorigin="anonymous"></script>
    <title>Solicitud del servicio</title>
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-light bg-dark">
        <a class="navbar-brand" href="#">Navbar</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                    <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#">Link</a>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Dropdown
                    </a>
                    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                        <a class="dropdown-item" href="#">Action</a>
                        <a class="dropdown-item" href="#">Another action</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="#">Something else here</a>
                    </div>
                </li>
                <li class="nav-item">
                    <a class="nav-link disabled" href="#" tabindex="-1" aria-disabled="true">Disabled</a>
                </li>
            </ul>
            <form class="form-inline my-2 my-lg-0">
                <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search" />
                <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
            </form>
        </div>
    </nav>

    <form id="form1" runat="server" autocomplete="off">
        <div class="card">
            <div class="card-header">
                Home
            </div>
            <div class="card-body">
                <h5 class="card-title">Special title treatment</h5>
                <div class="row">
                    <%-- Tarjeta lateral izquierda --%>
                    <div class="col-2">
                        <div class="nav flex-column nav-pills" id="v-pills-tab" role="tablist" aria-orientation="vertical">
                            <a>
                                <div class="card">
                                    <img src="https://cdn.icon-icons.com/icons2/67/PNG/512/user_13230.png" class="card-img-top" alt="..." />
                                    <div class="card-body">
                                        <h5 class="card-title">Administrador</h5>
                                        <p class="card-text">Kelly Joy Hernández</p>
                                        <a href="#" class="btn btn-primary">Configuración</a>
                                    </div>
                                </div>
                            </a>
                            <a class="nav-link active" id="v-pills-solicitud-tab" data-toggle="pill" href="#v-pills-solicitud" role="tab" aria-controls="v-pills-solicitud" aria-selected="true">Solicitar servicio</a>
                            <a class="nav-link" id="v-pills-misservicios-tab" data-toggle="pill" href="#v-pills-misservicios" role="tab" aria-controls="v-pills-misservicios" aria-selected="false">Mis servicios</a>
                        </div>
                    </div>
                    <%-- Tarjeta central --%>
                    <div class="col-10">
                        <div class="tab-content" id="v-pills-tabContent">
                            <%-- INICIO PANEL DE HOME --%>
                            <div class="tab-pane fade show active" id="v-pills-solicitud" role="tabpanel" aria-labelledby="v-pills-solicitud-tab">
                                <div class="card-body">
                                    <div class="alert alert-dark" role="alert">
                                        <asp:Label ID="lbRespuesta" runat="server" Text="Label"></asp:Label>
                                    </div>
                                    <div class="card">
                                        <div class="card-header">
                                            Solicitar servicio de traslado
                                        </div>
                                        <div class="card-body">
                                            <div class="row">

                                                <div class="col-4">
                                                    <div class="form-group">
                                                        <asp:Label ID="Label1" runat="server" Text="Agregar destinos" class="h4"></asp:Label>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:RadioButton ID="rdOrigen" runat="server" Text=" Origen" GroupName="RadioGroup1" Checked="true" />
                                                        <asp:RadioButton ID="rdDestino" runat="server" Text=" Destino" GroupName="RadioGroup1" />
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Label ID="Label6" runat="server" Text="Nombre de sucursal"></asp:Label>
                                                        <asp:TextBox ID="txtSucursal" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Label ID="Label7" runat="server" Text="Calle"></asp:Label>
                                                        <asp:TextBox ID="txtCalle" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-group col-md-6">
                                                            <asp:Label ID="Label12" runat="server" Text="N° exterior"></asp:Label>
                                                            <asp:TextBox ID="txtNumExt" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-6">
                                                            <asp:Label ID="Label13" runat="server" Text="N° interior"></asp:Label>
                                                            <asp:TextBox ID="txtNumInt" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Label ID="Label14" runat="server" Text="Colonia"></asp:Label>
                                                        <asp:TextBox ID="txtColonia" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-group col-md-6">
                                                            <asp:Label ID="Label15" runat="server" Text="CP"></asp:Label>
                                                            <asp:TextBox ID="txtCP" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-6">
                                                            <asp:Label ID="Label16" runat="server" Text="Ciudad"></asp:Label>
                                                            <asp:TextBox ID="txtCiudad" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Label ID="Label17" runat="server" Text="Estado: "></asp:Label>
                                                        <asp:TextBox ID="txtEstado" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Button ID="btnGuardarAgencias" runat="server" Text="Guardar" class="btn btn-block btn-success" OnClick="btnGuardarAgencias_Click" />
                                                    </div>
                                                </div>

                                                <div class="col-8">
                                                    <div class="row">
                                                        <div class="col-6">
                                                            <div class="card text-white bg-primary mb-3">
                                                                <div class="card-header">
                                                                    <asp:Label ID="Label32" runat="server" Text="Agencia de origen: "></asp:Label>
                                                                    <asp:Label ID="lbSucursalOrigen" runat="server"></asp:Label>
                                                                </div>
                                                                <div class="card-body">
                                                                    <div class="form-group">
                                                                        <asp:Label ID="Label5" runat="server" Text="Calle: "></asp:Label>
                                                                        <asp:Label ID="lbCalleOrigen" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="Label18" runat="server" Text="N° exterior: "></asp:Label>
                                                                        <asp:Label ID="lbNumExtOrigen" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="Label19" runat="server" Text="N° interior: "></asp:Label>
                                                                        <asp:Label ID="lbNumIntOrigen" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="Label20" runat="server" Text="Colonia: "></asp:Label>
                                                                        <asp:Label ID="lbColOrigen" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="Label21" runat="server" Text="C.P.: "></asp:Label>
                                                                        <asp:Label ID="lbCPOrigen" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="Label22" runat="server" Text="Ciudad: "></asp:Label>
                                                                        <asp:Label ID="lbCiudadOrigen" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="Label23" runat="server" Text="Estado: "></asp:Label>
                                                                        <asp:Label ID="lbEstadoOrigen" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Button ID="btnEditarOrigen" runat="server" Text="Editar" class="btn btn-light" Style="float: right;" OnClick="btnEditarOrigen_Click" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-6">
                                                            <div class="card text-white bg-danger mb-3">
                                                                <div class="card-header">
                                                                    <asp:Label ID="Label24" runat="server" Text="Agencia de destino: "></asp:Label>
                                                                    <asp:Label ID="lbSucursalDestino" runat="server"></asp:Label>
                                                                </div>
                                                                <div class="card-body">
                                                                    <div class="form-group">
                                                                        <asp:Label ID="Label25" runat="server" Text="Calle: "></asp:Label>
                                                                        <asp:Label ID="lbCalleDestino" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="Label26" runat="server" Text="N° exterior: "></asp:Label>
                                                                        <asp:Label ID="lbNumExtDestino" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="Label27" runat="server" Text="N° interior: "></asp:Label>
                                                                        <asp:Label ID="lbNumIntDestino" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="Label28" runat="server" Text="Colonia: "></asp:Label>
                                                                        <asp:Label ID="lbColDestino" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="Label29" runat="server" Text="C.P: "></asp:Label>
                                                                        <asp:Label ID="lbCPDestino" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="Label30" runat="server" Text="Ciudad"></asp:Label>
                                                                        <asp:Label ID="lbCiudadDestino" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Label ID="Label31" runat="server" Text="Estado"></asp:Label>
                                                                        <asp:Label ID="lbEstadoDestino" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Button ID="btnEditarDestino" runat="server" Text="Editar" class="btn btn-light" Style="float: right;" OnClick="btnEditarDestino_Click" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-6">
                                            <%-- TARJETA DE SOLICITUD DE SERVICIO --%>
                                            <div class="card">
                                                <div class="card-header">
                                                    Calcular gasto de servicio
                                                </div>
                                                <div class="card-body">
                                                    <div class="form-row">
                                                        <div class="form-group col-md-6">
                                                            <asp:Label ID="Label2" runat="server" Text="Kilometros de transporte"></asp:Label>
                                                            <asp:TextBox ID="txtKm" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="form-row">
                                                        <div class="form-group col-md-6">
                                                            <asp:Label for="inputAddress" ID="Label3" runat="server" Text="Duración de transporte"></asp:Label>
                                                            <asp:TextBox ID="txtTiempoTransporte" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-6">
                                                            <asp:Label ID="Label4" runat="server" Text="Costo de transporte : ????"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <asp:Label ID="Label8" runat="server" Text="Restricciones"></asp:Label>
                                                        <asp:TextBox ID="txtRestriccion" runat="server" class="form-control"></asp:TextBox>
                                                    </div>

                                                    <div class="form-group">
                                                        <asp:Label ID="Label9" runat="server" Text="Necesidades"></asp:Label>
                                                        <asp:TextBox ID="txtNecesidad" runat="server" class="form-control"></asp:TextBox>
                                                    </div>

                                                    <div class="form-row">
                                                        <div class="form-group col-md-6">
                                                            <asp:Button ID="btnCargaVehiculo" runat="server" Text="Vehiculos disponibles" class="btn btn-primary btn-block" OnClick="btnCargaVehiculo_Click" />
                                                        </div>
                                                        <div class="form-group col-md-6">
                                                            <asp:DropDownList ID="cmbVehiculo" runat="server" class="form-control"></asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <div class="form-row">
                                                        <div class="form-group col-md-6">
                                                            <asp:Label ID="Label11" runat="server" Text="Cantidad"></asp:Label>
                                                            <asp:TextBox ID="txtcantidad" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <asp:Button ID="btnagregar" runat="server" Text="Añadir" class="btn btn-success btn-block" OnClick="btnagregar_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                            <%-- FIN TARJETA DE SOLICITUD DE SERVICIOO --%>
                                        </div>
                                        <div class="col-6">
                                            <%-- INICIO TARJETA DE SOLICITUD DE SERVICIO --%>
                                            <div class="card">
                                                <div class="card-header">
                                                    <asp:Label ID="lbGastoServicio" runat="server" Text="Añadir más vehiculos: "></asp:Label>
                                                </div>
                                                <div class="card-body">
                                                    <p class="card-text">¿Desea añadir más vehiculos?</p>
                                                    <asp:DropDownList ID="cmbVehiculoExtra" runat="server" class="form-control"></asp:DropDownList>

                                                    <div class="form-row">
                                                        <div class="form-group col-md-6">
                                                            <asp:Label ID="Label10" runat="server" Text="Cantidad"></asp:Label>
                                                            <asp:TextBox class="form-control" ID="txtCantidadExtra" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <asp:Button class="btn btn-success btn-block " ID="btnAgregarExtra" runat="server" Text="Añadir" OnClick="btnAgregarExtra_Click" />
                                                    </div>

                                                    <div class="form-group">
                                                        <p class="card-text">Tipo de servicio</p>
                                                        <asp:DropDownList ID="cmbTipoServicio" runat="server" class="form-control"></asp:DropDownList>

                                                    </div>
                                                    <!-- Button trigger modal -->
                                                    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#staticBackdrop">
                                                        Guardar datos
                                                    </button>

                                                    <!-- Modal -->
                                                    <div class="modal fade" id="staticBackdrop" data-backdrop="static" data-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                                                        <div class="modal-dialog">
                                                            <div class="modal-content">
                                                                <div class="modal-header">
                                                                    <h5 class="modal-title" id="staticBackdropLabel">Confirmar servicio de traslado</h5>
                                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                        <span aria-hidden="true">&times;</span>
                                                                    </button>
                                                                </div>
                                                                <div class="modal-body">
                                                                    Dar click en botón "Solicitar servicio" para confirmar los datos y solicitar servicio de traslado.
                                                                </div>
                                                                <div class="modal-footer">
                                                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                                                                    <asp:Button class="btn btn-success" ID="btnGuardarServicio" runat="server" Text="Solicitar servicio" OnClick="btnGuardarServicio_Click" />

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <%-- FIN TARJETA DE SOLICITUD DE SERVICIO --%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%-- FIN PANEL DE HOME --%>
                            <%-- INICIO PANEL DE REGISTROS --%>
                            <div class="tab-pane fade" id="v-pills-misservicios" role="tabpanel" aria-labelledby="v-pills-misservicios-tab">Este div es test 2</div>
                            <%-- FIN DE PANEL REGISTROS --%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
