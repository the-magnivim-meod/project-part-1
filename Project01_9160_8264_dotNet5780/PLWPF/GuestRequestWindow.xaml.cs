using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for GuestRequest.xaml
    /// </summary>
    public partial class GuestRequestWindow : Window
    {
        public GuestRequestWindow()
        {
            InitializeComponent();
        }

        

        private void AddHostingUnitButtonClick(object sender, RoutedEventArgs e)
        {
            Window addGuestRequest = new addGuestRequestWindow();
            addGuestRequest.Show();
        }
    }
}
