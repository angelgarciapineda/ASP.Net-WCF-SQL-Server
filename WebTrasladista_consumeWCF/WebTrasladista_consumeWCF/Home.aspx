<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebTrasladista_consumeWCF.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ho+j7jyWK8fNQe+A12Hb8AhRq26LrZ/JpcUGGOn+Y7RsweNrtN/tE3MoK7ZeZDyx" crossorigin="anonymous"></script>
    <title>Servicios</title>
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

    <form id="form1" runat="server">
        <div class="card">
            <div class="card-header">
                Home
            </div>
            <div class="card-body">
                <h5 class="card-title">Special title treatment</h5>
                <div class="row">
                    <%-- Tarjeta lateral izquierda --%>
                    <div class="col-3">
                        <div class="nav flex-column nav-pills" id="v-pills-tab" role="tablist" aria-orientation="vertical">
                            <a>
                                <div class="card">
                                    <img src="https://cdn.icon-icons.com/icons2/67/PNG/512/user_13230.png" class="card-img-top" alt="..." />
                                    <div class="card-body">
                                        <h5 class="card-title">Administrador</h5>
                                        <p class="card-text">Luis Angel Garcia Pineda</p>
                                        <a href="#" class="btn btn-primary">Configuración</a>
                                    </div>
                                </div>
                            </a>
                            <a class="nav-link active" id="v-pills-home-tab" data-toggle="pill" href="#v-pills-home" role="tab" aria-controls="v-pills-home" aria-selected="true">Servicio</a>
                            <a class="nav-link" id="v-pills-profile-tab" data-toggle="pill" href="#v-pills-profile" role="tab" aria-controls="v-pills-profile" aria-selected="false">Registros</a>
                            <a class="nav-link" id="v-pills-messages-tab" data-toggle="pill" href="#v-pills-messages" role="tab" aria-controls="v-pills-messages" aria-selected="false">Estadisticas</a>
                            <a class="nav-link" id="v-pills-settings-tab" data-toggle="pill" href="#v-pills-settings" role="tab" aria-controls="v-pills-settings" aria-selected="false">Base de datos</a>
                            <a class="nav-link" id="v-pills-logout-tab" data-toggle="pill" href="#v-pills-settings" role="tab" aria-controls="v-pills-settings" aria-selected="false">Cerrar sesión</a>
                        </div>
                    </div>
                    <%-- Tarjeta central --%>
                    <div class="col-9">
                        <div class="tab-content" id="v-pills-tabContent">
                            <%-- INICIO PANEL DE HOME --%>
                            <div class="tab-pane fade show active" id="v-pills-home" role="tabpanel" aria-labelledby="v-pills-home-tab">
                                <div class="card-body">
                                    <div class="alert alert-dark" role="alert">
                                        <asp:Label ID="lbRespuesta" runat="server" Text="Label"></asp:Label>
                                    </div>
                                    <div class="row">
                                        <div class="col-6">
                                            <%-- TARJETA DE CALCULAR GASTO DE SERVICIO --%>
                                            <div class="card">
                                                <div class="card-header">
                                                    Calcular gasto de servicio
                                                </div>
                                                <div class="card-body">
                                                    <div class="form-row">
                                                        <div class="form-group col-md-6">
                                                            <asp:Button ID="btnCargarOperador" runat="server" OnClick="btnCargarOperador_Click" class="btn btn-primary btn-block" Text="Operadores disponible" />
                                                        </div>
                                                        <div class="form-group col-md-6">
                                                            <asp:DropDownList ID="cmbOperador" runat="server" class="form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-group col-md-6">
                                                            <asp:Label ID="Label1" runat="server" Text="Duracion"></asp:Label>
                                                            <asp:TextBox ID="txtduracion" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-6">
                                                            <asp:Label ID="Label2" runat="server" Text="Kilometros"></asp:Label>
                                                            <asp:TextBox ID="txtkm" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-group col-md-6">
                                                            <asp:Label for="inputAddress" ID="Label3" runat="server" Text="Tiempo de transporte"></asp:Label>
                                                            <asp:TextBox ID="txttiempotrans" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-6">
                                                            <asp:Label ID="Label4" runat="server" Text="Costo de transporte"></asp:Label>
                                                            <asp:TextBox ID="txtcontroltrans" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-group col-md-6">
                                                            <asp:Label ID="Label5" runat="server" Text="Sueldo"></asp:Label>
                                                            <asp:TextBox ID="txtsueldo" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-6">
                                                            <asp:Label ID="Label6" runat="server" Text="Salario"></asp:Label>
                                                            <asp:TextBox ID="txtsalario" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Label ID="Label7" runat="server" Text="Costo de casetas"></asp:Label>
                                                        <asp:TextBox ID="txtcostocaseta" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Label ID="Label8" runat="server" Text="Restricciones"></asp:Label>
                                                        <asp:TextBox ID="txtrestri" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Label ID="Label9" runat="server" Text="Necesidades"></asp:Label>
                                                        <asp:TextBox ID="txtneces" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-group col-md-6">
                                                            <asp:Button ID="btnCargaVehiculo" runat="server" Text="Vehiculos disponibles" class="btn btn-block btn-primary" OnClick="btnCargaVehiculo_Click" />
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
                                                        <div class="form-group col-md-6">
                                                            <asp:Label ID="Label12" runat="server" Text="Precio"></asp:Label>
                                                            <asp:TextBox ID="txtprecio" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Button ID="btnagregar" runat="server" Text="Añadir" class="btn btn-primary btn-block" OnClick="btnagregar_Click" />
                                                        <%--                                        <asp:Button ID="btnguardar" runat="server" Text="Guardar" class="btn btn-primary" />--%>
                                                    </div>
                                                </div>
                                            </div>
                                            <%-- FIN TARJETA DE CALCULAR GASTO DE SERVICIO --%>
                                        </div>
                                        <div class="col-6">
                                            <%-- INICIO TARJETA DETALLE DE SERVICIO --%>
                                            <div class="card">
                                                <div class="card-header">
                                                    <asp:Label ID="lbGastoServicio" runat="server" Text="Gasto de servicio: "></asp:Label>
                                                </div>
                                                <div class="card-body">
                                                    <h5 class="card-title">Honda Civic Type-R</h5>
                                                    <p class="card-text">Operador asignado: </p>
                                                    <p class="card-text">¿Desea añadir más vehiculos?</p>
                                                    <asp:DropDownList ID="cmbVehiculoExtra" runat="server" class="form-control"></asp:DropDownList>
                                                    <div class="form-row">
                                                        <div class="form-group col-md-6">
                                                            <asp:Label ID="Label10" runat="server" Text="Cantidad"></asp:Label>
                                                            <asp:TextBox class="form-control" ID="txtCantidadExtra" runat="server"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-6">
                                                            <asp:Label ID="Label13" runat="server" Text="Precio"></asp:Label>
                                                            <asp:TextBox class="form-control" ID="txtPrecioExtra" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <asp:Button class="btn btn-primary btn-block " ID="btnAgregarExtra" runat="server" Text="Añadir" OnClick="btnAgregarExtra_Click" />
                                                        <p class="card-text">Agencia origen</p>
                                                        <asp:DropDownList ID="cmbOrigen" runat="server" class="form-control"></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <p class="card-text">Agencia destino</p>
                                                        <asp:DropDownList ID="cmbDestino" runat="server" class="form-control"></asp:DropDownList>
                                                        <p class="card-text">Tipo de servicio</p>
                                                        <asp:DropDownList ID="cmbTipoServicio" runat="server" class="form-control"></asp:DropDownList>

                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Button class="btn btn-primary" ID="btnGuardarServicio" runat="server" Text="Guardar datos" OnClick="btnGuardarServicio_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                            <%-- FIN TARJETA DE DETALLE DE SERVICIO --%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%-- FIN PANEL DE HOME --%>
                            <%-- INICIO PANEL DE REGISTROS --%>
                            <div class="tab-pane fade" id="v-pills-profile" role="tabpanel" aria-labelledby="v-pills-profile-tab">Este div es test 2</div>
                            <%-- FIN DE PANEL REGISTROS --%>
                            <%-- INICIO PANEL DE ESTADISTICAS --%>
                            <div class="tab-pane fade" id="v-pills-messages" role="tabpanel" aria-labelledby="v-pills-messages-tab">Este div es test 3</div>
                            <%-- FIN DE PANEL DE ESTADISTICAS --%>
                            <%-- INICIO PANEL DE BASE DE DATOS --%>
                            <div class="tab-pane fade" id="v-pills-settings" role="tabpanel" aria-labelledby="v-pills-settings-tab">Este div es test 4</div>
                            <%-- FIN DE PANEL DE BASE DE DATOS --%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
