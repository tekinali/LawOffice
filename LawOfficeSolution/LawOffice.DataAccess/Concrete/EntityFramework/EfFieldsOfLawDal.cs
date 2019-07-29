using LawOffice.Core.DataAccess.EntityFramework;
using LawOffice.DataAccess.Abstract;
using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.DataAccess.Concrete.EntityFramework
{
    public class EfFieldsOfLawDal : EfEntityRepositoryBase<FieldsOfLaw, DatabaseContext>, IFieldsOfLawDal
    {       
    }
}
