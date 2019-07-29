using AutoMapper;
using LawOffice.Business.Abstract;
using LawOffice.Core.Aspects.Postsharp.AuthorizationAspects;
using LawOffice.Core.Aspects.Postsharp.CacheAspects;
using LawOffice.Core.CrossCuttingConcerns.Caching.Microsoft;
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
    public class AnswerManager : IAnswerService
    {
        private IAnswerDal _answerDal;
        private readonly IMapper _mapper;

        public AnswerManager(IAnswerDal answerDal, IMapper mapper)
        {
            _answerDal = answerDal;
            _mapper = mapper;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Answer> GetAll()
        {
            var answers = _mapper.Map<List<Answer>>(_answerDal.GetList());
            return answers;
        }

        public List<Answer> List(Expression<Func<Answer, bool>> filter)
        {
            var answers = _mapper.Map<List<Answer>>(_answerDal.GetList(filter));
            return answers;
        }

        public Answer Find(Expression<Func<Answer, bool>> filter)
        {
            var answer = _mapper.Map<Answer>(_answerDal.Get(filter));
            return answer;
        }

        [SecuredOperation(Roles = "Admin,StandartUser")]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Answer Add(Answer entity)
        {
            return _answerDal.Add(entity);
        }

        [SecuredOperation(Roles = "Admin,StandartUser")]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Answer Update(Answer entity)
        {
            return _answerDal.Update(entity);
        }

        [SecuredOperation(Roles = "Admin,StandartUser")]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Answer entity)
        {
            _answerDal.Delete(entity);
        }

        public Answer WithDetails(Expression<Func<Answer, bool>> filter)
        {
            var answer = _mapper.Map<Answer>(_answerDal.GetWithDetails(filter));
            return answer;
        }

        public List<Answer> ListWithDetails(Expression<Func<Answer, bool>> filter)
        {
            var answers = _mapper.Map<List<Answer>>(_answerDal.GetListWithDetails(filter));
            return answers;
        }

        public List<Answer> GetAllWithDetails()
        {
            var answers = _mapper.Map<List<Answer>>(_answerDal.GetListWithDetails());
            return answers;
        }
    }
}
