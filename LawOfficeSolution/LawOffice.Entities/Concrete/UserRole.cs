using LawOffice.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Entities.Concrete
{
    public class UserRole : EntityBase<Guid>, IEntity
    {       
        public Guid AppRoleId { get; set; }
        public AppRole AppRole { get; set; }

        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
