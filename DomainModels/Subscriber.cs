using System;

namespace DomainModels
{
    public class Subscriber : User
    {
        public DateTime SubscriptionTime { get; set; }
        public bool IsApproved { get; set; }
        public DateTime ApprovedSubscriptionTime { get; set; }
    }
}
