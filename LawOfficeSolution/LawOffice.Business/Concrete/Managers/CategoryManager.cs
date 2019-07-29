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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        private readonly IMapper _mapper;

        private IBlogCategoryService _blogCategoryService;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper, IBlogCategoryService blogCategoryService)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        [SecuredOperation(Roles = "Admin")]
        [FluentValidationAspect(typeof(CategoryValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Category Add(Category entity)
        {
            return _categoryDal.Add(entity);
        }

        [SecuredOperation(Roles = "Admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Category entity)
        {
            var blogCategories = _blogCategoryService.List(x => x.CategoryId == entity.Id);
            if(blogCategories.Count>0)
            {
                foreach (var item in blogCategories)
                {
                    _blogCategoryService.Delete(item);
                }
            }

            _categoryDal.Delete(entity);
        }

        public Category Find(Expression<Func<Category, bool>> filter)
        {
            var category = _mapper.Map<Category>(_categoryDal.Get(filter));
            return category;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Category> GetAll()
        {
            var categories = _mapper.Map<List<Category>>(_categoryDal.GetList());
            return categories;
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            var categories = _mapper.Map<List<Category>>(_categoryDal.GetList(filter));
            return categories;
        }


        [SecuredOperation(Roles = "Admin")]
        [FluentValidationAspect(typeof(CategoryValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Category Update(Category entity)
        {
            return _categoryDal.Update(entity);
        }



    }
}
