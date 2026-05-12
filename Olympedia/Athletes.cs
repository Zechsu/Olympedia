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
    public class Athletes : IAthletes
    {
        private AthleteManagementService athleteService = new AthleteManagementService();
        public List<AthleteDTO> GetAthletes()
        {
            return athleteService.Get();
        }
        public AthleteDTO GetAthleteById(int id)
        {
            return athleteService.GetById(id);
        }

        public string PostAthlete(AthleteDTO athleteDTO)
        {
            if (!athleteService.Save(athleteDTO))
            {
                return "Athlete is not saved!";
            }
            else
            {
                return "Athlete is saved!";
            }
        }

        public string UpdateAthlete(AthleteDTO athleteDTO)
        {
            if (!athleteService.Update(athleteDTO))
            {
                return "Athlete is not updated!";
            }
            else
            {
                return "Athlete is updated!";
            }
        }
        public string DeleteAthlete(int id)
        {
            if (!athleteService.Delete(id))
            {
                return "Athlete is not deleted!";
            }
            else
            {
                return "Athlete is deleted!";
            }
        }

        public List<AthleteDTO> GetAthletesByName(string name)
        {
            return athleteService.GetByName(name);
        }
    }
}
