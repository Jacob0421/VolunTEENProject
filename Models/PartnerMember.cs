namespace VolunTEENProject.Models
{
    public class PartnerMember
    {

        public string UserId { get; set; }
        public int PartnerId { get; set; }
        public EndUser User { get; set; }
        public Partner Partner { get; set; }

    }
}
