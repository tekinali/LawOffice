using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Business.Abstract
{
    public interface IUserRoleService
    {
        List<UserRole> GetAll();
        List<UserRole> List(Expression<Func<UserRole, bool>> filter);
        UserRole Find(Expression<Func<UserRole, bool>> filter);
        UserRole Add(UserRole entity);
        void Delete(UserRole entity);

        UserRole WithDetails(Expression<Func<UserRole, bool>> filter);
        List<UserRole> ListWithDetails(Expression<Func<UserRole, bool>> filter);
        List<UserRole> GetAllWithDetails();
    }
}
