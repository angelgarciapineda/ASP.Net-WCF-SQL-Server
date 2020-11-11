<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebTrasladista_consumeWCF.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <!-- Bootstrap CSS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ho+j7jyWK8fNQe+A12Hb8AhRq26LrZ/JpcUGGOn+Y7RsweNrtN/tE3MoK7ZeZDyx" crossorigin="anonymous"></script>
    <!-- Font Awesome CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous" />
    <link href="css/Login.css" rel="stylesheet" />
    <title></title>
</head>
<body class="row m-0 justify-content-center align-items-center vh-100">
    <form id="form1" runat="server" style="width: 50%;" autocomplete="off">
        <div class="card bg-primary">
            <div class="row no-gutters">
                <div class="col-md-6 bg-dark">
                    <img src="https://static.wixstatic.com/media/32246b_73666df3db6b4ea38a04bead0960de04~mv2.png/v1/fill/w_200,h_108,al_c,q_85,usm_0.66_1.00_0.01/32246b_73666df3db6b4ea38a04bead0960de04~mv2.webp" class="card-img" alt="..." />
                </div>
                <div class="col-md-6 bg-dark">
                    <!--Tarjeta de login-->
                    <div class="card bg-dark">
                        <div class="card-header text-white">
                            Login
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="Email address" class="text-white"></asp:Label>
                                <!-- Cuadro gris en textbox-->
                                <div class="input-group flex-nowrap">
                                    <div class="input-group-prepend">
                                        <!--icono-->
                                        <span class="input-group-text">
                                            <span class="fa fa-user-circle" aria-hidden="true"></span>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" aria-describedby="emailHelp"></asp:TextBox>
                                </div>

                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label2" runat="server" Text="Password" class="text-white"></asp:Label>
                                <!-- Cuadro gris en textbox-->
                                <div class="input-group flex-nowrap">
                                    <div class="input-group-prepend">
                                        <!--icono-->
                                        <span class="input-group-text">
                                            <span class="fa fa-key" aria-hidden="true"></span>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <button type="button" class="btn btn-light" data-toggle="modal" data-target="#exampleModal" data-whatever="@mdo">Registrarse</button>
                                <asp:Button Style="float: right;" ID="btnSignin" runat="server" Text="Ingresar" class="btn btn-primary" OnClick="btnSignin_Click" />
                            </div>
                            <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                <div class="modal-dialog modal-lg">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title" id="exampleModalLabel">Registro</h5>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>
                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="form-group col-4">
                                                    <asp:Label ID="Label3" runat="server" Text="Nombre" class="col-form-label"></asp:Label>
                                                    <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-4">
                                                    <asp:Label ID="Label4" runat="server" Text="Appelido paterno" class="col-form-label"></asp:Label>
                                                    <asp:TextBox ID="txtPaterno" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-4">
                                                    <asp:Label ID="Label5" runat="server" Text="Apellido materno" class="col-form-label"></asp:Label>
                                                    <asp:TextBox ID="txtMaterno" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="form-group col-4">
                                                    <asp:Label ID="Label6" runat="server" Text="RFC" class="col-form-label"></asp:Label>
                                                    <asp:TextBox ID="txtRfc" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-4">
                                                    <asp:Label ID="Label8" runat="server" Text="Edad" class="col-form-label"></asp:Label>
                                                    <asp:TextBox ID="txtEdad" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="form-group col-8">
                                                    <asp:Label ID="Label7" runat="server" Text="Email" class="col-form-label"></asp:Label>
                                                    <asp:TextBox ID="txtEmailR" runat="server" class="form-control" type="email" aria-describedby="emailHelp"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="form-group col-4">
                                                    <asp:Label ID="Label9" runat="server" Text="Contraseña" class="col-form-label"></asp:Label>
                                                    <asp:TextBox ID="txtPasswordR" runat="server" class="form-control" type="password"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-4">
                                                    <asp:Label ID="Label10" runat="server" Text="Confirmar contraseña" class="col-form-label"></asp:Label>
                                                    <asp:TextBox ID="txtConfirmaPass" runat="server" class="form-control" type="password"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-4">
                                                    <asp:Label ID="lbConfirmacion" runat="server" class="col-form-label"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                                            <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" class="btn btn-success" OnClick="btnRegistrarse_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:Label ID="lbError" runat="server" class="form-control text-white bg-danger" Visible="false"></asp:Label>
        <asp:Label ID="lbSuccess" runat="server" class="form-control text-white bg-success" Visible="false"></asp:Label>
    </form>
</body>
</html>
