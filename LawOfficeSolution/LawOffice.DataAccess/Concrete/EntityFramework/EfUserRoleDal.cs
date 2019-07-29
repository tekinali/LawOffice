using LawOffice.Core.DataAccess.EntityFramework;
using LawOffice.DataAccess.Abstract;
using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.DataAccess.Concrete.EntityFramework
{
    public class EfUserRoleDal : EfEntityRepositoryBase<UserRole, DatabaseContext>, IUserRoleDal
    {
        public List<UserRole> GetListWithDetails(Expression<Func<UserRole, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                if (filter != null)
                {

                    var result = context.UserRoles
                        .Include("AppRole")
                        .Include("AppUser")
                        .Where(filter)
                        .ToList();
                    return result;
                }
                else
                {
                    var result = context.UserRoles
                    .Include("AppRole")
                    .Include("AppUser")
                    .ToList();

                    return result;
                }
            }
        }

        public UserRole GetWithDetails(Expression<Func<UserRole, bool>> filter)
        {
            using (var context = new DatabaseContext())
            {

                var result = context.UserRoles
                    .Include("AppRole")
                    .Include("AppUser")
                    .Where(filter)
                    .FirstOrDefault();
                return result;
            }
        }
    }
}
