using ShippingPlatform.DataBase;
using System;
using System.Linq;
using ShippingPlatform.DataBase.Services;

namespace ConnectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientService clientService = new ClientService();
            AddressService addressService = new AddressService();
            LogisticCenterService lgCenterService = new LogisticCenterService();
            NotificationService notificationService = new NotificationService();
            OrderService orderService = new OrderService();
            PackageService packageService = new PackageService();
            RouteService routeService = new RouteService();

            using (ConnectionProvider.GetConnection())
            {
                //Console.WriteLine(clientService.FindOneClient(ConnectionProvider.GetConnection(), 1).login);
                Console.WriteLine(addressService.FindOneAddress(ConnectionProvider.GetConnection(), 1).country);
                Console.WriteLine(lgCenterService.FindOneLogisticCenter(ConnectionProvider.GetConnection(), 1).name);
                Console.WriteLine(notificationService.FindOneNotification(ConnectionProvider.GetConnection(), 1).message);
                Console.WriteLine(orderService.FindOneOrder(ConnectionProvider.GetConnection(), 1).createdDay);
                Console.WriteLine(packageService.FindOnePackage(ConnectionProvider.GetConnection(), 1).weight);
                Console.WriteLine(routeService.FindOneRoute(ConnectionProvider.GetConnection(), 1).endTime);
            }
        }
    }
}