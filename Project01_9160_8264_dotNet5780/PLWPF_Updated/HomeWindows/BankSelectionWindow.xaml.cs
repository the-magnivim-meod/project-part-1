using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
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
using BL;
namespace PLWPF_Updated
{
    /// <summary>
    /// Interaction logic for BankSelectionWindow.xaml
    /// </summary>
    public partial class BankSelectionWindow : Window
    {
        BackgroundWorker bg = new BackgroundWorker();
        HttpWebRequest httpRequest;
        IBL myIBL = FactoryBL.GetBL();
        public BankBranch BankBranch = new BankBranch();
        HostRegWindow hostRegWindow;
        public BankSelectionWindow(HostRegWindow input)
        {
            InitializeComponent();
            comboBoxBanks.ItemsSource = null;
            bg.DoWork += Bg_DoWork;
            bg.RunWorkerCompleted += Bg_RunWorkerCompleted;
            bg.ProgressChanged += Bg_ProgressChanged;
            bg.WorkerReportsProgress = true;
            hostRegWindow = input;
        }
        private void Bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
        }
        private void Bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataTable dt = e.Result as DataTable;
            DataView dv = dt.DefaultView;
            this.banksDatagrid.DataContext = dv;
            var banknames = dv.ToTable(true, "Bank_Name").AsEnumerable();

            comboBoxBanks.ItemsSource = banknames.Select(dr => dr["Bank_Name"].ToString().Trim()).Distinct();
        }
        private void Bg_DoWork(object sender, DoWorkEventArgs e)
        {
            bg.ReportProgress(10);
            // Construct HTTP request to get the file
            string uriString = (String)e.Argument;
            httpRequest = (HttpWebRequest)WebRequest.Create(uriString);
            httpRequest.Method = WebRequestMethods.Http.Get;
            bg.ReportProgress(30);
            // Get back the HTTP response for web server
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            Stream httpResponseStream = httpResponse.GetResponseStream();
            bg.ReportProgress(40);
            // Construct the Datset and read the data from the stream
            DataSet ds = new DataSet();
            ds.ReadXml(httpResponseStream);
            bg.ReportProgress(90);
            DataTable dt = ds.Tables[0];
            e.Result = dt;
            bg.ReportProgress(100);
        }
        private void populateBanksBtn_Click(object sender, RoutedEventArgs e)
        {
            bg.RunWorkerAsync(@"https://www.boi.org.il/en/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/snifim_en.xml");
        }
        private void comboBoxBanks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxBanks.ItemsSource != null)
            {
                string str = comboBoxBanks.SelectedItem as String;

                foreach (DataRowView drv in (DataView)banksDatagrid.ItemsSource)
                {
                    if (drv["Bank_Name"].ToString() == str)
                    {
                        // This is the data row view record you want...
                        banksDatagrid.SelectedItem = drv;
                        banksDatagrid.ScrollIntoView(drv);
                        break;
                    }
                }
            }
        }

        private void banksDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBoxResult message = MessageBox.Show("Would you like to select this branch?", "Select", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (message == MessageBoxResult.Yes)
            {
                DataRowView dataRowView = banksDatagrid.SelectedItem as DataRowView;
                hostRegWindow.host.BankBranchDetails.BranchAddress = dataRowView["Address"].ToString();
                hostRegWindow.host.BankBranchDetails.BranchCity = dataRowView["City"].ToString();
                hostRegWindow.host.BankBranchDetails.BankNumber = int.Parse(dataRowView[0].ToString());
                hostRegWindow.host.BankBranchDetails.BranchNumber = int.Parse(dataRowView[2].ToString());
                hostRegWindow.host.BankBranchDetails.BankName = dataRowView[1].ToString();
                this.Close();
            }
        }

    }
}
