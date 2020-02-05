﻿using System;
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
    /// Interaction logic for AdminWindows.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public AdminMainWindow()
        {
            InitializeComponent();
        }

        private void GuestRequestsList_Click(object sender, RoutedEventArgs e)
        {
            Window GuestGrid = new UpdateGuestRequests();
            GuestGrid.Show();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window NewMainWindow = new MainWindow();
            NewMainWindow.Show();
            this.Close();
        }
    }
}