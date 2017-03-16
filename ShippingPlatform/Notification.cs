using System;
using System.Collections.Generic;

namespace ShippingPlatform
{
    class Notification
    {
        private List<String> attachements = new List<string>();
        public int id { get; set; }
        public String clienEmail { get; set; }
        public String recipientEmail { get; set; }
        public String message{ get; set; }
        public String subject { get; set; }
        public DateTime timeStamp{ get; set; }
        public Order order { get; set; }
    }
}
