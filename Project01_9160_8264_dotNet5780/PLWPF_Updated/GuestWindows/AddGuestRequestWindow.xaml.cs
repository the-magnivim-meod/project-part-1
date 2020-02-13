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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;
using BE;
namespace PLWPF_Updated
{
    /// <summary>
    ///Logics for AddGuestRequestWindow.xaml
    /// </summary>
    public partial class AddGuestRequestWindow : Window
    {
        IBL myIBL = FactoryBL.GetBL();
        GuestRequest NewGuestRequest;
        Guest guest;
        public AddGuestRequestWindow(Guest guestIN)
        {
            InitializeComponent();

            NewGuestRequest = new GuestRequest();
            AddRequestGrid.DataContext = NewGuestRequest;

            pool.ItemsSource = Enum.GetValues(typeof(AmountOfIntrenst));
            cAttractions.ItemsSource = Enum.GetValues(typeof(AmountOfIntrenst));
            gStore.ItemsSource = Enum.GetValues(typeof(AmountOfIntrenst));
            garden.ItemsSource = Enum.GetValues(typeof(AmountOfIntrenst));
            AreaOfCountry.ItemsSource = Enum.GetValues(typeof(AreaOfTheCountry));
            TypeOfHostingUnit.ItemsSource = Enum.GetValues(typeof(HostingUnitType));

            guest = guestIN;

            NewGuestRequest.ChildrensAttractions = AmountOfIntrenst.Optional;
            NewGuestRequest.Garden = AmountOfIntrenst.Optional;
            NewGuestRequest.CloseByGroceryStore = AmountOfIntrenst.Optional;
            NewGuestRequest.Pool = AmountOfIntrenst.Optional;
            NewGuestRequest.EntryDate = DateTime.Today;
            NewGuestRequest.ReleaseDate = DateTime.Today.AddDays(1);
            NewGuestRequest.Adults = 1;
            NewGuestRequest.MailAddress = guest.MailAddress;
        }

        private void AddRequest_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                myIBL.AddGuestRequest(NewGuestRequest);
                Window mainGuest = new GuestMainWindow(guest);
                mainGuest.Show();
                this.Close();
            }
            catch (DateOrderException)
            {
                MessageBox.Show("The entry date must be before the release date.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                EndingDate.SelectedDate = NewGuestRequest.EntryDate.AddDays(1);
            }
            catch (DateComparedToTodayException)
            {
                MessageBox.Show("The vacation cannot be in the past.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                StartingDate.SelectedDate = DateTime.Today;
                EndingDate.SelectedDate = DateTime.Today.AddDays(1);
            }
            catch (NotValidEmailAddressException)
            {
                MessageBox.Show("The email address must be valid.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                EmailAdd.Focus();
            }
            catch(ChildrenAmountException)
            {
                MessageBox.Show("There cannot be a negative amount of people, this is earth!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                numChildren.Text = "0";
                numChildren.Focus();
            }
            catch(AdultAmountException)
            {
                MessageBox.Show("if there are no adults, who is requesting the vacation?!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                numAdults.Text = "1";
                numAdults.Focus();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window MainGuestWindow = new GuestMainWindow(guest);
            MainGuestWindow.Show();
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