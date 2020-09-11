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
        private readonly string _userId;

        public AssignmentService(string userId)
        {
            _userId = userId;
        }
        public bool AssignmentCreate(AssignmentCreate model)
        {
            var newAssignment = new Assignment()
            {
                ProjectId = model.ProjectId,
                UserId = _userId,
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
                var collection = new List<AssignmentListItems>();
                foreach (var item in ctx.Assignments)
                {
                    var newAssignmentListItems = new AssignmentListItems
                    {
                        AssignmentId = item.AssignmentId,
                        UserId = _userId,
                        ProjectId = item.ProjectId,
                        TeamId = item.TeamId
                    };
                    collection.Add(newAssignmentListItems);
                }
                return collection;
            }
        }

        public AssignmentDetails GetAssignmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Assignments
                        .Single(e => e.AssignmentId == id);
                return
                    new AssignmentDetails
                    {
                        AssignmentId = entity.AssignmentId,
                        UserId = entity.UserId,
                        ProjectId = entity.ProjectId,
                        TeamId = entity.TeamId
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
                {
                    model.UserId = _userId;
                    model.ProjectId = entity.ProjectId;
                    model.TeamId = entity.TeamId;
                }
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAssignment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Assignments
                        .Single(e => e.AssignmentId == id);
                ctx.Assignments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
