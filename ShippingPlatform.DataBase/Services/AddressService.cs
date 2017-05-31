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

        public IEnumerable<Address> AddAddress(IDbConnection connection, Address address)
        {
            return addressRepository.AddAddress(connection, address.country, address.city, address.zipcode,
                address.houseNumber);
        }

        public Address UpdateAddress(IDbConnection connection, Address address, int id)
        {
            return addressRepository.UpdateAddress(connection, address, id);
        }

        public void DeleteAddress(IDbConnection connection, int searchId)
        {
            addressRepository.DeleteAddress(connection, searchId);
        }
    }
}