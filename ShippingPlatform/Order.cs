using System;
using System.Collections.Generic;

namespace ShippingPlatform
{
    class Order
    {
        private Address recipientAddress;
        private Address clientAddress;
        private string orderNumber;
        private DateTime createdDay;
        private DateTime pickUpDate;
        private DateTime deliveryDate;
        private String status;
        private List<Route> routes = new List<Route>();
        private List<Package> packages = new List<Package>();
    }
}
