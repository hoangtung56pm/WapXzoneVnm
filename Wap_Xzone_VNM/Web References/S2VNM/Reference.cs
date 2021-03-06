﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.18408.
// 
#pragma warning disable 1591

namespace WapXzone_VNM.S2VNM {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="S2VnmSoap", Namespace="http://tempuri.org/")]
    public partial class S2Vnm : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback RegisterServiceOperationCompleted;
        
        private System.Threading.SendOrPostCallback RegisterS294xByServiceMasterOperationCompleted;
        
        private System.Threading.SendOrPostCallback SynchronizeUserOperationCompleted;
        
        private System.Threading.SendOrPostCallback SyncSubWapVnmDataOperationCompleted;
        
        private System.Threading.SendOrPostCallback CheckRegistrationOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetRegisteredServicesOperationCompleted;
        
        private System.Threading.SendOrPostCallback RegisterService_VoichatOperationCompleted;
        
        private System.Threading.SendOrPostCallback RegisterServiceTrachamMTOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public S2Vnm() {
            this.Url = global::WapXzone_VNM.Properties.Settings.Default.WapXzone_VNM_S2VNM_S2Vnm;
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
        public event RegisterServiceCompletedEventHandler RegisterServiceCompleted;
        
        /// <remarks/>
        public event RegisterS294xByServiceMasterCompletedEventHandler RegisterS294xByServiceMasterCompleted;
        
        /// <remarks/>
        public event SynchronizeUserCompletedEventHandler SynchronizeUserCompleted;
        
        /// <remarks/>
        public event SyncSubWapVnmDataCompletedEventHandler SyncSubWapVnmDataCompleted;
        
        /// <remarks/>
        public event CheckRegistrationCompletedEventHandler CheckRegistrationCompleted;
        
        /// <remarks/>
        public event GetRegisteredServicesCompletedEventHandler GetRegisteredServicesCompleted;
        
        /// <remarks/>
        public event RegisterService_VoichatCompletedEventHandler RegisterService_VoichatCompleted;
        
        /// <remarks/>
        public event RegisterServiceTrachamMTCompletedEventHandler RegisterServiceTrachamMTCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/RegisterService", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RegisterService(string Shortcode, string RequestID, string Msisdn, string Commandcode, string Message) {
            object[] results = this.Invoke("RegisterService", new object[] {
                        Shortcode,
                        RequestID,
                        Msisdn,
                        Commandcode,
                        Message});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void RegisterServiceAsync(string Shortcode, string RequestID, string Msisdn, string Commandcode, string Message) {
            this.RegisterServiceAsync(Shortcode, RequestID, Msisdn, Commandcode, Message, null);
        }
        
        /// <remarks/>
        public void RegisterServiceAsync(string Shortcode, string RequestID, string Msisdn, string Commandcode, string Message, object userState) {
            if ((this.RegisterServiceOperationCompleted == null)) {
                this.RegisterServiceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRegisterServiceOperationCompleted);
            }
            this.InvokeAsync("RegisterService", new object[] {
                        Shortcode,
                        RequestID,
                        Msisdn,
                        Commandcode,
                        Message}, this.RegisterServiceOperationCompleted, userState);
        }
        
        private void OnRegisterServiceOperationCompleted(object arg) {
            if ((this.RegisterServiceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RegisterServiceCompleted(this, new RegisterServiceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/RegisterS294xByServiceMaster", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RegisterS294xByServiceMaster(string Shortcode, string RequestID, string Msisdn, string Commandcode, string Message) {
            object[] results = this.Invoke("RegisterS294xByServiceMaster", new object[] {
                        Shortcode,
                        RequestID,
                        Msisdn,
                        Commandcode,
                        Message});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void RegisterS294xByServiceMasterAsync(string Shortcode, string RequestID, string Msisdn, string Commandcode, string Message) {
            this.RegisterS294xByServiceMasterAsync(Shortcode, RequestID, Msisdn, Commandcode, Message, null);
        }
        
        /// <remarks/>
        public void RegisterS294xByServiceMasterAsync(string Shortcode, string RequestID, string Msisdn, string Commandcode, string Message, object userState) {
            if ((this.RegisterS294xByServiceMasterOperationCompleted == null)) {
                this.RegisterS294xByServiceMasterOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRegisterS294xByServiceMasterOperationCompleted);
            }
            this.InvokeAsync("RegisterS294xByServiceMaster", new object[] {
                        Shortcode,
                        RequestID,
                        Msisdn,
                        Commandcode,
                        Message}, this.RegisterS294xByServiceMasterOperationCompleted, userState);
        }
        
        private void OnRegisterS294xByServiceMasterOperationCompleted(object arg) {
            if ((this.RegisterS294xByServiceMasterCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RegisterS294xByServiceMasterCompleted(this, new RegisterS294xByServiceMasterCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SynchronizeUser", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SynchronizeUser(string Shortcode, string RequestID, string Msisdn, string Commandcode, string Message, int ServiceID, int SyncType, string content, int chargedDay) {
            object[] results = this.Invoke("SynchronizeUser", new object[] {
                        Shortcode,
                        RequestID,
                        Msisdn,
                        Commandcode,
                        Message,
                        ServiceID,
                        SyncType,
                        content,
                        chargedDay});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SynchronizeUserAsync(string Shortcode, string RequestID, string Msisdn, string Commandcode, string Message, int ServiceID, int SyncType, string content, int chargedDay) {
            this.SynchronizeUserAsync(Shortcode, RequestID, Msisdn, Commandcode, Message, ServiceID, SyncType, content, chargedDay, null);
        }
        
        /// <remarks/>
        public void SynchronizeUserAsync(string Shortcode, string RequestID, string Msisdn, string Commandcode, string Message, int ServiceID, int SyncType, string content, int chargedDay, object userState) {
            if ((this.SynchronizeUserOperationCompleted == null)) {
                this.SynchronizeUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSynchronizeUserOperationCompleted);
            }
            this.InvokeAsync("SynchronizeUser", new object[] {
                        Shortcode,
                        RequestID,
                        Msisdn,
                        Commandcode,
                        Message,
                        ServiceID,
                        SyncType,
                        content,
                        chargedDay}, this.SynchronizeUserOperationCompleted, userState);
        }
        
        private void OnSynchronizeUserOperationCompleted(object arg) {
            if ((this.SynchronizeUserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SynchronizeUserCompleted(this, new SynchronizeUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SyncSubWapVnmData", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SyncSubWapVnmData(string Shortcode, string RequestID, string Msisdn, string Commandcode, string Message) {
            object[] results = this.Invoke("SyncSubWapVnmData", new object[] {
                        Shortcode,
                        RequestID,
                        Msisdn,
                        Commandcode,
                        Message});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SyncSubWapVnmDataAsync(string Shortcode, string RequestID, string Msisdn, string Commandcode, string Message) {
            this.SyncSubWapVnmDataAsync(Shortcode, RequestID, Msisdn, Commandcode, Message, null);
        }
        
        /// <remarks/>
        public void SyncSubWapVnmDataAsync(string Shortcode, string RequestID, string Msisdn, string Commandcode, string Message, object userState) {
            if ((this.SyncSubWapVnmDataOperationCompleted == null)) {
                this.SyncSubWapVnmDataOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSyncSubWapVnmDataOperationCompleted);
            }
            this.InvokeAsync("SyncSubWapVnmData", new object[] {
                        Shortcode,
                        RequestID,
                        Msisdn,
                        Commandcode,
                        Message}, this.SyncSubWapVnmDataOperationCompleted, userState);
        }
        
        private void OnSyncSubWapVnmDataOperationCompleted(object arg) {
            if ((this.SyncSubWapVnmDataCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SyncSubWapVnmDataCompleted(this, new SyncSubWapVnmDataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CheckRegistration", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CheckRegistration(string Shortcode, string RequestID, string Msisdn, string Commandcode, string Message) {
            object[] results = this.Invoke("CheckRegistration", new object[] {
                        Shortcode,
                        RequestID,
                        Msisdn,
                        Commandcode,
                        Message});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void CheckRegistrationAsync(string Shortcode, string RequestID, string Msisdn, string Commandcode, string Message) {
            this.CheckRegistrationAsync(Shortcode, RequestID, Msisdn, Commandcode, Message, null);
        }
        
        /// <remarks/>
        public void CheckRegistrationAsync(string Shortcode, string RequestID, string Msisdn, string Commandcode, string Message, object userState) {
            if ((this.CheckRegistrationOperationCompleted == null)) {
                this.CheckRegistrationOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCheckRegistrationOperationCompleted);
            }
            this.InvokeAsync("CheckRegistration", new object[] {
                        Shortcode,
                        RequestID,
                        Msisdn,
                        Commandcode,
                        Message}, this.CheckRegistrationOperationCompleted, userState);
        }
        
        private void OnCheckRegistrationOperationCompleted(object arg) {
            if ((this.CheckRegistrationCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CheckRegistrationCompleted(this, new CheckRegistrationCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetRegisteredServices", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetRegisteredServices(string Msisdn) {
            object[] results = this.Invoke("GetRegisteredServices", new object[] {
                        Msisdn});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void GetRegisteredServicesAsync(string Msisdn) {
            this.GetRegisteredServicesAsync(Msisdn, null);
        }
        
        /// <remarks/>
        public void GetRegisteredServicesAsync(string Msisdn, object userState) {
            if ((this.GetRegisteredServicesOperationCompleted == null)) {
                this.GetRegisteredServicesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRegisteredServicesOperationCompleted);
            }
            this.InvokeAsync("GetRegisteredServices", new object[] {
                        Msisdn}, this.GetRegisteredServicesOperationCompleted, userState);
        }
        
        private void OnGetRegisteredServicesOperationCompleted(object arg) {
            if ((this.GetRegisteredServicesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRegisteredServicesCompleted(this, new GetRegisteredServicesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/RegisterService_Voichat", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RegisterService_Voichat(string Shortcode, string RequestID, string Msisdn, string Commandcode, string Message) {
            object[] results = this.Invoke("RegisterService_Voichat", new object[] {
                        Shortcode,
                        RequestID,
                        Msisdn,
                        Commandcode,
                        Message});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void RegisterService_VoichatAsync(string Shortcode, string RequestID, string Msisdn, string Commandcode, string Message) {
            this.RegisterService_VoichatAsync(Shortcode, RequestID, Msisdn, Commandcode, Message, null);
        }
        
        /// <remarks/>
        public void RegisterService_VoichatAsync(string Shortcode, string RequestID, string Msisdn, string Commandcode, string Message, object userState) {
            if ((this.RegisterService_VoichatOperationCompleted == null)) {
                this.RegisterService_VoichatOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRegisterService_VoichatOperationCompleted);
            }
            this.InvokeAsync("RegisterService_Voichat", new object[] {
                        Shortcode,
                        RequestID,
                        Msisdn,
                        Commandcode,
                        Message}, this.RegisterService_VoichatOperationCompleted, userState);
        }
        
        private void OnRegisterService_VoichatOperationCompleted(object arg) {
            if ((this.RegisterService_VoichatCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RegisterService_VoichatCompleted(this, new RegisterService_VoichatCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/RegisterServiceTrachamMT", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RegisterServiceTrachamMT(string Shortcode, string RequestID, string Msisdn, string Commandcode, string Message) {
            object[] results = this.Invoke("RegisterServiceTrachamMT", new object[] {
                        Shortcode,
                        RequestID,
                        Msisdn,
                        Commandcode,
                        Message});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void RegisterServiceTrachamMTAsync(string Shortcode, string RequestID, string Msisdn, string Commandcode, string Message) {
            this.RegisterServiceTrachamMTAsync(Shortcode, RequestID, Msisdn, Commandcode, Message, null);
        }
        
        /// <remarks/>
        public void RegisterServiceTrachamMTAsync(string Shortcode, string RequestID, string Msisdn, string Commandcode, string Message, object userState) {
            if ((this.RegisterServiceTrachamMTOperationCompleted == null)) {
                this.RegisterServiceTrachamMTOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRegisterServiceTrachamMTOperationCompleted);
            }
            this.InvokeAsync("RegisterServiceTrachamMT", new object[] {
                        Shortcode,
                        RequestID,
                        Msisdn,
                        Commandcode,
                        Message}, this.RegisterServiceTrachamMTOperationCompleted, userState);
        }
        
        private void OnRegisterServiceTrachamMTOperationCompleted(object arg) {
            if ((this.RegisterServiceTrachamMTCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RegisterServiceTrachamMTCompleted(this, new RegisterServiceTrachamMTCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void RegisterServiceCompletedEventHandler(object sender, RegisterServiceCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RegisterServiceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RegisterServiceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void RegisterS294xByServiceMasterCompletedEventHandler(object sender, RegisterS294xByServiceMasterCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RegisterS294xByServiceMasterCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RegisterS294xByServiceMasterCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void SynchronizeUserCompletedEventHandler(object sender, SynchronizeUserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SynchronizeUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SynchronizeUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void SyncSubWapVnmDataCompletedEventHandler(object sender, SyncSubWapVnmDataCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SyncSubWapVnmDataCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SyncSubWapVnmDataCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void CheckRegistrationCompletedEventHandler(object sender, CheckRegistrationCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CheckRegistrationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CheckRegistrationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetRegisteredServicesCompletedEventHandler(object sender, GetRegisteredServicesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRegisteredServicesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRegisteredServicesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void RegisterService_VoichatCompletedEventHandler(object sender, RegisterService_VoichatCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RegisterService_VoichatCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RegisterService_VoichatCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void RegisterServiceTrachamMTCompletedEventHandler(object sender, RegisterServiceTrachamMTCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RegisterServiceTrachamMTCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RegisterServiceTrachamMTCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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