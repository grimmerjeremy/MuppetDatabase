using Muppets.Data;
using Muppets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Muppets.Services
{
    public class MovieServices
    {
        public bool CreateMovie(MovieCreate model)
        {
            var entity = new Movie()
            {
                MovieName = model.MovieName,
                DateReleased = model.DateReleased,
                MovieImage = model.MovieImage
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

        public MovieDetail GetMovieById(int movieId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Movies
                    .Include(e => e.MuppetsInMovie)
                    .Include(e => e.PerformersInMovie)
                    .Single(e => e.MovieId == movieId);
                var namesOfMuppets = new List<string>();
                foreach (var muppet in entity.MuppetsInMovie)
                {
                    namesOfMuppets.Add(muppet.MuppetName);
                }
                var namesOfPerformers = new List<string>();
                foreach (var performer in entity.PerformersInMovie)
                {
                    namesOfPerformers.Add(performer.PerformerName);
                }
                return new MovieDetail()
                {
                    MovieId = entity.MovieId,
                    MovieName = entity.MovieName,
                    DateReleased = entity.DateReleased,
                    MovieImage = entity.MovieImage,
                    MuppetsInMovie = namesOfMuppets,
                    PerformersInMovie = namesOfPerformers
                };
            }
        }

        public MovieDetail GetMovieByName(string movieName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Movies
                    .Include(e => e.MuppetsInMovie)
                    .Include(e => e.PerformersInMovie)
                    .Single(e => e.MovieName == movieName);
                var namesOfMuppets = new List<string>();
                foreach (var muppet in entity.MuppetsInMovie)
                {
                    namesOfMuppets.Add(muppet.MuppetName);
                }
                var namesOfPerformers = new List<string>();
                foreach (var performer in entity.PerformersInMovie)
                {
                    namesOfPerformers.Add(performer.PerformerName);
                }
                return new MovieDetail()
                {
                    MovieId = entity.MovieId,
                    MovieName = entity.MovieName,
                    DateReleased = entity.DateReleased,
                    MovieImage = entity.MovieImage,
                    MuppetsInMovie = namesOfMuppets,
                    PerformersInMovie = namesOfPerformers
                };
            }
        }

        public bool UpdateMovie(MovieUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Movies.Single(e => e.MovieId == model.MovieId);
                entity.MovieName = model.MovieName;
                entity.DateReleased = model.DateReleased;
                entity.MovieImage = model.MovieImage;
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
