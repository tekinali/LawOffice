using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Business.Abstract
{
    public interface IFieldsOfLawService
    {
        List<FieldsOfLaw> GetAll();
        List<FieldsOfLaw> List(Expression<Func<FieldsOfLaw, bool>> filter);
        FieldsOfLaw Find(Expression<Func<FieldsOfLaw, bool>> filter);
        FieldsOfLaw Add(FieldsOfLaw entity);
        FieldsOfLaw Update(FieldsOfLaw entity);
        void Delete(FieldsOfLaw entity);       
    }
}
