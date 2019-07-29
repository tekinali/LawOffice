using LawOffice.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Entities.Concrete
{
    [Table("AppRoles")]
    public class AppRole : EntityBase<Guid>, IEntity
    {        
        public string Name { get; set; }

        public List<UserRole> UserRoles { get; set; }

        public AppRole()
        {
            UserRoles = new List<UserRole>();
        }


    }
}
