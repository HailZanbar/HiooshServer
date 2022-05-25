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
            if (usersConID.ContainsKey(userID))
            {
                usersConID[userID] = Context.ConnectionId;
            } else
            {
                usersConID.Add(userID, Context.ConnectionId);
            }
        }

        public async Task SendMessage(string username, string message)
        {
            //createConID(username);
            var conID = usersConID[username];
            await Clients.Client((string)conID).SendAsync("ReceiveMessage", message);


            /*
            string connectionToSendMessage;
            Connections.TryGetValue(username, out connectionToSendMessage);

            if (string.IsNullOrWhiteSpace(connectionToSendMessage))
            {
                Connections.TryAdd(username, Context.ConnectionId);
            }
            await Clients.Client(connectionToSendMessage).SendAsync("ReceiveMessage", message);
            */
        }

        /*
        public async Task SendMessage(Message message, string clientId)
        {
            await Clients.Client(clientId).SendAsync("ReceiveMessage", message);
        }*/
    }
}
