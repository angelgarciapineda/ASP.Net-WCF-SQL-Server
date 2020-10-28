using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WcfServiceTrasladista
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Boolean Login(ref string msj, String email, String password, ref Boolean valida);

        [OperationContract]
        List<string> ObtenOperador(ref string msj, ref List<int> ids);

        [OperationContract]
        List<string> ObtenVehiculo(ref string msj, ref List<int> ids);

        [OperationContract]
        List<string> ObtenAgencia(ref string msj, ref List<int> ids);

        [OperationContract]
        void MuestraDatos(List<string> cad, DropDownList cmb1);

        [OperationContract]
        int InsertaGasto(int duracion, string restriccion, string necesidad, double km,
            int tiempo_trans, double costo_trans, double sueldo,
            double salario, double costo_casetas, double total, ref string mensaje);

        [OperationContract]
        void InsertaGastoVehiculo(int cantidad, double precio, int fkgasto, int fkvehiculo, ref string mensaje);

        [OperationContract]
        void InsertaServicio(String tipo, int fkuusuario, int fkgasto, int fkagenciaorigen, int fkagenciadestino, ref string mensaje);
        // TODO: agregue aquí sus operaciones de servicio

    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    [KnownType(typeof(DropDownList))]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
