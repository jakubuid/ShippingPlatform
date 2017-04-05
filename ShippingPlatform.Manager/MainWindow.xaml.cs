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
using MySql.Data.MySqlClient;

namespace ShippingPlatform.Manager
{
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


    //Using namespaces
    using System.Data;
    using System.Configuration;

    namespace DataGridBind
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            #region MySqlConnection Connection

            MySqlConnection conn = new
                MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            public MainWindow()
            {
                InitializeComponent();
            }

            #endregion

            #region bind data to DataGrid.

            private void btnloaddata_Click(object sender, RoutedEventArgs e)
            {
                Try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("Select
                    CustomerID,
                    ContactName,
                    Address,
                    City,
                    Phone,
                    Email from 
                    customers
                    ", conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds, "LoadDataBinding");
                    dataGridCustomers.DataContext = ds;
                }
                catch
                (MySqlException
                ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                Finally
                {
                    conn.Close();
                }
            }

            #endregion
        }
    }
}