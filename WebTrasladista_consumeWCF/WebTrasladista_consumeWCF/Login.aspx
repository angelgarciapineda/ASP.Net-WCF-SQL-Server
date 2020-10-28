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
                                <asp:Label class="text-danger" ID="lbResult" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnSignin" runat="server" Text="Ingresar" class="btn btn-primary" OnClick="btnSignin_Click" />

                            </div>
                            <div class="form-group">
                                <p style="float: left;" class="text-white">¿No tienes una cuenta? </p>
                                <a href="Home.aspx" id="emailHelp" class="form-text text-muted text-white">Registrarse</a>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>



    </form>
</body>
</html>
