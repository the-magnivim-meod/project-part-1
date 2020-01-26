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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;
using DAL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for UpdateHostingUnit.xaml
    /// </summary>
    public partial class UpdateHostingUnit : Window
    {
        BE.Host hostUser;
        BL.IBL bL;
        public UpdateHostingUnit(BE.Host hostUser)
        {
            InitializeComponent();
            this.hostUser = hostUser;

            bL = new BL.BL_imp();
            HostingUnitBox.ItemsSource = hostUser.HostingUnits.Select(item => item.HostinUnitKey);
            Area.ItemsSource = Enum.GetValues(typeof(Area));
            Type.ItemsSource = Enum.GetValues(typeof(Type));

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                bL.updateHostingUnit(hostUser.HostingUnits[HostingUnitBox.SelectedIndex]);

                new Host(hostUser).Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            new Host(hostUser).Show();
            Close();
        }

        private void HostingUnitBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            HostingUnitDetails.DataContext = hostUser.HostingUnits[HostingUnitBox.SelectedIndex];
        }
    }
}
