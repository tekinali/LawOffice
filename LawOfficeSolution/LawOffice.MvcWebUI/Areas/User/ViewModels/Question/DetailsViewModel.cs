using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawOffice.MvcWebUI.Areas.User.ViewModels.Question
{
    public class DetailsViewModel
    {
        public Entities.Concrete.Question Question { get; set; }
        public FieldsOfLaw FieldsOfLaw { get; set; }
        public List<Answer> Answers { get; set; }
    }
}