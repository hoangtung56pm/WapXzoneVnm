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

namespace WapXzone_VNM.RingTone {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="ServiceHandlerSoap", Namespace="http://tempuri.org/")]
    public partial class NC1_Handler : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback SyncSubscriptionDataOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public NC1_Handler() {
            this.Url = global::WapXzone_VNM.Properties.Settings.Default.WapXzone_VNM_RingTone_NC1_Handler;
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
        public event SyncSubscriptionDataCompletedEventHandler SyncSubscriptionDataCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SyncSubscriptionData", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SyncSubscriptionData(string ShortCode, string CommandCode, string UserID, string Message, string RequestID, string ServiceID, string RefID, string UpdateType, string UpdateDescription) {
            object[] results = this.Invoke("SyncSubscriptionData", new object[] {
                        ShortCode,
                        CommandCode,
                        UserID,
                        Message,
                        RequestID,
                        ServiceID,
                        RefID,
                        UpdateType,
                        UpdateDescription});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SyncSubscriptionDataAsync(string ShortCode, string CommandCode, string UserID, string Message, string RequestID, string ServiceID, string RefID, string UpdateType, string UpdateDescription) {
            this.SyncSubscriptionDataAsync(ShortCode, CommandCode, UserID, Message, RequestID, ServiceID, RefID, UpdateType, UpdateDescription, null);
        }
        
        /// <remarks/>
        public void SyncSubscriptionDataAsync(string ShortCode, string CommandCode, string UserID, string Message, string RequestID, string ServiceID, string RefID, string UpdateType, string UpdateDescription, object userState) {
            if ((this.SyncSubscriptionDataOperationCompleted == null)) {
                this.SyncSubscriptionDataOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSyncSubscriptionDataOperationCompleted);
            }
            this.InvokeAsync("SyncSubscriptionData", new object[] {
                        ShortCode,
                        CommandCode,
                        UserID,
                        Message,
                        RequestID,
                        ServiceID,
                        RefID,
                        UpdateType,
                        UpdateDescription}, this.SyncSubscriptionDataOperationCompleted, userState);
        }
        
        private void OnSyncSubscriptionDataOperationCompleted(object arg) {
            if ((this.SyncSubscriptionDataCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SyncSubscriptionDataCompleted(this, new SyncSubscriptionDataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void SyncSubscriptionDataCompletedEventHandler(object sender, SyncSubscriptionDataCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SyncSubscriptionDataCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SyncSubscriptionDataCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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