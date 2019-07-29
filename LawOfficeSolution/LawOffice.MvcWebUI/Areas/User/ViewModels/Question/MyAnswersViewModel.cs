using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LawOffice.Entities.Concrete;

namespace LawOffice.MvcWebUI.Areas.User.ViewModels.Question
{
    public class MyAnswersViewModel
    {
        public List<Answer> Answers { get; set; }
    }
}