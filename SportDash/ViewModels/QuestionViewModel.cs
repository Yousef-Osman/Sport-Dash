using SportDash.Components.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportDash.Models;


namespace SportDash.ViewModels
{
    public class QuestionViewModel
    {
        public Question Question { get; set; }
        public DataViewModel DataViewModel { get; set; }
    }
}
