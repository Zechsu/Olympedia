using ApplicationService.DTOs;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class GameVM
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Opening { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Closing { get; set; }

        public string HostCity { get; set; }
        public ICollection<ResultDTO> Results { get; set; }

        public GameVM() { }

        public GameVM(GameDTO gameDTO)
        {
            Id = gameDTO.Id;
            Title = gameDTO.Title;
            Opening = gameDTO.Opening;
            Closing = gameDTO.Closing;
            HostCity = gameDTO.HostCity;
            Results = gameDTO.Results;
        }

    }
}