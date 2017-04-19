using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using ShippingPlatform.DataBase;
using ShippingPlatform.DataBase.Repositories;
using ShippingPlatform.DataBase.Services;

namespace ShippingPlatform.Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region MySqlConnection Connection
        MySqlConnection conn = new MySqlConnection(ConnectionProvider.GetConnectionString());

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion
        #region bind data to DataGrid.

        private void btnloaddata_Click(object sender, RoutedEventArgs e)
        {
            using (ConnectionProvider.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(
                @"SELECT id_clients, id_client_address, id_order, login, password, address_email FROM clients", conn);

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "LoadDataBinding");
                dataGridClients.DataContext = ds;
            }
        }
        #endregion

        private void columnHeader_Click(object sender, RoutedEventArgs e)
        {
            var columnHeader = sender as DataGridColumnHeader;
            if (columnHeader != null)
            {
                // do stuff
            }
        }
    }
}