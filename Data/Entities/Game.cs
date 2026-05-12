using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Game : BaseEntity
    {
        [Required]
        public string HostCity { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime? Opening { get; set; }
        public DateTime? Closing { get; set; }

        public virtual ICollection<Result> Results { get; set; }
    }
}
