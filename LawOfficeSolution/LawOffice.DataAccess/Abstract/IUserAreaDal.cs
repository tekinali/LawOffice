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
    public interface IUserAreaDal : IEntityRepository<UserArea>
    {
        UserArea GetWithDetails(Expression<Func<UserArea, bool>> filter);
        List<UserArea> GetListWithDetails(Expression<Func<UserArea, bool>> filter = null);
    }
}
