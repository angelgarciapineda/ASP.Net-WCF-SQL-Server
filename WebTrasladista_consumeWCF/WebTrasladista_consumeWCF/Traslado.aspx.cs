using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTrasladista_consumeWCF
{
    public partial class Traslado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        ServiceReference1.Service1Client uno = new ServiceReference1.Service1Client();
        protected void btnCargarOperador_Click(object sender, EventArgs e)
        {
            string msj = "";
            List<int> idspro = new List<int>();
            List<string> profes = new List<string>();
            profes = uno.ObtenOperador(ref msj, ref idspro);
            lbConexion.Text = msj;
            cmbOperador.Items.Clear();
            if (profes != null)
            {
                foreach(string p in profes)
                {
                    cmbOperador.Items.Add(p);
                    cmbOperador.SelectedIndex = 0;
                }
            }

            Session["idstemp"] = idspro;
        }

        protected void btnagregar_Click(object sender, EventArgs e)
        {
            string msj = "";
            try
            {
                int i = 0; //id de Gasto

                double total = Convert.ToInt16(txtcantidad.Text) * Convert.ToDouble(txtprecio.Text);

                i = uno.InsertaGasto(Convert.ToInt16(txtduracion.Text), txtrestri.Text, txtneces.Text,
                    Convert.ToDouble(txtkm.Text), Convert.ToInt16(txttiempotrans.Text), Convert.ToDouble(txtcontroltrans.Text),
                    Convert.ToDouble(txtsueldo.Text), Convert.ToDouble(txtsalario.Text), Convert.ToDouble(txtcostocaseta.Text),
                    total, ref msj);
                lbConexion.Text = i.ToString();

                uno.InsertaGastoVehiculo(Convert.ToInt16(txtcantidad.Text), Convert.ToDouble(txtprecio.Text), 2,1, ref msj);
            }
            catch (Exception)
            {
                lbConexion.Text = msj;
            }
        }
    }
}