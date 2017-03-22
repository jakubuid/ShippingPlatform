using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ShippingPlatform.DataBase
{
    class AddressRepository
    {
        public Address GetAddress(IDbConnection connection, int searchId)
        {
            return connection.Query<Address>(
                "SELECT * FROM addresses WHERE id_addresses = @id",
                new { id = searchId }).FirstOrDefault();
        }

        public IEnumerable<Address> GetAllAddresses(IDbConnection connection)
        {
            return connection.Query<Address>("SELECT * FROM addresses").ToList();
        }
    }
}
