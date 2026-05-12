using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class AthleteDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Country { get; set; }

        public AthleteDTO() { }
        public AthleteDTO(Athlete item)
        {
            Id = item.Id;
            FirstName = item.FirstName;
            LastName = item.LastName;
            DOB = item.DOB;
            Height = item.Height;
            Weight = item.Weight;
            Country = item.Country;
        }
    }
}
