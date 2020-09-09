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
        private readonly Guid _userId;

        public ProjectService(Guid userId)
        {
            _userId = userId;
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

        public IEnumerable<ProjectListItems> GetAllProjects()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var collection = new List<ProjectListItems>();
                foreach (var item in ctx.Projects)
                {
                    var newProjectListItems = new ProjectListItems
                    {
                        Title = item.Title,
                        ProjectId = item.ProjectId
                    };

                    collection.Add(newProjectListItems);
                    
                }

                return collection;

            }
        }

        public IEnumerable<ProjectListItems> GetProjects()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Projects
                    .Where(e => e.ProjectCreator.OwnerId == _userId)
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
                        .Single(e => e.ProjectCreator.OwnerId == _userId && e.ProjectId == id);
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

        public bool DeleteProject(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Projects
                        .Single(e => e.ProjectCreator.OwnerId == _userId && e.ProjectId == id);
                ctx.Projects.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
