using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeAPI.Models
{
    public class ProjectDetails
    {
        public string Title { get; set; } // from ctx.Projects
        public int ProjectId { get; set; } // from ctx.Projects
        public string Description { get; set; } // from ctx.Projects
        public string CreatorName { get; set; } // from ctx.User and ctx.Assignments
        public string CreatorUserName { get; set; } // from ctx.User and ctx.Assignments
        public List<string> Teams { get; set; } // from ctx.Teams and ctx.Assignments
        public List<string> ProjectMembers { get; set; }
        public List<string> SkillsNeeded { get; set; } // from ctx.NeededSkills
        //public List<string> SkillsFulfilled { get; set; } // from ctx.NeededSkills

    }
}
