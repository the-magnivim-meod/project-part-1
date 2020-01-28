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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class HostingUnitWindow : Window
    {
        public HostingUnitWindow()
        {
            InitializeComponent();
        }

        

        private void AddHostingUnitButtonClick(object sender, RoutedEventArgs e)
        {
            Window addHostingUnit = new AddHostingUnitWindow();
            addHostingUnit.Show();
            this.Close();
        }

        private void PrivateAreaButtonClick(object sender, RoutedEventArgs e)
        {
            Window privateArea = new PrivateAreaWindow();
            privateArea.Show();
            this.Close();
        }

        private void LogOff_Click(object sender, RoutedEventArgs e)
        {
            Window Login = new MainWindow();
            Login.Show();
            this.Close();
        }
    }
}
