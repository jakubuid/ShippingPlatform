using ShippingPlatform.DataBase.Repositories;
using System.Collections.Generic;
using System.Data;

namespace ShippingPlatform.DataBase.Services
{
    public class ClientService
    {
        private ClientRepository clientRepository = new ClientRepository();

        public Client FindOneClient(IDbConnection connection, int searchId)
        {
            return clientRepository.GetClient(connection, searchId);
        }

        public IEnumerable<Client> FindAllClients(IDbConnection connection)
        {
            return clientRepository.GetAllClients(connection);
        }

        public void DeleteClient(IDbConnection connection, int searchId)
        {
            clientRepository.DeleteClient(connection, searchId);
        }

        public IEnumerable<Client> AddClient(IDbConnection connection, Client client)
        {
            return clientRepository.AddClient(connection, client.clientAddressId, client.orderId, client.login,
                client.password, client.addressEmail);
        }

        public Client UpdateClient(IDbConnection connection, Client client, int id)
        {
            return clientRepository.UpdateClient(connection, client, id);
        }
    }
}