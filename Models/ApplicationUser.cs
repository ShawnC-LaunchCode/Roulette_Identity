using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette_Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Bank { get; set; }

        public int UserLevel { get; set; }

    }
}
