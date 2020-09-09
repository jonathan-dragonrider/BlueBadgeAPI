using BlueBadgeAPI.Data;
using BlueBadgeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeAPI.Services
{
    public class ProjectService
    {
        private readonly int _projectId;

        public ProjectService(int projectId)
        {
            _projectId = projectId;
        }

        public bool ProjectCreate(ProjectCreate model)
        {
            var newProject = new Project()
            {
                UserId = model.UserId,
                Title = model.Title,
                Description = model.Description
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Projects.Add(newProject);
                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<ProjectListItems> GetProjects()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Projects
                    .Where(e => e.ProjectId == _projectId)
                    .Select(
                        e =>
                        new ProjectListItems
                        {
                            Title = e.Title,
                            ProjectId = e.ProjectId
                        }
                        );
                return query.ToArray();
            }
        }

        public ProjectDetails GetProjectById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Projects
                        .Single(e => e.ProjectId == _projectId);
                return
                    new ProjectDetails
                    {
                        ProjectId = entity.ProjectId,
                        Title = entity.Title,
                        Description = entity.Description,
                        Creator = entity.ProjectCreator.Name
                    };
            }
        }

        public bool UpdateProject(ProjectDetails model)
        {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Projects
                            .Single(e => e.ProjectId == model.ProjectId);
                    model.Title = entity.Title;
                    model.Description = entity.Description;
                    return ctx.SaveChanges() == 1;
                }
        }

        public bool DeleteProject()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Projects
                        .Single(e => e.ProjectId == _projectId);
                ctx.Projects.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        public bool AddMemberToProject(AssignmentCreate model)
        {
            Assignment newAssignment = new Assignment()
            {
                ProjectId = model.ProjectId,
                UserId = model.UserId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Assignments.Add(newAssignment);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool RemoveMemberFromProject(int userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Assignments  
                        .Single(e => e.ProjectId == _projectId && e.UserId == userId);
                ctx.Assignments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
