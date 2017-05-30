using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
            fillCombo();
            fillAddressCombo();
            fillClientCombo();
        }

        private void fillCombo()
        {
            try
            {
                dbConnection.Open();
                string selectPackages = @"SELECT *
                                FROM packages;";

                MySqlCommand createCommand = new MySqlCommand(selectPackages, dbConnection);
                MySqlDataReader dataReader = createCommand.ExecuteReader();

                comboBox.Items.Clear();

                while (dataReader.Read())
                {
                    string content = dataReader.GetString(5);
                    comboBox.Items.Add(content);
                }
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void comboBox_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                dbConnection.Open();
                string selectPackages = @"SELECT *
                                        FROM packages
                                        WHERE content = '" + this.comboBox.Text + "';";

                MySqlCommand createCommand = new MySqlCommand(selectPackages, dbConnection);
                MySqlDataReader dataReader = createCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    string packageId = dataReader.GetInt32(0).ToString();
                    string height = dataReader.GetDouble(1).ToString();
                    string width = dataReader.GetDouble(2).ToString();
                    string depth = dataReader.GetDouble(3).ToString();
                    string weight = dataReader.GetDouble(4).ToString();
                    string content = dataReader.GetString(5);

                    this.idBox.Text = packageId;
                    this.heightBox.Text = height;
                    this.contentBox.Text = content;
                    this.depthBox.Text = depth;
                    this.weightBox.Text = weight;
                    this.widthBox.Text = width;
                }
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                dbConnection.Close();
            }
        }

        private void loadDataButton_Click(object sender, RoutedEventArgs e)
        {
            fillCombo();
            try
            {
                dbConnection.Open();
                string selectPackages = @"SELECT id_packages, height, width, depth, weight, content
                                        FROM packages;";

                MySqlCommand createCommand = new MySqlCommand(selectPackages, dbConnection);
                createCommand.ExecuteNonQuery();

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(createCommand);
                DataTable dataTable = new DataTable("packages");
                dataAdapter.Fill(dataTable);
                dataGrid.ItemsSource = dataTable.DefaultView;
                dataAdapter.Update(dataTable);
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addAddresButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dbConnection.Open();
                string insertAddress = @"INSERT INTO 
                                        addresses(id_addresses, country, city, zipcode, house_number)
                                        VALUES('" + this.idAddressBox.Text + "', '" +
                                       this.countryAddressBox.Text + "', '" +
                                       this.cityAddressBox.Text + "', '" +
                                       this.zipcodeAddressBox.Text + "', '" +
                                       this.houseNumberAddressBox.Text + "');";

                MySqlCommand createCommand = new MySqlCommand(insertAddress, dbConnection);
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

        private void editAddressButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dbConnection.Open();
                string updateAddress = @"UPDATE addresses SET
                                        id_addresses = '" + this.idAddressBox.Text +
                                       "', country = '" + this.countryAddressBox.Text +
                                       "', city = '" + this.cityAddressBox.Text +
                                       "', zipcode = '" + this.zipcodeAddressBox.Text +
                                       "', house_number = '" + this.houseNumberAddressBox.Text + "'" +
                                       "WHERE  id_addresses = '" + this.idAddressBox.Text + "';";

                MySqlCommand createCommand = new MySqlCommand(updateAddress, dbConnection);
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

        private void deleteAddressButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dbConnection.Open();
                string deleteAddress = @"DELETE FROM addresses
                                        WHERE id_addresses = '" + this.idAddressBox.Text + "';";

                MySqlCommand createCommand = new MySqlCommand(deleteAddress, dbConnection);
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

        private void loadAddressDataButton_Click(object sender, RoutedEventArgs e)
        {
            fillAddressCombo();
            try
            {
                dbConnection.Open();
                string selectAddresses = @"SELECT id_addresses, country, city, zipcode, house_number
                                        FROM addresses;";

                MySqlCommand createCommand = new MySqlCommand(selectAddresses, dbConnection);
                createCommand.ExecuteNonQuery();

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(createCommand);
                DataTable dataTable = new DataTable("addresses");
                dataAdapter.Fill(dataTable);
                dataAddressGrid.ItemsSource = dataTable.DefaultView;
                dataAdapter.Update(dataTable);
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addressComboBox_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                dbConnection.Open();
                string selectAddresses = @"SELECT *
                                        FROM addresses
                                        WHERE country = '" + this.comboAddressBox.Text + "';";

                MySqlCommand createCommand = new MySqlCommand(selectAddresses, dbConnection);
                MySqlDataReader dataReader = createCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    string addressId = dataReader.GetInt32(0).ToString();
                    string country = dataReader.GetString(1);
                    string city = dataReader.GetString(2);
                    string zipcode = dataReader.GetString(3);
                    string houseNumber = dataReader.GetInt32(4).ToString();

                    this.idAddressBox.Text = addressId;
                    this.countryAddressBox.Text = country;
                    this.cityAddressBox.Text = city;
                    this.zipcodeAddressBox.Text = zipcode;
                    this.houseNumberAddressBox.Text = houseNumber;
                }
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                dbConnection.Close();
            }
        }

        private void fillAddressCombo()
        {
            try
            {
                dbConnection.Open();
                string selectAddresses = @"SELECT *
                                        FROM addresses;";

                MySqlCommand createCommand = new MySqlCommand(selectAddresses, dbConnection);
                MySqlDataReader dataReader = createCommand.ExecuteReader();

                comboAddressBox.Items.Clear();

                while (dataReader.Read())
                {
                    string country = dataReader.GetString(1);
                    comboAddressBox.Items.Add(country);
                }
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clientComboBox_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                dbConnection.Open();
                string selectClients = @"SELECT *
                                        FROM clients
                                        WHERE login = '" + this.comboClientBox.Text + "';";

                MySqlCommand createCommand = new MySqlCommand(selectClients, dbConnection);
                MySqlDataReader dataReader = createCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    string clientId = dataReader.GetInt32(0).ToString();
                    string login = dataReader.GetString(3);
                    string password = dataReader.GetString(4);
                    string email = dataReader.GetString(5);

                    this.idClientBox.Text = clientId;
                    this.loginClientBox.Text = login;
                    this.pwdClientBox.Text = password;
                    this.emailClientBox.Text = email;
                }
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                dbConnection.Close();
            }
        }

        private void deleteClientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dbConnection.Open();
                string deleteClient = @"DELETE FROM clients
                                        WHERE id_clients = '" + this.idClientBox.Text + "';";

                MySqlCommand createCommand = new MySqlCommand(deleteClient, dbConnection);
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

        private void editClientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dbConnection.Open();
                string updateClient = @"UPDATE clients SET
                                        id_clients = '" + this.idClientBox.Text +
                                      "', login = '" + this.loginClientBox.Text +
                                      "', password = '" + this.pwdClientBox.Text +
                                      "', address_email = '" + this.emailClientBox.Text + "'" +
                                      "WHERE  id_clients = '" + this.idClientBox.Text + "';";

                MySqlCommand createCommand = new MySqlCommand(updateClient, dbConnection);
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

        private void addClientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dbConnection.Open();
                string insertClient = @"INSERT INTO 
                                        clients(id_clients, id_client_address, id_order, login, password, address_email)
                                        VALUES('" + this.idClientBox.Text + "', 11 , 1 , '" +
                                      this.loginClientBox.Text + "', '" +
                                      this.pwdClientBox.Text + "', '" +
                                      this.emailClientBox.Text + "');";

                MySqlCommand createCommand = new MySqlCommand(insertClient, dbConnection);
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

        private void fillClientCombo()
        {
            try
            {
                dbConnection.Open();
                string selectClients = @"SELECT *
                                        FROM clients;";

                MySqlCommand createCommand = new MySqlCommand(selectClients, dbConnection);
                MySqlDataReader dataReader = createCommand.ExecuteReader();

                comboClientBox.Items.Clear();

                while (dataReader.Read())
                {
                    string login = dataReader.GetString(3);
                    comboClientBox.Items.Add(login);
                }
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadClientDataButton_Click(object sender, RoutedEventArgs e)
        {
            fillClientCombo();
            try
            {
                dbConnection.Open();
                string selectClients = @"SELECT id_clients, login, password, address_email
                                        FROM clients;";

                MySqlCommand createCommand = new MySqlCommand(selectClients, dbConnection);
                createCommand.ExecuteNonQuery();

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(createCommand);
                DataTable dataTable = new DataTable("clients");
                dataAdapter.Fill(dataTable);
                dataClientGrid.ItemsSource = dataTable.DefaultView;
                dataAdapter.Update(dataTable);
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    #endregion
}