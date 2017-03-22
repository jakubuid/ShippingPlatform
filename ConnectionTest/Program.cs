using ShippingPlatform.DataBase;
using System;

namespace ConnectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientService clientService = new ClientService();

            using (ConnectionProvider.GetConnection())
            {
                Console.WriteLine(clientService.FindOneClient(ConnectionProvider.GetConnection(), 2).password);
            }
        }
    }
}
