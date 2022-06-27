namespace VolunTEENProject.Models.Repositories
{
    public class PartnerRepository : IPartnerRepository
    {

        private readonly AppDBContext _context;

        public PartnerRepository(AppDBContext context)
        {
            _context = context;
        }

        public void AddUser(EndUser toBeAdded, Partner toBeUpdated)
        {

            PartnerMember member = new PartnerMember {
                  User  = toBeAdded,
                  UserId = toBeAdded.Id,
                  Partner = toBeUpdated,
                  PartnerId = toBeUpdated.PartnerID
            };

            _context.PartnerMembers.Add(member);
            _context.SaveChanges();
        }

        public Partner CreatePartner(Partner newPartner)
        {

            if(newPartner != null)
            {
                _context.Partners.Add(newPartner);
                _context.SaveChanges();
            }

            return newPartner;
        }

        public void DeletePartner(Partner toBeDeleted)
        {
            throw new NotImplementedException();
        }

        public Partner GetPartnerByID(string partnerID)
        {
            throw new NotImplementedException();
        }

        public Partner GetPartnerByPartnerName(string partnerName)
        {
            throw new NotImplementedException();
        }

        public List<Partner> GetPartners()
        {
             return _context.Partners.ToList();
        }

        public Partner UpdatePartner(Partner updatedPartner)
        {
            throw new NotImplementedException();
        }
    }
}
