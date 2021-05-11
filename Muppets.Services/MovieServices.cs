using Muppets.Data;
using Muppets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muppets.Services
{
    public class MovieServices
    {
        public bool CreateMovie(MovieCreate model)
        {
            var entity = new Movie()
            {
                MovieName = model.MovieName,
                DateReleased = model.DateReleased
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Movies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MovieList> GetAllMovies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Movies.Select(e => new MovieList()
                {
                    MovieId = e.MovieId,
                    MovieName = e.MovieName,
                    DateReleased = e.DateReleased
                });
                return query.ToArray();
            }
        }

        public bool UpdateMovie(MovieUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Movies.Single(e => e.MovieId == model.MovieId);
                entity.MovieName = model.MovieName;
                entity.DateReleased = model.DateReleased;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMovie(int movieId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Movies.Single(e => e.MovieId == movieId);
                ctx.Movies.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
