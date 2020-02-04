﻿#pragma checksum "..\..\..\HomeWindows\LoginWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "707168CF065D96E74DBD8CEAD7A045E4198B49053FDFFAAFEA62FCB868ABC66A"
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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace PLWPF_Updated {
    
    
    /// <summary>
    /// LoginWindow
    /// </summary>
    public partial class LoginWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\HomeWindows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UserName;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\HomeWindows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox UserPassword;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\HomeWindows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoginButton;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\HomeWindows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RegisterButton;
        
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
            System.Uri resourceLocater = new System.Uri("/PLWPF_Updated;component/homewindows/loginwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\HomeWindows\LoginWindow.xaml"
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
            this.UserName = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\..\HomeWindows\LoginWindow.xaml"
            this.UserName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextChangedForLoginButton);
            
            #line default
            #line hidden
            
            #line 36 "..\..\..\HomeWindows\LoginWindow.xaml"
            this.UserName.GotFocus += new System.Windows.RoutedEventHandler(this.UserName_GotFocus);
            
            #line default
            #line hidden
            
            #line 36 "..\..\..\HomeWindows\LoginWindow.xaml"
            this.UserName.LostFocus += new System.Windows.RoutedEventHandler(this.UserName_LostFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UserPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 42 "..\..\..\HomeWindows\LoginWindow.xaml"
            this.UserPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.TextChangedForLoginButton);
            
            #line default
            #line hidden
            
            #line 42 "..\..\..\HomeWindows\LoginWindow.xaml"
            this.UserPassword.GotFocus += new System.Windows.RoutedEventHandler(this.UserPassword_GotFocus);
            
            #line default
            #line hidden
            
            #line 42 "..\..\..\HomeWindows\LoginWindow.xaml"
            this.UserPassword.LostFocus += new System.Windows.RoutedEventHandler(this.UserPassword_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LoginButton = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\HomeWindows\LoginWindow.xaml"
            this.LoginButton.Click += new System.Windows.RoutedEventHandler(this.LoginButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RegisterButton = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\HomeWindows\LoginWindow.xaml"
            this.RegisterButton.Click += new System.Windows.RoutedEventHandler(this.RegisterButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

