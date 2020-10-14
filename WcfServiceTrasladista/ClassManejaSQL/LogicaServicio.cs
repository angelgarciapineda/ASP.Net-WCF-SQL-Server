using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ClassManejaSQL
{
    public class LogicaServicio
    {
        ManejaSQL capa1 = new ManejaSQL();

        public LogicaServicio()
        {
            capa1.CadenaConexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString.ToString();
        }
        public void MuestraDatosConID(List<string> cadena, DropDownList cmb1)
        {
            cmb1.Items.Clear();
            if (cadena != null)
            {
                foreach (string x in cadena)
                {
                    cmb1.Items.Add(x);
                    cmb1.SelectedIndex = 0;
                }
            }
        }

        /*Método para obtener los IDs de los operadores*/
        public List<string> DevuelveIDOperador(ref string mensaje, ref List<int> ids)
        {
            List<string> misOperadores = new List<string>();
            ids = new List<int>();
            SqlConnection abierta = null;
            SqlDataReader tablita = null;
            abierta = capa1.AbrirConexion(ref mensaje);
            tablita = capa1.ConsultaDataReader(ref abierta, "select idUsuario, CONCAT(Nombre,' ',Ap,' ',Am) from Usuario where fk_rol=3;", ref mensaje);

            if (tablita != null)
            {

                while (tablita.Read())
                {
                    ids.Add((int)tablita[0]);
                    misOperadores.Add((string)tablita[1]);
                }
                abierta.Close();
                abierta.Dispose();
            }
            else
            {
                mensaje = mensaje + "\n No hay datos";
                misOperadores = null;
                ids = null;
            }

            return misOperadores;
        }
    }
}
