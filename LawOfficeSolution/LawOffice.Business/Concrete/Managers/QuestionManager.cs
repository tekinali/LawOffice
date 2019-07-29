using LawOffice.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LawOffice.Entities.Concrete;
using System.Linq.Expressions;
using LawOffice.DataAccess.Abstract;
using AutoMapper;
using LawOffice.Core.Aspects.Postsharp.ValidationAspects;
using LawOffice.Business.ValidationRules.FluentValidation;
using LawOffice.Core.Aspects.Postsharp.TransactionAspects;
using System.Globalization;
using LawOffice.Core.Aspects.Postsharp.AuthorizationAspects;

namespace LawOffice.Business.Concrete.Managers
{
    public class QuestionManager : IQuestionService
    {

        private IQuestionDal _questionDal;
        private readonly IMapper _mapper;

        private IAnswerService _answerService;

        public QuestionManager(IQuestionDal questionDal, IMapper mapper, IAnswerService answerService)
        {
            _questionDal = questionDal;
            _mapper = mapper;
            _answerService = answerService;
        }

        [SecuredOperation(Roles = "Admin,StandartUser")]
        public List<Question> GetAll()
        {
            var questions = _mapper.Map<List<Question>>(_questionDal.GetList());
            return questions;
        }

        [SecuredOperation(Roles = "Admin,StandartUser")]
        public List<Question> List(Expression<Func<Question, bool>> filter)
        {
            var questions = _mapper.Map<List<Question>>(_questionDal.GetList(filter));
            return questions;
        }

        [SecuredOperation(Roles = "Admin,StandartUser")]
        public Question Find(Expression<Func<Question, bool>> filter)
        {
            var question = _mapper.Map<Question>(_questionDal.Get(filter));
            return question;
        }

        [FluentValidationAspect(typeof(QuestionValidatior))]
        public Question Add(Question entity)
        {
            string code = CultureInfo.CurrentCulture.TextInfo.ToUpper(FakeData.TextData.GetAlphabetical(2)) + FakeData.NumberData.GetNumber(10000, 99999);

            entity.CreatedOn = DateTime.Now;
            entity.Code = String.Join("", code.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)).Substring(0).ToUpper();
            
            return _questionDal.Add(entity);
        }

        [SecuredOperation(Roles = "Admin")]
        [TransactionScopeAspect]
        public void Delete(Question entity)
        {
            var answers = _answerService.List(x => x.QuestionId == entity.Id);
            if(answers.Count>0)
            {
                foreach (var item in answers)
                {
                    _answerService.Delete(item);
                }
            }

            _questionDal.Delete(entity);
        }

        [SecuredOperation(Roles = "Admin,StandartUser")]
        public Question WithDetails(Expression<Func<Question, bool>> filter)
        {
            var question = _mapper.Map<Question>(_questionDal.GetWithDetails(filter));
            return question;
        }

        [SecuredOperation(Roles = "Admin,StandartUser")]
        public List<Question> ListWithDetails(Expression<Func<Question, bool>> filter)
        {
            var questions = _mapper.Map<List<Question>>(_questionDal.GetListWithDetails(filter));
            return questions;
        }

        [SecuredOperation(Roles = "Admin,StandartUser")]
        public List<Question> GetAllWithDetails()
        {
            var questions = _mapper.Map<List<Question>>(_questionDal.GetListWithDetails());
            return questions;
        }
    }
}
