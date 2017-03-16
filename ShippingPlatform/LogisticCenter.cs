using System;

namespace ShippingPlatform
{
    class LogisticCenter
    {
        public int id { get; set; }
        public String name { get; set; }
        public Address logisticCenterAddress { get; set; }
        public Route shippingRoute { get; set; }
    }
}
