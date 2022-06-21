using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace VolunTEENProject.Models
{
    public class Opportunity
    {
        [Key]
        [HiddenInput]
        public int OpportunityID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime TimeOfEvent { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [MinLength(5), MaxLength(5)]
        [Display(Name ="Zip Code")]
        public int ZipCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public EndUser? UpdatedBy { get; set; }


    }
}
