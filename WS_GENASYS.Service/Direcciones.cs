using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
namespace WS_GENASYS.Service
{
   [CollectionDataContract()]
    public class Direcciones : Collection<Direccion>
    {

    }
}
