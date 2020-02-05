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
    /// Interaction logic for HostRegWindow.xaml
    /// </summary>
    public partial class HostRegWindow : Window
    {
        public HostRegWindow()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window NewLoginWindow = new LoginWindow();
            NewLoginWindow.Show();
            this.Close();
        }
    }
}
