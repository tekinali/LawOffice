using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LawOffice.Entities.Concrete;

namespace LawOffice.Business.ValidationRules.FluentValidation
{
    public class QuestionValidatior : AbstractValidator<Question>
    {
        public QuestionValidatior()
        {
            RuleFor(p => p.Email).NotEmpty().EmailAddress();
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.Subject).NotEmpty().MinimumLength(4);
            RuleFor(p => p.Text).NotEmpty().MinimumLength(4);
            RuleFor(p => p.FieldsOfLawId).NotEmpty();
        }
    }
}
