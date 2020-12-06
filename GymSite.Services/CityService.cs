using GymSite.Data;
using GymSite.Models.CityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSite.Services
{
    public class CityService
    {
        public IEnumerable<CityListItem> GetCities()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Cities.Select(e => new CityListItem
                {
                    CityId = e.CityId,
                    Name = e.Name,
                    StateId = e.StateId
                });

                return query.ToArray().OrderBy(o => o.Name).ToArray();
            }
        }

        public bool CreateCity(CityCreate model)
        {
            var entity = new City()
            {
                Name = model.Name,
                StateId = model.StateId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cities.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public CityDetail GetCityById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Cities.Single(e => e.CityId == id);
                return new CityDetail
                {
                    CityId = entity.CityId,
                    Name = entity.Name,
                    StateId = entity.StateId,
                    Gyms = entity.Gyms
                };
            }
        }

        public bool UpdateCity(CityEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Cities.Single(e => e.CityId == model.CityId);

                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCity(int cityId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Cities.Single(e => e.CityId == cityId);

                ctx.Cities.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
