using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public interface IMessageRepository
    {
        public IEnumerable<Message> GetMessagesR(string User_Id);
        public IEnumerable<Message> GetMessagesS(string User_Id);
        public Message GetMessage(int id);
        public Message PostMessage(Message m);
        public void DeleteMessage(int id);
    }
}
