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
using MySql.Data.MySqlClient;
using ShippingPlatform.DataBase;

namespace ShippingPlatform.Manager
{
    /// <summary>
    /// Interaction logic for MainPlatformWindow.xaml
    /// </summary>
    public partial class MainPlatformWindow : Window
    {
        #region MySqlConnection Connection

        public MySqlConnection dbConnection = new MySqlConnection(ConnectionProvider.GetConnectionString());

        public MainPlatformWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dbConnection.Open();
                string insertPackage = @"INSERT INTO 
                               packages(id_packages, height, width, depth, weight, content, id_order)
                               VALUES('" + this.idBox.Text + "', '" +
                                       this.heightBox.Text + "', '" +
                                       this.widthBox.Text + "', '" +
                                       this.depthBox.Text + "', '" +
                                       this.weightBox.Text + "', '" +
                                       this.contentBox.Text + "', 1);";

                MySqlCommand createCommand = new MySqlCommand(insertPackage, dbConnection);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Added");
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                dbConnection.Close();
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dbConnection.Open();
                string updatePackage = @"UPDATE packages SET
                                        id_packages = '" + this.idBox.Text +
                                       "', height = '" + this.heightBox.Text +
                                       "', Width = '" + this.widthBox.Text +
                                       "', depth = '" + this.depthBox.Text +
                                       "', weight = '" + this.weightBox.Text +
                                       "', content = '" + this.contentBox.Text + "'" +
                                       "WHERE  id_packages = '" + this.idBox.Text + "';";

                MySqlCommand createCommand = new MySqlCommand(updatePackage, dbConnection);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Edited");
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                dbConnection.Close();
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dbConnection.Open();
                string deletePackage = @"DELETE FROM packages
                                        WHERE id_packages = '" + this.idBox.Text + "';";

                MySqlCommand createCommand = new MySqlCommand(deletePackage, dbConnection);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Deleted");
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                dbConnection.Close();
            }
        }
    }

    #endregion
}