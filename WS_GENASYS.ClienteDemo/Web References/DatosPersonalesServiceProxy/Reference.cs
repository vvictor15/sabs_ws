﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
// 
#pragma warning disable 1591

namespace WS_GENASYS.ClienteDemo.DatosPersonalesServiceProxy {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1099.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BasicHttpBinding_IDatosPersonalesService", Namespace="http://tempuri.org/")]
    public partial class BasicHttpBinding_IDatosPersonalesService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ConsultarDatosOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public BasicHttpBinding_IDatosPersonalesService() {
            this.Url = global::WS_GENASYS.ClienteDemo.Properties.Settings.Default.WS_GENASYS_ClienteDemo_DatosPersonalesServiceProxy_DatosPersonalesService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ConsultarDatosCompletedEventHandler ConsultarDatosCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IDatosPersonalesService/ConsultarDatos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public DatosPersonalesResponse ConsultarDatos([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] DatosPersonalesRequest request) {
            object[] results = this.Invoke("ConsultarDatos", new object[] {
                        request});
            return ((DatosPersonalesResponse)(results[0]));
        }
        
        /// <remarks/>
        public void ConsultarDatosAsync(DatosPersonalesRequest request) {
            this.ConsultarDatosAsync(request, null);
        }
        
        /// <remarks/>
        public void ConsultarDatosAsync(DatosPersonalesRequest request, object userState) {
            if ((this.ConsultarDatosOperationCompleted == null)) {
                this.ConsultarDatosOperationCompleted = new System.Threading.SendOrPostCallback(this.OnConsultarDatosOperationCompleted);
            }
            this.InvokeAsync("ConsultarDatos", new object[] {
                        request}, this.ConsultarDatosOperationCompleted, userState);
        }
        
        private void OnConsultarDatosOperationCompleted(object arg) {
            if ((this.ConsultarDatosCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ConsultarDatosCompleted(this, new ConsultarDatosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1099.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BasicHttpBinding_IDatosMediodePagoService", Namespace="http://tempuri.org/")]
    public partial class BasicHttpBinding_IDatosMediodePagoService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ConsultarMedioPagoOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public BasicHttpBinding_IDatosMediodePagoService() {
            this.Url = global::WS_GENASYS.ClienteDemo.Properties.Settings.Default.WS_GENASYS_ClienteDemo_DatosPersonalesServiceProxy_DatosPersonalesService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ConsultarMedioPagoCompletedEventHandler ConsultarMedioPagoCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IDatosMediodePagoService/ConsultarMedioPago", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public DatosMedioPagoResponse ConsultarMedioPago([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] DatosPersonalesRequest request) {
            object[] results = this.Invoke("ConsultarMedioPago", new object[] {
                        request});
            return ((DatosMedioPagoResponse)(results[0]));
        }
        
        /// <remarks/>
        public void ConsultarMedioPagoAsync(DatosPersonalesRequest request) {
            this.ConsultarMedioPagoAsync(request, null);
        }
        
        /// <remarks/>
        public void ConsultarMedioPagoAsync(DatosPersonalesRequest request, object userState) {
            if ((this.ConsultarMedioPagoOperationCompleted == null)) {
                this.ConsultarMedioPagoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnConsultarMedioPagoOperationCompleted);
            }
            this.InvokeAsync("ConsultarMedioPago", new object[] {
                        request}, this.ConsultarMedioPagoOperationCompleted, userState);
        }
        
        private void OnConsultarMedioPagoOperationCompleted(object arg) {
            if ((this.ConsultarMedioPagoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ConsultarMedioPagoCompleted(this, new ConsultarMedioPagoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3163.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/WS_GENASYS.Service")]
    public partial class DatosPersonalesRequest {
        
        private string codFuncionarioField;
        
        private string iDCField;
        
        private string nroOperacionField;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string CodFuncionario {
            get {
                return this.codFuncionarioField;
            }
            set {
                this.codFuncionarioField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string IDC {
            get {
                return this.iDCField;
            }
            set {
                this.iDCField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string NroOperacion {
            get {
                return this.nroOperacionField;
            }
            set {
                this.nroOperacionField = value;
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3163.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/WS_GENASYS.Service")]
    public partial class MediodePago {
        
        private string cod_estadoproductoField;
        
        private string cod_familiaField;
        
        private string cod_monedaField;
        
        private string cod_productoField;
        
        private string des_estadoproductoField;
        
        private string numero_medioPagoField;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string cod_estadoproducto {
            get {
                return this.cod_estadoproductoField;
            }
            set {
                this.cod_estadoproductoField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string cod_familia {
            get {
                return this.cod_familiaField;
            }
            set {
                this.cod_familiaField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string cod_moneda {
            get {
                return this.cod_monedaField;
            }
            set {
                this.cod_monedaField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string cod_producto {
            get {
                return this.cod_productoField;
            }
            set {
                this.cod_productoField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string des_estadoproducto {
            get {
                return this.des_estadoproductoField;
            }
            set {
                this.des_estadoproductoField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string numero_medioPago {
            get {
                return this.numero_medioPagoField;
            }
            set {
                this.numero_medioPagoField = value;
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3163.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/WS_GENASYS.Service")]
    public partial class DatosMedioPagoResponse {
        
        private Error[] erroresField;
        
        private MediodePago[] mediodePagoDataField;
        
        private string servSeveridadField;
        
        private string servStatusCodField;
        
        private string servStatusDesField;
        
        private string severidadField;
        
        private string statusCodField;
        
        private string statusDesField;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        public Error[] Errores {
            get {
                return this.erroresField;
            }
            set {
                this.erroresField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        public MediodePago[] MediodePagoData {
            get {
                return this.mediodePagoDataField;
            }
            set {
                this.mediodePagoDataField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ServSeveridad {
            get {
                return this.servSeveridadField;
            }
            set {
                this.servSeveridadField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ServStatusCod {
            get {
                return this.servStatusCodField;
            }
            set {
                this.servStatusCodField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ServStatusDes {
            get {
                return this.servStatusDesField;
            }
            set {
                this.servStatusDesField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Severidad {
            get {
                return this.severidadField;
            }
            set {
                this.severidadField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string StatusCod {
            get {
                return this.statusCodField;
            }
            set {
                this.statusCodField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string StatusDes {
            get {
                return this.statusDesField;
            }
            set {
                this.statusDesField = value;
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3163.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/WS_GENASYS.Service")]
    public partial class Error {
        
        private string codigoField;
        
        private string descripcionField;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Codigo {
            get {
                return this.codigoField;
            }
            set {
                this.codigoField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Descripcion {
            get {
                return this.descripcionField;
            }
            set {
                this.descripcionField = value;
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3163.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/WS_GENASYS.Service")]
    public partial class Direccion {
        
        private string departamento_piso_interiorField;
        
        private string direccion_comprimidaField;
        
        private string localidadField;
        
        private string loteField;
        
        private string manzanaField;
        
        private string nombre_habitacional_codurbanizacionField;
        
        private string nombre_sector_etapa_zonaField;
        
        private string nombre_viaField;
        
        private string numero_departamento_piso_interiorField;
        
        private string numero_secuenciaField;
        
        private string numero_viaField;
        
        private string sector_etapa_zonaField;
        
        private string telefonoField;
        
        private string tipo_direccionField;
        
        private string tipo_habitacional_codurbanizacionField;
        
        private string tipo_viaField;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string departamento_piso_interior {
            get {
                return this.departamento_piso_interiorField;
            }
            set {
                this.departamento_piso_interiorField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string direccion_comprimida {
            get {
                return this.direccion_comprimidaField;
            }
            set {
                this.direccion_comprimidaField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string localidad {
            get {
                return this.localidadField;
            }
            set {
                this.localidadField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string lote {
            get {
                return this.loteField;
            }
            set {
                this.loteField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string manzana {
            get {
                return this.manzanaField;
            }
            set {
                this.manzanaField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string nombre_habitacional_codurbanizacion {
            get {
                return this.nombre_habitacional_codurbanizacionField;
            }
            set {
                this.nombre_habitacional_codurbanizacionField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string nombre_sector_etapa_zona {
            get {
                return this.nombre_sector_etapa_zonaField;
            }
            set {
                this.nombre_sector_etapa_zonaField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string nombre_via {
            get {
                return this.nombre_viaField;
            }
            set {
                this.nombre_viaField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string numero_departamento_piso_interior {
            get {
                return this.numero_departamento_piso_interiorField;
            }
            set {
                this.numero_departamento_piso_interiorField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string numero_secuencia {
            get {
                return this.numero_secuenciaField;
            }
            set {
                this.numero_secuenciaField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string numero_via {
            get {
                return this.numero_viaField;
            }
            set {
                this.numero_viaField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string sector_etapa_zona {
            get {
                return this.sector_etapa_zonaField;
            }
            set {
                this.sector_etapa_zonaField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string telefono {
            get {
                return this.telefonoField;
            }
            set {
                this.telefonoField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string tipo_direccion {
            get {
                return this.tipo_direccionField;
            }
            set {
                this.tipo_direccionField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string tipo_habitacional_codurbanizacion {
            get {
                return this.tipo_habitacional_codurbanizacionField;
            }
            set {
                this.tipo_habitacional_codurbanizacionField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string tipo_via {
            get {
                return this.tipo_viaField;
            }
            set {
                this.tipo_viaField = value;
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3163.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/WS_GENASYS.Service")]
    public partial class Cliente {
        
        private string apellido_maternoField;
        
        private string apellido_paternoField;
        
        private string estado_civilField;
        
        private System.Nullable<System.DateTime> fecha_nacimientoField;
        
        private bool fecha_nacimientoFieldSpecified;
        
        private string generoField;
        
        private string nacionalidadField;
        
        private string nombresField;
        
        private string numero_documentoField;
        
        private string profesionField;
        
        private string tipo_documentoField;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string apellido_materno {
            get {
                return this.apellido_maternoField;
            }
            set {
                this.apellido_maternoField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string apellido_paterno {
            get {
                return this.apellido_paternoField;
            }
            set {
                this.apellido_paternoField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string estado_civil {
            get {
                return this.estado_civilField;
            }
            set {
                this.estado_civilField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> fecha_nacimiento {
            get {
                return this.fecha_nacimientoField;
            }
            set {
                this.fecha_nacimientoField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool fecha_nacimientoSpecified {
            get {
                return this.fecha_nacimientoFieldSpecified;
            }
            set {
                this.fecha_nacimientoFieldSpecified = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string genero {
            get {
                return this.generoField;
            }
            set {
                this.generoField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string nacionalidad {
            get {
                return this.nacionalidadField;
            }
            set {
                this.nacionalidadField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string nombres {
            get {
                return this.nombresField;
            }
            set {
                this.nombresField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string numero_documento {
            get {
                return this.numero_documentoField;
            }
            set {
                this.numero_documentoField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string profesion {
            get {
                return this.profesionField;
            }
            set {
                this.profesionField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string tipo_documento {
            get {
                return this.tipo_documentoField;
            }
            set {
                this.tipo_documentoField = value;
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3163.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/WS_GENASYS.Service")]
    public partial class DatosPersonalesResponse {
        
        private Cliente clienteField;
        
        private Direccion[] direccionesField;
        
        private Error[] erroresField;
        
        private string servSeveridadField;
        
        private string servStatusCodField;
        
        private string servStatusDesField;
        
        private string severidadField;
        
        private string statusCodField;
        
        private string statusDesField;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public Cliente Cliente {
            get {
                return this.clienteField;
            }
            set {
                this.clienteField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        public Direccion[] Direcciones {
            get {
                return this.direccionesField;
            }
            set {
                this.direccionesField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        public Error[] Errores {
            get {
                return this.erroresField;
            }
            set {
                this.erroresField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ServSeveridad {
            get {
                return this.servSeveridadField;
            }
            set {
                this.servSeveridadField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ServStatusCod {
            get {
                return this.servStatusCodField;
            }
            set {
                this.servStatusCodField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ServStatusDes {
            get {
                return this.servStatusDesField;
            }
            set {
                this.servStatusDesField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Severidad {
            get {
                return this.severidadField;
            }
            set {
                this.severidadField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string StatusCod {
            get {
                return this.statusCodField;
            }
            set {
                this.statusCodField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string StatusDes {
            get {
                return this.statusDesField;
            }
            set {
                this.statusDesField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1099.0")]
    public delegate void ConsultarDatosCompletedEventHandler(object sender, ConsultarDatosCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1099.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ConsultarDatosCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ConsultarDatosCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public DatosPersonalesResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((DatosPersonalesResponse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1099.0")]
    public delegate void ConsultarMedioPagoCompletedEventHandler(object sender, ConsultarMedioPagoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1099.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ConsultarMedioPagoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ConsultarMedioPagoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public DatosMedioPagoResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((DatosMedioPagoResponse)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591