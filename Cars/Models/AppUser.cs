using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars.Models
{
    public class AppUser :IdentityUser
    {
        public string Fullname { get; set; }
        public string? ProfileImageUrl { get; set; }
        [NotMapped]
        public string PhoneNumber { get=>base.PhoneNumber; set=>base.PhoneNumber = value; }
       


    }

}
