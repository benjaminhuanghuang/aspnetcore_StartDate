using System;
using System.ComponentModel.DataAnnotations;

using StartDate.Models.Identity;

namespace StartDate.Models
{
    public class ProfileSearchResultViewModel
    {
        public int Id { get; set; }

        public Gender Gender{get; set;}
        
        [DisplayAttribute(Name="Display Name")]
        public string DisplayName { get; set; }
        
        public int Age { get; set; }

        [DisplayAttribute(Name="Hight (cm)")]
        public int Height { get; set; }

        public string Description { get; set;}

        public string Occupation { get; set; }

        [Display(Name="Profile picture")]
        public string ProfilePicture { get; set; }
        
        public SmokerType Smoking {get; set;}
    }

}