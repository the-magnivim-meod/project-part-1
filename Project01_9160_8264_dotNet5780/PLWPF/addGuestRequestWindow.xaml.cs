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
    /// Interaction logic for addGuestRequest.xaml
    /// </summary>
    public partial class addGuestRequestWindow : Window
    {
        static IBL myIBL = FactoryBL.GetBL();
        GuestRequest newGuestRequest = new GuestRequest();
        public addGuestRequestWindow()
        {
            InitializeComponent();
            pool.ItemsSource = Enum.GetValues(typeof(AmountOfIntrenst));
            cAttractions.ItemsSource = Enum.GetValues(typeof(AmountOfIntrenst));
            gStore.ItemsSource = Enum.GetValues(typeof(AmountOfIntrenst));
            garden.ItemsSource = Enum.GetValues(typeof(AmountOfIntrenst));
            AreaOfCountry.ItemsSource = Enum.GetValues(typeof(AreaOfTheCountry));
            TypeOfHostingUnit.ItemsSource = Enum.GetValues(typeof(HostingUnitType));
        }

        private void AddRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int children = int.Parse(numChildren.Text);
                int adults = int.Parse(numAdults.Text);
            }
            catch (Exception)
            {
               
            }
        }
    }
}
