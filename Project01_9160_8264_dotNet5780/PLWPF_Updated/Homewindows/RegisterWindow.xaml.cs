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

            UserTypeComboBox.ItemsSource = new List<UserType>() {UserType.Guest, UserType.Host};
        }

        /// <summary>
        /// make sure the login button appears only if the all the feilds not empty
        /// checks if either the feilds have the default value or their length is not 0 as it can be if focus is on the field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContentChangedForRegisterButton(object sender, RoutedEventArgs e)
        {
            if (UserName.Text.Length > 0 && UserPassword.Password.Length > 0 && UserPasswordEnsure.Password.Length > 0 && Pname.Text.Length > 0 && Fname.Text.Length > 0 && MailTextBox.Text.Length > 0)
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
            if (UserPassword.Password == UserPasswordEnsure.Password)
            {
                user.Password = UserPassword.Password;
                if ((UserType)UserTypeComboBox.SelectedItem == BE.UserType.Host)
                {
                    try
                    {
                        if (myIBL.AddHostCanMoveOn(user))
                        {
                            Window NewHostRegWindow = new HostRegWindow(user);
                            NewHostRegWindow.Show();
                            this.Close();
                        }
                    }
                    catch (UserAlreadyExistsException)
                    {
                        UserName.Focus();
                        MessageBox.Show("The UserName you entered is alredy used.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (NotValidEmailAddressException)
                    {
                        MailTextBox.Focus();
                        MessageBox.Show("The MailAddress you entered is invalid.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("There was a problem!!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if ((UserType)UserTypeComboBox.SelectedItem == BE.UserType.Guest)
                {
                    try
                    {
                        myIBL.AddGuest(user);
                        Window loginWindow = new LoginWindow();
                        loginWindow.Show();
                        this.Close();
                    }
                    catch (UserAlreadyExistsException)
                    {
                        UserName.Focus();
                        MessageBox.Show("The UserName you entered is alredy used.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (NotValidEmailAddressException)
                    {
                        MailTextBox.Focus();
                        MessageBox.Show("The MailAddress you entered is invalid.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("There was a problem!!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

            else
            {
                UserPasswordEnsure.Focus();
                MessageBox.Show("Check Your Password again!!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
