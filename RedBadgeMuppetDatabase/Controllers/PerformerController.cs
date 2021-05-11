using Muppets.Data;
using Muppets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeMuppetDatabase.Controllers
{
    public class PerformerController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Performer
        public ActionResult Index()
        {
            List<Performer> performerList = _db.Performers.ToList();
            List<Performer> aplhaList = performerList.OrderBy(performer => performer.PerformerName).ToList();
            return View(_db.Performers.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

    }
}