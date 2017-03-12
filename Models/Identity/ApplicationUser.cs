using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

using StartDate.Models;

namespace StartDate.Models.Identity
{
    public class ApplicationUser: IdentityUser
    {
        [ForeignKeyAttribute("Profile ")]
        public int ProfileId{get;set;}
        public Profile Profile{get;set;}
    }
}