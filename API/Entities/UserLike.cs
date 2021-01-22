namespace API.Entities
{
    // SourceUserId and LikedUserId make up the primary key for this entity
    public class UserLike
    {
        public AppUser SourceUser { get; set; } // the user that likes other users
        public int SourceUserId { get; set; }
        public AppUser LikedUser { get; set; } // list of users who are liked by current user
        public int LikedUserId { get; set; }
    }
}