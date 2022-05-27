using System.Collections.Concurrent;
using System.Threading.Tasks;
using HiooshServer.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections;

namespace HiooshServer.Hubs
{
    public class InvitationsHub : Hub
    {
        //private static ConcurrentDictionary<string, string> Connections = new ConcurrentDictionary<string, string>();

        private static Hashtable usersInvitConID = new Hashtable();

        public void CreateConID(string userID)
        {
            lock (usersInvitConID)
            {
                if (usersInvitConID.ContainsKey(userID))
                {
                    usersInvitConID[userID] = Context.ConnectionId;
                }
                else
                {
                    usersInvitConID.Add(userID, Context.ConnectionId);
                }
            }
        }

        public async Task SendInvitation(string username, string from)
        {
            //createConID(username);
            if (!usersInvitConID.ContainsKey(username))
            {
                return;
            }
            var conID = usersInvitConID[username];
            await Clients.Client((string)conID).SendAsync("ReceiveInvitation", from);

        }

    }
}

