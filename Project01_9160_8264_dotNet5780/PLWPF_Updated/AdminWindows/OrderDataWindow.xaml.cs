using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for OrderDataWindow.xaml
    /// </summary>
    public partial class OrderDataWindow : Window
    {
        IBL myIBL = FactoryBL.GetBL();
        public OrderDataWindow()
        {
            InitializeComponent();
            ObservableCollection<Order> Orders = new ObservableCollection<Order>(myIBL.GetAllOrders());
            GuestRequestDataGrid.ItemsSource = Orders;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window MainAdmin = new AdminMainWindow();
            MainAdmin.Show();
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
