using Muppets.Data;
using Muppets.Models;
using Muppets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeMuppetDatabase.Controllers
{
    public class PerformerController : Controller
    {
        
        // GET: Performer
        public ActionResult Index()
        {
            var service = new PerformerServices();
            var model = service.GetAllPerformers();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        //POST
        //Performer/Create/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PerformerCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = new PerformerServices();

            if (service.CreatePerformer(model))
            {
                TempData["SaveResult"] = "Your performer was created.";
                return RedirectToAction("Index");
            }
            
            ModelState.AddModelError("", "Your performer could not be created.");
            return View(model);
        }


        //GET / Details
        public ActionResult Details(int id)
        {
            var service = new PerformerServices();
            var model = service.GetPerformerById(id);
            return View(model);
        }


        //GET / Edit
        public ActionResult Edit(int id)
        {
            var service = new PerformerServices();
            var detail = service.GetPerformerById(id);
            var model =
                new PerformerUpdate
                {
                    PerformerId = detail.PerformerId,
                    PerformerName = detail.PerformerName,
                    PerformerBirthdate = detail.PerformerBirthdate
                };
            return View(model);
        }


        //POST / Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PerformerUpdate model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.PerformerId != id)
            {
                ModelState.AddModelError("", "Id does not match.");
                return View(model);
            }
            var service = new PerformerServices();
            if (service.UpdatePerformer(model))
            {
                TempData["SaveResult"] = "Your performer was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your performer could not be updated.");
            return View(model);
        }

        //GET / Delete
        public ActionResult Delete(int id)
        {
            var service = new PerformerServices();
            var model = service.GetPerformerById(id);
            return View(model);
        }

        //POST / Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePerformer(int id)
        {
            var service = new PerformerServices();
            service.DeletePerformer(id);
            TempData["SaveResult"] = "Your Performer was deleted.";
            return RedirectToAction("Index");
        }



    }
}