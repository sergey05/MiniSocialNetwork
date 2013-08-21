using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DomainModels;

namespace Services
{
    public class AdministrationService:ServiceBase<User>,IAdministrationService
    {
        public AdministrationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void MakeAdmin(Guid userId)
        {
            var user = Single(o => o.UserId == userId);
            user.Role = Role.Admin;
            Update(user);
            UnitOfWork.CommitChanges();
        }

        public void ChangeUserStatus(Guid userId, bool makeBlocked)
        {
            var user = Single(o => o.UserId == userId);
            user.IsBlocked = makeBlocked;
            Update(user);
            UnitOfWork.CommitChanges();
        }
    }
}
