using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class ApiUser : IdentityUser
    {
     
        [NotMapped]
        public string Password { get; set; }
    }
}
