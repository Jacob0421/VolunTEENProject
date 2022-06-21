using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace VolunTEENProject.Models
{
    public class Partner
    {
        
        [Key]
        [HiddenInput]
        public int PartnerID { get; set; }
        
        [Required]
        public string PartnerName { get; set; }
        
        [HiddenInput]
        public EndUser? HeadRepresentative { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        
        [Required]
        public string StreetAddress { get; set; }
        
        [Required]
        public string City { get; set; }
        
        [Required]
        public string State { get; set; }

        [Required]
        [MinLength(5), MaxLength(5)]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        public DateTime? CreatedTime { get; set; }
        public string? NormalizedEmail { get; set; }

    }
}
