using Muppets.Data;
using Muppets.Models;
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
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Muppet
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MuppetCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }

    }
}