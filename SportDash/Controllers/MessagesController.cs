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

        public MessagesController(IMessageRepository messageRepository, UserManager<ApplicationUser> userManager)
        {
            this.messageRepository = messageRepository;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(User);
            // getting the most recent 5 messages
            var msgs = messageRepository.GetMessagesR(currentUser.Id)
                                        .OrderByDescending(m => m.MessageDate)
                                        .GroupBy(m => m.Sender.UserName).Take(5);
            return View(msgs);
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
    }
}