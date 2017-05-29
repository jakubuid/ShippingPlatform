using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        #region MySqlConnection Connection

        public MySqlConnection dbConnection = new MySqlConnection(ConnectionProvider.GetConnectionString());

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.pwdBox.Password) && string.IsNullOrWhiteSpace(this.emailBox.Text)
                    && string.IsNullOrWhiteSpace(this.loginBox.Text))
                {
                    MessageBox.Show("Please enter every value!");
                }
                else
                {
                    dbConnection.Open();
                    string insertNewUser = @"INSERT INTO 
                    clients(id_client_address, id_order, login, password, address_email)
                    VALUES(10, 1, '" + this.loginBox.Text + "', '" + this.pwdBox.Password + "', '" + this.emailBox.Text + "');";
                    MySqlCommand createClientCommand = new MySqlCommand(insertNewUser, dbConnection);
                    createClientCommand.ExecuteNonQuery();

                    MainPlatformWindow mainWindow = new MainPlatformWindow();
                    this.Close();
                    mainWindow.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    #endregion
}