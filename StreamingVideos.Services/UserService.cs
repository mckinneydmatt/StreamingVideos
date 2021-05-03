using StreamingVideos.Data;
using StreamingVideos.Data.Entities;
using StreamingVideos.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingVideos.Services
{
    public class UserService
    {
        private readonly Guid _userId;
        public UserService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    UserId = _userId,
                    Name = model.Name,
                    UserEmail = model.UserEmail,
                    UserAge = model.UserAge,
                    MemberSince = DateTimeOffset.Now

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Users
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new UserListItem
                                {
                                    UserId = e.UserId,
                                    Name = e.Name,
                                    UserEmail = e.UserEmail,
                                    UserAge = e.UserAge,
                                    MemberSince = e.MemberSince
                                }
                        );
                return query.ToArray();
            }
        }



    }
}
