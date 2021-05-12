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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }


        //GET / Details

        //GET / Edit

        //POST / Edit

        //GET / Delete

        //POST / Delete
    }
}