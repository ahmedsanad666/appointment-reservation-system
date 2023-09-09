using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class ApiUser : IdentityUser
    {
       public string UserName { get; set; }
        [NotMapped]
        public string Password { get; set; }
    }
}
