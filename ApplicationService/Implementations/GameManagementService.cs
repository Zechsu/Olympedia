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
    public class GameManagementService
    {
        public List<GameDTO> Get()
        {
            List<GameDTO> gameDTOs = new List<GameDTO>();

            using (UnitOfWork unit = new UnitOfWork())
            {
                foreach (var item in unit.GameRepository.Get())
                {
                    gameDTOs.Add(new GameDTO(item));
                }
            }

            return gameDTOs;
        }

        public bool Save(GameDTO gameDTO)
        {
            Game game = new Game
            {
                Id = gameDTO.Id,
                Title = gameDTO.Title,
                Opening = gameDTO.Opening,
                Closing = gameDTO.Closing,
                HostCity = gameDTO.HostCity,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GameRepository.Insert(game);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public GameDTO GetById(int id)
        {
            GameDTO gameDTO = new GameDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Game game = unitOfWork.GameRepository.GetByID(id);
                if (game != null)
                {
                    gameDTO.Id = game.Id;
                    gameDTO.Title = game.Title;
                    gameDTO.Opening = game.Opening;
                    gameDTO.Closing = game.Closing;
                    gameDTO.HostCity = game.HostCity;
                    //gameDTO.Results = game.Results;
                }
            }
            return gameDTO;
        }

        public bool Update(GameDTO gameDTO)
        {
            Game game = new Game
            {
                Id = gameDTO.Id,
                Opening = gameDTO.Opening,
                Closing = gameDTO.Closing,
                Title = gameDTO.Title,
                HostCity = gameDTO.HostCity,
                UpdatedOn = DateTime.Now,
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GameRepository.Update(game);
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
                    unitOfWork.GameRepository.Delete(id);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<GameDTO> GetByTitle(string title)
        {
            List<GameDTO> gameDTOs = new List<GameDTO>();

            using (UnitOfWork unit = new UnitOfWork())
            {
                foreach (var item in unit.GameRepository.Get().Where(g => g.Title.Contains(title)))
                {
                    gameDTOs.Add(new GameDTO(item));
                }
            }

            return gameDTOs;
        }
    }
}
