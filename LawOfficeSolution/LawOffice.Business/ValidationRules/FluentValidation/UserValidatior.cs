using FluentValidation;
using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Business.ValidationRules.FluentValidation
{
    public class UserValidatior : AbstractValidator<AppUser>
    {
        public UserValidatior()
        {
            RuleFor(u => u.UserName).NotEmpty();
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();

            RuleFor(u => u.UserName).Length(6,16);
        }
    }
}
