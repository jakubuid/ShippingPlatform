using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ShippingPlatform.DataBase.Repositories
{
    class ClientRepository
    {
        public Client GetClient(IDbConnection connection, int searchId)
        {
            return connection.Query<Client>(
                "SELECT * FROM clients WHERE id_clients = @id",
                new { id = searchId }).FirstOrDefault();
        }

        public IEnumerable<Client> GetAllClients(IDbConnection connection)
        {
            return connection.Query<Client>("SELECT * FROM clients").ToList();
        }
    }
}
