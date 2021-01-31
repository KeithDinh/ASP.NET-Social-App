using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace API.SignalR
{
    public class PresenceTracker
    {
        private static readonly Dictionary<string, List<string>> OnlineUsers = new Dictionary<string, List<string>>(); 
        public Task<Boolean> UserConnected(string username, string connectionId)
        {
            bool isOnline = false;

            // locking the dictionary until we finish codes in the block
            lock (OnlineUsers)
            {
                if(OnlineUsers.ContainsKey(username))
                {
                    OnlineUsers[username].Add(connectionId);
                }
                else 
                {
                    OnlineUsers.Add(username, new List<string>{connectionId});
                    isOnline = true;
                }
            }
            return Task.FromResult(isOnline);
        }
        public Task<Boolean> UserDisconnected(string username, string connectionId)
        {
            bool isOffline = false;

            lock(OnlineUsers)
            {
                if (!OnlineUsers.ContainsKey(username)) return Task.FromResult(isOffline);

                OnlineUsers[username].Remove(connectionId);
                if(OnlineUsers[username].Count == 0)
                {
                    OnlineUsers.Remove(username);
                    isOffline = true;
                }
            }
            return Task.FromResult(isOffline);
        }
        public Task<string[]> GetOnlineUsers()
        {
            string[] onlineUsers;

            lock(OnlineUsers)
            {
                onlineUsers = OnlineUsers
                    .OrderBy(k => k.Key) // key is username, value is userid
                    .Select(k => k.Key) // select only username
                    .ToArray();
            }
            return Task.FromResult(onlineUsers);
        }
        public Task<List<string>> GetConnectionsForUser(string username)
        {
            List<string> connectionIds;
            lock(OnlineUsers)
            {
                connectionIds = OnlineUsers.GetValueOrDefault(username); // default: if nothing => return null
            }

            return Task.FromResult(connectionIds);
        }

    }
}