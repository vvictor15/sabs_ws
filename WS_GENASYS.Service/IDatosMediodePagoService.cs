using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WS_GENASYS.Service
{
    [ServiceContract()]
    public interface IDatosMediodePagoService
    {        
        [OperationContract()]
        DatosMedioPagoResponse ConsultarMedioPago(DatosPersonalesRequest request);
    }
}

