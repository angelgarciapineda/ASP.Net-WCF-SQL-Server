<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebTrasladista_consumeWCF.Register" %>

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
    <title></title>
</head>
<body class="row m-0 justify-content-center align-items-center vh-100">
    <form id="form1" runat="server" style="width: 50%;" autocomplete="off">
        <!--Tarjeta de login-->
        <div class="card bg-dark">
            <div class="card-header text-white">
                Register
            </div>
            <div class="card-body">
                <div class="form-row">
                    <!--Textbox de Nombre-->
                    <div class="form-group col-md-4">
                        <asp:Label ID="Label1" runat="server" Text="Nombre" class="text-white"></asp:Label>
                        <!-- Cuadro gris en textbox-->
                        <div class="input-group flex-nowrap">
                            <div class="input-group-prepend">
                                <!--icono-->
                                <span class="input-group-text">
                                    <span class="fa fa-user-circle" aria-hidden="true"></span>
                                </span>
                            </div>
                            <asp:TextBox ID="txtNombre" runat="server" class="form-control" aria-describedby="emailHelp"></asp:TextBox>
                        </div>
                    </div>
                    <!--Textbox de Appellido paterno-->
                    <div class="form-group  col-md-4">
                        <asp:Label ID="Label3" runat="server" Text="Appellido paterno" class="text-white"></asp:Label>
                        <!-- Cuadro gris en textbox-->
                        <div class="input-group flex-nowrap">
                            <div class="input-group-prepend">
                                <!--icono-->
                                <span class="input-group-text">
                                    <span class="fa fa-user-circle" aria-hidden="true"></span>
                                </span>
                            </div>
                            <asp:TextBox ID="txtPaterno" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <!--Textbox de Appellido materno-->
                    <div class="form-group   col-md-4">
                        <asp:Label ID="Label4" runat="server" Text="Appellido materno" class="text-white"></asp:Label>
                        <!-- Cuadro gris en textbox-->
                        <div class="input-group flex-nowrap">
                            <div class="input-group-prepend">
                                <!--icono-->
                                <span class="input-group-text">
                                    <span class="fa fa-user-circle" aria-hidden="true"></span>
                                </span>
                            </div>
                            <asp:TextBox ID="txtMaterno" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <!--Textbox de RFC-->
                    <div class="form-group col-md-6">
                        <asp:Label ID="Label5" runat="server" Text="RFC" class="text-white"></asp:Label>
                        <!-- Cuadro gris en textbox-->
                        <div class="input-group flex-nowrap">
                            <div class="input-group-prepend">
                                <!--icono-->
                                <span class="input-group-text">
                                    <span class="fa fa-user-circle" aria-hidden="true"></span>
                                </span>
                            </div>
                            <asp:TextBox ID="txtRfc" runat="server" class="form-control" maxlength="8"></asp:TextBox>
                        </div>
                    </div>
                    <!--Textbox de Email-->
                    <div class="form-group  col-md-6">
                        <asp:Label ID="Label6" runat="server" Text="Email" class="text-white"></asp:Label>
                        <!-- Cuadro gris en textbox-->
                        <div class="input-group flex-nowrap">
                            <div class="input-group-prepend">
                                <!--icono-->
                                <span class="input-group-text">
                                    <i class="fa fa-at" aria-hidden="true"></i>
                                </span>
                            </div>
                            <asp:TextBox ID="txtEmail" runat="server" class="form-control" aria-describedby="emailHelp"></asp:TextBox>
                        </div>
                    </div>
                    <!--Textbox de Edad-->
                    <div class="form-group  col-md-6">
                        <asp:Label ID="Label8" runat="server" Text="Edad" class="text-white"></asp:Label>
                        <!-- Cuadro gris en textbox-->
                        <div class="input-group flex-nowrap">
                            <div class="input-group-prepend">
                                <!--icono-->
                                <span class="input-group-text">
                                    <i class="fa fa-user-circle" aria-hidden="true"></i>
                                </span>
                            </div>
                            <asp:TextBox ID="txtEdad" runat="server" class="form-control" aria-describedby="emailHelp"></asp:TextBox>
                        </div>
                    </div>
                    <!--Textbox de Password-->
                    <div class="form-group  col-md-6">
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
                    <!--Textbox de confirmar Password-->
                    <div class="form-group col-md-6">
                        <asp:Label ID="Label7" runat="server" Text="Confirmar Password" class="text-white"></asp:Label>
                        <!-- Cuadro gris en textbox-->
                        <div class="input-group flex-nowrap">
                            <div class="input-group-prepend">
                                <!--icono-->
                                <span class="input-group-text">
                                    <span class="fa fa-key" aria-hidden="true"></span>
                                </span>
                            </div>
                            <asp:TextBox ID="txtconfirmapass" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label class="text-danger" ID="lbResult" runat="server" Text=""></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnSignup" runat="server" Text="Registrarse" class="btn btn-primary" style="float:right;" OnClick="btnSignup_Click"/>

                </div>
                <div class="form-group">
                    <p style="float: left;" class="text-white">¿Ya tienes una cuenta? </p>
                    <a href="Login.aspx" id="emailHelp" class="form-text text-muted text-white">Iniciar sesión</a>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
