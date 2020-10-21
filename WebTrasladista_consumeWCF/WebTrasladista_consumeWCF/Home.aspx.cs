using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTrasladista_consumeWCF
{
    public partial class Home : System.Web.UI.Page
    {
        ServiceReference1.Service1Client uno = new ServiceReference1.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string msj = "";
                List<int> idsagencias = new List<int>();
                List<string> agencias = new List<string>();
                agencias = uno.ObtenAgencia(ref msj, ref idsagencias);
                cmbVehiculo.Items.Clear();
                cmbVehiculoExtra.Items.Clear();
                if (agencias != null)
                {
                    foreach (string a in agencias)
                    {
                        cmbOrigen.Items.Add(a);
                        cmbDestino.Items.Add(a);
                        cmbOrigen.SelectedIndex = 0;
                        cmbDestino.SelectedIndex = 0;
                    }
                }
                lbRespuesta.Text = msj;
                Session["idsAgencias"] = idsagencias;
            }
            catch (Exception m)
            {
                lbRespuesta.Text = m.Message;
            }
        }

        protected void btnCargarOperador_Click(object sender, EventArgs e)
        {
            string msj = "";
            List<int> idspro = new List<int>();
            List<string> profes = new List<string>();
            profes = uno.ObtenOperador(ref msj, ref idspro);
            cmbOperador.Items.Clear();
            if (profes != null)
            {
                foreach (string p in profes)
                {
                    cmbOperador.Items.Add(p);
                    cmbOperador.SelectedIndex = 0;
                }
            }

            Session["idsProfes"] = idspro;
        }
        protected void btnCargaVehiculo_Click(object sender, EventArgs e)
        {
            string msj = "";
            List<int> idsvehiculos = new List<int>();
            List<string> vehiculos = new List<string>();
            vehiculos = uno.ObtenVehiculo(ref msj, ref idsvehiculos);
            cmbVehiculo.Items.Clear();
            cmbVehiculoExtra.Items.Clear();
            if (vehiculos != null)
            {
                foreach (string v in vehiculos)
                {
                    cmbVehiculo.Items.Add(v);
                    cmbVehiculoExtra.Items.Add(v);
                    cmbVehiculo.SelectedIndex = 0;
                    cmbVehiculoExtra.SelectedIndex = 0;
                }
            }

            Session["idsVehiculos"] = idsvehiculos;
        }
        protected void btnagregar_Click(object sender, EventArgs e)
        {
            string msj = "";
            try
            {
                int i = 0; //id de Gasto
                //Lista paara almacenar los id's de los vehiculos
                List<int> temp = new List<int>();
                temp = (List<int>)Session["idsVehiculos"];
                double total = Convert.ToInt16(txtcantidad.Text) * Convert.ToDouble(txtprecio.Text);
                //Inserta a tabla Gasto_servicio
                i = uno.InsertaGasto(Convert.ToInt16(txtduracion.Text), txtrestri.Text, txtneces.Text,
                    Convert.ToDouble(txtkm.Text), Convert.ToInt16(txttiempotrans.Text), Convert.ToDouble(txtcontroltrans.Text),
                    Convert.ToDouble(txtsueldo.Text), Convert.ToDouble(txtsalario.Text), Convert.ToDouble(txtcostocaseta.Text),
                    total, ref msj);
                lbGastoServicio.Text = lbGastoServicio.Text + " " + i.ToString();
                //Inserta a tabla GastoServicio_Vehiculo
                uno.InsertaGastoVehiculo(Convert.ToInt16(txtcantidad.Text), Convert.ToDouble(txtprecio.Text), i, temp[cmbVehiculo.SelectedIndex], ref msj);
                lbRespuesta.Text = msj;
            }
            catch (Exception m)
            {
                lbRespuesta.Text = m.ToString();
            }
        }

        protected void btnAgregarExtra_Click(object sender, EventArgs e)
        {
            string mensaje = "";

        }

        protected void cmbOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDestino.Items.RemoveAt(cmbOrigen.SelectedIndex);
        }
    }
}