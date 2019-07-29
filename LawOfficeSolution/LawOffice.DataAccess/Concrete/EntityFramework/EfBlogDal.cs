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
    public class EfBlogDal : EfEntityRepositoryBase<Blog, DatabaseContext>, IBlogDal
    {
       
        public Blog GetWithDetails(Expression<Func<Blog, bool>> filter)
        {
            using(var context = new DatabaseContext())
            {
                var result = context.Blogs
                    .Include("AppUser")
                    .Include("BlogCategories")
                    .Include("BlogCategories.Category")
                    .Where(filter)
                    .FirstOrDefault();

                return result;
            }
            
           
        }

        public List<Blog> GetListWithDetails(Expression<Func<Blog, bool>> filter=null)
        {
            using (var context = new DatabaseContext())
            {
                if(filter!=null)
                {
                    var result = context.Blogs
                    .Include("AppUser")
                    .Include("BlogCategories")            
                    .Where(filter)
                    .ToList();
                    return result;
                }
                else
                {
                    var result = context.Blogs
                    .Include("AppUser")
                    .Include("BlogCategories")                     
                    .ToList();
                    return result;
                }                               
            }
        }


    }
}
