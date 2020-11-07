using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClassManejaMySQL
{
    public class LogicaServicio
    {
        ManejaMySQL capa1 = new ManejaMySQL();

        public LogicaServicio()
        {
            capa1.CadenaConexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString.ToString();
        }

        public Boolean ValidaLogin(ref string mensaje, String email, String pass, ref Boolean valida)
        {
            MySqlConnection abierta = null;
            MySqlDataReader tablita = null;
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
            MySqlConnection abierta = null;
            MySqlDataReader tablita = null;
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
            MySqlConnection abierta = null;
            MySqlDataReader tablita = null;
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
            MySqlConnection abierta = null;
            MySqlDataReader tablita = null;
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
                MySqlDataReader tablita = null;
                MySqlConnection conex = null;
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
            catch (Exception c)
            {
                string h = "";
                h = c.Message;
            }
            return idGasto;

        }
        /*Método para insertar en tabla Usuario*/
        public void InsertToUsuario(String Nombre, String Paterno, String Materno, int Edad, String Rfc, String Email, String Pass, int fk_rol, ref string mensaje)
        {
            try
            {
                DateTime dt = DateTime.Now;
                String consulta = "insert into Usuario " + "(Creado_el, Modificado_el, Nombre, Ap, Am, Edad, Rfc, Email, Contrasenia, fk_rol) " +
                    "values (@CREADO_EL,@MODIFICADO_EL,@NOMBRE,@AP,@AM,@EDAD,@RFC,@EMAIL,@CONTRASENIA,@FK_ROL) ";
                MySqlParameter[] param = new MySqlParameter[10];

                param[0] = new MySqlParameter("@CREADO_EL", MySqlDbType.VarChar);
                param[0].Direction = System.Data.ParameterDirection.Input;
                param[0].Value = dt.ToString("MM/dd/yyyy HH:mm:ss");

                param[1] = new MySqlParameter("@MODIFICADO_EL", MySqlDbType.VarChar);
                param[1].Direction = System.Data.ParameterDirection.Input;
                param[1].Value = dt.ToString("MM/dd/yyyy HH:mm:ss");

                param[2] = new MySqlParameter("@NOMBRE", MySqlDbType.VarChar);
                param[2].Direction = System.Data.ParameterDirection.Input;
                param[2].Value = Nombre;

                param[3] = new MySqlParameter("@AP", MySqlDbType.VarChar);
                param[3].Direction = System.Data.ParameterDirection.Input;
                param[3].Value = Paterno;

                param[4] = new MySqlParameter("@AM", MySqlDbType.VarChar);
                param[4].Direction = System.Data.ParameterDirection.Input;
                param[4].Value = Materno;

                param[5] = new MySqlParameter("@EDAD", MySqlDbType.Int16);
                param[5].Direction = System.Data.ParameterDirection.Input;
                param[5].Value = Edad;

                param[6] = new MySqlParameter("@RFC", MySqlDbType.VarChar);
                param[6].Direction = System.Data.ParameterDirection.Input;
                param[6].Value = Rfc;

                param[7] = new MySqlParameter("@EMAIL", MySqlDbType.VarChar);
                param[7].Direction = System.Data.ParameterDirection.Input;
                param[7].Value = Email;

                param[8] = new MySqlParameter("@CONTRASENIA", MySqlDbType.VarChar);
                param[8].Direction = System.Data.ParameterDirection.Input;
                param[8].Value = Pass;


                param[9] = new MySqlParameter("@FK_ROL", MySqlDbType.Int16);
                param[9].Direction = System.Data.ParameterDirection.Input;
                param[9].Value = fk_rol;

                MySqlConnection conex = null;
                conex = capa1.AbrirConexion(ref mensaje);
                MySqlDataReader temp = null;
                temp = capa1.ConsultaDataReaderConParametros(ref conex, consulta, param, ref mensaje);
            }
            catch (Exception c)
            {
                mensaje = "Mensaje : " + c.Message;
            }
        }
        /*Método para insertar en tabla GastoServicio_Vehiculo*/
        public void InsertToGastoServicio_Vehiculo(int cantidad, double precio, int fk_gasto, int fk_vehiculo, ref string mensaje)
        {
            try
            {
                DateTime dt = DateTime.Now;
                String consulta = "insert into Gastoservicio_Vehiculo " + "(Creado_el,Modificado_el,Cantidad,Precio_unidad,fk_gastoservicio,fk_vehiculo) " +
                    "values (@CREADO_EL,@MODIFICADO_EL,@CANTIDAD,@PRECIO_UNIDAD,@FK_GASTO,@FK_VEHICULO) ";
                MySqlParameter[] param = new MySqlParameter[6];

                param[0] = new MySqlParameter("@CREADO_EL", MySqlDbType.VarChar);
                param[0].Direction = System.Data.ParameterDirection.Input;
                param[0].Value = dt.ToString("MM/dd/yyyy HH:mm:ss");

                param[1] = new MySqlParameter("@MODIFICADO_EL", MySqlDbType.VarChar);
                param[1].Direction = System.Data.ParameterDirection.Input;
                param[1].Value = dt.ToString("MM/dd/yyyy HH:mm:ss");

                param[2] = new MySqlParameter("@CANTIDAD", MySqlDbType.Int16);
                param[2].Direction = System.Data.ParameterDirection.Input;
                param[2].Value = cantidad;

                param[3] = new MySqlParameter("@PRECIO_UNIDAD", MySqlDbType.Float);
                param[3].Direction = System.Data.ParameterDirection.Input;
                param[3].Value = precio;

                param[4] = new MySqlParameter("@FK_GASTO", MySqlDbType.Int16);
                param[4].Direction = System.Data.ParameterDirection.Input;
                param[4].Value = fk_gasto;

                param[5] = new MySqlParameter("@FK_VEHICULO", MySqlDbType.Int16);
                param[5].Direction = System.Data.ParameterDirection.Input;
                param[5].Value = fk_vehiculo;


                MySqlConnection conex = null;
                conex = capa1.AbrirConexion(ref mensaje);
                MySqlDataReader temp = null;
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
                MySqlParameter[] param = new MySqlParameter[7];

                param[0] = new MySqlParameter("@CREADO_EL", MySqlDbType.VarChar);
                param[0].Direction = System.Data.ParameterDirection.Input;
                param[0].Value = dt.ToString("MM/dd/yyyy HH:mm:ss");

                param[1] = new MySqlParameter("@MODIFICADO_EL", MySqlDbType.VarChar);
                param[1].Direction = System.Data.ParameterDirection.Input;
                param[1].Value = dt.ToString("MM/dd/yyyy HH:mm:ss");

                param[2] = new MySqlParameter("@TIPO", MySqlDbType.VarChar);
                param[2].Direction = System.Data.ParameterDirection.Input;
                param[2].Value = Tipo_servicio;

                param[3] = new MySqlParameter("@FK_USUARIO", MySqlDbType.Int16);
                param[3].Direction = System.Data.ParameterDirection.Input;
                param[3].Value = fk_usuario;

                param[4] = new MySqlParameter("@FK_GASTO", MySqlDbType.Int16);
                param[4].Direction = System.Data.ParameterDirection.Input;
                param[4].Value = fk_gastoservicio;

                param[5] = new MySqlParameter("@FK_AGENCIAO", MySqlDbType.Int16);
                param[5].Direction = System.Data.ParameterDirection.Input;
                param[5].Value = fk_agenciaOrigen;

                param[6] = new MySqlParameter("@FK_AGENCIAD", MySqlDbType.Int16);
                param[6].Direction = System.Data.ParameterDirection.Input;
                param[6].Value = fk_agenciaDestino;

                MySqlConnection conex = null;
                conex = capa1.AbrirConexion(ref mensaje);
                MySqlDataReader temp = null;
                temp = capa1.ConsultaDataReaderConParametros(ref conex, consulta, param, ref mensaje);
            }
            catch (Exception c)
            {
                mensaje = "Mensaje : " + c.Message;
            }
        }
    }
}
