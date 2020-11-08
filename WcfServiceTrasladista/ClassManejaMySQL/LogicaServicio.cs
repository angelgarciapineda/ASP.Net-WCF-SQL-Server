using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
//using MySql.Data.MySqlClient;

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
        //Obtener IDS
        #region
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
        #endregion
        //Insertar en tablas
        #region
        /*Método para insertar en tabla Agencia origen*/
        public int InsertToAgenciaOrigen(string sucursal, string calle, string numint, string numext, string colonia, string cp, string ciudad, string estado, ref string mensaje)
        {
            int idAgenciaOrigen = 0;
            try
            {
                DateTime dt = DateTime.Now;
                SqlDataReader tablita = null;
                SqlConnection conex = null;
                conex = capa1.AbrirConexion(ref mensaje);
                string consulta = "exec InsertToAgenciaOrigen '" + dt.ToString("MM/dd/yyyy HH:mm:ss") + "','" +
                    dt.ToString("MM/dd/yyyy HH:mm:ss") + "','" + sucursal + "','" + calle + "','" +
                    numint + "','" + numext + "','" + colonia + "','" + cp + "','" + ciudad + "','" + estado + "';";
                tablita = capa1.ConsultaDataReader(ref conex, consulta, ref mensaje);

                if (tablita != null)
                {

                    while (tablita.Read())
                    {
                        idAgenciaOrigen = (int)tablita[0];
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
                mensaje = c.Message;
            }
            return idAgenciaOrigen;

        }

        /*Método para insertar en tabla Agencia destino*/
        public int InsertToAgenciaDestino(string sucursal, string calle, string numint, string numext, string colonia, string cp, string ciudad, string estado, ref string mensaje)
        {
            int idAgenciaDestino = 0;
            try
            {
                DateTime dt = DateTime.Now;
                SqlDataReader tablita = null;
                SqlConnection conex = null;
                conex = capa1.AbrirConexion(ref mensaje);
                string consulta = "exec InsertToAgenciaDestino '" + dt.ToString("MM/dd/yyyy HH:mm:ss") + "','" +
                    dt.ToString("MM/dd/yyyy HH:mm:ss") + "','" + sucursal + "','" + calle + "','" +
                    numint + "','" + numext + "','" + colonia + "','" + cp + "','" + ciudad + "','" + estado + "';";
                tablita = capa1.ConsultaDataReader(ref conex, consulta, ref mensaje);

                if (tablita != null)
                {

                    while (tablita.Read())
                    {
                        idAgenciaDestino = (int)tablita[0];
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
                mensaje = c.Message;
            }
            return idAgenciaDestino;

        }

        /*Método para insertar en tabla Gasto_servicio*/
        public int InsertToGasto_servicio(string restriccion, string necesidad, double km,
            int tiempo_trans, double costo_casetas, double total, ref string mensaje)
        {
            int idGasto = 0;
            try
            {
                DateTime dt = DateTime.Now;
                SqlDataReader tablita = null;
                SqlConnection conex = null;
                conex = capa1.AbrirConexion(ref mensaje);
                string consulta = "exec InsertToGastos_servicio '" + dt.ToString("MM/dd/yyyy HH:mm:ss") + "','" +
                    dt.ToString("MM/dd/yyyy HH:mm:ss") + "','" + restriccion + "','" + necesidad + "'," +
                    km + "," + tiempo_trans + "," + costo_casetas + "," + total + ";";
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
                SqlParameter[] param = new SqlParameter[10];

                param[0] = new SqlParameter("@CREADO_EL", SqlDbType.VarChar);
                param[0].Direction = System.Data.ParameterDirection.Input;
                param[0].Value = dt.ToString("MM/dd/yyyy HH:mm:ss");

                param[1] = new SqlParameter("@MODIFICADO_EL", SqlDbType.VarChar);
                param[1].Direction = System.Data.ParameterDirection.Input;
                param[1].Value = dt.ToString("MM/dd/yyyy HH:mm:ss");

                param[2] = new SqlParameter("@NOMBRE", SqlDbType.VarChar);
                param[2].Direction = System.Data.ParameterDirection.Input;
                param[2].Value = Nombre;

                param[3] = new SqlParameter("@AP", SqlDbType.VarChar);
                param[3].Direction = System.Data.ParameterDirection.Input;
                param[3].Value = Paterno;

                param[4] = new SqlParameter("@AM", SqlDbType.VarChar);
                param[4].Direction = System.Data.ParameterDirection.Input;
                param[4].Value = Materno;

                param[5] = new SqlParameter("@EDAD", SqlDbType.Int);
                param[5].Direction = System.Data.ParameterDirection.Input;
                param[5].Value = Edad;

                param[6] = new SqlParameter("@RFC", SqlDbType.VarChar);
                param[6].Direction = System.Data.ParameterDirection.Input;
                param[6].Value = Rfc;

                param[7] = new SqlParameter("@EMAIL", SqlDbType.VarChar);
                param[7].Direction = System.Data.ParameterDirection.Input;
                param[7].Value = Email;

                param[8] = new SqlParameter("@CONTRASENIA", SqlDbType.VarChar);
                param[8].Direction = System.Data.ParameterDirection.Input;
                param[8].Value = Pass;


                param[9] = new SqlParameter("@FK_ROL", SqlDbType.Int);
                param[9].Direction = System.Data.ParameterDirection.Input;
                param[9].Value = fk_rol;

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
        /*Método para insertar en tabla GastoServicio_Vehiculo*/
        public void InsertToGastoServicio_Vehiculo(int cantidad, double precio, double total, int fk_gasto, int fk_vehiculo, ref string mensaje)
        {
            try
            {
                DateTime dt = DateTime.Now;
                String consulta = "insert into Gastoservicio_Vehiculo " + "(Creado_el,Modificado_el,Cantidad,Precio_unidad,Total,fk_gastoservicio,fk_vehiculo) " +
                    "values (@CREADO_EL,@MODIFICADO_EL,@CANTIDAD,@PRECIO_UNIDAD,@TOTAL,@FK_GASTO,@FK_VEHICULO) ";
                SqlParameter[] param = new SqlParameter[7];

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

                param[4] = new SqlParameter("@TOTAL", SqlDbType.Float);
                param[4].Direction = System.Data.ParameterDirection.Input;
                param[4].Value = total;

                param[5] = new SqlParameter("@FK_GASTO", SqlDbType.Int);
                param[5].Direction = System.Data.ParameterDirection.Input;
                param[5].Value = fk_gasto;

                param[6] = new SqlParameter("@FK_VEHICULO", SqlDbType.Int);
                param[6].Direction = System.Data.ParameterDirection.Input;
                param[6].Value = fk_vehiculo;


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
        public void InsertToServicio(string Tipo_servicio, string Estado, int fk_usuario, int fk_gastoservicio, int fk_agenciaOrigen, int fk_agenciaDestino, ref string mensaje)
        {
            try
            {
                DateTime dt = DateTime.Now;
                String consulta = "insert into Servicio " + "(Creado_el,Modificado_el,Tipo_servicio,Estado,fk_usuario,fk_gastoservicio,fk_agenciaOrigen,fk_agenciaDestino) " +
                    "values (@CREADO_EL,@MODIFICADO_EL,@TIPO,@ESTADO,@FK_USUARIO,@FK_GASTO,@FK_AGENCIAO,@FK_AGENCIAD) ";
                SqlParameter[] param = new SqlParameter[8];

                param[0] = new SqlParameter("@CREADO_EL", SqlDbType.VarChar);
                param[0].Direction = System.Data.ParameterDirection.Input;
                param[0].Value = dt.ToString("MM/dd/yyyy HH:mm:ss");

                param[1] = new SqlParameter("@MODIFICADO_EL", SqlDbType.VarChar);
                param[1].Direction = System.Data.ParameterDirection.Input;
                param[1].Value = dt.ToString("MM/dd/yyyy HH:mm:ss");

                param[2] = new SqlParameter("@TIPO", SqlDbType.VarChar);
                param[2].Direction = System.Data.ParameterDirection.Input;
                param[2].Value = Tipo_servicio;

                param[3] = new SqlParameter("@ESTADO", SqlDbType.VarChar);
                param[3].Direction = System.Data.ParameterDirection.Input;
                param[3].Value = Estado;

                param[4] = new SqlParameter("@FK_USUARIO", SqlDbType.Int);
                param[4].Direction = System.Data.ParameterDirection.Input;
                param[4].Value = fk_usuario;

                param[5] = new SqlParameter("@FK_GASTO", SqlDbType.Int);
                param[5].Direction = System.Data.ParameterDirection.Input;
                param[5].Value = fk_gastoservicio;

                param[6] = new SqlParameter("@FK_AGENCIAO", SqlDbType.Int);
                param[6].Direction = System.Data.ParameterDirection.Input;
                param[6].Value = fk_agenciaOrigen;

                param[7] = new SqlParameter("@FK_AGENCIAD", SqlDbType.Int);
                param[7].Direction = System.Data.ParameterDirection.Input;
                param[7].Value = fk_agenciaDestino;

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
        #endregion
        //Mostrar datos
        public System.Data.DataTable MostrarServicios(string fecha, string estado, ref string msj)
        {
            SqlConnection ctn3 = null;
            System.Data.DataSet caja = null;
            System.Data.DataTable salida = null;
            string ms = "";
            string query = "SELECT Servicio.idServicio as 'ID', Servicio.Creado_el as 'Fecha de solicitud', Tipo_servicio, Estado, CONCAT(Nombre,' ',Ap,' ',Am)as 'Cliente' " +
                "FROM Servicio, Usuario, Agencia WHERE Estado='" + estado + "' AND Servicio.Creado_el>='" + fecha + "' and Servicio.fk_usuario = Usuario.idUsuario and Servicio.fk_agenciaOrigen = Agencia.idAgencia";

            ctn3 = capa1.AbrirConexion(ref ms);
            if (ctn3 != null)
            {
                caja = capa1.ConsultaDataSet(ctn3, query, ref ms);

                if (caja != null)
                {
                    salida = caja.Tables[0];
                }
            }
            return salida;

        }
        #region
        //public Boolean ValidaLogin(ref string mensaje, String email, String pass, ref Boolean valida)
        //{
        //    MySqlConnection abierta = null;
        //    MySqlDataReader tablita = null;
        //    abierta = capa1.AbrirConexion(ref mensaje);
        //    String consulta = "Select Email, Contrasenia from Usuario where Email='" + email + "' and Contrasenia='" + pass + "';";
        //    tablita = capa1.ConsultaDataReader(ref abierta, consulta, ref mensaje);

        //    if (tablita != null)
        //    {
        //        if (tablita.Read())
        //        {
        //            if ((email == tablita[0].ToString()) && (pass == tablita[1].ToString()))
        //            {
        //                valida = true;
        //            }
        //            else
        //            {
        //                valida = false;
        //                abierta.Close();
        //                abierta.Dispose();
        //            }
        //        }
        //        else
        //        {
        //            valida = false;
        //            abierta.Close();
        //            abierta.Dispose();
        //        }
        //    }
        //    else
        //    {
        //        valida = false;
        //        abierta.Close();
        //        abierta.Dispose();
        //    }
        //    return valida;
        //}
        ///*Método para obtener los IDs de los operadores*/
        //public List<string> DevuelveIDOperador(ref string mensaje, ref List<int> ids)
        //{
        //    List<string> misOperadores = new List<string>();
        //    ids = new List<int>();
        //    MySqlConnection abierta = null;
        //    MySqlDataReader tablita = null;
        //    abierta = capa1.AbrirConexion(ref mensaje);
        //    tablita = capa1.ConsultaDataReader(ref abierta, "select idUsuario, CONCAT(Nombre,' ',Ap,' ',Am) from Usuario where fk_rol=3;", ref mensaje);

        //    if (tablita != null)
        //    {

        //        while (tablita.Read())
        //        {
        //            ids.Add((int)tablita[0]);
        //            misOperadores.Add((string)tablita[1]);
        //        }
        //        abierta.Close();
        //        abierta.Dispose();
        //    }
        //    else
        //    {
        //        mensaje = mensaje + "\n No hay datos";
        //        misOperadores = null;
        //        ids = null;
        //    }

        //    return misOperadores;
        //}
        ///*Método para obtener los IDS de los vehiculos*/
        //public List<string> DevuelveIDVehiculo(ref string mensaje, ref List<int> ids)
        //{
        //    List<string> misVehiculos = new List<string>();
        //    ids = new List<int>();
        //    MySqlConnection abierta = null;
        //    MySqlDataReader tablita = null;
        //    abierta = capa1.AbrirConexion(ref mensaje);
        //    tablita = capa1.ConsultaDataReader(ref abierta, "select idVehiculo, CONCAT(Marca,',',Modelo,',',Color,',',Tipo) from Vehiculo;", ref mensaje);

        //    if (tablita != null)
        //    {

        //        while (tablita.Read())
        //        {
        //            ids.Add((int)tablita[0]);
        //            misVehiculos.Add((string)tablita[1]);
        //        }
        //        abierta.Close();
        //        abierta.Dispose();
        //    }
        //    else
        //    {
        //        mensaje = mensaje + "\n No hay datos";
        //        misVehiculos = null;
        //        ids = null;
        //    }

        //    return misVehiculos;
        //}
        ///*Método para obtener los IDS de las agencias*/
        //public List<string> DevuelveIDAgencia(ref string mensaje, ref List<int> ids)
        //{
        //    List<string> misAgencias = new List<string>();
        //    ids = new List<int>();
        //    MySqlConnection abierta = null;
        //    MySqlDataReader tablita = null;
        //    abierta = capa1.AbrirConexion(ref mensaje);
        //    tablita = capa1.ConsultaDataReader(ref abierta, "select idAgencia, Nombre_sucursal from Agencia;", ref mensaje);

        //    if (tablita != null)
        //    {

        //        while (tablita.Read())
        //        {
        //            ids.Add((int)tablita[0]);
        //            misAgencias.Add((string)tablita[1]);
        //        }
        //        abierta.Close();
        //        abierta.Dispose();
        //    }
        //    else
        //    {
        //        mensaje = mensaje + "\n No hay datos";
        //        misAgencias = null;
        //        ids = null;
        //    }

        //    return misAgencias;
        //}

        ///*Método para insertar en tabla Gasto_servicio*/
        //public int InsertToGasto_servicio(string restriccion, string necesidad, double km,
        //    int tiempo_trans, double costo_casetas, double total, ref string mensaje)
        //{
        //    int idGasto = 0;
        //    try
        //    {
        //        DateTime dt = DateTime.Now;
        //        MySqlDataReader tablita = null;
        //        MySqlConnection conex = null;
        //        conex = capa1.AbrirConexion(ref mensaje);
        //        string consulta = "exec InsertToGastos_servicio '" + dt.ToString("MM/dd/yyyy HH:mm:ss") + "','" +
        //            dt.ToString("MM/dd/yyyy HH:mm:ss") + "','" + restriccion + "','" + necesidad + "'," +
        //            km + "," + tiempo_trans + "," + costo_casetas + "," + total + ";";
        //        tablita = capa1.ConsultaDataReader(ref conex, consulta, ref mensaje);

        //        if (tablita != null)
        //        {

        //            while (tablita.Read())
        //            {
        //                idGasto = (int)tablita[0];
        //            }
        //            conex.Close();
        //            conex.Dispose();
        //        }
        //        else
        //        {
        //            mensaje = mensaje + "\n No hay datos";
        //        }


        //    }
        //    catch (Exception c)
        //    {
        //        string h = "";
        //        h = c.Message;
        //    }
        //    return idGasto;

        //}
        ///*Método para insertar en tabla Usuario*/
        //public void InsertToUsuario(String Nombre, String Paterno, String Materno, int Edad, String Rfc, String Email, String Pass, int fk_rol, ref string mensaje)
        //{
        //    try
        //    {
        //        DateTime dt = DateTime.Now;
        //        String consulta = "insert into Usuario " + "(Creado_el, Modificado_el, Nombre, Ap, Am, Edad, Rfc, Email, Contrasenia, fk_rol) " +
        //            "values (@CREADO_EL,@MODIFICADO_EL,@NOMBRE,@AP,@AM,@EDAD,@RFC,@EMAIL,@CONTRASENIA,@FK_ROL) ";
        //        MySqlParameter[] param = new MySqlParameter[10];

        //        param[0] = new MySqlParameter("@CREADO_EL", MySqlDbType.VarChar);
        //        param[0].Direction = System.Data.ParameterDirection.Input;
        //        param[0].Value = dt.ToString("MM/dd/yyyy HH:mm:ss");

        //        param[1] = new MySqlParameter("@MODIFICADO_EL", MySqlDbType.VarChar);
        //        param[1].Direction = System.Data.ParameterDirection.Input;
        //        param[1].Value = dt.ToString("MM/dd/yyyy HH:mm:ss");

        //        param[2] = new MySqlParameter("@NOMBRE", MySqlDbType.VarChar);
        //        param[2].Direction = System.Data.ParameterDirection.Input;
        //        param[2].Value = Nombre;

        //        param[3] = new MySqlParameter("@AP", MySqlDbType.VarChar);
        //        param[3].Direction = System.Data.ParameterDirection.Input;
        //        param[3].Value = Paterno;

        //        param[4] = new MySqlParameter("@AM", MySqlDbType.VarChar);
        //        param[4].Direction = System.Data.ParameterDirection.Input;
        //        param[4].Value = Materno;

        //        param[5] = new MySqlParameter("@EDAD", MySqlDbType.Int16);
        //        param[5].Direction = System.Data.ParameterDirection.Input;
        //        param[5].Value = Edad;

        //        param[6] = new MySqlParameter("@RFC", MySqlDbType.VarChar);
        //        param[6].Direction = System.Data.ParameterDirection.Input;
        //        param[6].Value = Rfc;

        //        param[7] = new MySqlParameter("@EMAIL", MySqlDbType.VarChar);
        //        param[7].Direction = System.Data.ParameterDirection.Input;
        //        param[7].Value = Email;

        //        param[8] = new MySqlParameter("@CONTRASENIA", MySqlDbType.VarChar);
        //        param[8].Direction = System.Data.ParameterDirection.Input;
        //        param[8].Value = Pass;


        //        param[9] = new MySqlParameter("@FK_ROL", MySqlDbType.Int16);
        //        param[9].Direction = System.Data.ParameterDirection.Input;
        //        param[9].Value = fk_rol;

        //        MySqlConnection conex = null;
        //        conex = capa1.AbrirConexion(ref mensaje);
        //        MySqlDataReader temp = null;
        //        temp = capa1.ConsultaDataReaderConParametros(ref conex, consulta, param, ref mensaje);
        //    }
        //    catch (Exception c)
        //    {
        //        mensaje = "Mensaje : " + c.Message;
        //    }
        //}
        ///*Método para insertar en tabla GastoServicio_Vehiculo*/
        //public void InsertToGastoServicio_Vehiculo(int cantidad, double precio, double total, int fk_gasto, int fk_vehiculo, ref string mensaje)
        //{
        //    try
        //    {
        //        DateTime dt = DateTime.Now;
        //        String consulta = "insert into Gastoservicio_Vehiculo " + "(Creado_el,Modificado_el,Cantidad,Precio_unidad,Total,fk_gastoservicio,fk_vehiculo) " +
        //            "values (@CREADO_EL,@MODIFICADO_EL,@CANTIDAD,@PRECIO_UNIDAD,@TOTAL,@FK_GASTO,@FK_VEHICULO) ";
        //        MySqlParameter[] param = new MySqlParameter[7];

        //        param[0] = new MySqlParameter("@CREADO_EL", MySqlDbType.VarChar);
        //        param[0].Direction = System.Data.ParameterDirection.Input;
        //        param[0].Value = dt.ToString("MM/dd/yyyy HH:mm:ss");

        //        param[1] = new MySqlParameter("@MODIFICADO_EL", MySqlDbType.VarChar);
        //        param[1].Direction = System.Data.ParameterDirection.Input;
        //        param[1].Value = dt.ToString("MM/dd/yyyy HH:mm:ss");

        //        param[2] = new MySqlParameter("@CANTIDAD", MySqlDbType.Int16);
        //        param[2].Direction = System.Data.ParameterDirection.Input;
        //        param[2].Value = cantidad;

        //        param[3] = new MySqlParameter("@PRECIO_UNIDAD", MySqlDbType.Float);
        //        param[3].Direction = System.Data.ParameterDirection.Input;
        //        param[3].Value = precio;

        //        param[4] = new MySqlParameter("@TOTAL", MySqlDbType.Float);
        //        param[4].Direction = System.Data.ParameterDirection.Input;
        //        param[4].Value = total;

        //        param[5] = new MySqlParameter("@FK_GASTO", MySqlDbType.Int16);
        //        param[5].Direction = System.Data.ParameterDirection.Input;
        //        param[5].Value = fk_gasto;

        //        param[6] = new MySqlParameter("@FK_VEHICULO", MySqlDbType.Int16);
        //        param[6].Direction = System.Data.ParameterDirection.Input;
        //        param[6].Value = fk_vehiculo;


        //        MySqlConnection conex = null;
        //        conex = capa1.AbrirConexion(ref mensaje);
        //        MySqlDataReader temp = null;
        //        temp = capa1.ConsultaDataReaderConParametros(ref conex, consulta, param, ref mensaje);
        //    }
        //    catch (Exception c)
        //    {
        //        mensaje = "Mensaje : " + c.Message;
        //    }
        //}
        ///*Método para insertar en tabla SERVICIO*/
        //public void InsertToServicio(string Tipo_servicio, int fk_usuario, int fk_gastoservicio, int fk_agenciaOrigen, int fk_agenciaDestino, ref string mensaje)
        //{
        //    try
        //    {
        //        DateTime dt = DateTime.Now;
        //        String consulta = "insert into Servicio " + "(Creado_el,Modificado_el,Tipo_servicio,fk_usuario,fk_gastoservicio,fk_agenciaOrigen,fk_agenciaDestino) " +
        //            "values (@CREADO_EL,@MODIFICADO_EL,@TIPO,@FK_USUARIO,@FK_GASTO,@FK_AGENCIAO,@FK_AGENCIAD) ";
        //        MySqlParameter[] param = new MySqlParameter[7];

        //        param[0] = new MySqlParameter("@CREADO_EL", MySqlDbType.VarChar);
        //        param[0].Direction = System.Data.ParameterDirection.Input;
        //        param[0].Value = dt.ToString("MM/dd/yyyy HH:mm:ss");

        //        param[1] = new MySqlParameter("@MODIFICADO_EL", MySqlDbType.VarChar);
        //        param[1].Direction = System.Data.ParameterDirection.Input;
        //        param[1].Value = dt.ToString("MM/dd/yyyy HH:mm:ss");

        //        param[2] = new MySqlParameter("@TIPO", MySqlDbType.VarChar);
        //        param[2].Direction = System.Data.ParameterDirection.Input;
        //        param[2].Value = Tipo_servicio;

        //        param[3] = new MySqlParameter("@FK_USUARIO", MySqlDbType.Int16);
        //        param[3].Direction = System.Data.ParameterDirection.Input;
        //        param[3].Value = fk_usuario;

        //        param[4] = new MySqlParameter("@FK_GASTO", MySqlDbType.Int16);
        //        param[4].Direction = System.Data.ParameterDirection.Input;
        //        param[4].Value = fk_gastoservicio;

        //        param[5] = new MySqlParameter("@FK_AGENCIAO", MySqlDbType.Int16);
        //        param[5].Direction = System.Data.ParameterDirection.Input;
        //        param[5].Value = fk_agenciaOrigen;

        //        param[6] = new MySqlParameter("@FK_AGENCIAD", MySqlDbType.Int16);
        //        param[6].Direction = System.Data.ParameterDirection.Input;
        //        param[6].Value = fk_agenciaDestino;

        //        MySqlConnection conex = null;
        //        conex = capa1.AbrirConexion(ref mensaje);
        //        MySqlDataReader temp = null;
        //        temp = capa1.ConsultaDataReaderConParametros(ref conex, consulta, param, ref mensaje);
        //    }
        //    catch (Exception c)
        //    {
        //        mensaje = "Mensaje : " + c.Message;
        //    }
        //}
        #endregion
    }
}
