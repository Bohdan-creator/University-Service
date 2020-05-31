using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SchoolRegister.BLL.Entities;
using SchoolRegisterSystem.DAL.EF;
using SchoolRegisterSystem.ViewModel.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegisterSystem.Hubs
{
    [Authorize]
    public class Chathub : Hub
    {
        private readonly ApplicationDbContext _db;

        public Chathub(ApplicationDbContext db)
        {
            _db = db;
        }

        public void SendMessageAll(MessageVm message)
        {
            message.Author = Context.User.Identity.Name;       
                Clients.All.SendAsync("ShowMessage", message);
        }
        public void SendMessageToUser(MessageVm message)
        {
            message.Author = Context.User.Identity.Name;
            var author = _db.Users.FirstOrDefault(u => u.Email == message.Author);
            var recepinient = _db.Users.FirstOrDefault(u => u.UserName == message.RecipientName);
            if (recepinient != null)
            {
                Clients.User(author.Id.ToString()).SendAsync("ShowMessage", message);
                Clients.User(recepinient.Id.ToString()).SendAsync("ShowMessage", message);
                //Clients.All.SendAsync("ShowMessage", message);

            }
        }
        public void SetGroups()
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == Context.User.Identity.Name);
            if (user is Student student)
                Groups.AddToGroupAsync(Context.ConnectionId, student.Group.Name);
        }
        public override Task OnConnectedAsync()
        {
            SetGroups();
            return base.OnConnectedAsync();
        }
    }
}
