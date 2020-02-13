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
using BL;
using BE;

namespace PLWPF_Updated
{
    /// <summary>
    /// Interaction logic for AddOrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        IBL myIBL = FactoryBL.GetBL();
        Host host;
        public AddOrderWindow(Host hostIN)
        {
            InitializeComponent();
            myIBL = FactoryBL.GetBL();

            System.Windows.Data.CollectionViewSource guestRequestViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("guestRequestViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // guestRequestViewSource.Source = [generic data source]
            host = hostIN;
            HostingUnits.ItemsSource = myIBL.GetHostingUnitsOfHost(host);
            guestRequestDataGrid.ItemsSource = GetRequestsSuitableHostingUnit();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource guestRequestViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("guestRequestViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // guestRequestViewSource.Source = [generic data source]
        }

        private IEnumerable<GuestRequest> GetRequestsSuitableHostingUnit()
        {
            var hU = HostingUnits.SelectedItem as HostingUnit;
            return myIBL.GetSuitableRequests(hU);
        }

        private void HostingUnits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            guestRequestDataGrid.ItemsSource = GetRequestsSuitableHostingUnit();
        }

        private void guestRequestDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var guestRequest = guestRequestDataGrid.SelectedItem as GuestRequest;
            var hostingUnit = HostingUnits.SelectedItem as HostingUnit;
            if (guestRequest == null) { }//do nothing}
            else
            {
                string TextToShow = "Are you sure that you want to order " + guestRequest.PrivateName + " " + guestRequest.FamilyName + " to " + hostingUnit.HostingUnitName + " from " + guestRequest.EntryDate.ToString("dd/MM/yy") + " to " + guestRequest.ReleaseDate.ToString("dd/MM/yy") + "?";
                MessageBoxResult messageBoxResult = MessageBox.Show(TextToShow, "Please Choose:", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    try
                    {
                        Order order = new Order();
                        order.CreateDate = DateTime.Today;
                        order.HostingUnitKey = hostingUnit.HostingUnitKey;
                        order.GuestRequestKey = guestRequest.GuestRequestKey;
                        myIBL.AddOrder(order);
                    }

                    catch (DateOrderException)
                    {
                        MessageBox.Show("These dates already taken.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (LackOfSigningPermissionException)
                    {
                        MessageBox.Show("You didn't signed a clearance. Sign and then try again.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("There was a problem. Please try again later.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
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