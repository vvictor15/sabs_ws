using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WS_GENASYS.Service
{
    [DataContract()]
    public class Error
    {
        [DataMember()]
        public string Codigo { get; set; }

        [DataMember()]
        public string Descripcion { get; set; }
    }
}
