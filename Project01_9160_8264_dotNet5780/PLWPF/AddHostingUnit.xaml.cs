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


namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddHostingUnit.xaml
    /// </summary>
    public partial class AddHostingUnit : Window
    {
        HostingUnit HostingUnit;
        BL.IBL bL;
        Host hostUser;

        public AddHostingUnit(Host user)
        {
            hostUser = user;
            InitializeComponent();

            HostingUnit = new HostingUnit();
            bL = new BL.BL_imp();

            HostingUnitDetails.DataContext = HostingUnit;

            Area.ItemsSource = Enum.GetValues(typeof(Area));
            Type.ItemsSource = Enum.GetValues(typeof(Type));

            Area.SelectedIndex = 0;
            Type.SelectedIndex = 0;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bL.AddHostingUnit(HostingUnit);
                hostUser.HostingUnits.Add(HostingUnit);

                HostingUnit = new HostingUnit();
                HostingUnitDetails.DataContext = HostingUnit;

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

        
    }
}
