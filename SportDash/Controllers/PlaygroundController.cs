using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportDash.Data;
using SportDash.Repository;
using SportDash.ViewModels;

namespace SportDash.Controllers
{
    public class PlaygroundController : Controller
    {
        private readonly IPlaygroundRepository playgroundRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMessageRepository messageRepository;

        public PlaygroundController(
                    IPlaygroundRepository playgroundRepository, 
                    UserManager<ApplicationUser> userManager, 
                    IMessageRepository messageRepository)
        {
            this.playgroundRepository = playgroundRepository;
            this.userManager = userManager;
            this.messageRepository = messageRepository;
        }

        public async Task<IActionResult> Index(string playgroundId)
        {
            var playground = await playgroundRepository.GetPlayground(playgroundId);
            return View(playground);
        }

        public async Task<IActionResult> Message(string id)
        {
            var playgroundReciver = await playgroundRepository.GetPlayground(id);
            var currentUser = await userManager.GetUserAsync(User);
            var allMessages = messageRepository.GetMessages(currentUser.Id, playgroundReciver.Id).OrderByDescending(m => m.MessageDate);

            MessagingViewModel messagingViewModel = new MessagingViewModel
            {
                CurrentPage = playgroundReciver.FullName,
                Messages = allMessages
            };

            return View(messagingViewModel);
        }
    }
}