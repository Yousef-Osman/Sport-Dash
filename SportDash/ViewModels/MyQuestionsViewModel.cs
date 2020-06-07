using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.ViewModels
{
    public class MyQuestionsViewModel
    {
        public List<Question> Questions { get; set; }
        public DataViewModel DataViewModel { get; set; }
    }
}
