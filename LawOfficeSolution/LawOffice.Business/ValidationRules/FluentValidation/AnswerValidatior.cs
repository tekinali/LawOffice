using FluentValidation;
using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Business.ValidationRules.FluentValidation
{
    public class AnswerValidatior : AbstractValidator<Answer>
    {
        public AnswerValidatior()
        {
            RuleFor(p => p.AppUserId).NotEmpty();
            RuleFor(p => p.CreatedOn).NotEmpty();
            RuleFor(p => p.QuestionId).NotEmpty();
            RuleFor(p => p.Text).NotEmpty();          
        }
    }
}
