using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ApplicationService.DTOs;

namespace Olympedia
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAthletes
    { 
        [OperationContract]
        List<AthleteDTO> GetAthletes();

        [OperationContract]
        AthleteDTO GetAthleteById(int id);

        [OperationContract]
        string PostAthlete(AthleteDTO athleteDTO);

        [OperationContract]
        string DeleteAthlete(int id);

        [OperationContract]
        string UpdateAthlete(AthleteDTO athleteDTO);
        [OperationContract]
        List<AthleteDTO> GetAthletesByName(string name);
    }
}
