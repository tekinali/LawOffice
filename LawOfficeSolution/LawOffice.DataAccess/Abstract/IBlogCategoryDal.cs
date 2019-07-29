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
    public interface IBlogCategoryDal : IEntityRepository<BlogCategory>
    {
        BlogCategory GetWithDetails(Expression<Func<BlogCategory, bool>> filter);
        List<BlogCategory> GetListWithDetails(Expression<Func<BlogCategory, bool>> filter = null);
    }
}
