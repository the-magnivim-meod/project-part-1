﻿#pragma checksum "..\..\..\AdminWindows\AdminMainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "ED4200DEE616776E60ED35015D636DD40C85CCA85303A64688E4DBB8C747CC15"
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
    /// AdminMainWindow
    /// </summary>
    public partial class AdminMainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\AdminWindows\AdminMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GuestRequestsList;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\AdminWindows\AdminMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HostingUnitList;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\AdminWindows\AdminMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OrderList;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\AdminWindows\AdminMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LogOff;
        
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
            System.Uri resourceLocater = new System.Uri("/PLWPF_Updated;component/adminwindows/adminmainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AdminWindows\AdminMainWindow.xaml"
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
            this.GuestRequestsList = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\AdminWindows\AdminMainWindow.xaml"
            this.GuestRequestsList.Click += new System.Windows.RoutedEventHandler(this.GuestRequestsList_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.HostingUnitList = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\AdminWindows\AdminMainWindow.xaml"
            this.HostingUnitList.Click += new System.Windows.RoutedEventHandler(this.HostingUnitList_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.OrderList = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\AdminWindows\AdminMainWindow.xaml"
            this.OrderList.Click += new System.Windows.RoutedEventHandler(this.OrderList_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LogOff = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\AdminWindows\AdminMainWindow.xaml"
            this.LogOff.Click += new System.Windows.RoutedEventHandler(this.LogOff_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

