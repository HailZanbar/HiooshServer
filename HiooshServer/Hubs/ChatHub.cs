using System.Threading.Tasks;
using HiooshServer.Models;
using Microsoft.AspNetCore.SignalR;

namespace HiooshServer.Hubs
{
    public class ChatHub: Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
