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
    public interface IBlogDal : IEntityRepository<Blog>
    {
        Blog GetWithDetails(Expression<Func<Blog, bool>> filter);
        List<Blog> GetListWithDetails(Expression<Func<Blog, bool>> filter = null);
       
    }
}
