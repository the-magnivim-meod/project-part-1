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

        public UpdateHostingUnitWindow(Host hostIN)
        {
            InitializeComponent();

            myIBL = BL.FactoryBL.GetBL();
            host = hostIN;

            unitArea.ItemsSource = Enum.GetValues(typeof(AreaOfTheCountry));
            unitType.ItemsSource = Enum.GetValues(typeof(HostingUnitType));
            HostingUnitsComboBox.ItemsSource = myIBL.GetHostingUnitsOfHost(host);

            HostingUnit = myIBL.GetHostingUnitByKey(int.Parse(HostingUnitsComboBox.SelectedItem.ToString()));
            UpdateUnitGrid.DataContext = HostingUnit;
        }



        private void Update_click(object sender, RoutedEventArgs e)
        {
            try
            {
                myIBL.UpdateHostingUnit(HostingUnit);
                MessageBox.Show("Well Done!! hosting unit was updated.", "Complete", MessageBoxButton.OK,MessageBoxImage.Information);
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
                MessageBoxResult result= MessageBox.Show($"Are you SURE you would like to delete hosting unit number {HostingUnit.HostingUnitKey}?", "Make sure", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    myIBL.DeleteHostingUnit(HostingUnit.HostingUnitKey);
                    IEnumerable<int> hostingUnitsList = myIBL.GetHostingUnitsOfHost(host);
                    HostingUnitsComboBox.ItemsSource = hostingUnitsList;
                }
            }
            catch(HostingUnitConnectedToOrderException)
            {
                MessageBox.Show($"You can't delete unit number {HostingUnit.HostingUnitKey} because it is connected to an order", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(NullReferenceException)
            {
                MessageBox.Show($"unit number {HostingUnit.HostingUnitKey} was deleted succefully", "Complete", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("There was a problem. Please try again later.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void HostingUnitsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HostingUnit = myIBL.GetHostingUnitByKey(int.Parse(HostingUnitsComboBox.SelectedItem.ToString()));
            UpdateUnitGrid.DataContext = HostingUnit;
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