using LawOffice.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Entities.Concrete
{
    [Table("FieldsOfLaw")]
    public class FieldsOfLaw : EntityBase<int>, IEntity
    {        
        public string Name { get; set; }

        public List<Question> Questions { get; set; }
        public List<UserArea> UserAreas { get; set; }

        public FieldsOfLaw()
        {
            Questions = new List<Question>();
            UserAreas = new List<UserArea>();
        }

    }


}
