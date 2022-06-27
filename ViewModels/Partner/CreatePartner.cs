using System.ComponentModel.DataAnnotations;
using VolunTEENProject.Models.ValidationExtensions;

namespace VolunTEENProject.ViewModels.Partner
{
    public class CreatePartner
    {
        [Required]
        public string PartnerName { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        
        public string? AddressSecondLine { get; set; }
        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [AllowedFileExtensions(new string[] {".jpg",".png"})]
        [DataType(DataType.Upload)]
        public IFormFile PartnerLogo { get; set; }

    }
}
