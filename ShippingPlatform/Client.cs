using System;

namespace ShippingPlatform
{
     public class Client
    {
        public int id { get; set; }
        public Address clientAddress { get; set; }
        public int clientAddressId { get; set; }
        public Order order { get; set; }
        public int orderId { get; set; }
        public String login { get; set; }
        public String  password{ get; set; }
        public String addressEmail { get; set; }

        public Client()
        {
            this.login = " ";
            this.password = " ";
            this.addressEmail = " ";
        }
    }
}
