using System.ComponentModel.DataAnnotations;

namespace StartDate.Models.Identity
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name= "Email")]
        public string Email{get;set;}

        [Required]
        [DataType(DataType.Password)]
        [Display(Name= "Password")]
        public string  Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name= "Confirm password")]
        [Compare("Password",ErrorMessage="The Password and confirmation do not match")]
        public string  ConfirmPassword { get; set; }
    }
}