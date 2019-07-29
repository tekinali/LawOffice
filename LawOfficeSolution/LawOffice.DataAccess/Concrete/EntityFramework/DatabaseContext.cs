using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LawOffice.Entities.Concrete;

namespace LawOffice.DataAccess.Concrete.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            Database.SetInitializer(new MyIntializer());
        }


        public DbSet<Answer> Answers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FieldsOfLaw> FieldsOfLaw { get; set; }    
        public DbSet<Question> Questions { get; set; }

        public DbSet<UserArea> UserAreas { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
