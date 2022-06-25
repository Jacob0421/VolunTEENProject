using System.ComponentModel.DataAnnotations;
using VolunTEENProject.Models.ValidationExtensions;

namespace VolunTEENProject.ViewModels.Partner
{
    public class CreatePartner
    {

        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string StreetAddress { get; set; }
        public string AddressSecondLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }

        [AllowedFileExtensions(new string[] {".jpg",".png"})]
        [DataType(DataType.Upload)]
        public IFormFile PartnerLogo { get; set; }

    }
}
