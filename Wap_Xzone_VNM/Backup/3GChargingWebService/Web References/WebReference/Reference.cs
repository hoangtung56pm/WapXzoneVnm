﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.1.
// 
#pragma warning disable 1591

namespace _3GChargingWebService.WebReference {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="CHARGINGSoap", Namespace="NMSCGW")]
    public partial class CHARGING : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback CheckBalanceOperationCompleted;
        
        private System.Threading.SendOrPostCallback extDebitOperationCompleted;
        
        private System.Threading.SendOrPostCallback extDebit2OperationCompleted;
        
        private System.Threading.SendOrPostCallback SubmitSMSOperationCompleted;
        
        private System.Threading.SendOrPostCallback GETMSISDNOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public CHARGING() {
            this.Url = global::_3GChargingWebService.Properties.Settings.Default._3GChargingWebService_WebReference_CHARGING;
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
        public event CheckBalanceCompletedEventHandler CheckBalanceCompleted;
        
        /// <remarks/>
        public event extDebitCompletedEventHandler extDebitCompleted;
        
        /// <remarks/>
        public event extDebit2CompletedEventHandler extDebit2Completed;
        
        /// <remarks/>
        public event SubmitSMSCompletedEventHandler SubmitSMSCompleted;
        
        /// <remarks/>
        public event GETMSISDNCompletedEventHandler GETMSISDNCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("NMSCGW/CheckBalance", RequestNamespace="NMSCGW", ResponseNamespace="NMSCGW", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CheckBalance(string username, string password, string msisdn, string balancename, int timeout) {
            object[] results = this.Invoke("CheckBalance", new object[] {
                        username,
                        password,
                        msisdn,
                        balancename,
                        timeout});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void CheckBalanceAsync(string username, string password, string msisdn, string balancename, int timeout) {
            this.CheckBalanceAsync(username, password, msisdn, balancename, timeout, null);
        }
        
        /// <remarks/>
        public void CheckBalanceAsync(string username, string password, string msisdn, string balancename, int timeout, object userState) {
            if ((this.CheckBalanceOperationCompleted == null)) {
                this.CheckBalanceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCheckBalanceOperationCompleted);
            }
            this.InvokeAsync("CheckBalance", new object[] {
                        username,
                        password,
                        msisdn,
                        balancename,
                        timeout}, this.CheckBalanceOperationCompleted, userState);
        }
        
        private void OnCheckBalanceOperationCompleted(object arg) {
            if ((this.CheckBalanceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CheckBalanceCompleted(this, new CheckBalanceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("NMSCGW/extDebit", RequestNamespace="NMSCGW", ResponseNamespace="NMSCGW", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string extDebit(string username, string password, string UserID, string msisdn, string Shortcode, int timeout) {
            object[] results = this.Invoke("extDebit", new object[] {
                        username,
                        password,
                        UserID,
                        msisdn,
                        Shortcode,
                        timeout});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void extDebitAsync(string username, string password, string UserID, string msisdn, string Shortcode, int timeout) {
            this.extDebitAsync(username, password, UserID, msisdn, Shortcode, timeout, null);
        }
        
        /// <remarks/>
        public void extDebitAsync(string username, string password, string UserID, string msisdn, string Shortcode, int timeout, object userState) {
            if ((this.extDebitOperationCompleted == null)) {
                this.extDebitOperationCompleted = new System.Threading.SendOrPostCallback(this.OnextDebitOperationCompleted);
            }
            this.InvokeAsync("extDebit", new object[] {
                        username,
                        password,
                        UserID,
                        msisdn,
                        Shortcode,
                        timeout}, this.extDebitOperationCompleted, userState);
        }
        
        private void OnextDebitOperationCompleted(object arg) {
            if ((this.extDebitCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.extDebitCompleted(this, new extDebitCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("NMSCGW/extDebit2", RequestNamespace="NMSCGW", ResponseNamespace="NMSCGW", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string extDebit2(string username, string password, string userID, string msisdn, string shortcode, int timeout, string desc) {
            object[] results = this.Invoke("extDebit2", new object[] {
                        username,
                        password,
                        userID,
                        msisdn,
                        shortcode,
                        timeout,
                        desc});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void extDebit2Async(string username, string password, string userID, string msisdn, string shortcode, int timeout, string desc) {
            this.extDebit2Async(username, password, userID, msisdn, shortcode, timeout, desc, null);
        }
        
        /// <remarks/>
        public void extDebit2Async(string username, string password, string userID, string msisdn, string shortcode, int timeout, string desc, object userState) {
            if ((this.extDebit2OperationCompleted == null)) {
                this.extDebit2OperationCompleted = new System.Threading.SendOrPostCallback(this.OnextDebit2OperationCompleted);
            }
            this.InvokeAsync("extDebit2", new object[] {
                        username,
                        password,
                        userID,
                        msisdn,
                        shortcode,
                        timeout,
                        desc}, this.extDebit2OperationCompleted, userState);
        }
        
        private void OnextDebit2OperationCompleted(object arg) {
            if ((this.extDebit2Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.extDebit2Completed(this, new extDebit2CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("NMSCGW/SubmitSMS", RequestNamespace="NMSCGW", ResponseNamespace="NMSCGW", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SubmitSMS(string Username, string Password, string ShortCode, string Msisdn, string SMSBody) {
            object[] results = this.Invoke("SubmitSMS", new object[] {
                        Username,
                        Password,
                        ShortCode,
                        Msisdn,
                        SMSBody});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SubmitSMSAsync(string Username, string Password, string ShortCode, string Msisdn, string SMSBody) {
            this.SubmitSMSAsync(Username, Password, ShortCode, Msisdn, SMSBody, null);
        }
        
        /// <remarks/>
        public void SubmitSMSAsync(string Username, string Password, string ShortCode, string Msisdn, string SMSBody, object userState) {
            if ((this.SubmitSMSOperationCompleted == null)) {
                this.SubmitSMSOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSubmitSMSOperationCompleted);
            }
            this.InvokeAsync("SubmitSMS", new object[] {
                        Username,
                        Password,
                        ShortCode,
                        Msisdn,
                        SMSBody}, this.SubmitSMSOperationCompleted, userState);
        }
        
        private void OnSubmitSMSOperationCompleted(object arg) {
            if ((this.SubmitSMSCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SubmitSMSCompleted(this, new SubmitSMSCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("NMSCGW/GETMSISDN", RequestNamespace="NMSCGW", ResponseNamespace="NMSCGW", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GETMSISDN(string username, string password, string IP) {
            object[] results = this.Invoke("GETMSISDN", new object[] {
                        username,
                        password,
                        IP});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GETMSISDNAsync(string username, string password, string IP) {
            this.GETMSISDNAsync(username, password, IP, null);
        }
        
        /// <remarks/>
        public void GETMSISDNAsync(string username, string password, string IP, object userState) {
            if ((this.GETMSISDNOperationCompleted == null)) {
                this.GETMSISDNOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGETMSISDNOperationCompleted);
            }
            this.InvokeAsync("GETMSISDN", new object[] {
                        username,
                        password,
                        IP}, this.GETMSISDNOperationCompleted, userState);
        }
        
        private void OnGETMSISDNOperationCompleted(object arg) {
            if ((this.GETMSISDNCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GETMSISDNCompleted(this, new GETMSISDNCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void CheckBalanceCompletedEventHandler(object sender, CheckBalanceCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CheckBalanceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CheckBalanceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void extDebitCompletedEventHandler(object sender, extDebitCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class extDebitCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal extDebitCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void extDebit2CompletedEventHandler(object sender, extDebit2CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class extDebit2CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal extDebit2CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void SubmitSMSCompletedEventHandler(object sender, SubmitSMSCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SubmitSMSCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SubmitSMSCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GETMSISDNCompletedEventHandler(object sender, GETMSISDNCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GETMSISDNCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GETMSISDNCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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