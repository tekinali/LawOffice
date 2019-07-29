using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Business.Abstract
{
    public interface IQuestionService
    {
        List<Question> GetAll();
        List<Question> List(Expression<Func<Question, bool>> filter);
        Question Find(Expression<Func<Question, bool>> filter);
        Question Add(Question entity); 
        void Delete(Question entity);

        Question WithDetails(Expression<Func<Question, bool>> filter);
        List<Question> ListWithDetails(Expression<Func<Question, bool>> filter);
        List<Question> GetAllWithDetails();
    }
}
