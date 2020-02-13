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
            User user;
            string userName = this.UserName.Text;
            string password = this.UserPassword.Password;
            try
            {
                user = myIBL.GetUser(userName);
                if (password == user.Password)
                {
                    if (user.Type == UserType.Guest)
                    {
                        Window guestMainWindow = new GuestMainWindow(myIBL.GetGuestByUserName(user.UserName));
                        guestMainWindow.Show();
                        this.Close();
                    }
                    else if (user.Type == UserType.Host)
                    {
                        Window hostMainWindow = new HostMainWindow(myIBL.GetHostByUserName(user.UserName));
                        hostMainWindow.Show();
                        //}
                    }
                    else if (user.Type == UserType.Admin)
                    {
                        Window adminMainWindow = new AdminMainWindow();
                        adminMainWindow.Show();
                        this.Close();
                    }
                }
                else throw new NotExsitingUserException();
            }
            catch (NotExsitingUserException)
            {
                UserPassword.Focus();
                MessageBox.Show("The Password you entered are incorrect.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (NotExistingKeyException)
            {
                UserName.Focus();
                MessageBox.Show("The UserName you entered doesn't exist", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Window Register = new RegisterWindow();
            Register.Show();
            this.Close();
        }
    }
}
