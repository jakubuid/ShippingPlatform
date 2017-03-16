using System;
using System.Collections.Generic;

namespace ShippingPlatform
{
    public class Notification
    {
        private List<String> attachements = new List<string>();
        public int id { get; set; }
        public String clientEmail { get; set; }
        public String recipientEmail { get; set; }
        public String message{ get; set; }
        public String subject { get; set; }
        public DateTime timeStamp{ get; set; }
        public Order order { get; set; }
    }
}
