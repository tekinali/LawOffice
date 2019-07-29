using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawOffice.MvcWebUI.Areas.User.ViewModels.Question
{
    public class IndexViewModel
    {
        public List<Entities.Concrete.Question> Questions { get; set; }
    }
}