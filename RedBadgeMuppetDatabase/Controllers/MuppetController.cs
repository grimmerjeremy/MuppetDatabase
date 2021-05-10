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
            List<Muppet> muppetList = _db.Muppets.ToList();
            List<Muppet> aplhaList = muppetList.OrderBy(muppet => muppet.MuppetName).ToList();
            return View(_db.Muppets.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

    }
}