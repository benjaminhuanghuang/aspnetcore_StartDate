using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StartDate.Models.Identity;

namespace StartDate.Models
{
    public enum SmokerType{
        No,
        Occasional,
        Regular,
        Heavy
    }

    public enum Gender{
        Male,
        Female
    }
    
    //[Table("Profile")]
    public class Profile
    {
        public int Id { get; set; }

        public Gender Gender{get; set;}
        
        [DisplayAttribute(Name="Display Name")]
        public string DisplayName { get; set; }
        
        public DateTime Birthday { get; set; }
        [DisplayAttribute(Name="Hight (cm)")]
        public int Height { get; set; }

        public string Description { get; set;}

        public string Occupation { get; set; }

        [Display(Name="Profile picture")]
        public string ProfilePicture { get; set; }
        
        public SmokerType Smoking {get; set;}

        public ApplicationUser User{get; set;}
    }
}