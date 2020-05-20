﻿using SportDash.Data;
using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public class MessageRepo : IMessage
    {

        ApplicationDbContext _context;

        public MessageRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DeleteMessage(int id)
        {
            _context.Messages.Remove(GetMessage(id));
            _context.SaveChanges();
        }

        public Message GetMessage(int id)
        {
            return _context.Messages.FirstOrDefault(m => m.Message_Id == id);
        }

        // get all messages send by this specific user
        public IEnumerable<Message> GetMessagesS(string User_Id)
        {
            return _context.Messages.Where(m => m.Sender_Id == User_Id).ToList();
        }


        // get all messages send to this specific user 
        public IEnumerable<Message> GetMessagesR(string User_Id)
        {
            return _context.Messages.Where(m => m.Receiver_Id == User_Id).ToList();
        }

        public Message PostMessage(Message m)
        {
            _context.Messages.Add(m);
            _context.SaveChanges();
            return m;
        }

    }
}
