using System;

namespace ShippingPlatform
{
    public class Package
    {
        public int id { get; set; }
        public double height { get; set; }
        public double width { get; set; }
        public double depth { get; set; }
        public double weight { get; set; }
        public String content { get; set; }
        public int orderId { get; set; }
        public Order order { get; set; }
    }
}