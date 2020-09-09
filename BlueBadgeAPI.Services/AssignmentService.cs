using BlueBadgeAPI.Data;
using BlueBadgeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeAPI.Services
{
    public class AssignmentService
    {
        private readonly int _assignmentId;

        public AssignmentService(int assignmentId)
        {
            _assignmentId = assignmentId;
        }

        public bool AssignmentCreate(AssignmentCreate model)
        {
            var newAssignment = new Assignment()
            {
                ProjectId = model.ProjectId,
                UserId = model.UserId,
                TeamId = model.TeamId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Assignments.Add(newAssignment);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AssignmentListItems> GetAssignments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Assignments
                    .Where(e => e.AssignmentId == _assignmentId)
                    .Select(
                        e =>
                        new AssignmentListItems
                        {
                            AssignmentId = e.AssignmentId,
                            UserId = e.UserId,
                            TeamId = e.TeamId,
                            ProjectId = e.ProjectId
                        }
                        );
                return query.ToArray();
            }
        }

        public AssignmentDetails GetAssignmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Assignments
                        .Single(e => e.AssignmentId == _assignmentId);
                return
                    new AssignmentDetails
                    {
                        AssignmentId = entity.AssignmentId,
                        UserName = entity.User.Name,
                        TeamName = entity.Team.Name,
                        ProjectTitle = entity.Project.Title
                    };
            }
        }

        public bool UpdateAssignment(AssignmentListItems model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Assignments
                        .Single(e => e.AssignmentId == model.AssignmentId);
                model.UserId = entity.UserId;
                model.ProjectId = entity.ProjectId;
                model.TeamId = entity.TeamId;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAssignment()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Assignments
                        .Single(e => e.AssignmentId == _assignmentId);
                ctx.Assignments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
