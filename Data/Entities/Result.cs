using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Result : BaseEntity
    {
        [Required]
        public int AthleteId { get; set; }
        public virtual Athlete Athlete { get; set; }
        [Required]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        public int Position { get; set; }
        public string Event { get; set; }
        public string Team { get; set; }
    }
}
