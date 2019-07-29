using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LawOffice.Entities.Concrete;

namespace LawOffice.MvcWebUI.Areas.Admin.ViewModels.Blog
{
    public class DetailsViewModel
    {
        public Entities.Concrete.Blog Blog { get; set; }
        public List<Entities.Concrete.Category> Categories { get; set; }
        public AppUser User { get; set; }
    }
}