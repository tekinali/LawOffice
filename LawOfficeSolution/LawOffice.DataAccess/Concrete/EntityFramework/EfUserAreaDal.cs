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
    public class EfUserAreaDal : EfEntityRepositoryBase<UserArea, DatabaseContext>, IUserAreaDal
    {
        public List<UserArea> GetListWithDetails(Expression<Func<UserArea, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                if (filter != null)
                {
                    var result = context.UserAreas
                    .Include("AppUser")
                    .Include("FieldsOfLaw")
                    .Where(filter)
                    .ToList();

                    return result;
                }
                else
                {
                    var result = context.UserAreas
                    .Include("AppUser")
                    .Include("FieldsOfLaw")
                    .ToList();

                    return result;
                }
            }
        }

        public UserArea GetWithDetails(Expression<Func<UserArea, bool>> filter)
        {
            using (var context = new DatabaseContext())
            {
                var result = context.UserAreas
                    .Include("AppUser")
                    .Include("FieldsOfLaw")
                    .Where(filter)
                    .FirstOrDefault();

                return result;
            }
        }
    }
}
