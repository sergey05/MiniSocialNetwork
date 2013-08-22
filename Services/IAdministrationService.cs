using System;
using DomainModels;

namespace Services
{
    public interface IAdministrationService:IServiceBase<User>
    {
        void MakeAdmin(Guid userId);
        void ChangeUserStatus(Guid userId, bool makeBlocked);
    }
}
