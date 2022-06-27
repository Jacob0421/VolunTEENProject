namespace VolunTEENProject.Models.Repositories
{
    public interface IPartnerRepository
    {
        public Partner GetPartnerByID(string partnerID);
        public Partner GetPartnerByPartnerName(string partnerName);
        public List<Partner> GetPartners();
        public Partner CreatePartner (Partner newPartner);
        public Partner UpdatePartner (Partner updatedPartner);
        public void DeletePartner (Partner toBeDeleted);

        public void AddUser(EndUser toBeAdded, Partner toBeUpdated);
    }
}
