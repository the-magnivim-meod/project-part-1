﻿#pragma checksum "..\..\..\HomeWindows\RegisterWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E952AFE92DAC5177D0FA95D2F801146284A72834BE87721689872FA854CF7BA3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PLWPF_Updated;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace PLWPF_Updated {
    
    
    /// <summary>
    /// RegisterWindow
    /// </summary>
    public partial class RegisterWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\HomeWindows\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid RegisterGrid;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\HomeWindows\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UserName;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\HomeWindows\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox UserPassword;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\HomeWindows\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox UserPasswordEnsure;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\HomeWindows\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Pname;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\HomeWindows\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Fname;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\HomeWindows\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MailTextBox;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\HomeWindows\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox UserTypeComboBox;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\HomeWindows\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RegisterButton;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\HomeWindows\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PLWPF_Updated;component/homewindows/registerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\HomeWindows\RegisterWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.RegisterGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.UserName = ((System.Windows.Controls.TextBox)(target));
            
            #line 47 "..\..\..\HomeWindows\RegisterWindow.xaml"
            this.UserName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ContentChangedForRegisterButton);
            
            #line default
            #line hidden
            return;
            case 3:
            this.UserPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 50 "..\..\..\HomeWindows\RegisterWindow.xaml"
            this.UserPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.ContentChangedForRegisterButton);
            
            #line default
            #line hidden
            return;
            case 4:
            this.UserPasswordEnsure = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 53 "..\..\..\HomeWindows\RegisterWindow.xaml"
            this.UserPasswordEnsure.PasswordChanged += new System.Windows.RoutedEventHandler(this.ContentChangedForRegisterButton);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Pname = ((System.Windows.Controls.TextBox)(target));
            
            #line 56 "..\..\..\HomeWindows\RegisterWindow.xaml"
            this.Pname.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ContentChangedForRegisterButton);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Fname = ((System.Windows.Controls.TextBox)(target));
            
            #line 59 "..\..\..\HomeWindows\RegisterWindow.xaml"
            this.Fname.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ContentChangedForRegisterButton);
            
            #line default
            #line hidden
            return;
            case 7:
            this.MailTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 62 "..\..\..\HomeWindows\RegisterWindow.xaml"
            this.MailTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ContentChangedForRegisterButton);
            
            #line default
            #line hidden
            return;
            case 8:
            this.UserTypeComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 65 "..\..\..\HomeWindows\RegisterWindow.xaml"
            this.UserTypeComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ContentChangedForRegisterButton);
            
            #line default
            #line hidden
            return;
            case 9:
            this.RegisterButton = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\HomeWindows\RegisterWindow.xaml"
            this.RegisterButton.Click += new System.Windows.RoutedEventHandler(this.RegisterButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Back = ((System.Windows.Controls.Button)(target));
            
            #line 119 "..\..\..\HomeWindows\RegisterWindow.xaml"
            this.Back.Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

