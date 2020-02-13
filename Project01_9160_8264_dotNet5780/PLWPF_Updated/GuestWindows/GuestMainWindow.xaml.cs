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
    /// Interaction logic for GuestRequest.xaml
    /// </summary>
    public partial class GuestMainWindow : Window
    {
        public GuestMainWindow()
        {
            InitializeComponent();
        }



        private void AddGuestRquestButtonClick(object sender, RoutedEventArgs e)
        {
            Window addGuestRequest = new AddGuestRequestWindow();
            addGuestRequest.Show();
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
