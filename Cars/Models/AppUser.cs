using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars.Models
{
    public class AppUser :IdentityUser
    {
        public string Name { get; set; }
        public string Email { get; set; } 
       


    }

}
