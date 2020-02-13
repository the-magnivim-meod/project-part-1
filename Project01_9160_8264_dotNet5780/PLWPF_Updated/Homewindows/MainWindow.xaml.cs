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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static IBL myBL = FactoryBL.GetBL();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GuestRequestButtonClick(object sender, RoutedEventArgs e)
        {
            Window guestRequestWindow = new GuestMainWindow(null);
            guestRequestWindow.Show();
            this.Close();
        }

        private void HostingUnitButtonClick(object sender, RoutedEventArgs e)
        {
            Window hostingUnitWindow = new HostMainWindow(null);
            hostingUnitWindow.Show();
            this.Close();
        }

        private void AdminButtonClick(object sender, RoutedEventArgs e)
        {
            Window AdminWindow = new AdminMainWindow();
            AdminWindow.Show();
            this.Close();
        }
    }
}
