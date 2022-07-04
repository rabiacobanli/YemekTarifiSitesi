using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete
{
    // Add profile data for application users by adding properties to the Kullanici class
    public class Kullanici:IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }
}
