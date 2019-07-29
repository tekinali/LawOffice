using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawOffice.Entities.Concrete;
using LawOffice.MvcWebUI.Areas.Admin.ViewModels.Question;
using LawOffice.Business.Abstract;
using System.Net;
using LawOffice.MvcWebUI.Filters;

namespace LawOffice.MvcWebUI.Areas.Admin.Controllers
{
    [Exc]
    [Auth]
    [AuthAdmin]
    public class QuestionController : Controller
    {
        private IQuestionService _questionService;
        private IFieldsOfLawService _fieldsOfLawService;
        private IAnswerService _answerService;
        private IUserService _userService;

        public QuestionController(IQuestionService questionService, IFieldsOfLawService 
            fieldsOfLawService, IAnswerService answerService, IUserService userService)
        {
            _questionService = questionService;
            _fieldsOfLawService = fieldsOfLawService;
            _answerService = answerService;
            _userService = userService;
        }

        // GET: Admin/Question
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
            model.Answers = _answerService.ListWithDetails(x=>x.QuestionId==question.Id);

            var userList = _userService.GetAll();
            ViewBag.userId = new SelectList(userList, "Id", "UserName");
            

            return View(model);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DeleteAnswer(int? answerId)
        {
            if (answerId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var answer = _answerService.Find(x => x.Id == answerId);
            var questionId = answer.QuestionId;

            if (answer == null)
            {
                return HttpNotFound();
            }

            try
            {
                _answerService.Delete(answer);
                return RedirectToAction("Details", "Question", new { id = questionId });
            }
            catch
            {
                return RedirectToAction("Details", "Question", new { id = questionId });
            }       
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(int? questionId)
        {
            if (questionId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var question = _questionService.Find(x => x.Id == questionId);
        

            if (question == null)
            {
                return HttpNotFound();
            }

            try
            {
                _questionService.Delete(question);
                return RedirectToAction("Index", "Question");
            }
            catch
            {
                return RedirectToAction("Index", "Question" );
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddAnswer(int questionId, Guid userId, string text)
        {
            try
            {
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


       

    }
}