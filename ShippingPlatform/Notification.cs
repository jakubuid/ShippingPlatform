using System;
using System.Collections.Generic;

namespace ShippingPlatform
{
    class Notification
    {
        private String clietEmail;
        private String recipientEmail;
        private String wessage;
        private String subject;
        private List<String> attachements = new List<string>();
        private DateTime timeStamp;
        private Order order;
    }
}
