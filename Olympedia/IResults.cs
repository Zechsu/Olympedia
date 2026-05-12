using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Olympedia
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IResults" in both code and config file together.
    [ServiceContract]
    public interface IResults
    {
        [OperationContract]
        List<ResultDTO> Get();
        [OperationContract]
        List<ResultDTO> GetResults();
        [OperationContract]
        List<ResultDTO> GetResultsForAthleteById(int id);
        [OperationContract]
        ResultDTO GetResultsById(int id);
        [OperationContract]
        string UpdateResult(ResultDTO item);
        [OperationContract]
        string DeleteResult(int id);
        [OperationContract]
        string PostResult(ResultDTO item);
        [OperationContract]
        List<ResultDTO> GetResultsByEventName(string eventName);
    }
}
