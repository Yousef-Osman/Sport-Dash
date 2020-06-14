using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SportDash.Data;
using SportDash.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IMessageRepository messageRepository;
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserRepository userRepository;
        private readonly IImageRepository imageRepository;

        public ChatHub(
            IMessageRepository messageRepository, 
            ApplicationDbContext dbContext, 
            UserManager<ApplicationUser> userManager,
            IUserRepository userRepository,
            IImageRepository imageRepository)
        {
            this.messageRepository = messageRepository;
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.userRepository = userRepository;
            this.imageRepository = imageRepository;
        }

        public async override Task OnConnectedAsync()
        {
            try
            {
                var user = await userManager.GetUserAsync(Context.User);
                var connectedUser = await dbContext.ConnectedUsers.FirstOrDefaultAsync(u => u.UserId == user.Id);
                if (connectedUser == null)
                {
                    dbContext.ConnectedUsers.Add(new Models.ConnectedUser
                    {
                        ConnectionId = Context.ConnectionId,
                        UserId = user.Id
                    });
                }
                else
                {
                    await Disconnect();
                    dbContext.ConnectedUsers.Add(new Models.ConnectedUser
                    {
                        ConnectionId = Context.ConnectionId,
                        UserId = user.Id
                    });
                }
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
            }
        }

        public async Task Disconnect()
        {
            var user = await userManager.GetUserAsync(Context.User);
            var userConnection = await dbContext.ConnectedUsers.FirstOrDefaultAsync(u => u.UserId == user.Id);
            dbContext.ConnectedUsers.Remove(userConnection);
            await dbContext.SaveChangesAsync();
        }

        public async override Task OnDisconnectedAsync(Exception exception)
        {
            try
            {
                var user = await userManager.GetUserAsync(Context.User);
                var userConnection = await dbContext.ConnectedUsers.FirstOrDefaultAsync(u => u.UserId == user.Id);
                if (userConnection != null)
                {
                    dbContext.ConnectedUsers.Remove(userConnection);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
            }
        }

        public async Task SendMsg(string msg, string recieverId)
        {
            var sender = await userManager.GetUserAsync(Context.User);
            var reciever = await userManager.Users.FirstOrDefaultAsync(u => u.Id == recieverId);
            
            var senderImg = imageRepository.GetImages(sender.Id).FirstOrDefault(img => img.IsProfileImg == true);
            var reciverImg = imageRepository.GetImages(reciever.Id).FirstOrDefault(img => img.IsProfileImg == true);

            var senderProfileImg = senderImg == null ? "/images/site/user-icon.jpg" : "/images/" + senderImg.Title;
            var recieverProfileImg = reciverImg == null ? "/images/site/user-icon.jpg" : "/images/" + reciverImg.Title;

            var recieverConnection = await dbContext.ConnectedUsers.FirstOrDefaultAsync(u => u.UserId == reciever.Id);

            if(recieverConnection != null)
            {                
                await Clients.Client(recieverConnection.ConnectionId).SendAsync("recMsg", msg, sender.Id, sender.FullName, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"), senderProfileImg, sender.Id);
                userRepository.ChangeMsgsStatus(reciever, true);
                // here i am sending the msg to the other guy on the other side
                await Clients.Client(Context.ConnectionId).SendAsync("recMsg", msg, reciever.Id, reciever.FullName, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"), recieverProfileImg, sender.Id);
            }
            else
            {
                await Clients.Client(Context.ConnectionId).SendAsync("recMsg", msg, sender.Id, sender.FullName, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"), senderProfileImg, sender.Id);
                userRepository.ChangeMsgsStatus(reciever, true);
            }
            messageRepository.PostMessage(new Models.Message
            {
                Body = msg,
                MessageDate = DateTime.Now,
                ReceiverId = reciever.Id,
                SenderId = sender.Id
            });
            await dbContext.SaveChangesAsync();
        }
    }
}
