using System;
using System.Collections.Generic;

namespace ShippingPlatform
{
    class Order
    {
        private List<Route> routes = new List<Route>();
        private List<Package> packages = new List<Package>();
        public int id { get; set; }
        public Address recipientAddress { get; set; }
        public Address clientAddress { get; set; }
        public String orderNumber { get; set; }
        public DateTime createdDay { get; set; }
        public DateTime pickUpDate { get; set; }
        public DateTime deliveryDate { get; set; }
        public String status { get; set; }
    }
}
