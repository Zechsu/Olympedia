using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class ResultDTO
    {
        public int Id { get; set; }
        public int AthleteId { get; set; }
        public AthleteDTO Athlete { get; set; }
        public int GameId { get; set; }
        public GameDTO Game { get; set; }
        public int Position { get; set; }
        public string Event { get; set; }
        public string Team { get; set; }

        public ResultDTO() { }
        public ResultDTO(Result item)
        {
            Id = item.Id;
            AthleteId = item.AthleteId;
            Game = new GameDTO { Id = item.Game.Id, Title = item.Game.Title, Closing = item.Game.Closing, Opening = item.Game.Opening, HostCity = item.Game.HostCity};
            GameId = item.GameId;
            Position = item.Position;
            Event = item.Event;
            Team = item.Team;
        }
    }
}
