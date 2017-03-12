using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace StartDate.Models.Identity
{
    public class ApplicationUser: IdentityUser
    {
          public string UseName {get;set;}
          public string Email { get; set; }

    }
}