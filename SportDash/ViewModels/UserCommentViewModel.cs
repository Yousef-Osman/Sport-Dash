using SportDash.Data;
using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.ViewModels
{
    public class UserCommentViewModel
    {
        public Comment Comment { get; set; }
        public ApplicationUser User { get; set; }
    }
}
