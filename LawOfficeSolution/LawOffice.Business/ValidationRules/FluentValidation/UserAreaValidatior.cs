using FluentValidation;
using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Business.ValidationRules.FluentValidation
{
    public class UserAreaValidatior : AbstractValidator<UserArea>
    {
        public UserAreaValidatior()
        {
            RuleFor(p => p.AppUserId).NotEmpty();
            RuleFor(p => p.FieldsOfLawId).NotEmpty();

        }
    }
}
