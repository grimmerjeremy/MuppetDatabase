using Muppets.Data;
using Muppets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeMuppetDatabase.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Movie
        public ActionResult Index()
        {
            List<Movie> movieList = _db.Movies.ToList();
            List<Movie> aplhaList = movieList.OrderBy(movie => movie.MovieName).ToList();
            return View(_db.Movies.ToList());
        }
    }
}