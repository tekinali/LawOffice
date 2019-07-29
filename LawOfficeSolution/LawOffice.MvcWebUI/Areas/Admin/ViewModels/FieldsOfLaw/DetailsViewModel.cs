using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LawOffice.Entities.Concrete;

namespace LawOffice.MvcWebUI.Areas.Admin.ViewModels.FieldsOfLaw
{
    public class DetailsViewModel
    {
        public Entities.Concrete.FieldsOfLaw FieldsOfLaw { get; set; }
        public List<AppUser> Users { get; set; }
    }
}