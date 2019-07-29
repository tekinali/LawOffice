using LawOffice.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Entities.Concrete
{
    [Table("Questions")]
    public class Question : EntityBase<int>, IEntity
    {
        public string Subject { get; set; }
        public string Text { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }

        public int FieldsOfLawId { get; set; }
        public FieldsOfLaw FieldsOfLaw { get; set; }

        public List<Answer> Answers { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}
