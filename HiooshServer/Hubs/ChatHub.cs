using System.Collections.Concurrent;
using System.Threading.Tasks;
using HiooshServer.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections;

namespace HiooshServer.Hubs
{
    public class ChatHub: Hub
    {
        //private static ConcurrentDictionary<string, string> Connections = new ConcurrentDictionary<string, string>();

        private static Hashtable usersChatConID = new Hashtable();

        public void CreateConID(string userID)
        {
            lock (usersChatConID) { 
                if (usersChatConID.ContainsKey(userID))
                {
                    usersChatConID[userID] = Context.ConnectionId;
                }
                else
                {
                    usersChatConID.Add(userID, Context.ConnectionId);
                }
            }
        }

        public async Task SendMessage(string username, string message)
        {
            //createConID(username);
            if (!usersChatConID.ContainsKey(username))
            {
                return;
            }
            var conID = usersChatConID[username];
            await Clients.Client((string)conID).SendAsync("ReceiveMessage", message);

        }

    }
}
