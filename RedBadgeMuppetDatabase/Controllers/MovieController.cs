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

        //GET / Details

        //GET / Edit

        //POST / Edit

        //GET / Delete

        //POST / Delete

    }
}