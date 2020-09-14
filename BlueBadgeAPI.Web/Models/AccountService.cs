using BlueBadgeAPI.Data;
using BlueBadgeAPI.Models;
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