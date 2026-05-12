using ApplicationService.DTOs;
using MVC.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace MVC.Controllers
{
    public class AthleteController : Controller
    {
        public ActionResult Index()
        {
            List<AthleteVM> athleteVMs = new List<AthleteVM>();

            using (AthletesService.AthletesClient service = new AthletesService.AthletesClient())
            {
                foreach (var item in service.GetAthletes())
                {
                    athleteVMs.Add(new AthleteVM(item));
                }
            }

            return View(athleteVMs);
        }

        [HttpGet]
        public ActionResult Index(string athleteName, int? itemsPerPage, int? page)
        {
            List<AthleteVM> athleteVMs = new List<AthleteVM>();

            if (String.IsNullOrEmpty(athleteName))
            {
                athleteName = "";
            }

            ViewBag.AthleteName = athleteName;

            using (AthletesService.AthletesClient service = new AthletesService.AthletesClient())
            {

                foreach (var item in service.GetAthletesByName(athleteName))
                {
                    athleteVMs.Add(new AthleteVM(item));
                }
            }

            int pageSize = itemsPerPage ?? 3;
            int pageNumber = page ?? 1;

            return View(athleteVMs.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int id)
        {
            AthleteVM athleteVM = new AthleteVM();
            ViewBag.AthleteId = id;
            using (AthletesService.AthletesClient service = new AthletesService.AthletesClient())
            {
                var athleteDTO = service.GetAthleteById(id);
                athleteVM = new AthleteVM(athleteDTO);
            }

            return View(athleteVM);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AthleteVM athleteVM)
        {
            try
            {
                using (AthletesService.AthletesClient service = new AthletesService.AthletesClient())
                {
                    AthleteDTO athleteDTO = new AthleteDTO
                    {
                        FirstName = athleteVM.FirstName,
                        LastName = athleteVM.LastName,
                        DOB = athleteVM.DOB,
                        Height = athleteVM.Height,
                        Weight = athleteVM.Weight,
                        Country = athleteVM.Country
                    };
                    service.PostAthlete(athleteDTO);
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
            using (AthletesService.AthletesClient service = new AthletesService.AthletesClient())
            {
                service.DeleteAthlete(id);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            AthleteVM athleteVM = new AthleteVM();
            using (AthletesService.AthletesClient service = new AthletesService.AthletesClient())
            {
                var athleteDto = service.GetAthleteById(id);
                athleteVM = new AthleteVM(athleteDto);
            }

            return View(athleteVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AthleteVM athleteVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (AthletesService.AthletesClient service = new AthletesService.AthletesClient())
                    {
                        AthleteDTO athleteDTO = new AthleteDTO
                        {
                            Id = athleteVM.Id,
                            FirstName = athleteVM.FirstName,
                            LastName = athleteVM.LastName,
                            DOB = athleteVM.DOB,
                            Height = athleteVM.Height,
                            Weight = athleteVM.Weight,
                            Country = athleteVM.Country
                        };
                        service.UpdateAthlete(athleteDTO);
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

        public PartialViewResult AthleteResultsPartial(int id)
        {
            List<ResultVM> resultVMs = new List<ResultVM>();

            using (ResultsService.ResultsClient service = new ResultsService.ResultsClient())
            {
                foreach (var item in service.GetResultsForAthleteById(id))
                {
                    resultVMs.Add(new ResultVM(item));
                }
            }
            return PartialView("_AthleteResults", resultVMs);
        }
    }
}