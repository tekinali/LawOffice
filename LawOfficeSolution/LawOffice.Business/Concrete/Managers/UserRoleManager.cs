using AutoMapper;
using LawOffice.Business.Abstract;
using LawOffice.Business.ValidationRules.FluentValidation;
using LawOffice.Core.Aspects.Postsharp.AuthorizationAspects;
using LawOffice.Core.Aspects.Postsharp.CacheAspects;
using LawOffice.Core.Aspects.Postsharp.ValidationAspects;
using LawOffice.Core.CrossCuttingConcerns.Caching.Microsoft;
using LawOffice.DataAccess.Abstract;
using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Business.Concrete.Managers
{
    public class UserRoleManager: IUserRoleService
    {

        private IUserRoleDal _userRoleDal;
        private readonly IMapper _mapper;

        public UserRoleManager(IUserRoleDal userRoleDal, IMapper mapper)
        {
            _userRoleDal = userRoleDal;
            _mapper = mapper;
        }


        [SecuredOperation(Roles = "Admin")]
        [FluentValidationAspect(typeof(UserRoleValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public UserRole Add(UserRole entity)
        {
            var db_userRole = _userRoleDal.Get(x=>x.AppUserId==entity.AppUserId && x.AppRoleId ==entity.AppRoleId);
            if(db_userRole!=null)
            {
                throw new Exception("Kullanıcı belirtilen role sahip.");
            }

            return _userRoleDal.Add(entity);
        }

        [SecuredOperation(Roles = "Admin")]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(UserRole entity)
        {
            _userRoleDal.Delete(entity);
        }

        public UserRole Find(Expression<Func<UserRole, bool>> filter)
        {
            var userRole = _mapper.Map<UserRole>(_userRoleDal.Get(filter));
            return userRole;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<UserRole> GetAll()
        {
            var userRoles = _mapper.Map<List<UserRole>>(_userRoleDal.GetList());
            return userRoles;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<UserRole> GetAllWithDetails()
        {
            var userRoles = _mapper.Map<List<UserRole>>(_userRoleDal.GetListWithDetails());
            return userRoles;
        }

        public List<UserRole> List(Expression<Func<UserRole, bool>> filter)
        {
            var userRoles = _mapper.Map<List<UserRole>>(_userRoleDal.GetList());
            return userRoles;
        }

        public List<UserRole> ListWithDetails(Expression<Func<UserRole, bool>> filter)
        {
            var userRoles = _mapper.Map<List<UserRole>>(_userRoleDal.GetListWithDetails(filter));
            return userRoles;
        }

        public UserRole WithDetails(Expression<Func<UserRole, bool>> filter)
        {
            var userRole = _mapper.Map<UserRole>(_userRoleDal.GetWithDetails(filter));
            return userRole;
        }


    }
}
