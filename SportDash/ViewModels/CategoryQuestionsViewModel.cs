using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.ViewModels
{
    public class CategoryQuestionsViewModel
    {
        public DataViewModel DataViewModel { get; set; }

        public List<Question> Questions { get; set; }
    }
}
