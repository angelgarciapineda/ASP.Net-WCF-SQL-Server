using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTrasladista_consumeWCF
{
    public partial class Login : System.Web.UI.Page
    {
        ServiceReference1.Service1Client serviceTras = new ServiceReference1.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignin_Click(object sender, EventArgs e)
        {
            try
            {
                String m = "";
                bool validador = false;
                validador = serviceTras.Login(ref m, txtEmail.Text, txtPassword.Text, ref validador);
                if (validador != false)
                {
                    FormsAuthentication.RedirectFromLoginPage(txtEmail.Text, false);
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    lbSuccess.Visible = false;
                    lbError.Visible = true;
                    lbError.Text = "No existe el usuario";
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception)
            {
                lbSuccess.Visible = false;
                lbError.Visible = true;
                lbError.Text = "Insert todos los campos";
            }

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                String mensaje = "";
                int fkrol = 3;
                if (txtPasswordR.Text != txtConfirmaPass.Text)
                {
                    lbSuccess.Visible = false;
                    lbError.Visible = true;
                    lbError.Text = "No coinciden las contraseñas";
                }
                else
                {
                    serviceTras.InsertaUsuario(txtNombre.Text, txtPaterno.Text, txtMaterno.Text, Convert.ToInt16(txtEdad.Text), txtRfc.Text, txtEmailR.Text, txtPasswordR.Text, fkrol, ref mensaje);
                    lbError.Visible = false;
                    lbSuccess.Visible = true;
                    lbSuccess.Text = "Registro correcto";
                }
            }
            catch (Exception c)
            {
                lbSuccess.Visible = false;
                lbError.Visible = true;
                lbError.Text = c.Message;
            }
        }
    }
}