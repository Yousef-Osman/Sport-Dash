using Microsoft.AspNetCore.Mvc;
using SportDash.Repository;
using SportDash.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Components.PlaygroundPrices
{
    public class PlaygroundPrices:ViewComponent
    {
        private readonly IPlaygroundPriceRepository _playgroundPriceRepositor;

        public PlaygroundPrices(IPlaygroundPriceRepository playgroundPriceRepositor)
        {
            _playgroundPriceRepositor = playgroundPriceRepositor;
        }

        public IViewComponentResult Invoke(DataViewModel dataModel)
        {
            string userId = null;

            if (dataModel.Entity != null)
            {
                userId = dataModel.Entity.Id;
            }
            else if (dataModel.Entity == null)
            {
                userId = dataModel.CurrentUser.Id;
                dataModel.Entity = dataModel.CurrentUser;
            }

            dataModel.PlaygroundPrices = _playgroundPriceRepositor.GetByPlayground(userId);

            return View("/Components/PlaygroundPrices/PlaygroundPrices.cshtml", dataModel);
        }
    }
}
