using System;
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
            return connection.Query<Client, Address, Order, Client>(
                @"SELECT * FROM clients
                INNER JOIN addresses a ON clients.id_client_address = a.id_addresses
                INNER JOIN orders o ON clients.id_order = o.id_orders
                WHERE id_clients = @id",
                (client, address, order) =>
                {
                    client.clientAddress = address;
                    client.order = order;
                    return client;
                },
                new {id = searchId}, splitOn: "id_addresses, id_orders").FirstOrDefault();
        }

        public IEnumerable<Client> GetAllClients(IDbConnection connection)
        {
            return connection.Query<Client, Address, Order, Client>(
                @"SELECT * FROM clients
                 INNER JOIN addresses a ON clients.id_client_address = a.id_addresses
                INNER JOIN orders o ON clients.id_order = o.id_orders",
                 (client, address, order) =>
                 {
                     client.clientAddress = address;
                     client.order = order;
                     return client;
                 },
                 splitOn: "id_addresses, id_orders").ToList();
        }

        public void DeleteClient(IDbConnection connection, int searchId)
        {
            connection.Query<Client>("DELETE FROM clients WHERE id_clients = @id",
                new {id = searchId});
        }

        public void AddClient(IDbConnection connection, Client client)
        {
            connection.Query<Client>(
                @"INSERT INTO clients
                VALUES (@clientAddressId, @orderId, @login, @password, @addressemail
                SELECT cast(scope_identity( ) as int");
        }

        public void UpdateClient(IDbConnection connection, Client client)
        {
            connection.Query<Client>(@"UPDATE clients SET id_client_address = @clientAddressId,
                                        id_order = @orderId, login = @login, password = @password,
                                        address_email = @addressEmail,
                                        WHERE id_clients = @id");
        }
    }
}