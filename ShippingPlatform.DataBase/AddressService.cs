using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.DataBase
{
    class AddressService
    {
        private AddressRepository addressRepository = new AddressRepository();
        public Address FindOneAddress(IDbConnection connection, int searchId)
        {
            return addressRepository.GetAddress(connection, searchId);
        }

        public IEnumerable<Address> FindAllAddresses(IDbConnection connection)
        {
            return addressRepository.GetAllAddresses(connection);
        }
    }
}
