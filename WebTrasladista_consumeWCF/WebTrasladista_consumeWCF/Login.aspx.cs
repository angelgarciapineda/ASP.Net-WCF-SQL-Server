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
                    lbResult.Text = "No existe el usuario";
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception)
            {
                lbResult.Text = "Insert todos los campos";
            }

        }
    }
}