using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Business.Abstract
{
    public interface ILogService
    {
        List<Log> GetAll();
        List<Log> List(Expression<Func<Log, bool>> filter);
        Log Find(Expression<Func<Log, bool>> filter);
    }
}
