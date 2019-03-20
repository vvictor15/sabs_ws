using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Security;
using System.ServiceModel.Channels;
using System.Xml.Serialization;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using WS_GENASYS.Agente.CltDatosGralInqV3;
using WS_GENASYS.Agente.ProdSvcInqV1;
using log4net;

namespace WS_GENASYS.Service
{
    public class DatosPersonalesService : IDatosPersonalesService, IDatosMediodePagoService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DatosPersonalesService));
        private static readonly bool isDebugEnabled = log.IsDebugEnabled;

        #region IDatosPersonalesService Members
        internal static Boolean CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public static string Replace(string valor)
        {
            if (valor == null)
                valor = "";

            return valor;
        }

        public DatosPersonalesResponse ConsultarDatos(DatosPersonalesRequest request)
        {

            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            string segTokenUsr_Login = ConfigurationManager.AppSettings["segTokenUsr.Login"];
            string wss_User = ConfigurationManager.AppSettings["wss:User"];
            string wss_Password = ConfigurationManager.AppSettings["wss:Password"];
            string clientApp_ClientCod = ConfigurationManager.AppSettings["clientApp.ClientCod"];
            string CltDatosGralInqRq_SelFlg = ConfigurationManager.AppSettings["CltDatosGralInqRq.SelFlg"];

            CltDatosGralInqRq_Type requestMBSimo = new CltDatosGralInqRq_Type();
            requestMBSimo.RqUID = Guid.NewGuid().ToString();

            WS_GENASYS.Agente.CltDatosGralInqV3.MsjRqHdr_Type msjRqHdr = new WS_GENASYS.Agente.CltDatosGralInqV3.MsjRqHdr_Type();
            WS_GENASYS.Agente.CltDatosGralInqV3.SegRqHdr_Type segRqHdr = new WS_GENASYS.Agente.CltDatosGralInqV3.SegRqHdr_Type();
            segRqHdr.ProdEmpAutzFlg = WS_GENASYS.Agente.CltDatosGralInqV3.TrueFalse.Item1;
            segRqHdr.ProdEmpAutzFlgSpecified = true;
            segRqHdr.ProdEspAutzFlg = WS_GENASYS.Agente.CltDatosGralInqV3.TrueFalse.Item1;
            segRqHdr.ProdEspAutzFlgSpecified = true;
            segRqHdr.TrnNivelAutz = WS_GENASYS.Agente.CltDatosGralInqV3.TrnNivelAutz_Type.Normal;
            segRqHdr.TrnNivelAutzSpecified = true;
            msjRqHdr.SegRqHdr = segRqHdr;

            WS_GENASYS.Agente.CltDatosGralInqV3.CredencialRqHdrLst_Type credencialRqHdrLst = new WS_GENASYS.Agente.CltDatosGralInqV3.CredencialRqHdrLst_Type();
            credencialRqHdrLst.Ctd = 1;

            WS_GENASYS.Agente.CltDatosGralInqV3.CredencialRqHdr_Type[] credencialRqHdr_Type = new WS_GENASYS.Agente.CltDatosGralInqV3.CredencialRqHdr_Type[1];

            //USUARIO APLICACION
            WS_GENASYS.Agente.CltDatosGralInqV3.CredencialRqHdr_Type credencialRqHdrUsuarioApp = new WS_GENASYS.Agente.CltDatosGralInqV3.CredencialRqHdr_Type();
            credencialRqHdrUsuarioApp.NroSec = 1;
            credencialRqHdrUsuarioApp.SegRol = WS_GENASYS.Agente.CltDatosGralInqV3.SegRol_Type.UsuarioApp;

            WS_GENASYS.Agente.CltDatosGralInqV3.SegTokenUsr_Type segTokenUsr = new WS_GENASYS.Agente.CltDatosGralInqV3.SegTokenUsr_Type();
            segTokenUsr.Login = segTokenUsr_Login;
            credencialRqHdrUsuarioApp.SegTokenUsr = new WS_GENASYS.Agente.CltDatosGralInqV3.SegTokenUsr_Type();
            credencialRqHdr_Type[0] = credencialRqHdrUsuarioApp;
            credencialRqHdr_Type[0].SegTokenUsr = segTokenUsr;

            credencialRqHdrLst.CredencialRqHdr = credencialRqHdr_Type;
            segRqHdr.CredencialRqHdrLst = credencialRqHdrLst;
            //FIN USUARIO APLICACION

            WS_GENASYS.Agente.CltDatosGralInqV3.CtxRqHdr_Type ctxRqHdr = new WS_GENASYS.Agente.CltDatosGralInqV3.CtxRqHdr_Type();
            ctxRqHdr.ClientFec = System.DateTime.Now;
            ctxRqHdr.OpnNro = request.NroOperacion;
            //ctxRqHdr.OpnExtornoNro = "";

            WS_GENASYS.Agente.CltDatosGralInqV3.ClientApp_Type clientApp = new WS_GENASYS.Agente.CltDatosGralInqV3.ClientApp_Type();
            clientApp.OrgCod = "1";
            clientApp.ClientCod = clientApp_ClientCod;

            ctxRqHdr.ClientApp = clientApp;
            msjRqHdr.CtxRqHdr = ctxRqHdr;
            requestMBSimo.MsjRqHdr = msjRqHdr;
            requestMBSimo.SelFlg = CltDatosGralInqRq_SelFlg;

            /*.----------------------------------------------------------------------*/
            requestMBSimo.CltDatosGralInqRef = new CltDatosGralInqRef_Type();
            requestMBSimo.CltDatosGralInqRef.IDC = request.IDC;

            MS_MB_CltDatosGralInqV3PortTypeClient proxy = new MS_MB_CltDatosGralInqV3PortTypeClient();
            proxy.ClientCredentials.UserName.UserName = wss_User;
            proxy.ClientCredentials.UserName.Password = wss_Password;

            MFX_CltDatosGralInq_Type requestServiceMB = new MFX_CltDatosGralInq_Type();
            requestServiceMB.CltDatosGralInqRq = requestMBSimo;

            BindingElementCollection elements = proxy.Endpoint.Binding.CreateBindingElements();
            elements.Find<SecurityBindingElement>().IncludeTimestamp = false;
            proxy.Endpoint.Binding = new CustomBinding(elements);

            DatosPersonalesResponse response = new DatosPersonalesResponse();
            response.Errores = new Errores();
            response.Direcciones = new Direcciones();

            if (isDebugEnabled) 
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(MFX_CltDatosGralInq_Type));
                    string xmlInput = string.Empty;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        serializer.Serialize(ms, requestServiceMB);
                        xmlInput = Encoding.UTF8.GetString(ms.ToArray());
                    }

                    log.Debug("WS:INPUT");
                    log.Debug(xmlInput);
                }
                catch (Exception)
                {
                    log.Debug("DOCUMENTO NO REGISTRADO");
                }

            }


            try
            {

                proxy.CltDatosGralInq(ref requestServiceMB);

                try
                {

                    if (isDebugEnabled)
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(MFX_CltDatosGralInq_Type));
                        string xmlOut = string.Empty;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            serializer.Serialize(ms, requestServiceMB);
                            xmlOut = Encoding.UTF8.GetString(ms.ToArray());
                        }

                        log.Debug("WS:OUTPUT");
                        log.Debug(xmlOut);
                    }

                }
                catch (Exception)
                {
                    log.Debug("DOCUMENTO NO REGISTRADO");
                }


                if (requestServiceMB != null)
                {

                    if (
                        (requestServiceMB.CltDatosGralInqRs.Status.StatusCod.CompareTo("DP6004") == 0) ||
                        (requestServiceMB.CltDatosGralInqRs.Status.StatusCod.CompareTo("DP6003") == 0) ||
                        (requestServiceMB.CltDatosGralInqRs.Status.StatusCod.CompareTo("DP6002") == 0) ||
                        (requestServiceMB.CltDatosGralInqRs.Status.StatusCod.CompareTo("DP6001") == 0) ||
                        (requestServiceMB.CltDatosGralInqRs.Status.StatusCod.CompareTo("DP6000") == 0) ||
                        (requestServiceMB.CltDatosGralInqRs.Status.StatusCod.CompareTo("DP5025") == 0)
                        )
                    {
                        Error error = new Error();
                        error.Codigo = "-1";
                        error.Descripcion = "*** MSBroker no disponible *** ";
                        response.Errores.Add(error);
                        return response;
                    }

                    response.StatusCod = requestServiceMB.CltDatosGralInqRs.Status.StatusCod;
                    response.Severidad = requestServiceMB.CltDatosGralInqRs.Status.Severidad.ToString();
                    response.StatusDes = requestServiceMB.CltDatosGralInqRs.Status.StatusDes;

                    if (requestServiceMB.CltDatosGralInqRs.Status.ServStatus != null)
                    {
                        response.ServStatusCod = requestServiceMB.CltDatosGralInqRs.Status.ServStatus.ServStatusCod;
                        if (requestServiceMB.CltDatosGralInqRs.Status.ServStatus.SeveridadSpecified)
                        {
                            response.ServSeveridad = requestServiceMB.CltDatosGralInqRs.Status.ServStatus.Severidad.ToString();
                        }
                        response.ServStatusDes = requestServiceMB.CltDatosGralInqRs.Status.ServStatus.StatusDes;
                    }

                    // respuesta satisfactoria del MB.
                    if (requestServiceMB.CltDatosGralInqRs.Status.StatusCod.CompareTo("MB0000") == 0)
                    {

                        // datos personales
                        response.Cliente = new Cliente();
                        response.Cliente.nombres = Replace(requestServiceMB.CltDatosGralInqRs.CltDatosGralInqReg.CltInfo.CltNom.NomCorto);
                        response.Cliente.apellido_paterno = Replace(requestServiceMB.CltDatosGralInqRs.CltDatosGralInqReg.CltInfo.CltNom.ApellidoPaterno);
                        response.Cliente.apellido_materno = Replace(requestServiceMB.CltDatosGralInqRs.CltDatosGralInqReg.CltInfo.CltNom.ApellidoMaterno);

                        if (requestServiceMB.CltDatosGralInqRs.CltDatosGralInqReg.CltInfo.FecNacimientoSpecified)
                        {
                            response.Cliente.fecha_nacimiento = requestServiceMB.CltDatosGralInqRs.CltDatosGralInqReg.CltInfo.FecNacimiento;
                        }
                        else
                        {
                            response.Cliente.fecha_nacimiento = null;
                        }

                        response.Cliente.nacionalidad = Replace(requestServiceMB.CltDatosGralInqRs.CltDatosGralInqReg.CltInfo.Nacionalidad);
                        response.Cliente.genero = Replace(requestServiceMB.CltDatosGralInqRs.CltDatosGralInqReg.CltInfo.Genero);
                        response.Cliente.estado_civil = Replace(requestServiceMB.CltDatosGralInqRs.CltDatosGralInqReg.CltInfo.StatusCivil);
                        response.Cliente.tipo_documento = Replace(requestServiceMB.CltDatosGralInqRs.CltDatosGralInqReg.CltInfo.IDC.Substring(12, 1));
                        response.Cliente.numero_documento = Replace(requestServiceMB.CltDatosGralInqRs.CltDatosGralInqReg.CltInfo.IDC.Substring(0, 12));
                        response.Cliente.profesion = Replace(requestServiceMB.CltDatosGralInqRs.CltDatosGralInqReg.CltInfo.Profesion);

                        // direcciones
                        long cantidadDirecciones = requestServiceMB.CltDatosGralInqRs.CltDatosGralInqReg.CltInfo.DirEstLst.Ctd;
                        for (int index = 0; index < cantidadDirecciones; index++)
                        {
                            DirEst_Type direccionMB = requestServiceMB.CltDatosGralInqRs.CltDatosGralInqReg.CltInfo.DirEstLst.DirEst[index];

                            Direccion direccion = new Direccion();
                            direccion.numero_secuencia = Replace(direccionMB.IdSec);
                            direccion.tipo_direccion = Replace(direccionMB.DirTp);
                            direccion.tipo_via = Replace(direccionMB.ViaTp);
                            direccion.nombre_via = Replace(direccionMB.ViaNom);
                            direccion.numero_via = Replace(direccionMB.ViaNro);
                            direccion.departamento_piso_interior = Replace(direccionMB.DptoTp);
                            direccion.numero_departamento_piso_interior = Replace(direccionMB.DptoNro);
                            direccion.manzana = Replace(direccionMB.Mz);
                            direccion.lote = Replace(direccionMB.Lt);
                            direccion.tipo_habitacional_codurbanizacion = Replace(direccionMB.UrbTp);
                            direccion.nombre_habitacional_codurbanizacion = Replace(direccionMB.UrbNom);
                            direccion.sector_etapa_zona = Replace(direccionMB.SectorTp);
                            direccion.nombre_sector_etapa_zona = Replace(direccionMB.SectorNom);
                            direccion.localidad = Replace(direccionMB.UbiCod);
                            direccion.telefono = Replace(direccionMB.TlfClt);
                            direccion.direccion_comprimida = Replace(direccionMB.DirLinea1);
                            response.Direcciones.Add(direccion);
                        }
                    }

                    // Adiciona status error
                    Error errMB = new Error();
                    errMB.Codigo = requestServiceMB.CltDatosGralInqRs.Status.StatusCod;
                    errMB.Descripcion = requestServiceMB.CltDatosGralInqRs.Status.StatusDes;
                    response.Errores.Add(errMB);

                    // Carga los errores
                    if (requestServiceMB.CltDatosGralInqRs.Status.StatusAdicLst != null)
                    {
                        long cantidad = requestServiceMB.CltDatosGralInqRs.Status.StatusAdicLst.Ctd;
                        for (long index = 0; index < cantidad; index++)
                        {
                            Error errorMB = new Error();
                            errorMB.Codigo = requestServiceMB.CltDatosGralInqRs.Status.StatusAdicLst.StatusAdic[index].StatusCod;
                            errorMB.Descripcion = requestServiceMB.CltDatosGralInqRs.Status.StatusAdicLst.StatusAdic[index].StatusDes;
                            response.Errores.Add(errorMB);
                        }
                    }
                }

            }
            catch (TimeoutException ex)
            {
                log.Error("Error Invocando Servicio", ex);
                Error error = new Error();
                error.Codigo = "-1";
                error.Descripcion = String.Concat("MSBroker no disponible. ", ex.Message, ". ", ex.Source);
                response.Errores.Add(error);
            }
            catch (Exception ex)
            {
                log.Error("Error Invocando Servicio", ex);
                Error error = new Error();
                error.Codigo = "-2";
                error.Descripcion = String.Concat("Error no especificado. ", ex.Message, ". ", ex.Source);
                response.Errores.Add(error);
            }
            finally
            {
                proxy.Close();
            }

            return response;
        }
        #endregion

        /*Medio de Pago*/
        public DatosMedioPagoResponse ConsultarMedioPago(DatosPersonalesRequest request) 
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            string segTokenUsr_Login = ConfigurationManager.AppSettings["segTokenUsr.LoginMP"];
            string wss_User = ConfigurationManager.AppSettings["wss:User"];
            string wss_Password = ConfigurationManager.AppSettings["wss:Password"];
            string clientApp_ClientCod = ConfigurationManager.AppSettings["clientApp.ClientCodMP"];
            string TipoSelector = ConfigurationManager.AppSettings["ProdSvcInqRef.SvcSelector"];
            string CodNecesidad = ConfigurationManager.AppSettings["ProdSvcInqRef.ProdSvcCod"];

            ProdSvcInqRq_Type requestMBSimo = new ProdSvcInqRq_Type();  
            requestMBSimo.RqUID = Guid.NewGuid().ToString();

            WS_GENASYS.Agente.ProdSvcInqV1.MsjRqHdr_Type msjRqHdr = new WS_GENASYS.Agente.ProdSvcInqV1.MsjRqHdr_Type();
            WS_GENASYS.Agente.ProdSvcInqV1.SegRqHdr_Type segRqHdr = new WS_GENASYS.Agente.ProdSvcInqV1.SegRqHdr_Type();
            segRqHdr.ProdEmpAutzFlg = WS_GENASYS.Agente.ProdSvcInqV1.TrueFalse.Item1;
            segRqHdr.ProdEmpAutzFlgSpecified = true;
            segRqHdr.ProdEspAutzFlg = WS_GENASYS.Agente.ProdSvcInqV1.TrueFalse.Item1;
            segRqHdr.ProdEspAutzFlgSpecified = true;
            msjRqHdr.SegRqHdr = segRqHdr;

            WS_GENASYS.Agente.ProdSvcInqV1.CredencialRqHdrLst_Type credencialRqHdrLst = new WS_GENASYS.Agente.ProdSvcInqV1.CredencialRqHdrLst_Type();
            credencialRqHdrLst.Ctd = 2;

            WS_GENASYS.Agente.ProdSvcInqV1.CredencialRqHdr_Type[] credencialRqHdr_Type = new WS_GENASYS.Agente.ProdSvcInqV1.CredencialRqHdr_Type[2];

            //USUARIO APLICACION

            WS_GENASYS.Agente.ProdSvcInqV1.CredencialRqHdr_Type credencialRqHdrUsuarioApp = new WS_GENASYS.Agente.ProdSvcInqV1.CredencialRqHdr_Type();
            credencialRqHdrUsuarioApp.NroSec = 1;
            credencialRqHdrUsuarioApp.SegRol = WS_GENASYS.Agente.ProdSvcInqV1.SegRol_Type.UsuarioApp;

            WS_GENASYS.Agente.ProdSvcInqV1.CredencialRqHdr_Type credencialRqHdrUsuarioApp2 = new WS_GENASYS.Agente.ProdSvcInqV1.CredencialRqHdr_Type();
            credencialRqHdrUsuarioApp2.NroSec = 2;
            credencialRqHdrUsuarioApp2.SegRol = WS_GENASYS.Agente.ProdSvcInqV1.SegRol_Type.UsuarioRq;

            WS_GENASYS.Agente.ProdSvcInqV1.SegTokenUsr_Type segTokenUsr = new WS_GENASYS.Agente.ProdSvcInqV1.SegTokenUsr_Type();
            segTokenUsr.Login = segTokenUsr_Login;
            credencialRqHdrUsuarioApp.SegTokenUsr = new WS_GENASYS.Agente.ProdSvcInqV1.SegTokenUsr_Type();
            credencialRqHdr_Type[0] = credencialRqHdrUsuarioApp;
            credencialRqHdr_Type[0].SegTokenUsr = segTokenUsr;

            WS_GENASYS.Agente.ProdSvcInqV1.SegTokenUsr_Type segTokenUsr2 = new WS_GENASYS.Agente.ProdSvcInqV1.SegTokenUsr_Type();
            segTokenUsr2.Login = request.CodFuncionario;

            credencialRqHdr_Type[1] = credencialRqHdrUsuarioApp2;
            credencialRqHdr_Type[1].SegTokenUsr = segTokenUsr2;

            credencialRqHdrLst.CredencialRqHdr = credencialRqHdr_Type;

            segRqHdr.CredencialRqHdrLst = credencialRqHdrLst;
            //FIN USUARIO APLICACION

            WS_GENASYS.Agente.ProdSvcInqV1.CtxRqHdr_Type ctxRqHdr = new WS_GENASYS.Agente.ProdSvcInqV1.CtxRqHdr_Type();
            ctxRqHdr.ClientFec = System.DateTime.Now;
            ctxRqHdr.OpnNro =  request.NroOperacion; 
            ctxRqHdr.OpnExtornoNro = "0";

            WS_GENASYS.Agente.ProdSvcInqV1.ClientApp_Type clientApp = new WS_GENASYS.Agente.ProdSvcInqV1.ClientApp_Type();
            clientApp.OrgCod = "1";
            clientApp.ClientCod = clientApp_ClientCod;

            ctxRqHdr.ExtornoFlg = WS_GENASYS.Agente.ProdSvcInqV1.TrueFalse.Item0;
            ctxRqHdr.ExtornoFlgSpecified = true;

            ctxRqHdr.ClientApp = clientApp;
            msjRqHdr.CtxRqHdr = ctxRqHdr;
            requestMBSimo.MsjRqHdr = msjRqHdr;

            requestMBSimo.ProdSvcInqRef = new ProdSvcInqRef_Type();
            requestMBSimo.ProdSvcInqRef.SvcSelector = TipoSelector;
            requestMBSimo.ProdSvcInqRef.IDC = request.IDC;
            requestMBSimo.ProdSvcInqRef.ProdSvcCod = CodNecesidad;
            //---

            MS_MB_ProdSvcInqV1PortTypeClient proxy = new MS_MB_ProdSvcInqV1PortTypeClient();
            proxy.ClientCredentials.UserName.UserName = wss_User;
            proxy.ClientCredentials.UserName.Password = wss_Password;

            MFX_ProdSvcInq_Type requestServiceMB = new MFX_ProdSvcInq_Type();
            requestServiceMB.ProdSvcInqRq = requestMBSimo;

            BindingElementCollection elements = proxy.Endpoint.Binding.CreateBindingElements();
            elements.Find<SecurityBindingElement>().IncludeTimestamp = false;
            proxy.Endpoint.Binding = new CustomBinding(elements);

            DatosMedioPagoResponse response = new DatosMedioPagoResponse();
            response.Errores = new Errores();
            response.MediodePagoData = new MediodePagoData();

            if (isDebugEnabled)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(MFX_ProdSvcInq_Type));
                    string xmlInput = string.Empty;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        serializer.Serialize(ms, requestServiceMB);
                        xmlInput = Encoding.UTF8.GetString(ms.ToArray());
                    }

                    log.Debug("WS:INPUT");
                    log.Debug(xmlInput);
                }
                catch (Exception)
                {
                    log.Debug("DOCUMENTO NO REGISTRADO");
                }

            }


            try
            {

                proxy.ProdSvcInq(ref requestServiceMB);

                try
                {

                    if (isDebugEnabled)
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(MFX_ProdSvcInq_Type));
                        string xmlOut = string.Empty;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            serializer.Serialize(ms, requestServiceMB);
                            xmlOut = Encoding.UTF8.GetString(ms.ToArray());
                        }

                        log.Debug("WS:OUTPUT");
                        log.Debug(xmlOut);
                    }

                }
                catch (Exception)
                {
                    log.Debug("DOCUMENTO NO REGISTRADO");
                }

                if (requestServiceMB != null)
                {

                    if (
                        (requestServiceMB.ProdSvcInqRs.Status.StatusCod.CompareTo("DP6004") == 0) ||
                        (requestServiceMB.ProdSvcInqRs.Status.StatusCod.CompareTo("DP6003") == 0) ||
                        (requestServiceMB.ProdSvcInqRs.Status.StatusCod.CompareTo("DP6002") == 0) ||
                        (requestServiceMB.ProdSvcInqRs.Status.StatusCod.CompareTo("DP6001") == 0) ||
                        (requestServiceMB.ProdSvcInqRs.Status.StatusCod.CompareTo("DP6000") == 0) ||
                        (requestServiceMB.ProdSvcInqRs.Status.StatusCod.CompareTo("DP5025") == 0)
                        )
                    {
                        Error error = new Error();
                        error.Codigo = "-1";
                        error.Descripcion = "*** MSBroker no disponible *** ";
                        response.Errores.Add(error);
                        return response;
                    }

                    response.StatusCod = requestServiceMB.ProdSvcInqRs.Status.StatusCod;
                    response.Severidad = requestServiceMB.ProdSvcInqRs.Status.Severidad.ToString();
                    response.StatusDes = requestServiceMB.ProdSvcInqRs.Status.StatusDes;

                    if (requestServiceMB.ProdSvcInqRs.Status.ServStatus != null)
                    {
                        response.ServStatusCod = requestServiceMB.ProdSvcInqRs.Status.ServStatus.ServStatusCod;

                        if (requestServiceMB.ProdSvcInqRs.Status.ServStatus.SeveridadSpecified)
                        {
                            response.ServSeveridad = requestServiceMB.ProdSvcInqRs.Status.ServStatus.Severidad.ToString();
                        }
                        response.ServStatusDes = requestServiceMB.ProdSvcInqRs.Status.ServStatus.StatusDes;
                    }

                    // respuesta satisfactoria del MB.
                    if (requestServiceMB.ProdSvcInqRs.Status.StatusCod.CompareTo("MB0000") == 0)
                    {
                        /*Datos del Medio de Pago*/
                        long cantidadMP = requestServiceMB.ProdSvcInqRs.ProdSvcInqReg.ProdSvcLst.Ctd;

                        for (int index = 0; index < cantidadMP; index++)
                        {
                            ProdSvc_Type cuentasMB = requestServiceMB.ProdSvcInqRs.ProdSvcInqReg.ProdSvcLst.ProdSvc[index];
                            
                            MediodePago MPago = new MediodePago();

                            MPago.numero_medioPago = cuentasMB.ProdNro;
                            MPago.cod_familia = cuentasMB.ClsEstFamCod;
                            MPago.cod_producto = cuentasMB.ClsEstProdCod;
                            MPago.cod_estadoproducto = cuentasMB.ProdStatusCod;
                            MPago.des_estadoproducto = cuentasMB.ProdStatusDes;
                            

                            //Cargando Productos por tipo de selector.
                            if (TipoSelector== "04")
                            {
                                /*Valida si la cuenta esta activa*/
                                string CodEstadoProd = Replace(cuentasMB.ProdStatusCod);
                                if (CodEstadoProd.Trim() == "00")
                                {
                                    /*Obtenemos el codigo de la moneda*/
                                    long cantMnd = cuentasMB.SaldoLst.Ctd;
                                    if (cantMnd > 0)
                                    {
                                        MPago.cod_moneda = cuentasMB.SaldoLst.Saldo[0].SaldoMto.MonCod;
                                    }

                                    response.MediodePagoData.Add(MPago);
                                }
                            }
                            else
                            {
                                MPago.cod_moneda = cuentasMB.MonCod;
                                response.MediodePagoData.Add(MPago);
                            }

                           
                            
                        }

                    }

                    // Adiciona status error
                    Error errMB = new Error();
                    errMB.Codigo = requestServiceMB.ProdSvcInqRs.Status.StatusCod;
                    errMB.Descripcion = requestServiceMB.ProdSvcInqRs.Status.StatusDes;
                    response.Errores.Add(errMB);

                    // Carga los errores
                    if (requestServiceMB.ProdSvcInqRs.Status.StatusAdicLst != null)
                    {
                        long cantidad = requestServiceMB.ProdSvcInqRs.Status.StatusAdicLst.Ctd;
                        for (long index = 0; index < cantidad; index++)
                        {
                            Error errorMB = new Error();
                            errorMB.Codigo = requestServiceMB.ProdSvcInqRs.Status.StatusAdicLst.StatusAdic[index].StatusCod;
                            errorMB.Descripcion = requestServiceMB.ProdSvcInqRs.Status.StatusAdicLst.StatusAdic[index].StatusDes;
                            response.Errores.Add(errorMB);
                        }
                    }
                }

            }
            catch (TimeoutException ex)
            {
                log.Error("Error Invocando Servicio", ex);
                Error error = new Error();
                error.Codigo = "-1";
                error.Descripcion = String.Concat("MSBroker no disponible. ", ex.Message, ". ", ex.Source);
                response.Errores.Add(error);
            }
            catch (Exception ex)
            {
                log.Error("Error Invocando Servicio", ex);
                Error error = new Error();
                error.Codigo = "-2";
                error.Descripcion = String.Concat("Error no especificado. ", ex.Message, ". ", ex.Source);
                response.Errores.Add(error);
            }
            finally
            {
                proxy.Close();
            }

            return response;
        }
    }
}