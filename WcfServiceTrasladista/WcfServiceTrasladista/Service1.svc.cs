using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ClassManejaMySQL;

namespace WcfServiceTrasladista
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        LogicaServicio objfinal = new LogicaServicio();

        public int InsertaGasto(int duracion, string restriccion, string necesidad, double km, int tiempo_trans, double costo_trans, double sueldo, double salario, double costo_casetas, double total, ref string mensaje)
        {
            return objfinal.InsertToGasto_servicio(duracion, restriccion, necesidad, km, tiempo_trans, costo_trans, sueldo, salario, costo_casetas, total, ref mensaje);
        }

        public void InsertaGastoVehiculo(int cantidad, double precio, int fkgasto, int fkvehiculo, ref string mensaje)
        {
            objfinal.InsertToGastoServicio_Vehiculo(cantidad, precio, fkgasto, fkvehiculo, ref mensaje);
        }

        public void InsertaServicio(string tipo, int fkuusuario, int fkgasto, int fkagenciaorigen, int fkagenciadestino, ref string mensaje)
        {
            objfinal.InsertToServicio(tipo, fkuusuario, fkgasto, fkagenciadestino, fkagenciadestino, ref mensaje);
        }

        public void InsertaUsuario(string Nombre, string Paterno, string Materno, int Edad, string Rfc, string Email, string Pass, int fk_rol, ref string mensaje)
        {
            objfinal.InsertToUsuario(Nombre, Paterno, Materno, Edad, Rfc, Email, Pass, fk_rol, ref mensaje);
        }

        public bool Login(ref string msj, string email, string password, ref bool valida)
        {
            return objfinal.ValidaLogin(ref msj, email, password, ref valida);
        }

        public List<string> ObtenAgencia(ref string msj, ref List<int> ids)
        {
            return objfinal.DevuelveIDAgencia(ref msj, ref ids);
        }

        public List<string> ObtenOperador(ref string msj, ref List<int> ids)
        {
            return objfinal.DevuelveIDOperador(ref msj, ref ids);
        }

        public List<string> ObtenVehiculo(ref string msj, ref List<int> ids)
        {
            return objfinal.DevuelveIDVehiculo(ref msj, ref ids);
        }
    }
}
