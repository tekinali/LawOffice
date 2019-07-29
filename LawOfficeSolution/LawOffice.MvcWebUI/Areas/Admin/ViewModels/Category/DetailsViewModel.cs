using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LawOffice.Entities.Concrete;

namespace LawOffice.MvcWebUI.Areas.Admin.ViewModels.Category
{
    public class DetailsViewModel
    {
        public Entities.Concrete.Category Category { get; set; }
        public List<Entities.Concrete.Blog> Blogs { get; set; }

    }
}