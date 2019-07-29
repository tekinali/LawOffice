using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LawOffice.Entities.Concrete;

namespace LawOffice.MvcWebUI.Areas.Admin.ViewModels.Question
{
    public class DetailsViewModel
    {
        public Entities.Concrete.Question Question { get; set; }
        public Entities.Concrete.FieldsOfLaw FieldsOfLaw { get; set; }
        public List<Entities.Concrete.Answer> Answers { get; set; }

    }
}