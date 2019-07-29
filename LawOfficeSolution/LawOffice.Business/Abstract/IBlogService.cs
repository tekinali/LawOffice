using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LawOffice.Entities.Concrete;

namespace LawOffice.Business.Abstract
{
    public interface IBlogService
    {
        List<Blog> GetAll();
        List<Blog> List(Expression<Func<Blog, bool>> filter);
        Blog Find(Expression<Func<Blog, bool>> filter);
        Blog Add(Blog entity,int categoryId);
        Blog Update(Blog entity);
        void Delete(Blog entity);

        Blog WithDetails(Expression<Func<Blog, bool>> filter);
        List<Blog> ListWithDetails(Expression<Func<Blog, bool>> filter);
        List<Blog> GetAllWithDetails();

    }
}
