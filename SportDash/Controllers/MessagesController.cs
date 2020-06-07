using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportDash.Data;
using SportDash.Models;
using SportDash.Repository;
using SportDash.ViewModels;

namespace SportDash.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IMessageRepository messageRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserRepository userRepository;

        public MessagesController(
            IMessageRepository messageRepository, 
            UserManager<ApplicationUser> userManager,
            IUserRepository userRepository)
        {
            this.messageRepository = messageRepository;
            this.userManager = userManager;
            this.userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(User);
            userRepository.ChangeMsgsStatus(currentUser, false);
            // getting the most recent 5 messages
            var msgs = messageRepository.GetMessagesR(currentUser.Id)
                                        .OrderByDescending(m => m.MessageDate)
                                        .GroupBy(m => m.Sender.UserName).Take(5);
            return View(msgs);
        }

        public async Task<IActionResult> ChangeMsgStatus()
        {
            var currentUser = await userManager.GetUserAsync(User);
            userRepository.ChangeMsgsStatus(currentUser, false);
            return Ok();
        }

        public async Task<IActionResult> GetAll()
        {
            var currentUser = await userManager.GetUserAsync(User);
            // getting the most recent 10 messages
            var msgs = messageRepository.GetMessagesR(currentUser.Id)
                                        .OrderByDescending(m => m.MessageDate)
                                        .GroupBy(m => m.Sender.UserName);
            return PartialView("_AllMessages", msgs);
        }

        public async Task<IActionResult> MiniChat(string senderId)
        {
            var playgroundReciver = await userManager.FindByIdAsync(senderId);
            if (playgroundReciver == null) return NotFound();

            var currentUser = await userManager.GetUserAsync(User);
            var allMessages = messageRepository.GetMessages(currentUser.Id, playgroundReciver.Id).OrderByDescending(m => m.MessageDate);

            MessagingViewModel messagingViewModel = new MessagingViewModel
            {
                CurrentPage = playgroundReciver.FullName,
                EntityId = senderId,
                Messages = allMessages
            };

            return PartialView("_MiniChat", messagingViewModel);
        }
    }
}