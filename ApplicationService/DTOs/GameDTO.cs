using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class GameDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string HostCity { get; set; }
        public DateTime? Opening { get; set; }
        public DateTime? Closing { get; set; }
        public ICollection<ResultDTO> Results { get; set; }

        public GameDTO() { }
        public GameDTO(Game item)
        {
            Id = item.Id;
            Title = item.Title;
            HostCity = item.HostCity;
            Opening = item.Opening;
            Closing = item.Closing;
            Results = new List<ResultDTO>();
            if (item.Results != null)
            {
                foreach (var result in item.Results)
                {
                    Results.Add(new ResultDTO(result));
                }
            }
        }
    }
}
