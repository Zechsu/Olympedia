using ApplicationService.DTOs;
using MVC.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            List<GameVM> gameVMs = new List<GameVM>();

            using (GamesService.GamesClient service = new GamesService.GamesClient())
            {
                foreach (var item in service.GetGames())
                {
                    gameVMs.Add(new GameVM(item));
                }
            }

            return View(gameVMs);
        }
        [HttpGet]
        public ActionResult Index(string gameTitle, int? itemsPerPage, int? page)
        {
            List<GameVM> gameVMs = new List<GameVM>();

            if (string.IsNullOrEmpty(gameTitle))
            {
                gameTitle = "";
            }

            ViewBag.GameTitle = gameTitle;

            using (GamesService.GamesClient service = new GamesService.GamesClient())
            {
                foreach (var item in service.GetGameByTitle(gameTitle))
                {
                    gameVMs.Add(new GameVM(item));
                }
            }

            int pageSize = itemsPerPage ?? 3;
            int pageNumber = page ?? 1;

            return View(gameVMs.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameVM gameVM)
        {
            try
            {
                using (GamesService.GamesClient service = new GamesService.GamesClient())
                {
                    GameDTO gameDTO = new GameDTO
                    {
                        Id = gameVM.Id,
                        Title = gameVM.Title,
                        Opening = gameVM.Opening,
                        Closing = gameVM.Closing,
                        Results = gameVM.Results,
                        HostCity = gameVM.HostCity
                    };
                    service.PostGame(gameDTO);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            using (GamesService.GamesClient service = new GamesService.GamesClient())
            {
                service.DeleteGame(id);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            GameVM gameVM = new GameVM();
            using (GamesService.GamesClient service = new GamesService.GamesClient())
            {
                var gameDTO = service.GetGameById(id);
                gameVM = new GameVM(gameDTO);
            }

            return View(gameVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GameVM gameVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (GamesService.GamesClient service = new GamesService.GamesClient())
                    {
                        GameDTO gameDTO = new GameDTO
                        {
                            Id = gameVM.Id,
                            Opening = gameVM.Opening,
                            Closing = gameVM.Closing,
                            Title = gameVM.Title,
                            HostCity = gameVM.HostCity,
                            Results = gameVM.Results
                        };
                        service.UpdateGame(gameDTO);
                    }

                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}