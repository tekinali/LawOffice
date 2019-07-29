using FluentValidation;
using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Business.ValidationRules.FluentValidation
{
    public class BlogCategoryValidatior : AbstractValidator<BlogCategory>
    {
        public BlogCategoryValidatior()
        {
            RuleFor(p => p.BlogId).NotEmpty();
            RuleFor(p => p.CategoryId).NotEmpty();
        }
    }
}
