using System.ComponentModel.DataAnnotations;

namespace VolunTEENProject.ViewModels.Partner
{
    public class AddUser
    {
        [Required]
        public string userID { get; set; }
        [Required]
        public string partnerID { get; set; }
    }
}
