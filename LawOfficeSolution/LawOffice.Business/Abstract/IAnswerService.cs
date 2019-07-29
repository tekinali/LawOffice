using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Business.Abstract
{
    public interface IAnswerService
    {
        List<Answer> GetAll();
        List<Answer> List(Expression<Func<Answer, bool>> filter);
        Answer Find(Expression<Func<Answer, bool>> filter);
        Answer Add(Answer entity);
        Answer Update(Answer entity);
        void Delete(Answer entity);

        Answer WithDetails(Expression<Func<Answer, bool>> filter);
        List<Answer> ListWithDetails(Expression<Func<Answer, bool>> filter);
        List<Answer> GetAllWithDetails();
    }
}
