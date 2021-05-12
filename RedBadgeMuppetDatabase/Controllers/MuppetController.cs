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
    [Authorize]
    public class MuppetController : Controller
    {

        // GET: Muppet
        public ActionResult Index()
        {
            var service = new MuppetServices();
            var model = service.GetAllMuppets();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        //POST / Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MuppetCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new MuppetServices();

            if (service.CreateMuppet(model))
            {
                TempData["SaveResult"] = "Your muppet was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your muppet could not be created.");
            return View(model);
        }

        //GET / Details
        public ActionResult Details(int id)
        {
            var service = new MuppetServices();
            var model = service.GetMuppetById(id);
            return View(model);
        }

        //GET / Edit
        public ActionResult Edit(int id)
        {
            var service = new MuppetServices();
            var detail = service.GetMuppetById(id);
            var model =
                new MuppetUpdate
                {
                    MuppetId = detail.MuppetId,
                    MuppetName = detail.MuppetName,
                    MuppetBirthdate = detail.MuppetBirthdate,
                    Origin = detail.Origin,
                    PerformerId = detail.PerformerId
                };
            return View(model);
        }

        //POST / Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MuppetUpdate model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.MuppetId != id)
            {
                ModelState.AddModelError("", "Id does not match.");
                return View(model);
            }
            var service = new MuppetServices();
            if (service.UpdateMuppet(model))
            {
                TempData["SaveResult"] = "Your muppet was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your muppet could not be updated.");
            return View(model);
        }

        //GET / Delete
        public ActionResult Delete(int id)
        {
            var service = new MuppetServices();
            var model = service.GetMuppetById(id);
            return View(model);
        }

        //POST / Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMuppet(int id)
        {
            var service = new MuppetServices();
            service.DeleteMuppet(id);
            TempData["SaveResult"] = "Your muppet was deleted.";
            return RedirectToAction("Index");
        }

    }
}