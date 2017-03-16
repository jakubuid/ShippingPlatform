using System;

namespace ShippingPlatform
{
     class Client
    {
        public Address clientAddress { get; set; }
        public Order order { get; set; }
        public String login { get; set; }
        public String  password{ get; set; }
        public String addressEmail { get; set; }
    }
}
