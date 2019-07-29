using AutoMapper;
using LawOffice.Business.Abstract;
using LawOffice.DataAccess.Abstract;
using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Business.Concrete.Managers
{
    public class LogManager : ILogService
    {
        private ILogDal _logDal;
        private readonly IMapper _mapper;

        public LogManager(ILogDal logDal, IMapper mapper)
        {
            _logDal = logDal;
            _mapper = mapper;
        }

        public List<Log> GetAll()
        {
            var logs = _mapper.Map<List<Log>>(_logDal.GetList());
            return logs;
        }

        public List<Log> List(Expression<Func<Log, bool>> filter)
        {
            var logs = _mapper.Map<List<Log>>(_logDal.GetList(filter));
            return logs;
        }

        public Log Find(Expression<Func<Log, bool>> filter)
        {
            var log = _mapper.Map<Log>(_logDal.Get(filter));
            return log;
        }
    }
}
