﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportDash.Data;
using SportDash.Models;
using SportDash.Repository;
using SportDash.ViewModels;

namespace SportDash.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private readonly IMessageRepository messageRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserRepository userRepository;
        private readonly IImageRepository imageRepository;

        public MessagesController(
            IMessageRepository messageRepository, 
            UserManager<ApplicationUser> userManager,
            IUserRepository userRepository,
            IImageRepository imageRepository)
        {
            this.messageRepository = messageRepository;
            this.userManager = userManager;
            this.userRepository = userRepository;
            this.imageRepository = imageRepository;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(User);
            userRepository.ChangeMsgsStatus(currentUser, false);
            // getting the most recent 5 messages
            var msgs = messageRepository.GetMessagesR(currentUser.Id);

            Dictionary<string, Image> profileImgs = new Dictionary<string, Image>();
            foreach(var msg in msgs)
            {
                var img = imageRepository.GetImages(msg.SenderId).FirstOrDefault(m => m.IsProfileImg == true);
                if(!profileImgs.ContainsKey(msg.SenderId))
                {
                    profileImgs.Add(msg.SenderId, img);
                }
            }

            var allMsgs = msgs.OrderByDescending(m => m.MessageDate)
                                        .GroupBy(m => m.Sender.FullName).Take(5);

            var msgViewModel = new MessagingViewModel
            {
                RecievedMessages = allMsgs,
                ProfileImages = profileImgs
            };
            return View(msgViewModel);
        }

        public async Task<IActionResult> ChangeMsgStatus()
        {
            var currentUser = await userManager.GetUserAsync(User);
            userRepository.ChangeMsgsStatus(currentUser, false);
            return Ok("<html>Status Changed</html>");
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

            Dictionary<string, Image> profileImgs = new Dictionary<string, Image>();
            
            var img = imageRepository.GetImages(playgroundReciver.Id).FirstOrDefault(m => m.IsProfileImg == true);
             
            if (!profileImgs.ContainsKey(playgroundReciver.Id))
            {
                profileImgs.Add(playgroundReciver.Id, img);
            }

            MessagingViewModel messagingViewModel = new MessagingViewModel
            {
                CurrentPage = playgroundReciver.FullName,
                EntityId = senderId,
                Messages = allMessages,
                ProfileImages = profileImgs
            };

            return PartialView("_MiniChat", messagingViewModel);
        }        
    }
}