using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUsers.Models
{
    partial class User
    {
        public static Int32 GetPasswordHashCode1(String password)
        {
            return (password + "SexMashine").GetHashCode();
        }

        public static Int32 GetPasswordHashCode2(String password)
        {
            return GetPasswordHashCode1(password).ToString().GetHashCode();
        }
    }
}