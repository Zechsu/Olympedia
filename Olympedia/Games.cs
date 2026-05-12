using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Olympedia
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Games : IGames
    {
        GameManagementService gamesService = new GameManagementService();
        public List<GameDTO> GetGames()
        {
            return gamesService.Get();
        }
        public string PostGame(GameDTO item)
        {
            if (!gamesService.Save(item))
            {
                return "Game is not saved!";
            }
            else
            {
                return "Game is saved!";
            }
        }

        public GameDTO GetGameById(int id)
        {
            return gamesService.GetById(id);
        }
        public string UpdateGame(GameDTO item)
        {
            if (!gamesService.Update(item))
            {
                return "Game is not updated!";
            }
            else
            {
                return "Game is updated!";
            }
        }
        public string DeleteGame(int id)
        {
            if (!gamesService.Delete(id))
            {
                return "Game is not updated!";
            }
            else
            {
                return "Game is updated!";
            }
        }

        public List<GameDTO> GetGameByTitle(string title)
        {
            return gamesService.GetByTitle(title);
        }
    }
}
