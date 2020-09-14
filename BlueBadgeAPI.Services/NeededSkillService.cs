using BlueBadgeAPI.Data;
using BlueBadgeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeAPI.Services
{
    public class NeededSkillService
    {
        public NeededSkillService()
        {
        }
        public bool NeededSkillCreate(NeededSkillCreate model)
        {
            var newNeededSkill = new NeededSkill()
            {
                Skill = model.Skill,
                ProjectId = model.ProjectId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.NeededSkills.Add(newNeededSkill);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<NeededSkillListItems> GetNeededSkill()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var collection = new List<NeededSkillListItems>();
                foreach (var item in ctx.NeededSkills)
                {
                    var newNeededSkillListItems = new NeededSkillListItems
                    {
                        NeededSkillId = item.NeededSkillId,
                        Skill = item.Skill,
                        ProjectTitle = item.MotherProject.Title
                    };
                    collection.Add(newNeededSkillListItems);
                }
                return collection;
            }
        }

        public NeededSkillDetails GetNeededSkillById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .NeededSkills
                        .Single(e => e.NeededSkillId == id);
                return
                    new NeededSkillDetails
                    {
                        Skill = entity.Skill,
                        ProjectId = entity.ProjectId,
                        ProjectTitle = entity.MotherProject.Title
                    };
            }
        }

        public bool UpdateNeededSkill(NeededSkillEdit model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .NeededSkills
                        .Single(e => e.NeededSkillId == model.NeededSkillId);
                {
                    entity.Skill = model.Skill;
                }
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNeededSkill(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .NeededSkills
                        .Single(e => e.NeededSkillId == id);
                ctx.NeededSkills.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
