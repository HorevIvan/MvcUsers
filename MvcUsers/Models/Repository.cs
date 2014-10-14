using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUsers.Models
{
    public static class Repository
    {
        public static User CreateUser(String name, String password)
        {
            var user = new User
            {
                Name = name,
                PasswordHashCode1 = User.GetPasswordHashCode1(password),
                PasswordHashCode2 = User.GetPasswordHashCode2(password),
            };

            using (var db = new DatabaseEntities())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            return user;
        }
    }
}