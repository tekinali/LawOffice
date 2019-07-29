using LawOffice.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Entities.Concrete
{
    public class UserArea : EntityBase<int>, IEntity
    {
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int FieldsOfLawId { get; set; }
        public FieldsOfLaw FieldsOfLaw { get; set; }


    }
}
