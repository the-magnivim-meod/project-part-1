using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddHostingUnitWindow.xaml
    /// </summary>
    public partial class AddHostingUnitWindow : Window
    {
        public AddHostingUnitWindow()
        {
            InitializeComponent();
            unitType.ItemsSource = Enum.GetValues(typeof(HostingUnitType));
            unitArea.ItemsSource = Enum.GetValues(typeof(AreaOfTheCountry));

        }

        private void AddHostingUnit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
