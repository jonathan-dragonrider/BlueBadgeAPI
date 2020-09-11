using BlueBadgeAPI.Data;
using BlueBadgeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeAPI.Services
{
    public class TeamService
    {
        private readonly Guid _userId;

        public TeamService(Guid userId)
        {
            _userId = userId;
        }

        public bool TeamCreate(TeamCreate model)
        {
            var newTeam = new Team()
            {
                Name = model.Name
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teams.Add(newTeam);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TeamListItems> GetTeams()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var collection = new List<TeamListItems>();
                foreach (var item in ctx.Teams)
                {
                    var newTeamListItems = new TeamListItems
                    {
                        Name = item.Name,
                        TeamId = item.TeamId
                    };
                    collection.Add(newTeamListItems);
                }
                return collection;
            }
        }

        public TeamDetails GetTeamById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == id);
                return
                    new TeamDetails
                    {
                        TeamId = entity.TeamId,
                        Name = entity.Name
                    };
            }
        }

        public bool UpdateTeam(TeamDetails model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == model.TeamId);
                entity.Name = model.Name;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTeam(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == id);
                ctx.Teams.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
