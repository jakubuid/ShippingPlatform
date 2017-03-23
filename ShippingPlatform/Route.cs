using System;

namespace ShippingPlatform
{
    public class Route
    {
        public int id { get; set; }
        public Address startAddress { get; set; }
        public int startAddressId { get; set; }
        public Address endAddress { get; set; }
        public int endAddressId { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int orderId { get; set; }
        public Order order { get; set; }
    }
}
