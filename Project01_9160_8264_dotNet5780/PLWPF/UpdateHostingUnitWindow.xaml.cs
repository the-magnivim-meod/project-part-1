//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using BE;
//using BL;
//using DAL;

//namespace PLWPF
//{
//    /// <summary>
//    /// Interaction logic for UpdateHostingUnit.xaml
//    /// </summary>
//    public partial class UpdateHostingUnitWindow : Window
//    {
//        Host hostUser;
//        static IBL myIbl = FactoryBL.GetBL();

//        public UpdateHostingUnitWindow(Host hostUser)
//        {
//            InitializeComponent();
//            this.hostUser = hostUser;

//            SelectHostingUnit.ItemsSource = hostUser.HostingUnits.Select(item => item.HostinUnitKey);
//            Area.ItemsSource = Enum.GetValues(typeof(AreaOfTheCountry));
//            Type.ItemsSource = Enum.GetValues(typeof(HostingUnitType));

//        }

//        private void Add_Click(object sender, RoutedEventArgs e)
//        {

//            try
//            {
//                myIbl.(hostUser.HostingUnits[HostingUnitBox.SelectedIndex]);

//                new Host(hostUser).Show();
//                Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//        }

//        private void Cancel_Click(object sender, RoutedEventArgs e)
//        {
//            new Host(hostUser).Show();
//            Close();
//        }

//        private void HostingUnitBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
//        {
//            HostingUnitDetails.DataContext = hostUser.HostingUnits[HostingUnitBox.SelectedIndex];
//        }
//    }
//}
