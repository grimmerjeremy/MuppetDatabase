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
        // GET: Muppet
        public ActionResult Index()
        {
            var model = new MuppetList[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

    }
}