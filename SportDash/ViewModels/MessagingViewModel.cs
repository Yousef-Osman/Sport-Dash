using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.ViewModels
{
    public class MessagingViewModel
    {
        public IOrderedEnumerable<Models.Message> Messages { get; set; }
        public string CurrentPage { get; set; }
    }
}
