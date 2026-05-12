using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class ResultVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int AthleteId { get; set; }
        public AthleteDTO Athlete { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int GameId { get; set; }
        public GameDTO Game { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int Position { get; set; }
        public string Event { get; set; }
        public string Team { get; set; }

        public ResultVM() { }
        public ResultVM(ResultDTO item) {
            Id = item.Id;
            Athlete = item.Athlete;
            AthleteId = item.AthleteId;
            Game = item.Game;
            GameId = item.GameId;
            Position = item.Position;
            Event = item.Event;
            Team = item.Team;
        }
    }
}