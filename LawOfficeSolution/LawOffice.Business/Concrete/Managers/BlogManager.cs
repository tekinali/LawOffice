using LawOffice.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LawOffice.Entities.Concrete;
using System.Linq.Expressions;
using LawOffice.DataAccess.Abstract;
using AutoMapper;
using LawOffice.Core.Aspects.Postsharp.ValidationAspects;
using LawOffice.Business.ValidationRules.FluentValidation;
using LawOffice.Core.Aspects.Postsharp.CacheAspects;
using LawOffice.Core.CrossCuttingConcerns.Caching.Microsoft;
using LawOffice.Core.Aspects.Postsharp.TransactionAspects;
using LawOffice.Core.Aspects.Postsharp.AuthorizationAspects;
using LawOffice.Core.Aspects.Postsharp.LogAspects;
using LawOffice.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

namespace LawOffice.Business.Concrete.Managers
{
    public class BlogManager : IBlogService
    {
        private IBlogDal _blogDal;
        private IBlogCategoryService _blogCategoryService;
        private readonly IMapper _mapper;

        public BlogManager(IBlogDal blogDal, IMapper mapper, IBlogCategoryService blogCategoryService)
        {
            _blogDal = blogDal;
            _mapper = mapper;
            _blogCategoryService = blogCategoryService;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Blog> GetAll()
        {
            var blogs = _mapper.Map<List<Blog>>(_blogDal.GetList());
            return blogs;
        }

        public List<Blog> List(Expression<Func<Blog, bool>> filter)
        {
            var blogs = _mapper.Map<List<Blog>>(_blogDal.GetList(filter));
            return blogs;
        }

        public Blog Find(Expression<Func<Blog, bool>> filter)
        {
            var blog = _mapper.Map<Blog>(_blogDal.Get(filter));
            return blog;
        }


   
        [SecuredOperation(Roles = "Admin,StandartUser")]
        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(BlogValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Blog Add(Blog entity,int categoryId)
        {
            var blog = _blogDal.Add(entity);

            var blogCategory = _blogCategoryService.Add(new BlogCategory()
            {
                BlogId=blog.Id,
                CategoryId=categoryId
            });

            return blog;
        }

        [SecuredOperation(Roles = "Admin,StandartUser")]
        [FluentValidationAspect(typeof(BlogValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Blog Update(Blog entity)
        {
            return _blogDal.Update(entity);
        }

        [SecuredOperation(Roles = "Admin,StandartUser")]
        [TransactionScopeAspect]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Blog entity)
        {
            var categories = _blogCategoryService.List(x => x.BlogId == entity.Id);
            if(categories.Count>0)
            {
                foreach (var item in categories)
                {
                    _blogCategoryService.Delete(item);
                }
            }

            _blogDal.Delete(entity);
        }

        public Blog WithDetails(Expression<Func<Blog, bool>> filter)
        {
            var blog = _mapper.Map<Blog>(_blogDal.GetWithDetails(filter));
            return blog;
        }

        public List<Blog> ListWithDetails(Expression<Func<Blog, bool>> filter)
        {
            var blogs = _mapper.Map<List<Blog>>(_blogDal.GetListWithDetails(filter));
            return blogs;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Blog> GetAllWithDetails()
        {
            var blogs = _mapper.Map<List<Blog>>(_blogDal.GetListWithDetails());
            return blogs;
        }
       


    }
}
