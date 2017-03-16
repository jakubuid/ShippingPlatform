using System;

namespace ShippingPlatform
{
    class Route
    {
        public Address startAddress { get; set; }
        public Address endAddress { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }
}
