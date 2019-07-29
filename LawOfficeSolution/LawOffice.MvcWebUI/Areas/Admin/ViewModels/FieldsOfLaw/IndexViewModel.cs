using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LawOffice.Entities.Concrete;

namespace LawOffice.MvcWebUI.Areas.Admin.ViewModels.FieldsOfLaw
{
    public class IndexViewModel
    {
        public List<Entities.Concrete.FieldsOfLaw> FieldsOfLaw { get; set; }
    }
}