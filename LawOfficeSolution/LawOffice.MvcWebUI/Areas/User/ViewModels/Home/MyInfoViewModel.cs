using LawOffice.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawOffice.MvcWebUI.Areas.User.ViewModels.Home
{
    public class MyInfoViewModel
    {
        public AppUser User { get; set; }

        public List<AppRole> Roles { get; set; }  
        public List<FieldsOfLaw> FieldsOfLaw { get; set; }
    }
}