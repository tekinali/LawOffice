using AutoMapper;
using LawOffice.Business.Abstract;
using LawOffice.Business.ValidationRules.FluentValidation;
using LawOffice.Core.Aspects.Postsharp.AuthorizationAspects;
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
    public class FieldsOfLawManager : IFieldsOfLawService
    {
        private IFieldsOfLawDal _fieldsOfLawDal;
        private readonly IMapper _mapper;

        private IUserAreaService _userAreaService;

        public FieldsOfLawManager(IFieldsOfLawDal fieldsOfLawDal, IMapper mapper, IUserAreaService userAreaService)
        {
            _fieldsOfLawDal = fieldsOfLawDal;
            _mapper = mapper;
            _userAreaService = userAreaService;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<FieldsOfLaw> GetAll()
        {
            var fieldsOfLaw = _mapper.Map<List<FieldsOfLaw>>(_fieldsOfLawDal.GetList());
            return fieldsOfLaw;
        }

        public List<FieldsOfLaw> List(Expression<Func<FieldsOfLaw, bool>> filter)
        {
            var fieldsOfLaw = _mapper.Map<List<FieldsOfLaw>>(_fieldsOfLawDal.GetList(filter));
            return fieldsOfLaw;
        }

        public FieldsOfLaw Find(Expression<Func<FieldsOfLaw, bool>> filter)
        {
            var fieldsOfLaw = _mapper.Map<FieldsOfLaw>(_fieldsOfLawDal.Get(filter));
            return fieldsOfLaw;
        }


        [SecuredOperation(Roles = "Admin")]
        [FluentValidationAspect(typeof(FieldsOfLawValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public FieldsOfLaw Add(FieldsOfLaw entity)
        {
            return _fieldsOfLawDal.Add(entity);
        }


        [SecuredOperation(Roles = "Admin")]
        [FluentValidationAspect(typeof(FieldsOfLawValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public FieldsOfLaw Update(FieldsOfLaw entity)
        {
            return _fieldsOfLawDal.Update(entity);
        }

        [SecuredOperation(Roles = "Admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(FieldsOfLaw entity)
        {
            var areas = _userAreaService.List(x => x.FieldsOfLawId == entity.Id);
            if(areas.Count>0)
            {
                foreach (var item in areas)
                {
                    _userAreaService.Delete(item);
                }
            }

            _fieldsOfLawDal.Delete(entity);
        }



    }
}
