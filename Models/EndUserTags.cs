namespace VolunTEENProject.Models
{
    public class EndUserTags
    {

        public string EndUserID { get; set; }
        public int TagID { get; set; }
        public EndUser EndUser { get; set; }
        public Tag Tag { get; set; }

    }
}
