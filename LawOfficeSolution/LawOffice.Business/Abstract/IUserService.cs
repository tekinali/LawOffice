using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LawOffice.Entities.Concrete;

namespace LawOffice.Business.Abstract
{
    public interface IUserService
    {
        List<AppUser> GetAll();
        List<AppUser> List(Expression<Func<AppUser, bool>> filter);
        AppUser Find(Expression<Func<AppUser, bool>> filter);
        AppUser Add(AppUser entity);
        AppUser Update(AppUser entity);
        void Delete(AppUser entity);

        List<string> GetUserRolesStringName(Guid UserId);
        List<AppRole> GetUserRoles(Guid UserId);

        AppUser LoginUser(string userName, string password);
        AppUser LoginAdmin(string userName, string password);

        bool IsAdmin(AppUser entity);
        bool IsStandartUser(AppUser entity);

    }
}
