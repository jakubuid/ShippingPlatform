using System.Collections.Generic;
using System.Data;
using ShippingPlatform.DataBase.Repositories;

namespace ShippingPlatform.DataBase.Services
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
