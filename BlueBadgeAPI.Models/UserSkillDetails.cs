using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeAPI.Models
{
    public class UserSkillDetails
    {
        public int UserSkillId { get; set; }
        public string Skill { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
