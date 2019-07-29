using AutoMapper;
using LawOffice.Business.Abstract;
using LawOffice.Core.Aspects.Postsharp.AuthorizationAspects;
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
    public class BlogCategoryManager : IBlogCategoryService
    {
        private IBlogCategoryDal _blogCategoryDal;
        private readonly IMapper _mapper;

        public BlogCategoryManager(IBlogCategoryDal blogCategoryDal, IMapper mapper)
        {
            _blogCategoryDal = blogCategoryDal;
            _mapper = mapper;
        }

        public List<BlogCategory> GetAll()
        {
            var blogCategories = _mapper.Map<List<BlogCategory>>(_blogCategoryDal.GetList());
            return blogCategories;
        }

        public List<BlogCategory> List(Expression<Func<BlogCategory, bool>> filter)
        {
            var blogCategories = _mapper.Map<List<BlogCategory>>(_blogCategoryDal.GetList(filter));
            return blogCategories;
        }

        public BlogCategory Find(Expression<Func<BlogCategory, bool>> filter)
        {
            var blogCategory = _mapper.Map<BlogCategory>(_blogCategoryDal.Get(filter));
            return blogCategory;
        }

        [SecuredOperation(Roles = "Admin,StandartUser")]
        public BlogCategory Add(BlogCategory entity)
        {
            var db_blogCategory = _blogCategoryDal.Get(x => x.BlogId == entity.BlogId && x.CategoryId == entity.CategoryId);
            if(db_blogCategory!=null)
            {
                throw new Exception("Blog belirtilen kategoriye sahip.");
            }

            return _blogCategoryDal.Add(entity);
        }

        [SecuredOperation(Roles = "Admin,StandartUser")]
        public void Delete(BlogCategory entity)
        {
            _blogCategoryDal.Delete(entity);
        }

        public BlogCategory WithDetails(Expression<Func<BlogCategory, bool>> filter)
        {
            var blogCategory = _mapper.Map<BlogCategory>(_blogCategoryDal.GetWithDetails(filter));
            return blogCategory;
        }

        public List<BlogCategory> ListWithDetails(Expression<Func<BlogCategory, bool>> filter)
        {
            var blogCategories = _mapper.Map<List<BlogCategory>>(_blogCategoryDal.GetListWithDetails(filter));
            return blogCategories;
        }

        public List<BlogCategory> GetAllWithDetails()
        {
            var blogCategories = _mapper.Map<List<BlogCategory>>(_blogCategoryDal.GetListWithDetails());
            return blogCategories;
        }
    }
}
