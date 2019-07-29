using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LawOffice.Entities.Concrete;

namespace LawOffice.MvcWebUI.Areas.Admin.ViewModels.User
{
    public class IndexViewModel
    {
        public List<AppUser> Users { get; set; }
    }
}