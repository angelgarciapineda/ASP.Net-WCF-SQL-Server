using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTrasladista_consumeWCF
{
    public partial class Solicitud : System.Web.UI.Page
    {
        ServiceReference1.Service1Client uno = new ServiceReference1.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCargaVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                string msj = "";
                List<int> idsvehiculos = new List<int>();
                List<string> vehiculos = new List<string>();
                vehiculos = uno.ObtenVehiculo(ref msj, ref idsvehiculos);
                cmbVehiculo.Items.Clear();
                cmbVehiculoExtra.Items.Clear();

                cmbTipoServicio.Items.Clear();
                cmbTipoServicio.Items.Add("Sencillo");
                cmbTipoServicio.Items.Add("Redondo");
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
            catch (Exception exc)
            {
                lbRespuesta.Text = exc.Message;
            }
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

                int cantidad = Convert.ToInt16(txtcantidad.Text);
                double precio = 0;
                int tiempo = Convert.ToInt16(txtTiempoTransporte.Text);
                double km = Convert.ToDouble(txtKm.Text);
                double costo_caseta = 0;
                double total = tiempo * km;
                //Inserta a tabla Gasto_servicio
                i = uno.InsertaGasto(txtRestriccion.Text, txtNecesidad.Text, km, tiempo, costo_caseta, total, ref msj);
                lbGastoServicio.Text = lbGastoServicio.Text + " " + i.ToString();
                //Inserta a tabla GastoServicio_Vehiculo
                uno.InsertaGastoVehiculo(cantidad, precio, cantidad * precio, i, temp[cmbVehiculo.SelectedIndex], ref msj);
                lbRespuesta.Text = msj;

                //Limpiar cajas
                txtKm.Text = "";
                txtTiempoTransporte.Text = "";
                txtRestriccion.Text = "";
                txtNecesidad.Text = "";
                txtcantidad.Text = "";
                cmbVehiculo.SelectedIndex = 0;
                Session["idGasto"] = i;
            }
            catch (Exception m)
            {
                lbRespuesta.Text = m.ToString();
            }
        }

        protected void btnAgregarExtra_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> temp = new List<int>();
                temp = (List<int>)Session["idsVehiculos"];
                int i = (int)Session["idGasto"];
                String msj = "";
                int cantidad = Convert.ToInt16(txtCantidadExtra.Text);
                double precio = 0;
                //Inserta a tabla GastoServicio_Vehiculo
                uno.InsertaGastoVehiculo(cantidad, precio, cantidad * precio, i, temp[cmbVehiculoExtra.SelectedIndex], ref msj);
                lbRespuesta.Text = msj;
                cmbVehiculoExtra.SelectedIndex = 0;
                txtCantidadExtra.Text = "";
            }
            catch (Exception c)
            {
                lbRespuesta.Text = c.Message;
            }
        }

        protected void btnGuardarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> tempOperador = new List<int>();
                tempOperador = (List<int>)Session["idsOpera"];
                int idgasto = (int)Session["idGasto"];

                List<int> tempAgencias = new List<int>();
                tempAgencias = (List<int>)Session["idsAgencias"];

                string estado = "PENDIENTE";

                //Guardar la agencia de origen y destino, después obtener el ID de cada tabla para mandarla a la tabla de servicio
                int id_agenciaOrigen = 0;
                int id_agenciaDestino = 0;

                String mensaje = "";
                id_agenciaOrigen = uno.InsertaAgenciaOrigen(lbSucursalOrigen.Text, lbCalleOrigen.Text, lbNumExtOrigen.Text, lbNumIntOrigen.Text, lbColOrigen.Text, lbCPOrigen.Text, lbCiudadOrigen.Text, lbEstadoOrigen.Text, ref mensaje);
                id_agenciaDestino = uno.InsertaAgenciaDestino(lbSucursalDestino.Text, lbCalleDestino.Text, lbNumExtDestino.Text, lbNumIntDestino.Text, lbColDestino.Text, lbCPDestino.Text, lbCiudadDestino.Text, lbEstadoDestino.Text, ref mensaje);

                uno.InsertaServicio(cmbTipoServicio.SelectedItem.ToString(), estado, 2, idgasto, id_agenciaOrigen, id_agenciaDestino, ref mensaje);
                lbRespuesta.Text = mensaje;

            }
            catch (Exception m)
            {
                lbRespuesta.Text = m.Message;
            }
        }

        protected void btnGuardarAgencias_Click(object sender, EventArgs e)
        {
            if (rdOrigen.Checked == true)
            {
                lbSucursalOrigen.Text = txtSucursal.Text;
                lbCalleOrigen.Text = txtCalle.Text;
                lbNumExtOrigen.Text = txtNumExt.Text;
                lbNumIntOrigen.Text = txtNumInt.Text;
                lbColOrigen.Text = txtColonia.Text;
                lbCPOrigen.Text = txtCP.Text;
                lbCiudadOrigen.Text = txtCiudad.Text;
                lbEstadoOrigen.Text = txtEstado.Text;
                txtSucursal.Text = "";
                txtCalle.Text = "";
                txtNumExt.Text = "";
                txtNumInt.Text = "";
                txtColonia.Text = "";
                txtCP.Text = "";
                txtCiudad.Text = "";
                txtEstado.Text = "";
            }
            else
            {
                lbSucursalDestino.Text = txtSucursal.Text;
                lbCalleDestino.Text = txtCalle.Text;
                lbNumExtDestino.Text = txtNumExt.Text;
                lbNumIntDestino.Text = txtNumInt.Text;
                lbColDestino.Text = txtColonia.Text;
                lbCPDestino.Text = txtCP.Text;
                lbCiudadDestino.Text = txtCiudad.Text;
                lbEstadoDestino.Text = txtEstado.Text;
                txtSucursal.Text = "";
                txtCalle.Text = "";
                txtNumExt.Text = "";
                txtNumInt.Text = "";
                txtColonia.Text = "";
                txtCP.Text = "";
                txtCiudad.Text = "";
                txtEstado.Text = "";
            }
        }

        protected void btnEditarOrigen_Click(object sender, EventArgs e)
        {
            rdOrigen.Checked = true;
            rdDestino.Checked = false;
            txtSucursal.Text = lbSucursalOrigen.Text;
            txtCalle.Text = lbCalleOrigen.Text;
            txtNumExt.Text = lbNumExtOrigen.Text;
            txtNumInt.Text = lbNumIntOrigen.Text;
            txtColonia.Text = lbColOrigen.Text;
            txtCP.Text = lbCPOrigen.Text;
            txtCiudad.Text = lbCiudadOrigen.Text;
            txtEstado.Text = lbEstadoOrigen.Text;
        }

        protected void btnEditarDestino_Click(object sender, EventArgs e)
        {
            rdDestino.Checked = true;
            rdOrigen.Checked = false;
            txtSucursal.Text = lbSucursalDestino.Text;
            txtCalle.Text = lbCalleDestino.Text;
            txtNumExt.Text = lbNumExtDestino.Text;
            txtNumInt.Text = lbNumIntDestino.Text;
            txtColonia.Text = lbColDestino.Text;
            txtCP.Text = lbCPDestino.Text;
            txtCiudad.Text = lbCiudadDestino.Text;
            txtEstado.Text = lbEstadoDestino.Text;
        }
    }
}