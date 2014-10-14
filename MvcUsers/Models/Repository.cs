using MvcUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUsers
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

        public static IEnumerable<User> GetUsers()
        {
            using (var db = new DatabaseEntities())
            {
                return db.Users.ToList();
            }
        }

        public static User GetUser(Int32 number)
        {
            using (var db = new DatabaseEntities())
            {
                return db.Users.SingleOrDefault(user => user.Number == number);
            }
        }

        internal static User GetUser(String name, String password)
        {
            using (var db = new DatabaseEntities())
            {
                var user = db.Users.SingleOrDefault(u => u.Name == name);

                if (user == null) return null;
                else
                {
                    if (user.PasswordHashCode1 == User.GetPasswordHashCode1(password) &&
                        user.PasswordHashCode2 == User.GetPasswordHashCode2(password)) return user;
                    else 
                        return null;
                }
            }
        }
    }
}