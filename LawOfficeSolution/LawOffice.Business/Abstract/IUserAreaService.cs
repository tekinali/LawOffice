using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Business.Abstract
{
    public interface IUserAreaService
    {
        List<UserArea> GetAll();
        List<UserArea> List(Expression<Func<UserArea, bool>> filter);
        UserArea Find(Expression<Func<UserArea, bool>> filter);
        UserArea Add(UserArea entity);
        void Delete(UserArea entity);

        UserArea WithDetails(Expression<Func<UserArea, bool>> filter);
        List<UserArea> ListWithDetails(Expression<Func<UserArea, bool>> filter);
        List<UserArea> GetAllWithDetails();
    }
}
