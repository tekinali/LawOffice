using LawOffice.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Entities.Concrete
{
    [Table("AppUsers")]
    public class AppUser : EntityBase<Guid>, IEntity
    {
      
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }



        public List<Answer> Answers { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<UserArea> UserAreas { get; set; }
        public List<UserRole> UserRoles { get; set; }

        public AppUser()
        {
            Answers = new List<Answer>();
            Blogs = new List<Blog>();
            UserAreas = new List<UserArea>();
            UserRoles = new List<UserRole>();
        }


    }
}
