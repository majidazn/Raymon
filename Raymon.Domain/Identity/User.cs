using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raymon.Domain.Identity
{
    public class User : IdentityUser
    {

        public User()
        {
        }

        public User(string userName) : base(userName)
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
