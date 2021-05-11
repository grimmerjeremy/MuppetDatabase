using Muppets.Data;
using Muppets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muppets.Services
{
    public class PerformerServices
    {
        public bool CreatePerformer(PerformerCreate model)
        {
            var entity = new Performer()
            {
                PerformerName = model.PerformerName,
                PerformerBirthdate = model.PerformerBirthdate
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

        public bool UpdatePerformer(PerformerUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Performers.Single(e => e.PerformerId == model.PerformerId);
                entity.PerformerName = model.PerformerName;
                entity.PerformerBirthdate = model.PerformerBirthdate;
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
