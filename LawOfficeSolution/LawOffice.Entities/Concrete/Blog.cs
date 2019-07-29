using LawOffice.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Entities.Concrete
{
    [Table("Blogs")]
    public class Blog : EntityBase<int>, IEntity
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Text { get; set; }
        public DateTime CreatedOn { get; set; }

        public List<BlogCategory> BlogCategories { get; set; }

        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public Blog()
        {
            BlogCategories = new List<BlogCategory>();
        }


    }
}
