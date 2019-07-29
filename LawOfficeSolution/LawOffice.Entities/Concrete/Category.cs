using LawOffice.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Entities.Concrete
{
    [Table("Categories")]
    public class Category : EntityBase<int>, IEntity
    {
        public string Name { get; set; }

        public List<BlogCategory> BlogCategories { get; set; }

        public Category()
        {
            BlogCategories = new List<BlogCategory>();
        }
    }
}
