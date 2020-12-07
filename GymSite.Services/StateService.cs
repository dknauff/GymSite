using GymSite.Data;
using GymSite.Models.StateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSite.Services
{
    public class StateService
    {
        public IEnumerable<StateListItem> GetStates()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.States.Select(e => new StateListItem
                {
                    StateId = e.StateId,
                    Name = e.Name,
                    Abbreviation = e.Abbreviation
                });

                return query.ToArray().OrderBy(o => o.Name).ToArray();
            }
        }

        public bool CreateState(StateCreate model)
        {
            var entity = new State()
            {
                StateId = model.StateId,
                Name = model.Name,
                Abbreviation = model.Abbreviation
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.States.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public StateDetail GetStateById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.States.Single(e => e.StateId == id);
                return new StateDetail
                {
                    StateId = entity.StateId,
                    Name = entity.Name,
                    Abbreviation = entity.Abbreviation,
                    Cities = entity.Cities
                };
            }
        }

        public bool UpdateState(StateEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.States.Single(e => e.StateId == model.StateId);

                entity.Name = model.Name;
                entity.Abbreviation = model.Abbreviation;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteState(int stateId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.States.Single(e => e.StateId == stateId);

                ctx.States.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
