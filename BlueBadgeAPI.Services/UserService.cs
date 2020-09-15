using BlueBadgeAPI.Data;
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
                var userDetail = new UserDetail();

                var userEntity = ctx
                                    .Users
                                    .Where(e => e.UserName == userName)
                                    .Select(
                                        e =>
                                            userDetail{
                                                User
                
                                         
                                            )

                

               
                        
                        
                        
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