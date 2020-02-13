using System;
using System.Collections.Generic;
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
    /// Interaction logic for UpdateHostingUnit.xaml
    /// </summary>
    public partial class UpdateHostingUnitWindow : Window
    {
        IBL myIBL;
        Host host;
        HostingUnit HostingUnit;

        public UpdateHostingUnitWindow(Host host)
        {
            InitializeComponent();

            myIBL = BL.FactoryBL.GetBL();
            this.host = host;

            unitArea.ItemsSource = Enum.GetValues(typeof(AreaOfTheCountry));
            unitType.ItemsSource = Enum.GetValues(typeof(HostingUnitType));
            HostingUnitsComboBox.ItemsSource = myIBL.GetHostingUnitsOfHost(host);

            HostingUnit = HostingUnitsComboBox.SelectedItem as HostingUnit;
            ApdateUnitGrid.DataContext = HostingUnit;

        }



        private void Update_click(object sender, RoutedEventArgs e)
        {
            try
            {
                myIBL.UpdateHostingUnit(HostingUnit);
                MessageBox.Show("The hosting unit was updated.", "Success", MessageBoxButton.OK);
            }

            catch (NotExistingKeyException)
            {
                MessageBox.Show("There was a problem. Please try again later.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("There was a problem. Please try again later.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void DeleteHostingUnit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                myIBL.DeleteHostingUnit(HostingUnit.HostingUnitKey);
                MessageBox.Show("The hosting unit was deleted.", "Success", MessageBoxButton.OK);
                HostingUnitsComboBox.ItemsSource = myIBL.GetHostingUnitsOfHost(host);
            }

            catch (NotExistingKeyException)
            {
                MessageBox.Show("There was a problem. Please try again later.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("There was a problem. Please try again later.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void HostingUnitsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HostingUnit = HostingUnitsComboBox.SelectedItem as HostingUnit;
            ApdateUnitGrid.DataContext = HostingUnit;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window HostWindow = new HostMainWindow(host);
            HostWindow.Show();
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