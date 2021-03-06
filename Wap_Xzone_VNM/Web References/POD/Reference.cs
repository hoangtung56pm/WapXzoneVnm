﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.17929.
// 
#pragma warning disable 1591

namespace WapXzone_VNM.POD {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="S2ProcessSoap", Namespace="http://tempuri.org/")]
    public partial class S2Process : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback RegisterOperationCompleted;
        
        private System.Threading.SendOrPostCallback BPRegisterOperationCompleted;
        
        private System.Threading.SendOrPostCallback BPCancelOperationCompleted;
        
        private System.Threading.SendOrPostCallback ImportUserOperationCompleted;
        
        private System.Threading.SendOrPostCallback CancelByMsisdnAndRequestIDOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public S2Process() {
            this.Url = global::WapXzone_VNM.Properties.Settings.Default.WapXzone_VNM_POD_S2Process;
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
        public event RegisterCompletedEventHandler RegisterCompleted;
        
        /// <remarks/>
        public event BPRegisterCompletedEventHandler BPRegisterCompleted;
        
        /// <remarks/>
        public event BPCancelCompletedEventHandler BPCancelCompleted;
        
        /// <remarks/>
        public event ImportUserCompletedEventHandler ImportUserCompleted;
        
        /// <remarks/>
        public event CancelByMsisdnAndRequestIDCompletedEventHandler CancelByMsisdnAndRequestIDCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Register", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Register(string msisdn, string requestid, string chanel, string servicetype, string source) {
            object[] results = this.Invoke("Register", new object[] {
                        msisdn,
                        requestid,
                        chanel,
                        servicetype,
                        source});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void RegisterAsync(string msisdn, string requestid, string chanel, string servicetype, string source) {
            this.RegisterAsync(msisdn, requestid, chanel, servicetype, source, null);
        }
        
        /// <remarks/>
        public void RegisterAsync(string msisdn, string requestid, string chanel, string servicetype, string source, object userState) {
            if ((this.RegisterOperationCompleted == null)) {
                this.RegisterOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRegisterOperationCompleted);
            }
            this.InvokeAsync("Register", new object[] {
                        msisdn,
                        requestid,
                        chanel,
                        servicetype,
                        source}, this.RegisterOperationCompleted, userState);
        }
        
        private void OnRegisterOperationCompleted(object arg) {
            if ((this.RegisterCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RegisterCompleted(this, new RegisterCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/BPRegister", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string BPRegister(string msisdn, string requestid, string chanel, string servicetype, string source) {
            object[] results = this.Invoke("BPRegister", new object[] {
                        msisdn,
                        requestid,
                        chanel,
                        servicetype,
                        source});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void BPRegisterAsync(string msisdn, string requestid, string chanel, string servicetype, string source) {
            this.BPRegisterAsync(msisdn, requestid, chanel, servicetype, source, null);
        }
        
        /// <remarks/>
        public void BPRegisterAsync(string msisdn, string requestid, string chanel, string servicetype, string source, object userState) {
            if ((this.BPRegisterOperationCompleted == null)) {
                this.BPRegisterOperationCompleted = new System.Threading.SendOrPostCallback(this.OnBPRegisterOperationCompleted);
            }
            this.InvokeAsync("BPRegister", new object[] {
                        msisdn,
                        requestid,
                        chanel,
                        servicetype,
                        source}, this.BPRegisterOperationCompleted, userState);
        }
        
        private void OnBPRegisterOperationCompleted(object arg) {
            if ((this.BPRegisterCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.BPRegisterCompleted(this, new BPRegisterCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/BPCancel", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string BPCancel(string msisdn, string servicetype, string reason) {
            object[] results = this.Invoke("BPCancel", new object[] {
                        msisdn,
                        servicetype,
                        reason});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void BPCancelAsync(string msisdn, string servicetype, string reason) {
            this.BPCancelAsync(msisdn, servicetype, reason, null);
        }
        
        /// <remarks/>
        public void BPCancelAsync(string msisdn, string servicetype, string reason, object userState) {
            if ((this.BPCancelOperationCompleted == null)) {
                this.BPCancelOperationCompleted = new System.Threading.SendOrPostCallback(this.OnBPCancelOperationCompleted);
            }
            this.InvokeAsync("BPCancel", new object[] {
                        msisdn,
                        servicetype,
                        reason}, this.BPCancelOperationCompleted, userState);
        }
        
        private void OnBPCancelOperationCompleted(object arg) {
            if ((this.BPCancelCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.BPCancelCompleted(this, new BPCancelCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ImportUser", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ImportUser(string msisdn, string requestid, string chanel, string servicetype, string source) {
            object[] results = this.Invoke("ImportUser", new object[] {
                        msisdn,
                        requestid,
                        chanel,
                        servicetype,
                        source});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ImportUserAsync(string msisdn, string requestid, string chanel, string servicetype, string source) {
            this.ImportUserAsync(msisdn, requestid, chanel, servicetype, source, null);
        }
        
        /// <remarks/>
        public void ImportUserAsync(string msisdn, string requestid, string chanel, string servicetype, string source, object userState) {
            if ((this.ImportUserOperationCompleted == null)) {
                this.ImportUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnImportUserOperationCompleted);
            }
            this.InvokeAsync("ImportUser", new object[] {
                        msisdn,
                        requestid,
                        chanel,
                        servicetype,
                        source}, this.ImportUserOperationCompleted, userState);
        }
        
        private void OnImportUserOperationCompleted(object arg) {
            if ((this.ImportUserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ImportUserCompleted(this, new ImportUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CancelByMsisdnAndRequestID", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CancelByMsisdnAndRequestID(string msisdn, string servicetype, string request_id) {
            object[] results = this.Invoke("CancelByMsisdnAndRequestID", new object[] {
                        msisdn,
                        servicetype,
                        request_id});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void CancelByMsisdnAndRequestIDAsync(string msisdn, string servicetype, string request_id) {
            this.CancelByMsisdnAndRequestIDAsync(msisdn, servicetype, request_id, null);
        }
        
        /// <remarks/>
        public void CancelByMsisdnAndRequestIDAsync(string msisdn, string servicetype, string request_id, object userState) {
            if ((this.CancelByMsisdnAndRequestIDOperationCompleted == null)) {
                this.CancelByMsisdnAndRequestIDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCancelByMsisdnAndRequestIDOperationCompleted);
            }
            this.InvokeAsync("CancelByMsisdnAndRequestID", new object[] {
                        msisdn,
                        servicetype,
                        request_id}, this.CancelByMsisdnAndRequestIDOperationCompleted, userState);
        }
        
        private void OnCancelByMsisdnAndRequestIDOperationCompleted(object arg) {
            if ((this.CancelByMsisdnAndRequestIDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CancelByMsisdnAndRequestIDCompleted(this, new CancelByMsisdnAndRequestIDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void RegisterCompletedEventHandler(object sender, RegisterCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RegisterCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RegisterCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void BPRegisterCompletedEventHandler(object sender, BPRegisterCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class BPRegisterCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal BPRegisterCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void BPCancelCompletedEventHandler(object sender, BPCancelCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class BPCancelCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal BPCancelCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void ImportUserCompletedEventHandler(object sender, ImportUserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ImportUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ImportUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void CancelByMsisdnAndRequestIDCompletedEventHandler(object sender, CancelByMsisdnAndRequestIDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CancelByMsisdnAndRequestIDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CancelByMsisdnAndRequestIDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591