using System;
using DataAccess;
using DomainModels;

namespace Services
{
    public class SubscriptionService : ServiceBase<Subscription>, ISubscriptionService
    {
        public void ApproveNewSubscription(Guid userId, Guid subscriberId)
        {
            using (var unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                var subscriptionRepository = unitOfWork.GetRepository<Subscription>();
                var approvedSubcription = subscriptionRepository.Single(sub => sub.UserId == userId && sub.SubscriberId == subscriberId);
                approvedSubcription.IsApproved = true;
                subscriptionRepository.Update(approvedSubcription);
                unitOfWork.CommitChanges();
            }
        }

        public void RemoveMySubscription(Guid myId, Guid userId)
        {
            using (var unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                var subscriptionRepository = unitOfWork.GetRepository<Subscription>();
                var approvedSubcription = subscriptionRepository.Single(sub => sub.UserId == userId && sub.SubscriberId == myId);
                approvedSubcription.IsRemoved = true;
                subscriptionRepository.Update(approvedSubcription);
                unitOfWork.CommitChanges();
            }
        }

        public void RemoveMySubscriber(Guid myId, Guid subscriberId)
        {
            using (var unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                var subscriptionRepository = unitOfWork.GetRepository<Subscription>();
                var approvedSubcription = subscriptionRepository.Single(sub => sub.UserId == myId && sub.SubscriberId == subscriberId);
                approvedSubcription.IsRemoved = true;
                subscriptionRepository.Update(approvedSubcription);
                unitOfWork.CommitChanges();
            }
        }
    }
}
