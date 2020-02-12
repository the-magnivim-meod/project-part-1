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
using System.Globalization;
using BE;
using BL;
namespace PLWPF_Updated
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        IBL myIBL = FactoryBL.GetBL();
        User user;

        public LoginWindow()
        {
            InitializeComponent();
            UserPassword.Password = "123456";
            UserName.Text = "UserName";
        }

        /// <summary>
        /// make sure the login button appears only if the password and userName feilds are not empty
        /// checks if either the feilds have the default value or their length is not 0 as it can be if focus is on the field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextChangedForLoginButton(object sender, RoutedEventArgs e)
        {
            if (UserName.Text.Length > 0 && UserPassword.Password.Length > 0 && UserName.Foreground != (Brush)new BrushConverter().ConvertFromString("Gray") && UserPassword.Foreground != (Brush)new BrushConverter().ConvertFromString("Gray"))
            {
                LoginButton.IsEnabled = true;
                LoginButton.Background = (Brush)new BrushConverter().ConvertFromString("Beige");
                LoginButton.Foreground = (Brush)new BrushConverter().ConvertFromString("Maroon");

            }
            else
            {
                LoginButton.IsEnabled = false;
                LoginButton.Foreground = (Brush)new BrushConverter().ConvertFromString("Gray");
            }
        }

        /// <summary>
        /// delete the default content of UserName textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UserName.Foreground == (Brush)new BrushConverter().ConvertFromString("Gray"))
            {
                UserName.Foreground = (Brush)new BrushConverter().ConvertFromString("Black");
                UserName.Text = "";
            }
        }

        /// <summary>
        /// refill the default content of UserName textBox in case we need to
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserName_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((UserName.Text.Length == 0))
            {
                UserName.Foreground = (Brush)new BrushConverter().ConvertFromString("Gray");
                UserName.Text = "UserName";
            }
        }

        /// <summary>
        /// delete the default content of UserPassword PasswordBox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UserPassword.Foreground == (Brush)new BrushConverter().ConvertFromString("Gray"))
            {
                UserPassword.Foreground = (Brush)new BrushConverter().ConvertFromString("Black");
                UserPassword.Password = "";
            }
        }

        /// <summary>
        /// refill the default content of UserPassword PasswordBox in case we need to
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((UserPassword.Password.Length == 0))
            {
                UserPassword.Foreground = (Brush)new BrushConverter().ConvertFromString("Gray");
                UserPassword.Password = "123456";
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = this.UserName.Text;
            string password = this.UserPassword.Password;

            if (username == "" || password == "")
                MessageBox.Show("You must fill all fields!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);

            if (username == "Admin" && password == "123456")
            {
                Window adminWindow = new AdminMainWindow();
                adminWindow.Show();
                Close();
            }
            else
            {
                try
                {
                    user = myIBL.GetUser(username);

                    if (password == user.Password)
                    {
                        if (user.Type == UserType.Guest)
                        {
                            Guest guest = GetGuest(user);
                            Window guestWindow = new GuestMainWindow();
                            guestWindow.Show();
                        }
                        else if (user.Type == UserType.Host)
                        {
                            if (!user.finish)
                                CompleteHostRegistration(user);
                            else
                            {
                                Host host = GetHost(user);
                                Window hostMainWindow = new HostMainWindow();
                                hostMainWindow.Show();
                            }
                        }
                        Close();
                    }
                    else throw new NotExsitingUserException();
                }
                catch (NotExsitingUserException)
                {
                    this.UserName.Text = "";
                    this.UserPassword.Password = "";
                    MessageBox.Show("Username or Password is incorrect.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (NotExistingKeyException)
                {
                    MessageBox.Show("not exist", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private Guest GetGuest(User user)
        {
            return (from item in myIBL.GetAllGuests()
                    where item.UserName == user.UserName
                    select item).ToList().First();
        }

        private Host GetHost(User user)
        {
            return (from item in myIBL.GetAllHosts()
                    where item.UserName == user.UserName
                    select item).ToList().First();
        }

        private void CompleteHostRegistration(User user)
        {
            Host host = GetHost(user);
            Window hostRegistrationWindow = new HostRegWindow();
            hostRegistrationWindow.Show();
            this.Close();
        }






        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Window Register = new RegisterWindow();
            Register.Show();
            this.Close();
        }
    }
}
