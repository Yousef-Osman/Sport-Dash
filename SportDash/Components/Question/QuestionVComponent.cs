using Microsoft.AspNetCore.Mvc;
using SportDash.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Components.Question
{
    public class QuestionVComponent : ViewComponent
    {
        public IViewComponentResult Invoke(QuestionViewModel questionViewModel)
        {
            return View("/Components/Question/QuestionViewComponent.cshtml", questionViewModel);
        }

    }
}
