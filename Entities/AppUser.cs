using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirtsName { get; set; }
        public string LastName { get; set; }
    }
}
