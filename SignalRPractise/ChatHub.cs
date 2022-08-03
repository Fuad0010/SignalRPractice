using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace SignalRPractise
{
    public class ChatHub:Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, DateTime.Now.ToString("dd.mm.yyyy")); 
        }
    }
}
