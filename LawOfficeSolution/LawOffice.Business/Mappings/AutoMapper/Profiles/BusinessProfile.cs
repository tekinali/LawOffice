using AutoMapper;
using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Business.Mappings.AutoMapper.Profiles
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<Answer, Answer>();
            CreateMap<AppRole, AppRole>();
            CreateMap<AppUser, AppUser>();
            CreateMap<Blog, Blog>();

            CreateMap<BlogCategory, BlogCategory>();
            CreateMap<Category, Category>();
            CreateMap<FieldsOfLaw, FieldsOfLaw>();
            CreateMap<Question, Question>();

            CreateMap<UserArea, UserArea>();
            CreateMap<UserRole, UserRole>();
        }
    }
}
