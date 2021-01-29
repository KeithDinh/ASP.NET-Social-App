namespace API.Entities
{
    public class Connection
    {
        // This is an entity, we need a default constructor to prevent EF from error
        public Connection()
        {
        }

        public Connection(string connectionId, string username)
        {
            ConnectionId = connectionId;
            Username = username;
        }

        public string ConnectionId {get; set;}
        public string Username { get; set; }
    }
}