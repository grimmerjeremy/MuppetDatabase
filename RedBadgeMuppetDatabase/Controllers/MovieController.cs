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
    public class MovieController : Controller
    {
        
        // GET: Movie
        public ActionResult Index()
        {
            var service = new MovieServices();
            var model = service.GetAllMovies();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }


        //POST / Create
        //Movie/Create/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new MovieServices();
            
            if (service.CreateMovie(model))
            {
                TempData["SaveResult"] = "Your movie was created.";
                return RedirectToAction("Index");
            }
            
            ModelState.AddModelError("", "Your movie could not be created.");
            return View(model);
        }

        //GET / Details
        public ActionResult Details(int id)
        {
            var service = new MovieServices();
            var model = service.GetMovieById(id);
            return View(model);
        }

        //GET / Edit
        public ActionResult Edit(int id)
        {
            var service = new MovieServices();
            var detail = service.GetMovieById(id);
            var model =
                new MovieUpdate
                {
                    MovieId = detail.MovieId,
                    MovieName = detail.MovieName,
                    DateReleased = detail.DateReleased
                };
            return View(model);
        }

        //POST / Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieUpdate model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.MovieId != id)
            {
                ModelState.AddModelError("", "Id does not match.");
                return View(model);
            }
            var service = new MovieServices();
            if (service.UpdateMovie(model))
            {
                TempData["SaveResult"] = "Your movie was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your movie could not be updated.");
            return View(model);
        }

        //GET / Delete
        public ActionResult Delete(int id)
        {
            var service = new MovieServices();
            var model = service.GetMovieById(id);
            return View(model);
        }

        //POST / Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMovie(int id)
        {
            var service = new MovieServices();
            service.DeleteMovie(id);
            TempData["SaveResult"] = "Your movie was deleted.";
            return RedirectToAction("Index");
        }

    }
}