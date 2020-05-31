using Microsoft.EntityFrameworkCore;
using SportDash.Data;
using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public class MessageRepository : IMessageRepository
    {

        ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
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
            return _context.Messages.FirstOrDefault(m => m.Id == id);
        }

        // get all messages send by this specific user
        public IEnumerable<Message> GetMessagesS(string User_Id)
        {
            return _context.Messages.Where(m => m.SenderId == User_Id).ToList();
        }


        // get all messages send to this specific user 
        public IEnumerable<Message> GetMessagesR(string User_Id)
        {
            return _context.Messages.Include("Sender").Where(m => m.ReceiverId == User_Id).ToList();
        }

        // get all messages between User A and B
        public IEnumerable<Message> GetMessages(string senderId, string receiverId)
        {
            return _context.Messages.Include("Sender").Include("Receiver").Where(m => (m.ReceiverId == receiverId && m.SenderId == senderId) || (m.ReceiverId == senderId && m.SenderId == receiverId)).ToList();
        }

        public Message PostMessage(Message m)
        {
            _context.Messages.Add(m);
            _context.SaveChanges();
            return m;
        }

    }
}
