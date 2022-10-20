using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public List<string> Role { get; set; }

        public void Update(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            this.Email = user.Email;
            this.PhoneNumber = user.PhoneNumber;
        }
    }
}
