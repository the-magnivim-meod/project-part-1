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
using BL;

namespace PLWPF_Updated
{
    /// <summary>
    /// Interaction logic for AddHostingUnitWindow.xaml
    /// </summary>
    public partial class AddHostingUnitWindow : Window
    {
        HostingUnit unit;
        IBL myIbL = FactoryBL.GetBL();
        Host host;
        public AddHostingUnitWindow(Host hostIN)
        {
            InitializeComponent();

            unitType.ItemsSource = Enum.GetValues(typeof(HostingUnitType));
            unitArea.ItemsSource = Enum.GetValues(typeof(AreaOfTheCountry));

            unit = new HostingUnit();
            AddUnitGrid.DataContext = unit;
            host = hostIN;
        }

        private void AddHostingUnit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                unit.Owner = host;
                myIbL.AddHostingUnit(unit);
                unit = new HostingUnit();
                AddUnitGrid.DataContext = unit;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There Was a problem. Please try again soon", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window HostWindow = new HostMainWindow(host);
            HostWindow.Show();
            this.Close();
        }

        private void LogOff_Click(object sender, RoutedEventArgs e)
        {
            Window Login = new LoginWindow();
            Login.Show();
            this.Close();
        }
    }
}
