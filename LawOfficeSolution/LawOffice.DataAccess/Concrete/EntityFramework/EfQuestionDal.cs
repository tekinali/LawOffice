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
    public class EfQuestionDal : EfEntityRepositoryBase<Question, DatabaseContext>, IQuestionDal
    {
        public List<Question> GetListWithDetails(Expression<Func<Question, bool>> filter = null)
        {

            using (var context = new DatabaseContext())
            {
                if(filter!=null)
                {
                    var result = context.Questions
                  .Include("FieldsOfLaw")
                  .Include("Answers")
                  .Where(filter)
                  .ToList();

                    return result;
                }
                else
                {
                    var result = context.Questions
                  .Include("FieldsOfLaw")
                  .Include("Answers")          
                  .ToList();

                    return result;
                }
              

             
            }
        }

        public Question GetWithDetails(Expression<Func<Question, bool>> filter)
        {
            using (var context = new DatabaseContext())
            {
                var result = context.Questions
                    .Include("FieldsOfLaw")                       
                    .Include("Answers")
                    .Where(filter)
                    .FirstOrDefault();

                return result;
            }
        }
    }
}
