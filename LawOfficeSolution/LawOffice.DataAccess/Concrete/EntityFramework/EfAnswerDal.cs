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
    public class EfAnswerDal : EfEntityRepositoryBase<Answer, DatabaseContext>, IAnswerDal
    {
        public List<Answer> GetListWithDetails(Expression<Func<Answer, bool>> filter)
        {
            using (var context = new DatabaseContext())
            {
                if (filter != null)
                {
                    var result = context.Answers
                .Include("Question")
                .Include("AppUser")
                .Where(filter)
                .ToList();
                    return result;
                }
                else
                {
                    var result = context.Answers
                 .Include("Question")
                 .Include("AppUser")
                 .ToList();
                    return result;
                }

            }
        }

        public Answer GetWithDetails(Expression<Func<Answer, bool>> filter)
        {
            using (var context = new DatabaseContext())
            {
                var result = context.Answers
                    .Include("Question")
                    .Include("AppUser")
                    .Where(filter)
                    .FirstOrDefault();
                return result;
            }
        }
    }
}
