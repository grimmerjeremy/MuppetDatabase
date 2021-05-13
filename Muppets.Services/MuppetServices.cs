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
    public class MuppetServices
    {
        public bool CreateMuppet(MuppetCreate model)
        {
            var entity = new Muppet()
            {
                MuppetName = model.MuppetName,
                Origin = model.Origin,
                PerformerId = model.PerformerId,
                MuppetBirthdate = model.MuppetBirthdate,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Muppets.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MuppetList> GetAllMuppets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Muppets.Select(e => new MuppetList()
                {
                    MuppetId = e.MuppetId,
                    MuppetName = e.MuppetName,
                    MuppetBirthdate = e.MuppetBirthdate
                });
                return query.ToArray();
            }
        }

        public MuppetDetail GetMuppetById(int muppetId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Muppets
                    .Include(e => e.MoviesAppearedIn)
                    .Include(e => e.Performer)
                    .Single(e => e.MuppetId == muppetId);

                var namesOfMovies = new List<string>();
                foreach (var movie in entity.MoviesAppearedIn)
                {
                    namesOfMovies.Add(movie.MovieName);
                }

                return new MuppetDetail()
                {
                    MuppetId = entity.MuppetId,
                    MuppetName = entity.MuppetName,
                    MuppetBirthdate = entity.MuppetBirthdate,
                    Origin = entity.Origin,
                    PerformerId = entity.PerformerId,
                    PerformerName = entity.Performer.PerformerName,
                    MoviesAppearedIn = namesOfMovies
                };
            }
        }

        public MuppetDetail GetMuppetByName(string muppetName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Muppets
                    .Include(e => e.MoviesAppearedIn)
                    .Include(e => e.Performer.PerformerName)
                    .Single(e => e.MuppetName == muppetName);

                var namesOfMovies = new List<string>();
                foreach (var movie in entity.MoviesAppearedIn)
                {
                    namesOfMovies.Add(movie.MovieName);
                }

                return new MuppetDetail()
                {
                    MuppetId = entity.MuppetId,
                    MuppetName = entity.MuppetName,
                    MuppetBirthdate = entity.MuppetBirthdate,
                    Origin = entity.Origin,
                    PerformerId = entity.PerformerId,
                    PerformerName = entity.Performer.PerformerName,
                    MoviesAppearedIn = namesOfMovies
                };
            }
        }

        public bool UpdateMuppet(MuppetUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Muppets.Single(e => e.MuppetId == model.MuppetId);
                entity.MuppetName = model.MuppetName;
                entity.MuppetBirthdate = model.MuppetBirthdate;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMuppet(int muppetId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Muppets.Single(e => e.MuppetId == muppetId);
                ctx.Muppets.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
