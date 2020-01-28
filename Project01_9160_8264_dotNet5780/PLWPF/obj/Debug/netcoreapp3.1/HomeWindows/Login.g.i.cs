﻿#pragma checksum "..\..\..\..\HomeWindows\Login.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FD9074F746C56382034BE95E7C65FCC4599FF06B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PLWPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace PLWPF {
    
    
    /// <summary>
    /// Login
    /// </summary>
    public partial class Login : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\..\HomeWindows\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UserName;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\HomeWindows\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox UserPassword;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\HomeWindows\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoginButton;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\HomeWindows\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RegisterButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PLWPF;component/homewindows/login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\HomeWindows\Login.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.UserName = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\..\..\HomeWindows\Login.xaml"
            this.UserName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextChangedForLoginButton);
            
            #line default
            #line hidden
            
            #line 35 "..\..\..\..\HomeWindows\Login.xaml"
            this.UserName.GotFocus += new System.Windows.RoutedEventHandler(this.UserName_GotFocus);
            
            #line default
            #line hidden
            
            #line 35 "..\..\..\..\HomeWindows\Login.xaml"
            this.UserName.LostFocus += new System.Windows.RoutedEventHandler(this.UserName_LostFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UserPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 41 "..\..\..\..\HomeWindows\Login.xaml"
            this.UserPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.TextChangedForLoginButton);
            
            #line default
            #line hidden
            
            #line 41 "..\..\..\..\HomeWindows\Login.xaml"
            this.UserPassword.GotFocus += new System.Windows.RoutedEventHandler(this.UserPassword_GotFocus);
            
            #line default
            #line hidden
            
            #line 41 "..\..\..\..\HomeWindows\Login.xaml"
            this.UserPassword.LostFocus += new System.Windows.RoutedEventHandler(this.UserPassword_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LoginButton = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\..\HomeWindows\Login.xaml"
            this.LoginButton.Click += new System.Windows.RoutedEventHandler(this.LoginButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RegisterButton = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\..\HomeWindows\Login.xaml"
            this.RegisterButton.Click += new System.Windows.RoutedEventHandler(this.RegisterButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

