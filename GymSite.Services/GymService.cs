using GymSite.Data;
using GymSite.Models.GymModels;
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
                        GymId = e.GymId,
                        Name = e.Name,
                        MembershipPrice = e.MembershipPrice,
                        Description = e.Description,
                        Address = e.Address,
                        Phone = e.Phone,
                        Website = e.Website,
                        Size = e.Size,
                        CityId = e.CityId
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
                Size = model.Size,
                CityId = model.CityId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Gyms.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public GymDetail GetGymById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Gyms.Single(e => e.GymId == id);
                return new GymDetail
                {
                    GymId = entity.GymId,
                    Name = entity.Name,
                    MembershipPrice = entity.MembershipPrice,
                    Description = entity.Description,
                    Address = entity.Address,
                    Phone = entity.Phone,
                    Website = entity.Website,
                    Size = entity.Size,
                    Reviews = entity.Reviews,
                    CityId = entity.CityId
                };
            }
        }

        public bool UpdateGym(GymEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Gyms.Single(e => e.GymId == model.GymId);

                entity.Name = model.Name;
                entity.MembershipPrice = model.MembershipPrice;
                entity.Description = model.Description;
                entity.Address = model.Address;
                entity.Phone = model.Phone;
                entity.Website = model.Website;
                entity.Size = model.Size;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGym(int gymId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Gyms.Single(e => e.GymId == gymId);

                ctx.Gyms.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
