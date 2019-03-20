using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WS_GENASYS.Service
{

    [DataContract()]
    public class MediodePago
    {
        [DataMember()]
        public string numero_medioPago { get; set; }

        [DataMember()]
        public string cod_familia { get; set; }

        [DataMember()]
        public string cod_producto { get; set; }

        [DataMember()]
        public string cod_moneda { get; set; }

        [DataMember()]
        public string cod_estadoproducto { get; set; }

        [DataMember()]
        public string des_estadoproducto { get; set; }

    }

    [DataContract()]
    public class Cliente
    {      
        [DataMember()]
        public string nombres { get; set; }

        [DataMember()]
        public string apellido_paterno { get; set; }

        [DataMember()]
        public string apellido_materno { get; set; }

        [DataMember()]
        public string tipo_documento { get; set; }

        [DataMember()]
        public string numero_documento { get; set; }

        [DataMember()]
        public DateTime? fecha_nacimiento { get; set; }

        [DataMember()]
        public string nacionalidad { get; set; }

        [DataMember()]
        public string genero { get; set; }

        [DataMember()]
        public string estado_civil { get; set; }

        [DataMember()]
        public string profesion { get; set; }

    }

}
