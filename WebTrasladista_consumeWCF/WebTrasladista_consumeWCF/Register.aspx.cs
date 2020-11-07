using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTrasladista_consumeWCF
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        ServiceReference1.Service1Client serviceTras = new ServiceReference1.Service1Client();
        protected void btnSignup_Click(object sender, EventArgs e)
        {
            try
            {
                String mensaje = "";
                int fkrol = 3;
                if (txtPassword.Text != txtconfirmapass.Text)
                {
                    lbResult.Text = "No coinciden las contraseñas";
                }
                else
                {
                    serviceTras.InsertaUsuario(txtNombre.Text, txtPaterno.Text, txtMaterno.Text, Convert.ToInt16(txtEdad.Text), txtRfc.Text, txtEmail.Text, txtPassword.Text, fkrol, ref mensaje);
                    lbResult.Text = mensaje;
                }
            }
            catch (Exception c)
            {
                lbResult.Text = c.Message;
            }
        }
    }
}