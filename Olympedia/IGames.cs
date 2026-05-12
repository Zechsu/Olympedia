using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Olympedia
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IGames
    {
        [OperationContract]
        List<GameDTO> GetGames();
        [OperationContract]
        string PostGame(GameDTO item);
        [OperationContract]
        GameDTO GetGameById(int id);
        [OperationContract]
        string UpdateGame(GameDTO item);
        [OperationContract]
        string DeleteGame(int id);
        [OperationContract]
        List<GameDTO> GetGameByTitle(string title);
    }
}
