using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ClassManejaSQL;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WcfServiceTrasladista
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        LogicaServicio objfinal = new LogicaServicio();

        public void MuestraDatos(List<string> cad, DropDownList cmb1)
        {
            objfinal.MuestraDatosConID(cad, cmb1);
        }

        public List<string> ObtenOperador(ref string msj, ref List<int> ids)
        {
            return objfinal.DevuelveIDOperador(ref msj, ref ids);
        }
    }
}
