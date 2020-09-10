using BlueBadgeAPI.Data;
using BlueBadgeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeAPI.Services
{
    public class UserService
    {
        private readonly Guid _userId;
       
        public UserService(Guid userId)
        {
            _userId = userId;
        }

        public bool UserCreate(UserCreate model)
        {
            var newUser = new User()
            {
                OwnerId = _userId,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(newUser);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<UserListItems> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Users
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new UserListItems
                        {
                            Name = e.Name,
                            UserId = e.UserId
                        }
                        );
                return query.ToArray();
            }
        }

        public UserDetails GetUserById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.OwnerId == _userId);
                return
                    new UserDetails
                    {
                        OwnerId = entity.OwnerId,
                        UserId = entity.UserId,
                        Name = entity.Name,
                        About = entity.About
                    };
            }
        }

        public bool UpdateUser(UserDetails model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.OwnerId == model.OwnerId);

                model.OwnerId = entity.OwnerId;
                model.UserId = entity.UserId;
                model.Name = entity.Name;
                model.About = entity.About;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUser(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.OwnerId == _userId);

                ctx.Users.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
