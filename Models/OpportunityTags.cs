namespace VolunTEENProject.Models
{
    public class OpportunityTags
    {
        public int OpportunityID { get; set; }
        public int TagID { get; set; }
        public Opportunity Opportunity { get; set; }
        public Tag Tag { get; set; }
    }
}
