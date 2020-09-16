using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeAPI.Models.User
{
    public class UserDetail
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string About { get; set; }
        public List<string> UserSkills { get; set; }
        public List<UserProject> AffiliatedProjects { get; set; }

    }
}
