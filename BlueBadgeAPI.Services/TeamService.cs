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
        private readonly int _teamId;

        public TeamService(int teamId)
        {
            _teamId = teamId;
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
                var query =
                    ctx
                    .Teams
                    .Where(e => e.TeamId == _teamId)
                    .Select(
                        e =>
                        new TeamListItems
                        {
                            Name = e.Name,
                            TeamId = e.TeamId
                        }
                        );
                return query.ToArray();
            }
        }

        public TeamDetails GetTeamById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == _teamId);
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
                model.Name = entity.Name;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTeam(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == _teamId);
                ctx.Teams.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
