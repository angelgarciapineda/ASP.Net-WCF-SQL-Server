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
            string msj = "";
            System.Data.DataTable tablita = null;
            tablita = uno.MostrarServicios("2020-11-07", "PENDIENTE", ref msj);
            System.Data.DataColumn Columna = null; //Para recorrer columnas.


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
            grServicios.DataKeyNames = xy;

            lbRespuesta.Text = msj;
            grServicios.DataBind();
            
        }

        protected void grServicios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grServicios.PageIndex = e.NewPageIndex;
            string msj = "";
            grServicios.DataSource = uno.MostrarServicios("2020-11-07", "PENDIENTE", ref msj);
            lbRespuesta.Text = msj;
            grServicios.DataBind();
        }

        protected void grServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int POS = grServicios.SelectedIndex;
            DataKey Obj = grServicios.DataKeys[POS];
            lbtablita.Text = "id:" + Obj.Values[0];
            //txtmuestra.Text = "id: " + Obj.Values[0]
            //    + ", Dia: " + Obj.Values[1]
            //    + " Hora: " + Obj.Values[2]
            //    + ", Grupo: " + Obj.Values[3]
            //    + ", Profesor: " + Obj.Values[4]
            //    + ", Materia: " + Obj.Values[5]
            //    + ", Lab: " + Obj.Values[6];

            //Session["idprofetabla"] = (int)Obj.Values[0];
        }
    }
}