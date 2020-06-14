using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.ViewModels
{
    public class MessagingViewModel
    {
        public IOrderedEnumerable<Message> Messages { get; set; }
        public string CurrentPage { get; set; }
        public string EntityId { get; set; }
        public Dictionary<string, Image> ProfileImages { get; set; }
        public IEnumerable<IGrouping<string, Message>> RecievedMessages { get; set; }
    }
}
