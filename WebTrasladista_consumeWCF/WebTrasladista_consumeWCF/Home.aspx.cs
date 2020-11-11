using System;
using System.Collections.Generic;
using System.Data;
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
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("ACEPTADO");
            cmbEstado.Items.Add("PENDIENTE");
            //string msj = "";
            //List<int> idspro = new List<int>();
            //List<string> profes = new List<string>();
            //profes = uno.ObtenOperador(ref msj, ref idspro);
            //cmbOperador.Items.Clear();

            //if (profes != null)
            //{
            //    foreach (string p in profes)
            //    {
            //        cmbOperador.Items.Add(p);
            //        cmbOperador.SelectedIndex = 0;
            //    }
            //}

            //Session["idsOpera"] = idspro;
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


                //String mensaje = "";
                //uno.InsertaServicio(cmbTipoServicio.SelectedItem.ToString(), tempOperador[cmbOperador.SelectedIndex], idgasto, tempAgencias[cmbOrigen.SelectedIndex], tempAgencias[cmbDestino.SelectedIndex], ref mensaje);
                //lbRespuesta.Text = mensaje;

            }
            catch (Exception m)
            {
                lbRespuesta.Text = m.Message;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string msj = "";
                DataTable tablita = null;
                string estado = (string)Session["estado"];
                tablita = uno.MostrarServicios(txtFecha.Text, "PENDIENTE", ref msj);
                DataColumn Columna = null; //Para recorrer columnas.


                List<string> NColumnas = new List<string>();
                string[] xy;
                xy = new string[tablita.Columns.Count]; //Inicializar arreglo de forma dinámica.

                for (int a = 0; a < tablita.Columns.Count; a++) //Recorrer columnas de DataTable.
                {
                    Columna = tablita.Columns[a];
                    xy[a] = Columna.ColumnName; //Guardar nombres de columnas en arreglo.
                    NColumnas.Add(Columna.ColumnName);
                }
                grServicios.DataSource = tablita;
                Session["grid"] = tablita;
                grServicios.DataKeyNames = xy;

                lbRespuesta.Text = msj;
                grServicios.DataBind();
            }
            catch (Exception ex)
            {
                lbRespuesta.Text = ex.Message;
            }

        }

        protected void grServicios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grServicios.PageIndex = e.NewPageIndex;
                string msj = "";
                grServicios.DataSource = uno.MostrarServicios(txtFecha.Text, "PENDIENTE", ref msj);
                lbRespuesta.Text = msj;
                grServicios.DataBind();
            }
            catch (Exception ex)
            {
                lbRespuesta.Text = ex.Message;
            }
        }

        protected void grServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string mensaje = "";
                int POS = grServicios.SelectedIndex;
                DataKey Obj = grServicios.DataKeys[POS];
                lbtablita.Text = "Detalles del servicio:" + Obj.Values[0];
                gvDetalleServicio.DataSource = uno.MostrarDetalle_Servicio("2020-11-07", "PENDIENTE", (int)Obj.Values[0], ref mensaje);
                gvDetalleServicio.DataBind();

                //Llenar card de detalle del servicio
                lbNumServicio.Text = Obj.Values[0].ToString();
                lbFechaSolicitud.Text = Obj.Values[1].ToString();
                lbTipoSolicitud.Text = Obj.Values[2].ToString();
                lbEstado.Text = Obj.Values[3].ToString();
                lbCliente.Text = Obj.Values[4].ToString();
                lbOrigen.Text = Obj.Values[5].ToString();
                lbDestino.Text = Obj.Values[6].ToString();

                btnAceptar.Visible = true;
                lbRespuesta.Text = mensaje;
            }
            catch (Exception ex)
            {
                lbRespuesta.Text = ex.Message;
            }

            //Session["idprofetabla"] = (int)Obj.Values[0];
        }

        /*Metodo para hacer editable las celdas del gridview
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                this.gvDetalleServicio.EditIndex = e.NewEditIndex;
                DataTable dt = new DataTable();
                dt = (DataTable)Session["grid"];

                this.gvDetalleServicio.DataSource = dt;
                this.gvDetalleServicio.DataBind();
            }
            catch (Exception ex)
            {
                lbRespuesta.Text = ex.Message;
            }
        }
        */
    }
}