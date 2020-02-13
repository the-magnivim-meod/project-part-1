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
    /// Interaction logic for HostMainWindow.xaml
    /// </summary>
    public partial class HostMainWindow : Window
    {
        Host host;

        public HostMainWindow(Host hostIN)
        {
            InitializeComponent();
            host = hostIN;
        }

        private void AddHostingUnitButtonClick(object sender, RoutedEventArgs e)
        {
            Window addOrder = new AddHostingUnitWindow(host);
            addOrder.Show();
            this.Close();
        }

        private void PrivateAreaButtonClick(object sender, RoutedEventArgs e)
        {
            Window Update = new UpdateHostingUnitWindow(host);
            Update.Show();
            this.Close();
        }

        private void LogOff_Click(object sender, RoutedEventArgs e)
        {
            Window Login = new LoginWindow();
            Login.Show();
            this.Close();
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            Window addOrder = new AddOrderWindow(host);
            addOrder.Show();
            this.Close();
        }
    }
}