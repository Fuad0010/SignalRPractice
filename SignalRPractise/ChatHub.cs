using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using SignalRPractise.DAL;
using SignalRPractise.Models;
using System;
using System.Threading.Tasks;

namespace SignalRPractise
{
    public class ChatHub : Hub
    {
            private readonly UserManager<AppUser> _userManager;
            private readonly AppDbContext _context;

            public ChatHub(UserManager<AppUser> userManager,AppDbContext context)
            {
                _userManager = userManager;
                _context = context;
            }
            public async Task SendMessage(string user, string message)
            {
                await Clients.All.SendAsync("ReceiveMessage", user, message, DateTime.Now.ToString("dd.mm.yyyy"));
            }
            public override Task OnConnectedAsync()
            {
                if (Context.User.Identity.IsAuthenticated)
                {
                    AppUser user = _userManager.FindByNameAsync(Context.User.Identity.Name).Result;
                    user.ConnectId = Context.ConnectionId;
                    _userManager.UpdateAsync(user);
                _context.SaveChanges();    
                };


                return base.OnConnectedAsync();
            }
    } 
}
