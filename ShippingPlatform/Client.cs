using System;

namespace ShippingPlatform
{
     public class Client
    {
        public int id { get; set; }
        public Address clientAddress { get; set; }
        public Address order { get; set; }
        public String login { get; set; }
        public String  password{ get; set; }
        public String addressEmail { get; set; }
    }
}
