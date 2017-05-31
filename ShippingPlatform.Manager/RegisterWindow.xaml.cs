using System;
using System.Windows;
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
                                            VALUES(10, 1, '" + this.loginBox.Text + "', '" + this.pwdBox.Password +
                                           "', '" + this.emailBox.Text + "');";

                    MySqlCommand createClientCommand = new MySqlCommand(insertNewUser, dbConnection);
                    createClientCommand.ExecuteNonQuery();
                    dbConnection.Close();

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