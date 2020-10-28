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
        public Boolean ValidaLogin(ref string mensaje, String email, String pass, ref Boolean valida)
        {
            SqlConnection abierta = null;
            SqlDataReader tablita = null;
            abierta = capa1.AbrirConexion(ref mensaje);
            String consulta = "Select Email, Contrasenia from Usuario where Email='" + email + "' and Contrasenia='" + pass + "';";
            tablita = capa1.ConsultaDataReader(ref abierta, consulta, ref mensaje);

            if (tablita != null)
            {
                if (tablita.Read())
                {
                    if ((email == tablita[0].ToString()) && (pass == tablita[1].ToString()))
                    {
                        valida = true;
                    }
                    else
                    {
                        valida = false;
                        abierta.Close();
                        abierta.Dispose();
                    }
                }
                else
                {
                    valida = false;
                    abierta.Close();
                    abierta.Dispose();
                }
            }
            else
            {
                valida = false;
                abierta.Close();
                abierta.Dispose();
            }
            return valida;
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
        /*Método para obtener los IDS de los vehiculos*/
        public List<string> DevuelveIDVehiculo(ref string mensaje, ref List<int> ids)
        {
            List<string> misVehiculos = new List<string>();
            ids = new List<int>();
            SqlConnection abierta = null;
            SqlDataReader tablita = null;
            abierta = capa1.AbrirConexion(ref mensaje);
            tablita = capa1.ConsultaDataReader(ref abierta, "select idVehiculo, CONCAT(Marca,',',Modelo,',',Color,',',Tipo) from Vehiculo;", ref mensaje);

            if (tablita != null)
            {

                while (tablita.Read())
                {
                    ids.Add((int)tablita[0]);
                    misVehiculos.Add((string)tablita[1]);
                }
                abierta.Close();
                abierta.Dispose();
            }
            else
            {
                mensaje = mensaje + "\n No hay datos";
                misVehiculos = null;
                ids = null;
            }

            return misVehiculos;
        }
        /*Método para obtener los IDS de las agencias*/
        public List<string> DevuelveIDAgencia(ref string mensaje, ref List<int> ids)
        {
            List<string> misAgencias = new List<string>();
            ids = new List<int>();
            SqlConnection abierta = null;
            SqlDataReader tablita = null;
            abierta = capa1.AbrirConexion(ref mensaje);
            tablita = capa1.ConsultaDataReader(ref abierta, "select idAgencia, Nombre_sucursal from Agencia;", ref mensaje);

            if (tablita != null)
            {

                while (tablita.Read())
                {
                    ids.Add((int)tablita[0]);
                    misAgencias.Add((string)tablita[1]);
                }
                abierta.Close();
                abierta.Dispose();
            }
            else
            {
                mensaje = mensaje + "\n No hay datos";
                misAgencias = null;
                ids = null;
            }

            return misAgencias;
        }
        /*Método para insertar en tabla Gasto_servicio*/
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
        /*Método para insertar en tabla GastoServicio_Vehiculo*/
        public void InsertToGastoServicio_Vehiculo(int cantidad, double precio, int fk_gasto, int fk_vehiculo, ref string mensaje)
        {
            try
            {
                DateTime dt = DateTime.Now;
                String consulta = "insert into Gastoservicio_Vehiculo " + "(Creado_el,Modificado_el,Cantidad,Precio_unidad,fk_gastoservicio,fk_vehiculo) " +
                    "values (@CREADO_EL,@MODIFICADO_EL,@CANTIDAD,@PRECIO_UNIDAD,@FK_GASTO,@FK_VEHICULO) ";
                SqlParameter[] param = new SqlParameter[6];

                param[0] = new SqlParameter("@CREADO_EL", SqlDbType.VarChar);
                param[0].Direction = System.Data.ParameterDirection.Input;
                param[0].Value = dt.ToString("MM/dd/yyyy HH:mm:ss");

                param[1] = new SqlParameter("@MODIFICADO_EL", SqlDbType.VarChar);
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
        /*Método para insertar en tabla SERVICIO*/
        public void InsertToServicio(string Tipo_servicio, int fk_usuario, int fk_gastoservicio, int fk_agenciaOrigen, int fk_agenciaDestino, ref string mensaje)
        {
            try
            {
                DateTime dt = DateTime.Now;
                String consulta = "insert into Servicio " + "(Creado_el,Modificado_el,Tipo_servicio,fk_usuario,fk_gastoservicio,fk_agenciaOrigen,fk_agenciaDestino) " +
                    "values (@CREADO_EL,@MODIFICADO_EL,@TIPO,@FK_USUARIO,@FK_GASTO,@FK_AGENCIAO,@FK_AGENCIAD) ";
                SqlParameter[] param = new SqlParameter[7];

                param[0] = new SqlParameter("@CREADO_EL", SqlDbType.VarChar);
                param[0].Direction = System.Data.ParameterDirection.Input;
                param[0].Value = dt.ToString("MM/dd/yyyy HH:mm:ss");

                param[1] = new SqlParameter("@MODIFICADO_EL", SqlDbType.VarChar);
                param[1].Direction = System.Data.ParameterDirection.Input;
                param[1].Value = dt.ToString("MM/dd/yyyy HH:mm:ss");

                param[2] = new SqlParameter("@TIPO", SqlDbType.VarChar);
                param[2].Direction = System.Data.ParameterDirection.Input;
                param[2].Value = Tipo_servicio;

                param[3] = new SqlParameter("@FK_USUARIO", SqlDbType.Int);
                param[3].Direction = System.Data.ParameterDirection.Input;
                param[3].Value = fk_usuario;

                param[4] = new SqlParameter("@FK_GASTO", SqlDbType.Int);
                param[4].Direction = System.Data.ParameterDirection.Input;
                param[4].Value = fk_gastoservicio;

                param[5] = new SqlParameter("@FK_AGENCIAO", SqlDbType.Int);
                param[5].Direction = System.Data.ParameterDirection.Input;
                param[5].Value = fk_agenciaOrigen;

                param[6] = new SqlParameter("@FK_AGENCIAD", SqlDbType.Int);
                param[6].Direction = System.Data.ParameterDirection.Input;
                param[6].Value = fk_agenciaDestino;

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
    }
}
