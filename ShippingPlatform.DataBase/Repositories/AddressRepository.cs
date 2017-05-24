using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ShippingPlatform.DataBase.Repositories
{
    class AddressRepository
    {
        public Address GetAddress(IDbConnection connection, int searchId)
        {
            return connection.Query<Address>(
                "SELECT * FROM addresses WHERE id_addresses = @id",
                new {id = searchId}).FirstOrDefault();
        }

        public IEnumerable<Address> GetAllAddresses(IDbConnection connection)
        {
            return connection.Query<Address>("SELECT * FROM addresses").ToList();
        }

        public IEnumerable<Client> AddAddress(IDbConnection connection, string newCountry, string newCity,
            string newZipcode, int newHousenumber)
        {
            return connection.Query<Client>
            (
                @"INSERT INTO 
                addresses(country, city, zipcode, house_number)
                VALUES(@country, @city, @zipcode, @house_number);",
                new
                {
                    country = newCountry,
                    city = newCity,
                    zipcode = newZipcode,
                    house_number = newHousenumber,
                });
        }

        public Address UpdateAddress(IDbConnection connection, Address address, int addressId)
        {
           return 
                connection.Query<Address>(
                @"UPDATE addresses SET
                country = @country,
                city = @city,
                zipcode = @zipcode,
                house_number = @houseNumber
                WHERE id_addresses = @id;",
                new
                {
                    id = addressId,
                    country = address.country,
                    city = address.city,
                    zipcode = address.zipcode,
                    housenumber = address.houseNumber

                }).FirstOrDefault();
        }
    }
}