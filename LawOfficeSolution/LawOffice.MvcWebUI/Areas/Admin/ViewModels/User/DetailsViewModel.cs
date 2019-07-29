using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LawOffice.Entities.Concrete;

namespace LawOffice.MvcWebUI.Areas.Admin.ViewModels.User
{
    public class DetailsViewModel
    {
        public AppUser User { get; set; }

        public List<AppRole> Roles { get; set; }
        public List<Entities.Concrete.Blog> Blogs { get; set; }
        public List<Answer> Answers { get; set; }
        public List<Entities.Concrete.FieldsOfLaw> FieldsOfLaw { get; set; }
    }
}