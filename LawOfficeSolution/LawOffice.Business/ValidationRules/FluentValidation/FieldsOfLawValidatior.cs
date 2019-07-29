using FluentValidation;
using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Business.ValidationRules.FluentValidation
{
    public class FieldsOfLawValidatior : AbstractValidator<FieldsOfLaw>
    {
        public FieldsOfLawValidatior()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).Must(ContainsLaw);
        }

        private bool ContainsLaw(string arg)
        {
            return arg.Contains("Hukuku");
        }
    }
}
