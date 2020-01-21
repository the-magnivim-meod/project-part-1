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

        private void HostButtonClick(object sender, RoutedEventArgs e)
        {
            //in need to go to the Host's window (page 2.0)
        }

        private void GuestButtonClick(object sender, RoutedEventArgs e)
        {
            //in need to go to the GuestRequest's window (page 1.0)
        }

        private void OwnerButtonClick(object sender, RoutedEventArgs e)
        {
            //in need to go to the Owner's window (page 4.0)
        }
    }
}
