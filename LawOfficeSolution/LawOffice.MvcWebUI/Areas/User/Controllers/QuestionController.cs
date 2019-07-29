using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LawOffice.Business.Abstract;
using LawOffice.Core.CrossCuttingConcerns.Security;
using LawOffice.Entities.Concrete;
using LawOffice.MvcWebUI.Areas.User.ViewModels.Question;
using LawOffice.MvcWebUI.Filters;

namespace LawOffice.MvcWebUI.Areas.User.Controllers
{
    [Exc]
    [Auth]
    [AuthUser]
    public class QuestionController : Controller
    {

        private IQuestionService _questionService;
        private IFieldsOfLawService _fieldsOfLawService;
        private IAnswerService _answerService;
        private IUserService _userService;
        private IUserAreaService _userAreaService;


        public QuestionController(IQuestionService questionService, IFieldsOfLawService fieldsOfLawService, 
            IAnswerService answerService, IUserService userService, 
            IUserAreaService userAreaService)
        {
            _questionService = questionService;
            _fieldsOfLawService = fieldsOfLawService;
            _answerService = answerService;
            _userService = userService;
            _userAreaService = userAreaService;
        }

        
        public ActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.Questions = _questionService.GetAllWithDetails();

            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var question = _questionService.Find(x => x.Id == id);

            if (question == null)
            {
                return HttpNotFound();
            }

            DetailsViewModel model = new DetailsViewModel();
            model.Question = question;
            model.FieldsOfLaw = _fieldsOfLawService.Find(x => x.Id == question.FieldsOfLawId);
            model.Answers = _answerService.ListWithDetails(x => x.QuestionId == question.Id);   

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddAnswer(int questionId, string text)
        {
            try
            {
                var userId = GetUserId();
                Answer answer = new Answer()
                {
                    AppUserId = userId,
                    QuestionId = questionId,
                    Text = text,
                    CreatedOn = DateTime.Now
                };

                _answerService.Add(answer);
                return RedirectToAction("Details", "Question", new { id = questionId });

            }
            catch
            {
                return RedirectToAction("Details", "Question", new { id = questionId });
            }

        }

        public ActionResult MyArea()
        {
            var userId = GetUserId();
            var fieldsOfLawIds = _userAreaService.List(x => x.AppUserId == userId).Select(s => s.FieldsOfLawId).ToList();

            IndexViewModel model = new IndexViewModel();
            model.Questions = _questionService.ListWithDetails(x => fieldsOfLawIds.Contains(x.FieldsOfLawId));

            return View("Index",model);
        }

        public ActionResult MyAnswers()
        {
            MyAnswersViewModel model = new MyAnswersViewModel();

            var userId = GetUserId();

            model.Answers = _answerService.ListWithDetails(x => x.AppUserId == userId);

            return View(model);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DeleteAnswer(int answerId)
        {
            try
            {
                var userId = GetUserId();
                var answer = _answerService.Find(x => x.Id == answerId && x.AppUserId == userId);
                _answerService.Delete(answer);

                return RedirectToAction("MyAnswers", "Question");
            }
            catch
            {
                return RedirectToAction("MyAnswers", "Question");
            }    
        }

        private Guid GetUserId()
        {
            var myIdentity = (Identity)System.Web.HttpContext.Current.User.Identity;
            var userId = myIdentity.UserId;

            return userId;
        }


    }
}