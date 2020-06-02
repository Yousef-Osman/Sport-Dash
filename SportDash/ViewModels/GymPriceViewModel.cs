using SportDash.Components.GymPrice;
using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.ViewModels
{
    public class GymPriceViewModel
    {
        //1 gym price (I take the class as it without renaming and it should be singular not plural)
        public GymPrices GymPrice;
        public DataViewModel DataViewModel { get; set; }
    }
}
