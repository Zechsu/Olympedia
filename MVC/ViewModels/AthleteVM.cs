using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class AthleteVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Born")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }
        [Range(0, int.MaxValue)]
        public int Height { get; set; }
        [Range(0, int.MaxValue)]
        public int Weight { get; set; }
        public string Country { get; set; }

        public int PageCount { get; set; } = 0;
        public int PageNumber { get; set; } = 0;

        public AthleteVM() { }
        public AthleteVM(AthleteDTO dto)
        {
            Id = dto.Id;
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            DOB = dto.DOB;
            Height = dto.Height;
            Weight = dto.Weight;
            Country = dto.Country;
        }
    }
}