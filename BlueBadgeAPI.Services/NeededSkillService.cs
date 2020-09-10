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
        private readonly int _neededSkillId;

        public NeededSkillService(int neededSkillId)
        {
            _neededSkillId = neededSkillId;
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
        public IEnumerable<NeededSkillListItems> GetNeededSkills()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .NeededSkills
                    .Where(e => e.NeededSkillId == _neededSkillId)
                    .Select(
                        e =>
                        new NeededSkillListItems
                        {
                            Skill = e.Skill,
                            NeededSkillId = e.NeededSkillId
                        }
                        );
                return query.ToArray();
            }
        }

        public NeededSkillDetails GetNeededSkillById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .NeededSkills
                        .Single(e => e.NeededSkillId == _neededSkillId);
                return
                    new NeededSkillDetails
                    {
                        NeededSkillId = entity.NeededSkillId,
                        Skill = entity.Skill,
                        ProjectTitle = entity.MotherProject.Title
                    };
            }
        }

        public bool UpdateNeededSkill(NeededSkillDetails model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .NeededSkills
                        .Single(e => e.NeededSkillId == model.NeededSkillId);
                model.Skill = entity.Skill;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNeededSkill(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .NeededSkills
                        .Single(e => e.NeededSkillId == _neededSkillId);
                ctx.NeededSkills.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
