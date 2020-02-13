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
    /// Interaction logic for HostRegWindow.xaml
    /// </summary>
    public partial class HostRegWindow : Window
    {
        IBL myIBL = FactoryBL.GetBL();
        public Host host;
        bool bankWasSelected = false;

        public HostRegWindow(User HalfFullUser)
        {
            InitializeComponent();
            host = myIBL.UserFeildsToHost(HalfFullUser);
            HostRegGrid.DataContext = host;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window NewLoginWindow = new LoginWindow();
            NewLoginWindow.Show();
            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {               
                myIBL.AddHost(host);
                Window NewLoginWindow = new LoginWindow();
                NewLoginWindow.Show();
                this.Close();
            }
            catch (NotValidPhoneNumberException)
            {
                PhoneNumber.Focus();
                MessageBox.Show("The PhoneNumber you entered is invalid.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("There was a problem!!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BankSelectorButton_Click(object sender, RoutedEventArgs e)
        {
            bankWasSelected = true;
            ContentChangedForRegisterButton(sender, e);
            var SelectBank = new BankSelectionWindow(this);
            if ((bool)SelectBank.ShowDialog() == true)
            {
                host.BankBranchDetails = SelectBank.BankBranch;
            }
        }

        private void ContentChangedForRegisterButton(object sender, RoutedEventArgs e)
        {
            if (PhoneNumber.Text.Length > 0 && BankNumber.Text.Length > 0 && bankWasSelected)
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
    }
}
