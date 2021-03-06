using System.ComponentModel.DataAnnotations;

namespace VolunTEENProject.ViewModels.Account
{
    public class CreateEndUser
    {
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastName{ get; set; }
        [Required]

        public int Age { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Required]

        public string City{ get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [Display(Name ="Zip code")]
        public int ZipCode { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Would you like to Opt-in to email communications?")]
        public bool TextOptIn { get; set; }

        [Display(Name = "Would you like to Opt-in to SMS communications? (Message Rates May apply)")]
        public bool EmailOptIn { get; set; }
    }
}
