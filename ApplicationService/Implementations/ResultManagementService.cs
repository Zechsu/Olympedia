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
    public class ResultManagementService
    {
        public List<ResultDTO> Get()
        {
            List<ResultDTO> resultDTOs = new List<ResultDTO>();

            using (UnitOfWork unit = new UnitOfWork())
            {
                foreach (var item in unit.ResultRepository.Get())
                {
                    if(item.Athlete != null)
                    {
                        resultDTOs.Add(new ResultDTO(item));
                    }
                    
                }
            }

            return resultDTOs;
        }

        public ResultDTO GetResultById(int id)
        {
            ResultDTO resultDTO = new ResultDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Result result = unitOfWork.ResultRepository.GetByID(id);
                if (result != null)
                {
                    resultDTO.Id = result.Id;
                    resultDTO.AthleteId = result.AthleteId;
                    resultDTO.GameId = result.GameId;
                    resultDTO.Event = result.Event;
                    resultDTO.Position = result.Position;
                    resultDTO.Team = result.Team;
                }
            }
            return resultDTO;
        }

        public List<ResultDTO> GetResultsForAthleteById(int id)
        {
            List<ResultDTO> resultDTOs = new List<ResultDTO>();

            using (UnitOfWork unit = new UnitOfWork())
            {
                foreach (var item in unit.ResultRepository.Get())
                {
                    if (item.AthleteId == id)
                    {
                        resultDTOs.Add(new ResultDTO(item));
                    }
                }
            }

            return resultDTOs;
        }
        public bool Save(ResultDTO resultDTO)
        {
            Result result = new Result
            {
                Id = resultDTO.Id,
                AthleteId = resultDTO.AthleteId,
                GameId = resultDTO.GameId,
                Team = resultDTO.Team,
                Position = resultDTO.Position,
                Event = resultDTO.Event,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.ResultRepository.Insert(result);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(ResultDTO resultDTO)
        {
            Result result = new Result
            {
                Id = resultDTO.Id,
                AthleteId = resultDTO.AthleteId,
                GameId = resultDTO.GameId,
                Team = resultDTO.Team,
                Position = resultDTO.Position,
                Event = resultDTO.Event,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.ResultRepository.Update(result);
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
                    unitOfWork.ResultRepository.Delete(id);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ResultDTO> GetResultsByEvent(string eventName)
        {
            List<ResultDTO> resultDTOs = new List<ResultDTO>();

            using (UnitOfWork unit = new UnitOfWork())
            {
                foreach (var item in unit.ResultRepository.Get().Where(r => r.Event.Contains(eventName)))
                {
                    if (item.Athlete != null)
                    {
                        resultDTOs.Add(new ResultDTO(item));
                    }

                }
            }

            return resultDTOs;
        }
    }
}
