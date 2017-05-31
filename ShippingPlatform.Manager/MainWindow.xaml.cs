using System;
using System.Windows;
using MySql.Data.MySqlClient;
using ShippingPlatform.DataBase;

namespace ShippingPlatform.Manager
{
    public partial class MainWindow : Window
    {
        #region MySqlConnection Connection

        public MySqlConnection dbConnection = new MySqlConnection(ConnectionProvider.GetConnectionString());

        public MainWindow()
        {
            InitializeComponent();
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