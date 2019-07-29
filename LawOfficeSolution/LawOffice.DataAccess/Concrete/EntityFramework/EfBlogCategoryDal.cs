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
    public class EfBlogCategoryDal : EfEntityRepositoryBase<BlogCategory, DatabaseContext>, IBlogCategoryDal
    {
        public List<BlogCategory> GetListWithDetails(Expression<Func<BlogCategory, bool>> filter = null)
        {
            using(var context = new DatabaseContext())
            {
                if(filter!=null)
                {
                    var result = context.BlogCategories
                    .Include("Blog")               
                    .Include("Category")
                    .Where(filter)
                    .ToList();

                    return result;
                }
                else
                {
                    var result = context.BlogCategories
                    .Include("Blog")
                    .Include("Category")
                    .ToList();

                    return result;
                }
            }
        }

        public BlogCategory GetWithDetails(Expression<Func<BlogCategory, bool>> filter)
        {
            using(var context = new DatabaseContext())
            {

                var result = context.BlogCategories
                    .Include("Blog")
                    .Include("Category")
                    .Where(filter)
                    .FirstOrDefault();
                return result;
            }


        }



    }
}
