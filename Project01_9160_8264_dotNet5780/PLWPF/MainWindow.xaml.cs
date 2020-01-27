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
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static IBL myBL  = FactoryBL.GetBL();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GuestRequestButtonClick(object sender, RoutedEventArgs e)
        {
            Window guestRequestWindow = new GuestRequestWindow();
            guestRequestWindow.ShowDialog();
        }

        private void HostingUnitButtonClick(object sender, RoutedEventArgs e)
        {
            Window hostingUnitWindow = new HostingUnitWindow();
            hostingUnitWindow.ShowDialog();
        }

        private void AdminButtonClick(object sender, RoutedEventArgs e)
        {
            //in need to go to the Admin's window (page 4.0)
        }

        
    }
}
