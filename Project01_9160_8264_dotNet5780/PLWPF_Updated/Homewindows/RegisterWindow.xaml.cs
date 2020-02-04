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

            UserType.ItemsSource = Enum.GetValues(typeof(UserType));
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
            if(Enum.GetValues(typeof(UserType))== Enum.GetValues(typeof(Host)))
            {
                Window NewHostRegWindow = new HostRegWindow();
                NewHostRegWindow.Show();
                this.Close();
            }
        }

        
    }
}
