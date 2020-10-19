using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

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

        public int InsertToGasto_servicio(int duracion, string restriccion, string necesidad, double km,
            int tiempo_trans, double costo_trans, double sueldo,
            double salario, double costo_casetas, double total, ref string mensaje)
        {
            int idGasto = 0;
            try
            {
                DateTime dt = DateTime.Now;
                SqlDataReader tablita = null;
                SqlConnection conex = null;
                conex = capa1.AbrirConexion(ref mensaje);
                string consulta = "exec InsertToGastos_servicio '" + dt.ToString("MM/dd/yyyy HH:mm:ss") + "','" +
                    dt.ToString("MM/dd/yyyy HH:mm:ss") + "'," + duracion + ",'" + restriccion + "','" + necesidad + "'," +
                    km + "," + tiempo_trans + "," + costo_trans + "," + sueldo + "," + salario + "," + costo_trans + "," +
                    total + ";";
                tablita = capa1.ConsultaDataReader(ref conex, consulta, ref mensaje);

                if (tablita != null)
                {

                    while (tablita.Read())
                    {
                        idGasto = (int)tablita[0];
                    }
                    conex.Close();
                    conex.Dispose();
                }
                else
                {
                    mensaje = mensaje + "\n No hay datos";
                }


            }
            catch (SqlException c)
            {
                string h = "";
                h = c.Message;
            }
            return idGasto;

        }
        public void InsertToGastoServicio_Vehiculo(int cantidad, double precio, int fk_gasto, int fk_vehiculo, ref string mensaje)
        {
            try
            {
                DateTime dt = DateTime.Now;
                String consulta = "insert into Gastoservicio_Vehiculo " + "(Creado_el,Modificado_el,Cantidad,Precio_unidad,fk_gastoservicio,fk_vehiculo) " +
                    "values (@CREADO_EL,@MODIFICADO_EL,@CANTIDAD,@PRECIO_UNIDAD,@FK_GASTO,@FK_VEHICULO) ";
                SqlParameter[] param = new SqlParameter[6];

                param[0] = new SqlParameter("@CREADO_EL", SqlDbType.DateTime);
                param[0].Direction = System.Data.ParameterDirection.Input;
                param[0].Value = dt.ToString("MM/dd/yyyy HH:mm:ss");

                param[1] = new SqlParameter("@MODIFICADO_EL", SqlDbType.DateTime);
                param[1].Direction = System.Data.ParameterDirection.Input;
                param[1].Value = dt.ToString("MM/dd/yyyy HH:mm:ss");

                param[2] = new SqlParameter("@CANTIDAD", SqlDbType.Int);
                param[2].Direction = System.Data.ParameterDirection.Input;
                param[2].Value = cantidad;

                param[3] = new SqlParameter("@PRECIO_UNIDAD", SqlDbType.Float);
                param[3].Direction = System.Data.ParameterDirection.Input;
                param[3].Value = precio;

                param[4] = new SqlParameter("@FK_GASTO", SqlDbType.Int);
                param[4].Direction = System.Data.ParameterDirection.Input;
                param[4].Value = fk_gasto;

                param[5] = new SqlParameter("@FK_VEHICULO", SqlDbType.Int);
                param[5].Direction = System.Data.ParameterDirection.Input;
                param[5].Value = fk_vehiculo;


                SqlConnection conex = null;
                conex = capa1.AbrirConexion(ref mensaje);
                SqlDataReader temp = null;
                temp = capa1.ConsultaDataReaderConParametros(ref conex, consulta, param, ref mensaje);
            }
            catch (Exception c)
            {
                mensaje = "Mensaje : " + c.Message;
            }
        }
        /*public void InsertIntoGasto_servicio(int duracion, string restriccion, string necesidad, float km,
            int tiempo_trans, float costo_trans, float sueldo,
            float salario, float costo_casetas, ref string mensaje)
        {
            try
            {
                DateTime dt = DateTime.Now;
                string consulta =
                    "insert into Gasto_servicio " +
                    "(Creado_el,Modificado_el,Duracion,Restriccion,Necesidades_especificas,Kilometros,Tiempo_transporte,Costo_transporte,Sueldo,Salario,Costo_casetas,Total) " +
                    "values (@CREADO_EL,@MODIFICADO_EL,@DURACION,@RESTRICCION,@NECESIDADES,@KM,@TIEMPO_TRANS,@COSTO_TRANS,@SUELDO,@SALARIO,@COSTO_CASETAS,@TOTAL)";

                SqlParameter[] param = new SqlParameter[12];

                param[0] = new SqlParameter("@CREADO_EL", SqlDbType.DateTime);
                param[0].Direction = System.Data.ParameterDirection.Input;
                param[0].Value = dt.ToLongDateString();

                param[1] = new SqlParameter("@MODIFICADO_EL", SqlDbType.Int);
                param[1].Direction = System.Data.ParameterDirection.Input;
                param[1].Value = dt;

                param[2] = new SqlParameter("@DURACION", SqlDbType.Int);
                param[2].Direction = System.Data.ParameterDirection.Input;
                param[2].Value = duracion;

                param[3] = new SqlParameter("@RESTRICCION", SqlDbType.VarChar);
                param[3].Direction = System.Data.ParameterDirection.Input;
                param[3].Value = restriccion;

                param[4] = new SqlParameter("@NECESIDADES", SqlDbType.VarChar);
                param[4].Direction = System.Data.ParameterDirection.Input;
                param[4].Value = necesidad;

                param[5] = new SqlParameter("@KM", SqlDbType.Float);
                param[5].Direction = System.Data.ParameterDirection.Input;
                param[5].Value = km;

                param[6] = new SqlParameter("@TIEMPO_TRANS", SqlDbType.Int);
                param[6].Direction = System.Data.ParameterDirection.Input;
                param[6].Value = tiempo_trans;

                param[7] = new SqlParameter("@COSTO_TRANS", SqlDbType.Float);
                param[7].Direction = System.Data.ParameterDirection.Input;
                param[7].Value = costo_trans;

                param[8] = new SqlParameter("@SUELDO", SqlDbType.Float);
                param[8].Direction = System.Data.ParameterDirection.Input;
                param[8].Value = sueldo;

                param[9] = new SqlParameter("@SALARIO", SqlDbType.Float);
                param[9].Direction = System.Data.ParameterDirection.Input;
                param[9].Value = salario;

                param[10] = new SqlParameter("@COSTO_CASETAS", SqlDbType.Float);
                param[10].Direction = System.Data.ParameterDirection.Input;
                param[10].Value = costo_casetas;

                param[11] = new SqlParameter("@TOTAL", SqlDbType.Float);
                param[11].Direction = System.Data.ParameterDirection.Input;
                param[11].Value = 0;

                SqlConnection conexion;
                conexion = capa1.AbrirConexion(ref mensaje);

                SqlDataReader temp = null;
                temp = capa1.ConsultaDataReaderConParametros(ref conexion, consulta, param, ref mensaje);
            }
            catch (Exception c)
            {
                mensaje = "Error" + c.Message;
            }
        }*/

    }
}
