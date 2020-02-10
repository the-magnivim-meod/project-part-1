using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for HostingUnitDataWindow.xaml
    /// </summary>
    public partial class HostingUnitDataWindow : Window
    {
        IBL myIBL = FactoryBL.GetBL();
        public HostingUnitDataWindow()
        {
            InitializeComponent();
            ObservableCollection<HostingUnit> hostingUnits = new ObservableCollection<HostingUnit>(myIBL.GetAllHostingUnits());
            GuestRequestDataGrid.ItemsSource = hostingUnits;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window MainGuestWindow = new GuestMainWindow();
            MainGuestWindow.Show();
            this.Close();
        }

        private void LogOff_Click(object sender, RoutedEventArgs e)
        {
            Window Login = new MainWindow();
            Login.Show();
            this.Close();
        }
    }
}
