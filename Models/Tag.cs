using System.ComponentModel.DataAnnotations;

namespace VolunTEENProject.Models
{
    public class Tag
    {

        [Key]
        public int ID { get; set; }

        public string TagType { get; set; }

        public string TagName { get; set; }

        public EndUser CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
