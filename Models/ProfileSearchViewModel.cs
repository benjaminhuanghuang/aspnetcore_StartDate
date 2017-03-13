using System;
using System.ComponentModel.DataAnnotations;

using StartDate.Models.Identity;

namespace StartDate.Models
{
    public class ProfileSearchViewModel
    {
        [DisplayAttribute(Name = "I'm looling for a")]
        public Gender Gender { get; set; }

        [DisplayAttribute(Name = "Age from")]
        public int MinAge { get; set; }
        [DisplayAttribute(Name = "to ")]
        public int MaxAge { get; set; }

        [DisplayAttribute(Name = "Height from")]
        public int MinHeight { get; set; }
        [DisplayAttribute(Name = "to")]
        public int MaxHeight { get; set; }

        [DisplayAttribute(Name = "Only non-smoker")]
        public bool NoSmoking { get; set; }

    }

}