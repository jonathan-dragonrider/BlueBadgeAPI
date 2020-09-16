using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeAPI.Models
{
    public class TeamDetails
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string ProjectName { get; set; }
        public List<string> TeamMembers { get; set; }

    }
}
