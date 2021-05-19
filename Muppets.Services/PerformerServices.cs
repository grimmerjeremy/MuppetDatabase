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
    public class PerformerServices
    {
        public bool CreatePerformer(PerformerCreate model)
        {
            var entity = new Performer()
            {
                PerformerName = model.PerformerName,
                PerformerBirthdate = model.PerformerBirthdate,
                PerformerImage = model.PerformerImage
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Performers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PerformerList> GetAllPerformers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Performers.Select(e => new PerformerList()
                {
                    PerformerId = e.PerformerId,
                    PerformerName = e.PerformerName
                });
                return query.ToArray();
            }
        }

        public PerformerDetail GetPerformerById(int performerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Performers
                    .Include(e => e.MuppetsPerformed)
                    .Include(e => e.MoviesPerformedIn)
                    .Single(e => e.PerformerId == performerId);
                var namesOfMuppets = new List<string>();
                foreach (var muppet in entity.MuppetsPerformed)
                {
                    namesOfMuppets.Add(muppet.MuppetName);
                }

                var namesOfMovies = new List<string>();
                foreach (var movie in entity.MoviesPerformedIn)
                {
                    namesOfMovies.Add(movie.MovieName);
                }
                return new PerformerDetail()
                {
                    PerformerId = entity.PerformerId,
                    PerformerName = entity.PerformerName,
                    PerformerBirthdate = entity.PerformerBirthdate,
                    PerformerImage = entity.PerformerImage,
                    MuppetsPerformedByPerformer = namesOfMuppets,
                    MoviesPerformedIn = namesOfMovies
                };
            }
        }

        public PerformerDetail GetPerformerByName(string performerName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Performers.Include(e => e.MuppetsPerformed)
                    .Include(e => e.MoviesPerformedIn)
                    .Single(e => e.PerformerName == performerName);
                var namesOfMuppets = new List<string>();
                foreach (var muppet in entity.MuppetsPerformed)
                {
                    namesOfMuppets.Add(muppet.MuppetName);
                }

                var namesOfMovies = new List<string>();
                foreach (var movie in entity.MoviesPerformedIn)
                {
                    namesOfMovies.Add(movie.MovieName);
                }
                return new PerformerDetail()
                {
                    PerformerId = entity.PerformerId,
                    PerformerName = entity.PerformerName,
                    PerformerBirthdate = entity.PerformerBirthdate,
                    PerformerImage = entity.PerformerImage,
                    MuppetsPerformedByPerformer = namesOfMuppets,
                    MoviesPerformedIn = namesOfMovies
                };
            }
        }

        public bool UpdatePerformer(PerformerUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Performers.Single(e => e.PerformerId == model.PerformerId);
                entity.PerformerName = model.PerformerName;
                entity.PerformerBirthdate = model.PerformerBirthdate;
                entity.PerformerImage = model.PerformerImage;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePerformer(int performerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Performers.Single(e => e.PerformerId == performerId);
                ctx.Performers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
