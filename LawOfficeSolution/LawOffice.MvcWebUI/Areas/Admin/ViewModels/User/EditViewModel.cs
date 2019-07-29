using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawOffice.MvcWebUI.Areas.Admin.ViewModels.User
{
    public class EditViewModel
    {
        public AppUser User { get; set; }

        public List<AppRole> Roles { get; set; }
        public List<Entities.Concrete.FieldsOfLaw> FieldsOfLaw { get; set; }
    }
}