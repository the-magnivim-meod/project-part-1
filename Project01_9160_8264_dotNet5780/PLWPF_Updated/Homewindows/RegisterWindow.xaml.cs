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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        User user;
        IBL myIBL = FactoryBL.GetBL();
        public RegisterWindow()
        {
            InitializeComponent();
            user = new User();
            RegisterGrid.DataContext = user;

            UserTypeComboBox.ItemsSource = Enum.GetValues(typeof(UserType));
        }

        /// <summary>
        /// make sure the login button appears only if the all the feilds not empty
        /// checks if either the feilds have the default value or their length is not 0 as it can be if focus is on the field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContentChangedForRegisterButton(object sender, RoutedEventArgs e)
        {
            if (UserName.Text.Length > 0 && UserPassword.Password.Length > 0 && UserPasswordEnsure.Password.Length > 0 && Pname.Text.Length > 0 && Fname.Text.Length > 0)
            {
                RegisterButton.IsEnabled = true;
                RegisterButton.Background = (Brush)new BrushConverter().ConvertFromString("Beige");
                RegisterButton.Foreground = (Brush)new BrushConverter().ConvertFromString("Maroon");

            }
            else
            {
                RegisterButton.IsEnabled = false;
                RegisterButton.Foreground = (Brush)new BrushConverter().ConvertFromString("Gray");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window NewLoginWindow = new LoginWindow();
            NewLoginWindow.Show();
            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterGrid.DataContext = user;

            user.Password = UserPassword.Password;
            string rePass = UserPasswordEnsure.Password;

            if (UserName.Text == "" || UserPassword.Password == "" || UserPasswordEnsure.Password == "" )
                MessageBox.Show("You must fill all fields!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (rePass != user.Password)
                MessageBox.Show("Passwords aren't equal!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                user.RegistrationDate = DateTime.Today;

                if (user.Type == UserType.Guest)
                    CompleteGuestRegistration();
                else
                    CompleteHostRegistration();

            }
        }

        private void CompleteGuestRegistration()
        {
            try
            {
                user.finish = true;
                Guest guest = GetGuest(user);
                myIBL.AddGuest(guest);
                GoToLogin();
            }
            
            catch (mailAlreadyExistException)
            {
                MessageBox.Show("Mail address already exist in the system. Please try another address.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (UserNameAlreadyExistException)
            {
                MessageBox.Show("Nickname already exist in the system. Please try another nickname.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
            catch (NotValidEmailAddressException)
            {
                MessageBox.Show("Mail address invalid.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private Guest GetGuest(User user)
        {
            Guest guest = new Guest();

            guest.UserName = user.UserName;
            guest.Password = user.Password;
            guest.MailAddress = user.MailAddress;
            guest.PrivateName = user.PrivateName;
            guest.FamilyName = user.FamilyName;
            guest.RegistrationDate = user.RegistrationDate;
            guest.Type = user.Type;
            guest.finish = user.finish;

            return guest;
        }

        

        private void CompleteHostRegistration()
        {
            Host host = GetHost(user);
            host.BankBranchDetails = new BankBranch() { BankName = "", BankNumber = 0, BranchAddress = "", BranchCity = "", BranchNumber = 0 };
            try
            {
                myIBL.AddHost(host);
                Window hostRegistrationWindow = new HostRegWindow();
                hostRegistrationWindow.Show();
                Close();
            }
            
            catch (mailAlreadyExistException)
            {
                MessageBox.Show("Mail address already exist in the system. Please try another address.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (UserNameAlreadyExistException)
            {
                MessageBox.Show("Nickname already exist in the system. Please try another nickname.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            catch (NotValidEmailAddressException)
            {
                MessageBox.Show("Mail address invalid.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private Host GetHost(User user)
        {
            Host host = new Host();

            host.UserName = user.UserName;
            host.Password = user.Password;
            host.MailAddress = user.MailAddress;
            host.PrivateName = user.PrivateName;
            host.FamilyName = user.FamilyName;
            host.RegistrationDate = user.RegistrationDate;
            host.Type = user.Type;
            host.finish = false;
            host.PhoneNumber = "0546557768";

            return host;
        }


        private void GoToLogin()
        {
            Window LoginWindow = new LoginWindow();
            LoginWindow.Show();
            Close();
        }




    }
}
