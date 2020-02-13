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
using System.Collections.ObjectModel;

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
            host = hostIN;
            HostingUnits.ItemsSource = myIBL.GetHostingUnitsOfHost(host);
        }

        private IEnumerable<GuestRequest> GetSuitableGuestRequestsForTheUnit()
        {
            try
            {
                var unit = myIBL.GetHostingUnitByKey(int.Parse(HostingUnits.SelectedItem.ToString())) as HostingUnit;
                var guestRequests = myIBL.GetSuitableRequests(unit);
                return (guestRequests.Count() == 0 ? null : guestRequests);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void HostingUnits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IEnumerable<GuestRequest> guestRequestsList = GetSuitableGuestRequestsForTheUnit();
            if (guestRequestsList != null)
            {
                ObservableCollection<GuestRequest> guestRequests = new ObservableCollection<GuestRequest>(guestRequestsList);
                guestRequestDataGrid.ItemsSource = guestRequests;
            }
            else
            {
                guestRequestDataGrid.ItemsSource = null;
            }
        }

        private void guestRequestDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var guestRequest = guestRequestDataGrid.SelectedItem as GuestRequest;
            var hostingUnit = myIBL.GetHostingUnitByKey(int.Parse(HostingUnits.SelectedItem.ToString()));
            if(!(guestRequest == null) && !(guestRequest == null))
            {
                string orderDetails = "Are you sure that you would like to order guest " + guestRequest.PrivateName + " " + guestRequest.FamilyName + " to the " + hostingUnit.HostingUnitName + " unit, from " 
                    + guestRequest.EntryDate.ToString("MM/dd/yyyy") + " until " + guestRequest.ReleaseDate.ToString("MM/dd/yyyy") + "?";
                MessageBoxResult messageBoxResult = MessageBox.Show(orderDetails, "select your option", MessageBoxButton.YesNo, MessageBoxImage.Question);

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
                        MessageBoxResult SignCleatanceResult = MessageBox.Show("You did not sign collection clearance. Would you like To sign?", "Error!", MessageBoxButton.YesNo, MessageBoxImage.Error);
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("There was a problem. Please try again later.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("There was a problem. Please try again later.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
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