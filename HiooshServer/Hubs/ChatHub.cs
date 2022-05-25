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

        private static Hashtable usersConID = new Hashtable();

        public void CreateConID(string userID)
        {
            lock (usersConID) { 
                if (usersConID.ContainsKey(userID))
                {
                    usersConID[userID] = Context.ConnectionId;
                }
                else
                {
                    usersConID.Add(userID, Context.ConnectionId);
                }
            }
        }

        public async Task SendMessage(string username, string message)
        {
            //createConID(username);
            if (!usersConID.ContainsKey(username))
            {
                return;
            }
            var conID = usersConID[username];
            await Clients.Client((string)conID).SendAsync("ReceiveMessage", message);

        }

    }
}
