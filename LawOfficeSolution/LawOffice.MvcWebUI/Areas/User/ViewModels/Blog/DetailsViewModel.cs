using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawOffice.MvcWebUI.Areas.User.ViewModels.Blog
{
    public class DetailsViewModel
    {
        public Entities.Concrete.Blog Blog { get; set; }
        public List<Entities.Concrete.Category> Categories { get; set; }        
    }
}