// Updated by XamlIntelliSenseFileGenerator 27/01/2020 0:29:44
#pragma checksum "..\..\..\addGuestRequestWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6571ACBBB9065A9777654D55AC4FAF07A08D6921"
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


namespace PLWPF
{


    /// <summary>
    /// addGuestRequestWindow
    /// </summary>
    public partial class addGuestRequestWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PLWPF;component/addguestrequestwindow.xaml", System.UriKind.Relative);

#line 1 "..\..\..\addGuestRequestWindow.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.pName = ((System.Windows.Controls.TextBox)(target));

#line 44 "..\..\..\addGuestRequestWindow.xaml"
                    this.pName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.pName_TextChanged);

#line default
#line hidden
                    return;
                case 2:
                    this.fName = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 3:
                    this.email = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 4:
                    this.startDate = ((System.Windows.Controls.DatePicker)(target));
                    return;
                case 5:
                    this.EndingDate = ((System.Windows.Controls.DatePicker)(target));
                    return;
                case 6:
                    this.Area = ((System.Windows.Controls.ListBox)(target));
                    return;
                case 7:
                    this.area1 = ((System.Windows.Controls.ListBoxItem)(target));
                    return;
                case 8:
                    this.area2 = ((System.Windows.Controls.ListBoxItem)(target));
                    return;
                case 9:
                    this.area3 = ((System.Windows.Controls.ListBoxItem)(target));
                    return;
                case 10:
                    this.area4 = ((System.Windows.Controls.ListBoxItem)(target));
                    return;
                case 11:
                    this.area5 = ((System.Windows.Controls.ListBoxItem)(target));
                    return;
                case 12:
                    this.area6 = ((System.Windows.Controls.ListBoxItem)(target));
                    return;
                case 13:
                    this.area7 = ((System.Windows.Controls.ListBoxItem)(target));
                    return;
                case 14:

#line 67 "..\..\..\addGuestRequestWindow.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.TextBox Pname;
        internal System.Windows.Controls.TextBox Fname;
        internal System.Windows.Controls.TextBox EmailAdd;
        internal System.Windows.Controls.DatePicker StartingDate;
        internal System.Windows.Controls.DatePicker EndingDate;
        internal System.Windows.Controls.ComboBox AreaOfCountry;
        internal System.Windows.Controls.ComboBox TypeOfHostingUnit;
        internal System.Windows.Controls.TextBox numAdults;
        internal System.Windows.Controls.TextBox numChildren;
        internal System.Windows.Controls.ComboBox pool;
        internal System.Windows.Controls.Button AddRequest;
        internal System.Windows.Controls.ComboBox gStore;
        internal System.Windows.Controls.ComboBox garden;
        internal System.Windows.Controls.ComboBox cAttractions;
    }
}

