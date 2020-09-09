using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeAPI.Data
{
    public class UserDetails
    {
        public Guid OwnerId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
    }
}
