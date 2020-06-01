using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WebApplication1.Hubs
{
    public class ChatHub : Hub
    {
        public void JoinRoom(string room)
        {
            Groups.Add(Context.ConnectionId, room);
        }
        public void SendMessage(string room, string message, int x, int y)
        {
            var username = Context.User.Identity.Name;
            Clients.Group(room).onNewMessage(username, message, x, y);
        }

        public void SendPrivateMessage(string toUsername, string message)
        {
            var fromUsername = Context.User.Identity.Name;
            Clients.Group("users/" + toUsername).onNewPrivateMessage(fromUsername, message);
        }

        public override Task OnConnected()
        {
            var username = Context.User.Identity.Name;
            if (!string.IsNullOrEmpty(username))
            {
                Groups.Add(Context.ConnectionId, "users/" + username);
            }
            return base.OnConnected();
        }
    }
}