using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WS_GENASYS.Service
{
    [DataContract()]
    public class DatosPersonalesRequest
    {
        [DataMember()]
        public string IDC { get; set; }

        [DataMember()]
        public string NroOperacion { get; set; }

        /*Mejoras Web*/
        [DataMember()]
        public string CodFuncionario { get; set; }

    }

    [DataContract()]
    public class DatosPersonalesResponse
    {
        [DataMember()]
        public Cliente Cliente { get; set; }

        [DataMember()]
        public Direcciones Direcciones { get; set; }

        [DataMember()]
        public Errores Errores { get; set; }

        [DataMember()]
        public string StatusCod { get; set; }

        [DataMember()]
        public string Severidad { get; set; }

        [DataMember()]
        public string StatusDes { get; set; }

        [DataMember()]
        public string ServStatusCod { get; set; }

        [DataMember()]
        public string ServSeveridad { get; set; }

        [DataMember()]
        public string ServStatusDes { get; set; }
    }

    [DataContract()]
    public class DatosMedioPagoResponse 
    {
        /*Inicio: Mejoras Web - MedioPago*/
        [DataMember()]
        public MediodePagoData MediodePagoData { get; set; }

        [DataMember()]
        public Errores Errores { get; set; }

        [DataMember()]
        public string StatusCod { get; set; }

        [DataMember()]
        public string Severidad { get; set; }

        [DataMember()]
        public string StatusDes { get; set; }

        [DataMember()]
        public string ServStatusCod { get; set; }

        [DataMember()]
        public string ServSeveridad { get; set; }

        [DataMember()]
        public string ServStatusDes { get; set; }
        /*Fin*/
    }
}
