using LawOffice.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Business.Abstract
{
    public interface IBaseService<T>
        where T : class, IEntity, new()
    {
        List<T> GetAll();
        List<T> List(Expression<Func<T, bool>> filter);
        T Find(Expression<Func<T, bool>> filter);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
