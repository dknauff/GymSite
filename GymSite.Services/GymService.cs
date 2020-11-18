using GymSite.Data;
using GymSite.Models.Gym;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSite.Services
{
    public class GymService
    {
        public IEnumerable<GymListItem> GetGyms()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Gyms.Select(e => new GymListItem
                    {
                        Name = e.Name,
                        MembershipPrice = e.MembershipPrice,
                        Description = e.Description,
                        Address = e.Address,
                        Phone = e.Phone,
                        Website = e.Website,
                        Size = e.Size
                    });

                return query.ToArray();
            }
        }

        public bool CreateGym(GymCreate model)
        {
            var entity = new Gym()
            {
                Name = model.Name,
                MembershipPrice = model.MembershipPrice,
                Description = model.Description,
                Address = model.Address,
                Phone = model.Phone,
                Website = model.Website,
                Size = model.Size
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Gyms.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
