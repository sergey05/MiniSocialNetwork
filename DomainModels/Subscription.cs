using System;

namespace DomainModels
{
    public class Subscription
    {
        public virtual User Subscriber { get; set; }
        public Guid SubscriberId { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        public DateTime SubscriptionTime { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime? ApprovedSubscriptionTime { get; set; }
    }
}
