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
    /// Interaction logic for UpdateHostingUnit.xaml
    /// </summary>
    public partial class UpdateHostingUnit : Window
    {
        public UpdateHostingUnit()
        {
            InitializeComponent();
        }

        private void SelectHostingUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}




namespace PLWPF
{
    /// <summary>
    /// Interaction logic for UpdateHostingUnit.xaml
    /// </summary>
    public partial class UpdateHostingUnit : Window
    {
        BE.HostUser hostUser;
        BL.IBL bL;
        public UpdateHostingUnit(BE.HostUser hostUser)
        {
            InitializeComponent();
            this.hostUser = hostUser;

            bL = new BL.BL_imp();
            HostingUnitBox.ItemsSource = hostUser.HostingUnits.Select(item => item.HostinUnitKey);
            Location.ItemsSource = Enum.GetValues(typeof(Location));
            KindOfUnit.ItemsSource = Enum.GetValues(typeof(KindOfUnit));

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
