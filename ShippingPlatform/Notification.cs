using System;
using System.Collections.Generic;

namespace ShippingPlatform
{
    public class Notification
    {
        public int attachmentId { get; set; }
        public int id { get; set; }
        public Order order { get; set; }
        public String clientEmail { get; set; }
        public String recipientEmail { get; set; }
        public String message{ get; set; }
        public String subject { get; set; }
        public DateTime timeStamp{ get; set; }
    }
}
