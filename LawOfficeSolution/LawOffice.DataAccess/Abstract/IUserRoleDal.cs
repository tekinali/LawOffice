using LawOffice.Core.DataAccess;
using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.DataAccess.Abstract
{
    public interface IUserRoleDal : IEntityRepository<UserRole>
    {
        UserRole GetWithDetails(Expression<Func<UserRole, bool>> filter);
        List<UserRole> GetListWithDetails(Expression<Func<UserRole, bool>> filter = null);
    }
}
