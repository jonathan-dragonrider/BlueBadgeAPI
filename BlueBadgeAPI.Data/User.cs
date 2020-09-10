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
    public class User
    {
        [Key]
        public int UserId { get; set; }

<<<<<<< HEAD
        public Guid SomethingId { get; set; }

        [Required]
        public string FirstName { get; set; }

=======
        [Required]
        public string FirstName { get; set; }

        public Guid OwnerId { get; set; }

>>>>>>> Alex
        [Required]
        public string LastName { get; set; }

        public string About { get; set; }

<<<<<<< HEAD
=======
        public string Name
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

>>>>>>> Alex
    }
}
