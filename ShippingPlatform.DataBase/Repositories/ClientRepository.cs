using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ShippingPlatform.DataBase.Repositories
{
    public class ClientRepository
    {
        public Client GetClient(IDbConnection connection, int searchId)
        {
            return connection.Query<Client, Address, Order, Address, Address, Client>(
                @"SELECT * FROM clients
                INNER JOIN addresses a1 ON clients.id_client_address = a1.id_addresses
                INNER JOIN orders o ON clients.id_order = o.id_orders
                INNER JOIN addresses a3 ON o.id_client_address = a3.id_addresses
                INNER JOIN addresses a2 ON o.id_recipient_address = a2.id_addresses
                WHERE id_clients = @id",
                (client, clientAddress, order, orderRecipientAddress, orderClientAddress) =>
                {
                    client.clientAddress = clientAddress;
                    client.order = order;
                    order.clientAddress = orderClientAddress;
                    order.recipientAddress = orderRecipientAddress;
                    return client;
                },
                new {id = searchId}, splitOn: "id_addresses, id_orders, id_addresses, id_addresses").FirstOrDefault();
        }


        public IEnumerable<Client> GetAllClients(IDbConnection connection)
        {
            return connection.Query<Client, Address, Order, Address, Address, Client>(
                @"SELECT * FROM clients
                INNER JOIN addresses a ON clients.id_client_address = a.id_addresses
                INNER JOIN orders o ON clients.id_order = o.id_orders
                INNER JOIN addresses a3 ON o.id_client_address = a3.id_addresses
                INNER JOIN addresses a2 ON o.id_recipient_address = a2.id_addresses",
                (client, clientAddress, order, orderRecipientAddress, orderClientAddress) =>
                {
                    client.clientAddress = clientAddress;
                    client.order = order;
                    order.clientAddress = orderClientAddress;
                    order.recipientAddress = orderRecipientAddress;
                    return client;
                },
                splitOn: "id_addresses, id_orders, id_addresses, id_addresses").ToList();
        }

        public void DeleteClient(IDbConnection connection, int searchId)
        {
            connection.Query<Client>
            (
                "DELETE FROM clients WHERE id_clients = @id",
                new {id = searchId});
        }

        public void AddClient(IDbConnection connection, Client client)
        {
            connection.Query<Client>
            (
                @"INSERT INTO clients
                VALUES (@clientAddressId, @orderId, @login, @password, @addressemail
                SELECT cast(scope_identity( ) as int");
        }

        public void UpdateClient(IDbConnection connection, Client client)
        {
            connection.Query<Client>
            (
                @"UPDATE clients SET id_client_address = @clientAddressId,
                id_order = @orderId, login = @login, password = @password,
                address_email = @addressEmail,
                WHERE id_clients = @id");
        }
    }
}