using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace VolunTEENProject.ViewModels.Account
{
    public class EndUserDetails
    {
        [HiddenInput]
        public string Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        public int Age { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        public string City { get; set; }
        
        public string State { get; set; }

        [Display(Name="Postal Code")]
        public int ZipCode { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Opted In for Emails")]
        public bool TextOptIn { get; set; }

        [Display(Name = "Opted in for Texts")]
        public bool EmailOptIn { get; set; }
    }
}
