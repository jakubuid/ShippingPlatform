using System.Collections.Generic;
using System.Data;

namespace ShippingPlatform.DataBase
{
    public class AddressService
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
