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
    public interface IAnswerDal : IEntityRepository<Answer>
    {
        Answer GetWithDetails(Expression<Func<Answer, bool>> filter);
        List<Answer> GetListWithDetails(Expression<Func<Answer, bool>> filter=null);
    }
}
