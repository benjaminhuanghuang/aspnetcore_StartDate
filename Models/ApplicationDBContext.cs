using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StartDate.Models.Identity;


namespace StartDate.Models
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {

    }
}