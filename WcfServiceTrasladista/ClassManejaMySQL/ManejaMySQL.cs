using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManejaMySQL
{
    class ManejaMySQL
    {
        public string CadenaConexion { set; get; }

        public MySqlConnection AbrirConexion(ref string msj)
        {
            MySqlConnection conexion = new MySqlConnection();
            conexion.ConnectionString = CadenaConexion;

            try
            {
                conexion.Open();
                msj = "Conexion exitosa";
            }
            catch (Exception c)
            {
                msj = "ERROR " + c.Message;
                conexion = null;
            }
            return conexion;
        }

        public bool Op_ModificarBD(MySqlConnection carretera, string sentenciaSQL, ref string mensj)
        {
            bool salida = false;
            MySqlCommand carrito = new MySqlCommand();
            if (carretera != null)
            {
                carrito.Connection = carretera;
                carrito.CommandText = sentenciaSQL;
                try
                {
                    carrito.ExecuteNonQuery();
                    salida = true;
                    mensj = "Modificacion correcta";
                }
                catch (Exception h)
                {
                    salida = false;
                    mensj = "Error " + h.Message;
                }
                carretera.Close();
            }
            else
            {
                salida = false;
                mensj = "No hay conexion abierta";
            }
            return salida;
        }
        public MySqlDataReader ConsultaDataReader(ref MySqlConnection cn_abierta, string query1, ref string mensj)
        {
            MySqlDataReader contenedor = null;
            MySqlCommand carrito = new MySqlCommand();

            if (cn_abierta != null)
            {
                carrito.Connection = cn_abierta;
                carrito.CommandText = query1;
                try
                {
                    contenedor = carrito.ExecuteReader();
                    mensj = "Consulta correcta";
                }
                catch (Exception g)
                {
                    mensj = "Error: " + g.Message;
                    contenedor = null;
                }
            }
            else
            {
                mensj = "No hay conexión abierta";
                contenedor = null;
            }
            return contenedor;
        }

        public System.Data.DataSet ConsultaDataSet(MySqlConnection conexion, string query, ref string mensaje)
        {
            System.Data.DataSet contenedorgrande = new System.Data.DataSet();
            MySqlCommand carrito = new MySqlCommand();
            MySqlDataAdapter trailer = new MySqlDataAdapter();

            if (conexion != null)
            {
                carrito.Connection = conexion;
                carrito.CommandText = query;
                trailer.SelectCommand = carrito;
                try
                {
                    trailer.Fill(contenedorgrande);
                    mensaje = "Consulta en DT correcta";
                }
                catch (Exception c)
                {
                    contenedorgrande = null;
                    mensaje = "Error" + c.Message;
                }

                conexion.Close();
            }
            else
            {
                contenedorgrande = null;
                mensaje = "No hay conexión";
            }

            return contenedorgrande;
        }

        public MySqlDataReader ConsultaDataReaderConParametros(ref MySqlConnection ConexAbierta, string query, MySqlParameter[] para, ref string mensaje)
        {
            MySqlDataReader contenedor = null;
            MySqlCommand TransporteSQL = new MySqlCommand();

            foreach (MySqlParameter n in para)
            {
                TransporteSQL.Parameters.Add(n);
            }

            if (ConexAbierta != null)
            {
                TransporteSQL.Connection = ConexAbierta;
                TransporteSQL.CommandText = query;

                try
                {
                    contenedor = TransporteSQL.ExecuteReader();
                    mensaje = "Consulta Correcta";
                }
                catch (Exception c)
                {
                    mensaje = "Error" + c.Message;
                    contenedor = null;
                }
            }
            else
            {
                mensaje = "No hay conexion abierta";
                contenedor = null;
            }

            return contenedor;
        }
    }
}
