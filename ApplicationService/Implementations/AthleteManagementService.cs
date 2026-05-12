using ApplicationService.DTOs;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class AthleteManagementService
    {
        public List<AthleteDTO> Get()
        {
            List<AthleteDTO> athleteDTOs = new List<AthleteDTO>();

            using (UnitOfWork unit = new UnitOfWork())
            {
                foreach (var item in unit.AthleteRepository.Get())
                {
                    athleteDTOs.Add(new AthleteDTO
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        DOB = item.DOB,
                        Height = item.Height,
                        Weight = item.Weight,
                        Country = item.Country
                    });
                }
            }

            return athleteDTOs;
        }

        public AthleteDTO GetById(int id)
        {
            AthleteDTO athleteDTO = new AthleteDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Athlete athlete = unitOfWork.AthleteRepository.GetByID(id);
                if (athlete != null)
                {
                    athleteDTO.Id = athlete.Id;
                    athleteDTO.FirstName = athlete.FirstName;
                    athleteDTO.LastName = athlete.LastName;
                    athleteDTO.DOB = athlete.DOB;
                    athleteDTO.Height = athlete.Height;
                    athleteDTO.Weight = athlete.Weight;
                    athleteDTO.Country = athlete.Country;
                }
            }
            return athleteDTO;
        }

        public bool Save(AthleteDTO athleteDTO)
        {
            Athlete athlete = new Athlete
            {
                FirstName = athleteDTO.FirstName,
                LastName = athleteDTO.LastName,
                DOB = athleteDTO.DOB,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                Height = athleteDTO.Height,
                Weight = athleteDTO.Weight,
                Country = athleteDTO.Country
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.AthleteRepository.Insert(athlete);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(AthleteDTO athleteDTO)
        {
            Athlete athlete = new Athlete
            {
                Id = athleteDTO.Id,
                FirstName = athleteDTO.FirstName,
                LastName = athleteDTO.LastName,
                DOB = athleteDTO.DOB,
                UpdatedOn = DateTime.Now,
                Height = athleteDTO.Height,
                Weight = athleteDTO.Weight,
                Country = athleteDTO.Country
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.AthleteRepository.Update(athlete);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.AthleteRepository.Delete(id);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<AthleteDTO> GetByName(string name)
        {
            List<AthleteDTO> athleteDTOs = new List<AthleteDTO>();

            using (UnitOfWork unit = new UnitOfWork())
            {
                foreach (var item in unit.AthleteRepository.Get().Where(a => a.FirstName.Contains(name) || a.LastName.Contains(name)))
                {
                    athleteDTOs.Add(new AthleteDTO
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        DOB = item.DOB,
                        Height = item.Height,
                        Weight = item.Weight,
                        Country = item.Country
                    });
                }
            }

            return athleteDTOs;
        }
    }
}
