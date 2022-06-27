using System.ComponentModel.DataAnnotations;

namespace VolunTEENProject.ViewModels.Role
{
    public class CreateRole
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsPartnerRole { get; set; }

    }
}
