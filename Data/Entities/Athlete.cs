using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Athlete : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
