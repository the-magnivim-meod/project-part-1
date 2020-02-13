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

namespace PLWPF_Updated
{
    /// <summary>
    /// Interaction logic for HostMainWindow.xaml
    /// </summary>
    public partial class HostMainWindow : Window
    {
        public HostMainWindow()
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
            //Window privateArea = new PrivateAreaWindow();
            //privateArea.Show();
            //this.Close();
        }

        private void LogOff_Click(object sender, RoutedEventArgs e)
        {
            Window Login = new LoginWindow();
            Login.Show();
            this.Close();
        }
    }
}
