namespace VolunTEENProject.Models
{
    public class Friend
    {

        public int MainUserID { get; set; }

        public int FriendUserID { get; set; }

        public EndUser MainUser { get; set; }

        public EndUser FriendUser { get; set; }

    }
}
