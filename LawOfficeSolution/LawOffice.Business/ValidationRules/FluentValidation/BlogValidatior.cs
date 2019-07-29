using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LawOffice.Entities.Concrete;

namespace LawOffice.Business.ValidationRules.FluentValidation
{
    public class BlogValidatior :AbstractValidator<Blog>
    {
        public BlogValidatior()
        {
            RuleFor(p => p.AppUserId).NotEmpty();
            RuleFor(p => p.CreatedOn).NotEmpty();
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Summary).NotEmpty();
            RuleFor(p => p.Text).NotEmpty();
        }
    }
}
