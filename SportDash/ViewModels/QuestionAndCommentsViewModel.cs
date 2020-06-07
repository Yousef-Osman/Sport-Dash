using SportDash.Data;
using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.ViewModels
{
    public class QuestionAndCommentsViewModel
    {
        public DataViewModel DataViewModel { get; set; }
        public Question Question { get; set; }
        public ApplicationUser User { get; set; }
        public List<UserCommentViewModel> UserComment { get; set; }
    }
}
