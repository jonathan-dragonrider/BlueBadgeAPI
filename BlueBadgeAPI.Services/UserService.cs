using BlueBadgeAPI.Data;
using BlueBadgeAPI.Data.Migrations;
using BlueBadgeAPI.Models;
using BlueBadgeAPI.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlueBadgeAPI.Web.Models
{
    public class AccountService
    {
        public AccountService()
        {

        }

        public UserDetail GetUserByUserName(string userName)
        {
            using (var ctx = new ApplicationDbContext())
            {
           
                var userEntity =
                    ctx
                        .Users
                        .Single(e => e.UserName == userName);

                // Get list of UserSkills
                var userSkillsEntity = 
                    ctx
                        .UserSkills
                        .Where(e => e.UserId == userEntity.Id);

                var userSkills = new List<string>();

                foreach (var userSkill in userSkillsEntity)
                {
                    userSkills.Add(userSkill.Skill);
                }

                // Find the projects that the user is associated with in Assignments, then return the project name and Id
                var userAssignmentsEntity =
                    ctx
                        .Assignments
                        .Where(e => e.UserId == userEntity.Id && e.ProjectId != 0);

                var userProjects = new List<UserProject>();
                    
                foreach (var assignment in userAssignmentsEntity)
                {
                    var userProject = new UserProject
                    {
                        ProjectId = assignment.ProjectId,
                        ProjectName = ctx.Projects.Single(e => e.ProjectId == assignment.ProjectId).Title
                    };

                    userProjects.Add(userProject);
                }

                return new UserDetail
                {
                    UserName = userEntity.UserName,
                    FullName = userEntity.Name,
                    About = userEntity.About,
                    UserSkills = userSkills,
                    AffiliatedProjects = userProjects
                };
            }
        }


        public IEnumerable<UserSkillDetails> GetUsersBySkill(string skill)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserSkills
                        .Where(e => e.Skill == skill)
                        .Select(
                            e =>
                                new UserSkillDetails
                                {
                                    Skill = e.Skill,
                                    UserName = e.ApplicationUser.UserName,
                                    UserId = e.UserId
                                }
                                ).ToArray();
                return entity;

            }
        }
    }
}