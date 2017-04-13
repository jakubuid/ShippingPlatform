using System;
using System.Collections.Generic;
using System.Data;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnloaddata_Click(object sender, RoutedEventArgs e)
        {
            ClientRepository client = new ClientRepository();

//                using (MySqlDataAdapter adapter = new MySqlDataAdapter(client.GetAllClients(ConnectionProvider.GetConnection()), ConnectionProvider.GetConnection()))
//                {
//                    DataSet ds = new DataSet();
//                    adapter.Fill(ds);
//                    DataGridView1.DataSource = ds.Tables[0];
//                }
        }
    }
}