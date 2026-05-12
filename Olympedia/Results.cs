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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Results" in both code and config file together.
    public class Results : IResults
    {
        private ResultManagementService resultService = new ResultManagementService();
        public List<ResultDTO> GetResults()
        {
            return resultService.Get();
        }
        public List<ResultDTO> Get()
        {
            return resultService.Get();
        }
        public List<ResultDTO> GetResultsForAthleteById(int id) {
            return resultService.GetResultsForAthleteById(id);
        }
        public ResultDTO GetResultsById(int id) {
            return resultService.GetResultById(id);
        }
        public string UpdateResult(ResultDTO item)
        {
            if (!resultService.Update(item))
            {
                return "Result is not updated!";
            }
            else
            {
                return "Result is updated!";
            }
        }
        public string DeleteResult(int id)
        {
            if (!resultService.Delete(id))
            {
                return "Result is not deleted!";
            }
            else
            {
                return "Result is deleted!";
            }
        }
        public string PostResult(ResultDTO item)
        {
            if (!resultService.Save(item))
            {
                return "Result is not saved!";
            }
            else
            {
                return "Result is saved!";
            }
        }

        public List<ResultDTO> GetResultsByEventName(string eventName)
        {
            return resultService.GetResultsByEvent(eventName);
        }
    }
}
