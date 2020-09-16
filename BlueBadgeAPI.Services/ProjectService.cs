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

        public ProjectService()
        {
        }

        public bool ProjectCreate(ProjectCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var userEntity =
                    ctx
                        .Users
                        .Single(u => u.UserName == model.UserName);


                var newProject = new Project()
                {
                    UserId = userEntity.Id,
                    Title = model.Title,
                    Description = model.Description
                };

                ctx.Projects.Add(newProject);
                return ctx.SaveChanges() == 1;
            }
        }

        public List<ProjectListItems> GetProjects()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var projectEntity = ctx.Projects;

                var projectListItems = new List<ProjectListItems>();

                foreach (var project in projectEntity)
                {
                    var projectListItem = new ProjectListItems()
                    {
                        ProjectCreatorUserName = project.ProjectCreator.UserName,
                        ProjectId = project.ProjectId,
                        Title = project.Title
                    };

                    projectListItems.Add(projectListItem);
                }

                return projectListItems;

            }
        }

        public ProjectDetails GetProjectById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                // Title, ProjectId, Description, CreatorName, CreatorUserName
                var projectEntity =
                    ctx
                        .Projects
                        .Single(e => e.ProjectId == id);

                // Teams, ProjectMembers
                var assignmentEntity =
                    ctx
                        .Assignments
                        .Where(a => a.ProjectId == id);

                var projectMembers = new List<string>();

                foreach (var assignment in assignmentEntity)
                    projectMembers.Add(ctx.Users.Single(u => u.Id == assignment.UserId).UserName);

                var projectTeamsUnfiltered = new List<string>();

                foreach (var assignment in assignmentEntity)
                    projectTeamsUnfiltered.Add(ctx.Teams.Single(t => t.TeamId == assignment.TeamId).Name);

                List<string> projectTeamsDistinct = projectTeamsUnfiltered.Distinct().ToList();

                var neededSkillsEntity =
                    ctx
                        .NeededSkills
                        .Where(s => s.ProjectId == id);

                List<string> neededSkills = new List<string>();

                foreach (var skill in neededSkillsEntity)
                    neededSkills.Add(skill.Skill);

                return new ProjectDetails
                {
                    Title = projectEntity.Title,
                    ProjectId = projectEntity.ProjectId,
                    Description = projectEntity.Description,
                    CreatorName = projectEntity.ProjectCreator.Name,
                    CreatorUserName = projectEntity.ProjectCreator.UserName,
                    Teams = projectTeamsDistinct,
                    ProjectMembers = projectMembers,
                    SkillsNeeded = neededSkills
                };
            }
        }

        public bool UpdateProject(ProjectEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Projects
                        .Single(e => e.ProjectId == model.ProjectId);
                entity.Title = model.Title;
                entity.Description = model.Description;
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
                        .Single(e => e.ProjectId == id);
                ctx.Projects.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<NeededSkillDetails> GetProjectByNeededSkill(string skill)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .NeededSkills
                        .Where(e => e.Skill == skill)
                        .Select(
                            e =>
                                new NeededSkillDetails
                                {
                                    Skill = e.Skill,
                                    ProjectTitle = e.MotherProject.Title,
                                    ProjectId = e.MotherProject.ProjectId
                                }
                                ).ToArray();
                return entity;
                
            }
        }
    }
}
