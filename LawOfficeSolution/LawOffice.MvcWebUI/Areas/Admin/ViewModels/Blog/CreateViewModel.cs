﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawOffice.MvcWebUI.Areas.Admin.ViewModels.Blog
{
    public class CreateViewModel
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Text { get; set; }

        public Guid UserId { get; set; }
        public int CategoryId { get; set; }

    }
}