using System;

namespace ShippingPlatform
{
    public class Route
    {
        public int id { get; set; }
        public Address startAddress { get; set; }
        public Address endAddress { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }
}
