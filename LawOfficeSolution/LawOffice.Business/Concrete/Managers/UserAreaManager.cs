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
    public class UserAreaManager : IUserAreaService
    {
        private IUserAreaDal _userAreaDal;
        private readonly IMapper _mapper;

        public UserAreaManager(IUserAreaDal userAreaDal, IMapper mapper)
        {
            _userAreaDal = userAreaDal;
            _mapper = mapper;
        }

        [SecuredOperation(Roles = "Admin")]
        [FluentValidationAspect(typeof(UserAreaValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public UserArea Add(UserArea entity)
        {
            var userArea = _userAreaDal.Get(x => x.AppUserId == entity.AppUserId && x.FieldsOfLawId == entity.FieldsOfLawId);
            if(userArea!=null)
            {
                throw new Exception("Kullanıcı belirtilen alana sahip.");
            }

            return _userAreaDal.Add(entity);
        }

        [SecuredOperation(Roles = "Admin")]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(UserArea entity)
        {
            _userAreaDal.Delete(entity);
        }

        public UserArea Find(Expression<Func<UserArea, bool>> filter)
        {
            var userArea = _mapper.Map<UserArea>(_userAreaDal.Get(filter));
            return userArea;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<UserArea> GetAll()
        {
            var userAreas = _mapper.Map<List<UserArea>>(_userAreaDal.GetList());
            return userAreas;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<UserArea> GetAllWithDetails()
        {
            var userAreas = _mapper.Map<List<UserArea>>(_userAreaDal.GetListWithDetails());
            return userAreas;
        }

        public List<UserArea> List(Expression<Func<UserArea, bool>> filter)
        {
            var userAreas = _mapper.Map<List<UserArea>>(_userAreaDal.GetList(filter));
            return userAreas;
        }

        public List<UserArea> ListWithDetails(Expression<Func<UserArea, bool>> filter)
        {
            var userAreas = _mapper.Map<List<UserArea>>(_userAreaDal.GetListWithDetails(filter));
            return userAreas;
        }

        public UserArea WithDetails(Expression<Func<UserArea, bool>> filter)
        {
            var userArea = _mapper.Map<UserArea>(_userAreaDal.GetWithDetails(filter));
            return userArea;
        }


    }
}
