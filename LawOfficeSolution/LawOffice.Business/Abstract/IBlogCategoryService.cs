using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Business.Abstract
{
    public interface IBlogCategoryService
    {
        List<BlogCategory> GetAll();
        List<BlogCategory> List(Expression<Func<BlogCategory, bool>> filter);
        BlogCategory Find(Expression<Func<BlogCategory, bool>> filter);
        BlogCategory Add(BlogCategory entity);
        void Delete(BlogCategory entity);

        BlogCategory WithDetails(Expression<Func<BlogCategory, bool>> filter);
        List<BlogCategory> ListWithDetails(Expression<Func<BlogCategory, bool>> filter);
        List<BlogCategory> GetAllWithDetails();
    }
}
