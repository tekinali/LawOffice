using AutoMapper;
using LawOffice.Business.Abstract;
using LawOffice.Business.ValidationRules.FluentValidation;
using LawOffice.Core.Aspects.Postsharp.CacheAspects;
using LawOffice.Core.Aspects.Postsharp.TransactionAspects;
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
    public class RoleManager : IRoleService
    {
        private IRoleDal _roleDal;
        private readonly IMapper _mapper;

        private IUserRoleService _userRoleService;


        public RoleManager(IRoleDal roleDal, IMapper mapper, IUserRoleService userRoleService)
        {
            _roleDal = roleDal;
            _mapper = mapper;
            _userRoleService = userRoleService;
            
        }      

        public AppRole Find(Expression<Func<AppRole, bool>> filter)
        {
            var role = _mapper.Map<AppRole>(_roleDal.Get(filter));
            return role;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<AppRole> GetAll()
        {
            var roles = _mapper.Map<List<AppRole>>(_roleDal.GetList());
            return roles;
        }

        public List<AppRole> List(Expression<Func<AppRole, bool>> filter)
        {
            var roles = _mapper.Map<List<AppRole>>(_roleDal.GetList(filter));
            return roles;
        }           

        public Guid GetAdminRolesId()
        {
            return _roleDal.Get(x => x.Name == "Admin").Id;
        }

        public Guid GetStandartUserRoleId()
        {
            return _roleDal.Get(x => x.Name == "StandartUser").Id;
        }


    }
}
