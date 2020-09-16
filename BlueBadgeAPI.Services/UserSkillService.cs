using BlueBadgeAPI.Data;
using BlueBadgeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeAPI.Services
{
    public class UserSkillService
    {
        private readonly string _userId;

        public UserSkillService(string userSkillId)
        {
            _userId = userSkillId;
        }

        public bool UserSkillCreate(UserSkillCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var userEntity =
                    ctx
                        .Users
                        .Single(u => u.UserName == model.UserName);

                var newuserSkill = new UserSkill()
                {
                    UserId = userEntity.Id,
                    Skill = model.Skill
                };

                ctx.UserSkills.Add(newuserSkill);
                return ctx.SaveChanges() == 1;

            }
        }
        public IEnumerable<UserSkillListItems> GetUserSkills()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var userSkillEntity = ctx.UserSkills;

                var userSkillListItems = new List<UserSkillListItems>();

                foreach (var userSkill in userSkillEntity)
                {
                    var userSkillListItem = new UserSkillListItems()
                    {
                        Skill = userSkill.Skill,
                        UserSkillId = userSkill.UserSkillId
                    };

                    userSkillListItems.Add(userSkillListItem);
                }

                return userSkillListItems;

            }
        }

        public UserSkillDetails GetUserSkillById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserSkills
                        .Single(e => e.UserSkillId == id);
                return
                    new UserSkillDetails
                    {
                        UserSkillId = entity.UserSkillId,
                        Skill = entity.Skill,
                        UserName = entity.ApplicationUser.Name,
                        UserId = entity.UserId
                    };
            }
        }

        public bool UpdateUserSkill(UserSkillDetails model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserSkills
                        .Single(e => e.UserSkillId == model.UserSkillId);
                entity.Skill = model.Skill;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUserSkill(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserSkills
                        .Single(e => e.UserSkillId == id);
                ctx.UserSkills.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
