using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LawOffice.MvcWebUI.Areas.Admin.ViewModels.Home
{    
    public class IndexViewModel
    {
        public List<Entities.Concrete.Question> Questions { get; set; }
        public int BlogCount { get; set; }
        public int QuestionCount { get; set; }
        public int UserCount { get; set; }

    }
}