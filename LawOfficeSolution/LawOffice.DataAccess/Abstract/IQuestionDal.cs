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
    public interface IQuestionDal : IEntityRepository<Question>
    {
        Question GetWithDetails(Expression<Func<Question, bool>> filter);
        List<Question> GetListWithDetails(Expression<Func<Question, bool>> filter = null);
    }
}
