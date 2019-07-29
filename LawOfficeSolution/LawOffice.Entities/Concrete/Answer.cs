using LawOffice.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Entities.Concrete
{
    [Table("Answers")]
    public class Answer : EntityBase<int>, IEntity
    {
        public string Text { get; set; }
        public DateTime CreatedOn { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
