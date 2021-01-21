namespace API.Entities
{
    public class UserLike
    {
        public AppUser SourceUser { get; set; } // the user that likes other users
        public int SourceUserId { get; set; }
        public AppUser LikedUser { get; set; } // list of users who are liked by current user
        public int LikedUserId { get; set; }
    }
}