using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawOffice.Entities.Concrete;
using LawOffice.Business.Abstract;
using LawOffice.MvcWebUI.Filters;
using LawOffice.MvcWebUI.ViewModels.Home;

namespace LawOffice.MvcWebUI.Controllers
{
    [Exc]
    public class HomeController : Controller
    {
        private IQuestionService _questionService;
        private IAnswerService _answerService;
        private IFieldsOfLawService _fieldsOfLawService;


        public HomeController(IQuestionService questionService, IAnswerService answerService, IFieldsOfLawService fieldsOfLawService)
        {
            _questionService = questionService;
            _answerService = answerService;
            _fieldsOfLawService = fieldsOfLawService;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult PracticeAreas()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Question()
        {
            var lawList = _fieldsOfLawService.GetAll();
            ViewBag.lawId = new SelectList(lawList, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ExceptionHandler]
        public ActionResult Question(Question model)
        {
            List<string> messages = new List<string>();

            try
            {
                var result = _questionService.Add(model);

                messages.Add("Sorunuz kayıt edildi. Kısa süre içerisinde cevaplanacaktır.");
                messages.Add("Takip kodunuz :" + result.Code);
                TempData["message"] = messages;

                return RedirectToAction("Question");
            }
            catch
            {
                messages.Add("Sorunuz kayıt edilemedi. Lütfen gerekli alanları giriniz.");             
                TempData["message"] = messages;
                return RedirectToAction("Question");
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Answer(string code)
        {

            var question = _questionService.WithDetails(x => x.Code == code);

            if(question==null)
            {
                return RedirectToAction("Question");
            }

            var questionId = question.Id;



            var answers = _answerService.ListWithDetails(x => x.QuestionId == questionId);
            AnswerViewModel model = new AnswerViewModel();
            model.Answers = answers;
            model.Question = question;

            return View(model);
        }

        public ActionResult AccessDenied()
        {
            return View();
        }

        public ActionResult HasError()
        {
            return View();
        }



    }
}