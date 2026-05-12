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
    public class ResultController : Controller
    {
        // GET: Result
        public ActionResult Index()
        {
            List<ResultVM> resultVMs = new List<ResultVM>();

            using (ResultsService.ResultsClient service = new ResultsService.ResultsClient())
            {
                foreach (var item in service.GetResults())
                {
                    resultVMs.Add(new ResultVM(item));
                }
            }

            return View(resultVMs);
        }

        [HttpGet]
        public ActionResult Index(string eventName, int? itemsPerPage, int? page)
        {
            List<ResultVM> resultVMs = new List<ResultVM>();

            if (String.IsNullOrEmpty(eventName))
            {
                eventName = "";
            }

            ViewBag.EventName = eventName;

            using (ResultsService.ResultsClient service = new ResultsService.ResultsClient())
            {
                foreach (var item in service.GetResultsByEventName(eventName))
                {
                    resultVMs.Add(new ResultVM(item));
                }
            }

            int pageSize = itemsPerPage ?? 3;
            int pageNumber = page ?? 1;

            return View(resultVMs.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Delete(int id)
        {
            using (ResultsService.ResultsClient service = new ResultsService.ResultsClient())
            {
                service.DeleteResult(id);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id) {
            ResultVM resultVM = new ResultVM();
            using (ResultsService.ResultsClient service = new ResultsService.ResultsClient())
            {
                var resultDTO = service.GetResultsById(id);
                resultVM = new ResultVM(resultDTO);
            }

            return View(resultVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResultVM resultVM)
        {
            try
            {
                using (ResultsService.ResultsClient service = new ResultsService.ResultsClient())
                {
                    ResultDTO resultDTO = new ResultDTO
                    {
                        Id = resultVM.Id,
                        AthleteId = resultVM.AthleteId,
                        Athlete = resultVM.Athlete,
                        GameId = resultVM.GameId,
                        Game = resultVM.Game,
                        Event = resultVM.Event,
                        Team = resultVM.Team,
                        Position = resultVM.Position
                    };
                    service.PostResult(resultDTO);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ResultVM resultVM)
        {
            try
            {
                using (ResultsService.ResultsClient service = new ResultsService.ResultsClient())
                {
                    ResultDTO resultDTO = new ResultDTO
                    {
                        Id = resultVM.Id,
                        AthleteId = resultVM.AthleteId,
                        Athlete = resultVM.Athlete,
                        GameId = resultVM.GameId,
                        Game = resultVM.Game,
                        Event = resultVM.Event,
                        Team = resultVM.Team,
                        Position = resultVM.Position
                    };
                    service.UpdateResult(resultDTO);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}