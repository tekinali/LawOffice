using LawOffice.Core.DataAccess.EntityFramework;
using LawOffice.DataAccess.Abstract;
using LawOffice.Entities.ComplexTypes;
using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<AppUser, DatabaseContext>, IUserDal
    {
        public List<UserRoleItem> GetUserRoles(AppUser user)
        {
            using(var context = new DatabaseContext())
            {
                var result = from ur in context.UserRoles
                             join r in context.AppRoles
                             on ur.AppUserId equals user.Id
                             where ur.AppUserId == user.Id
                             select new UserRoleItem { RoleName = r.Name };
                return result.ToList();
            }
        }
    }
}
