using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        List<Category> List(Expression<Func<Category, bool>> filter);
        Category Find(Expression<Func<Category, bool>> filter);
        Category Add(Category entity);
        Category Update(Category entity);
        void Delete(Category entity);

    }
}
