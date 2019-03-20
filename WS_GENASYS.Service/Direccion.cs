using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace WS_GENASYS.Service
{

    [DataContract()]
    public class Direccion
    {
        [DataMember()]
        public string numero_secuencia { get; set; }

        [DataMember()]
        public string tipo_direccion { get; set; }

        [DataMember()]
        public string tipo_via { get; set; }

        [DataMember()]
        public string nombre_via { get; set; }

        [DataMember()]
        public string numero_via { get; set; }

        [DataMember()]
        public string departamento_piso_interior { get; set; }

        [DataMember()]
        public string numero_departamento_piso_interior { get; set; }

        [DataMember()]
        public string manzana { get; set; }

        [DataMember()]
        public string lote { get; set; }

        [DataMember()]
        public string tipo_habitacional_codurbanizacion { get; set; }

        [DataMember()]
        public string nombre_habitacional_codurbanizacion { get; set; }

        [DataMember()]
        public string sector_etapa_zona { get; set; }

        [DataMember()]
        public string nombre_sector_etapa_zona { get; set; }

        [DataMember()]
        public string localidad { get; set; }

        [DataMember()]
        public string telefono { get; set; }

        [DataMember()]
        public string direccion_comprimida { get; set; }
    }
}
