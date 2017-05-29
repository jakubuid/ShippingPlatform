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
    public partial class MainWindow : Window
    {
        #region MySqlConnection Connection

        public MySqlConnection dbConnection = new MySqlConnection(ConnectionProvider.GetConnectionString());

        public MainWindow()
        {
            InitializeComponent();
            //DataContext = new ClientsViewModel(); 
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dbConnection.Open();
                string query = @"SELECT *
                            FROM clients
                            WHERE login='" + this.loginBox.Text + "' and password='" + this.pwdBox.Password + "'";

                MySqlCommand createCommand = new MySqlCommand(query, dbConnection);
                createCommand.ExecuteNonQuery();
                MySqlDataReader dataReader = createCommand.ExecuteReader();

                int count = 0;
                while (dataReader.Read())
                {
                    count++;
                }

                if (count == 1)
                {
                    dbConnection.Close();
                    MainPlatformWindow platformWindow = new MainPlatformWindow();
                    this.Close();
                    platformWindow.ShowDialog();
                }
                else if (count > 1)
                {
                    MessageBox.Show("Login and password are duplicated");
                    dbConnection.Close();
                }
                else if (count < 1)
                {
                    MessageBox.Show("Login and password are incorrect");
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            this.Close();
            registerWindow.ShowDialog();
        }
    }

    #endregion
}