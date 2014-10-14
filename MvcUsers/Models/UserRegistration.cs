using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcUsers.Models
{
    public class UserRegistration
    {
        public String Name { set; get; }

        public String Password { set; get; }
    }
}