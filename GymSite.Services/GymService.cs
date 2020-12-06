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
                        MonthlyCost = e.MonthlyCost,
                        Description = e.Description,
                        Hours = e.Hours,
                        Address = e.Address,
                        Phone = e.Phone,
                        Website = e.Website,
                        Size = e.Size,
                        Equipment = e.Equipment,
                        LockerRoom = e.LockerRoom,
                        Classes = e.Classes,
                        PersonalTraining = e.PersonalTraining,
                        AdditionalInfo = e.AdditionalInfo,
                        CityId = e.CityId
                    });

                return query.ToArray().OrderBy(o => o.Name).ToArray();
            }
        }

        public bool CreateGym(GymCreate model)
        {
            var entity = new Gym()
            {
                Name = model.Name,
                MonthlyCost = model.MonthlyCost,
                Hours = model.Hours,
                Description = model.Description,
                Address = model.Address,
                Phone = model.Phone,
                Website = model.Website,
                Size = model.Size,
                Equipment = model.Equipment,
                LockerRoom = model.LockerRoom,
                Classes = model.Classes,
                PersonalTraining = model.PersonalTraining,
                AdditionalInfo = model.AdditionalInfo,
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
                    MonthlyCost = entity.MonthlyCost,
                    Hours = entity.Hours,
                    Description = entity.Description,
                    Address = entity.Address,
                    Phone = entity.Phone,
                    Website = entity.Website,
                    Size = entity.Size,
                    Equipment = entity.Equipment,
                    LockerRoom = entity.LockerRoom,
                    Classes = entity.Classes,
                    PersonalTraining = entity.PersonalTraining,
                    AdditionalInfo = entity.AdditionalInfo,
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
                entity.MonthlyCost = model.MonthlyCost;
                entity.Hours = model.Hours;
                entity.Description = model.Description;
                entity.Address = model.Address;
                entity.Phone = model.Phone;
                entity.Website = model.Website;
                entity.Size = model.Size;
                entity.Equipment = model.Equipment;
                entity.LockerRoom = model.LockerRoom;
                entity.Classes = model.Classes;
                entity.PersonalTraining = model.PersonalTraining;
                entity.AdditionalInfo = model.AdditionalInfo;

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
