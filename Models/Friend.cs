namespace VolunTEENProject.Models
{
    public class Friend
    {

        public string MainUserID { get; set; }

        public string FriendUserID { get; set; }

        public EndUser MainUser { get; set; }

        public EndUser FriendUser { get; set; }

    }
}
