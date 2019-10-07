﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

namespace Uruguay
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="Cotiza", ConfigurationName="Uruguay.wsbcucotizacionesSoapPort")]
    public interface wsbcucotizacionesSoapPort
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="Cotizaaction/AWSBCUCOTIZACIONES.Execute", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Uruguay.ExecuteResponse> ExecuteAsync(Uruguay.ExecuteRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Cotiza")]
    public partial class wsbcucotizacionesin
    {
        
        private short[] monedaField;
        
        private System.Nullable<System.DateTime> fechaDesdeField;
        
        private System.Nullable<System.DateTime> fechaHastaField;
        
        private sbyte grupoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", IsNullable=false)]
        public short[] Moneda
        {
            get
            {
                return this.monedaField;
            }
            set
            {
                this.monedaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", IsNullable=true, Order=1)]
        public System.Nullable<System.DateTime> FechaDesde
        {
            get
            {
                return this.fechaDesdeField;
            }
            set
            {
                this.fechaDesdeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", IsNullable=true, Order=2)]
        public System.Nullable<System.DateTime> FechaHasta
        {
            get
            {
                return this.fechaHastaField;
            }
            set
            {
                this.fechaHastaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public sbyte Grupo
        {
            get
            {
                return this.grupoField;
            }
            set
            {
                this.grupoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName="datoscotizaciones.dato", Namespace="Cotiza")]
    public partial class datoscotizacionesdato
    {
        
        private System.Nullable<System.DateTime> fechaField;
        
        private short monedaField;
        
        private string nombreField;
        
        private string codigoISOField;
        
        private string emisorField;
        
        private double tCCField;
        
        private double tCVField;
        
        private double arbActField;
        
        private sbyte formaArbitrarField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date", IsNullable=true, Order=0)]
        public System.Nullable<System.DateTime> Fecha
        {
            get
            {
                return this.fechaField;
            }
            set
            {
                this.fechaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public short Moneda
        {
            get
            {
                return this.monedaField;
            }
            set
            {
                this.monedaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Nombre
        {
            get
            {
                return this.nombreField;
            }
            set
            {
                this.nombreField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string CodigoISO
        {
            get
            {
                return this.codigoISOField;
            }
            set
            {
                this.codigoISOField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Emisor
        {
            get
            {
                return this.emisorField;
            }
            set
            {
                this.emisorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public double TCC
        {
            get
            {
                return this.tCCField;
            }
            set
            {
                this.tCCField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public double TCV
        {
            get
            {
                return this.tCVField;
            }
            set
            {
                this.tCVField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public double ArbAct
        {
            get
            {
                return this.arbActField;
            }
            set
            {
                this.arbActField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public sbyte FormaArbitrar
        {
            get
            {
                return this.formaArbitrarField;
            }
            set
            {
                this.formaArbitrarField = value;
            }
        }

        public override string ToString()
        {
            return $"Moneda: {Nombre} - Compra: {TCC} - Venta: {TCV} - Fecha: {Fecha.Value.ToString("yyyy-MM-dd")}";
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Cotiza")]
    public partial class respuestastatus
    {
        
        private sbyte statusField;
        
        private short codigoerrorField;
        
        private string mensajeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public sbyte status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public short codigoerror
        {
            get
            {
                return this.codigoerrorField;
            }
            set
            {
                this.codigoerrorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string mensaje
        {
            get
            {
                return this.mensajeField;
            }
            set
            {
                this.mensajeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Cotiza")]
    public partial class wsbcucotizacionesout
    {
        
        private respuestastatus respuestastatusField;
        
        private datoscotizacionesdato[] datoscotizacionesField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public respuestastatus respuestastatus
        {
            get
            {
                return this.respuestastatusField;
            }
            set
            {
                this.respuestastatusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public datoscotizacionesdato[] datoscotizaciones
        {
            get
            {
                return this.datoscotizacionesField;
            }
            set
            {
                this.datoscotizacionesField = value;
            }
        }

        public override string ToString()
        {
            if (respuestastatus == null || respuestastatus.status == 0 || 
                datoscotizacionesField == null || datoscotizacionesField.Length == 0)
            {
                return string.Empty;
            }
            string result = string.Empty;
            foreach (datoscotizacionesdato dato in datoscotizacionesField)
            {
                result += $"{dato.ToString()}";
            }
            return result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="wsbcucotizaciones.Execute", WrapperNamespace="Cotiza", IsWrapped=true)]
    public partial class ExecuteRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="Cotiza", Order=0)]
        public Uruguay.wsbcucotizacionesin Entrada;
        
        public ExecuteRequest()
        {
        }
        
        public ExecuteRequest(Uruguay.wsbcucotizacionesin Entrada)
        {
            this.Entrada = Entrada;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="wsbcucotizaciones.ExecuteResponse", WrapperNamespace="Cotiza", IsWrapped=true)]
    public partial class ExecuteResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="Cotiza", Order=0)]
        public Uruguay.wsbcucotizacionesout Salida;
        
        public ExecuteResponse()
        {
        }
        
        public ExecuteResponse(Uruguay.wsbcucotizacionesout Salida)
        {
            this.Salida = Salida;
        }

        public override string ToString()
        {
            return Salida.ToString();
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    public interface wsbcucotizacionesSoapPortChannel : Uruguay.wsbcucotizacionesSoapPort, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    public partial class wsbcucotizacionesSoapPortClient : System.ServiceModel.ClientBase<Uruguay.wsbcucotizacionesSoapPort>, Uruguay.wsbcucotizacionesSoapPort
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public wsbcucotizacionesSoapPortClient() : 
                base(wsbcucotizacionesSoapPortClient.GetDefaultBinding(), wsbcucotizacionesSoapPortClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.wsbcucotizacionesSoapPort.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public wsbcucotizacionesSoapPortClient(EndpointConfiguration endpointConfiguration) : 
                base(wsbcucotizacionesSoapPortClient.GetBindingForEndpoint(endpointConfiguration), wsbcucotizacionesSoapPortClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public wsbcucotizacionesSoapPortClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(wsbcucotizacionesSoapPortClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public wsbcucotizacionesSoapPortClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(wsbcucotizacionesSoapPortClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public wsbcucotizacionesSoapPortClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Uruguay.ExecuteResponse> Uruguay.wsbcucotizacionesSoapPort.ExecuteAsync(Uruguay.ExecuteRequest request)
        {
            return base.Channel.ExecuteAsync(request);
        }
        
        public System.Threading.Tasks.Task<Uruguay.ExecuteResponse> ExecuteAsync(Uruguay.wsbcucotizacionesin Entrada)
        {
            Uruguay.ExecuteRequest inValue = new Uruguay.ExecuteRequest();
            inValue.Entrada = Entrada;
            return ((Uruguay.wsbcucotizacionesSoapPort)(this)).ExecuteAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.wsbcucotizacionesSoapPort))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.wsbcucotizacionesSoapPort))
            {
                return new System.ServiceModel.EndpointAddress("https://cotizaciones.bcu.gub.uy/wscotizaciones/servlet/awsbcucotizaciones");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return wsbcucotizacionesSoapPortClient.GetBindingForEndpoint(EndpointConfiguration.wsbcucotizacionesSoapPort);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return wsbcucotizacionesSoapPortClient.GetEndpointAddress(EndpointConfiguration.wsbcucotizacionesSoapPort);
        }
        
        public enum EndpointConfiguration
        {
            
            wsbcucotizacionesSoapPort,
        }
    }
}
