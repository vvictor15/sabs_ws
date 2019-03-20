using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WS_GENASYS.Service
{

    [ServiceContract()]
    public interface IDatosPersonalesService
    {
        [OperationContract()]
        DatosPersonalesResponse ConsultarDatos(DatosPersonalesRequest request);
    }
}
