using LawOffice.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Entities.Concrete
{
    [Table("BlogCategories")]
    public class BlogCategory : EntityBase<int>, IEntity
    {
        public int BlogId { get; set; }
        public int CategoryId { get; set; }

        public Blog Blog { get; set; }
        public Category Category { get; set; }
    }
}
