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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        User user;
        IBL myIBL = FactoryBL.GetBL();
        public RegisterWindow()
        {
            InitializeComponent();
            user = new User();
            RegisterGrid.DataContext = user;

            UserType.ItemsSource = Enum.GetValues(typeof(UserType));
        }
    }
}
