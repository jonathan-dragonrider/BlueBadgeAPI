using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeAPI.Data
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        //add min, max length
        public string Title { get; set; }

        //add min, max length
        public string Description { get; set; }

        //[ForeignKey(nameof(ProjectCreator))]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ProjectCreator { get; set; }

        //public Guid OwnerId { get; set; }
        //public User ProjectCreator { get; set; }


        //public virtual IdentityUserClaim<Guid> ProjectCreator
        //{
        //    get
        //    {
        //       return Guid.Parse(User.Identity.GetUserId());
        //    }
        //}

        //public Guid UserId => Guid.Parse(ApplicationUser.GetUserId());




    }
}
