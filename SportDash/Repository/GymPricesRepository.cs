using Microsoft.EntityFrameworkCore;
using SportDash.Data;
using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public class GymPricesRepository : IGymPricesRepository
    {
        private readonly ApplicationDbContext _context;

        public GymPricesRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<bool> Commit()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<IEnumerable<GymPrices>> PricesOfAGym(string gymId)
        {
            return await _context.GymPrices.Where(gp => gp.GymId == gymId).ToListAsync();
        }


        public async Task AddOrEditPricePerPeriod(GymPrices gymPrices)
        {
            var gymPrice = await _context.GymPrices.FirstOrDefaultAsync(gp => gp.GymId == gymPrices.GymId && gp.Subscribtion_Type == gymPrices.Subscribtion_Type);
            if (gymPrice == null)
            {
                _context.GymPrices.Add(gymPrices);
            }
            else
            {
                gymPrice.Subscribtion_Price = gymPrices.Subscribtion_Price;
                gymPrice.Subscribtion_Type = gymPrices.Subscribtion_Type;
                gymPrice.GymId = gymPrices.GymId;
                _context.Entry(gymPrice).State = EntityState.Modified;
            }
            await this.Commit();
        }

        //public async Task AddPerDayPrice(string gymId, GymPrices gymPrices)
        //{
        //    var gymPrice = await _context.GymPrices.FirstOrDefaultAsync(gp => gp.GymId == gymId && gp.Subscribtion_Type == Subscribtion_type.Day);
        //    if (gymPrice == null)
        //    {
        //        _context.GymPrices.Add(gymPrices);
        //    }
        //    else
        //    {
        //        gymPrice.Subscribtion_Price = gymPrices.Subscribtion_Price;
        //        gymPrice.Subscribtion_Type = Subscribtion_type.Day;
        //        gymPrice.GymId = gymId;
        //        _context.Entry(gymPrice).State = EntityState.Modified;
        //    }
        //    await this.Commit();
        //}


        //public async Task AddPerWeekPrice(string gymId, GymPrices gymPrices)
        //{
        //    var gymPrice = await _context.GymPrices.FirstOrDefaultAsync(gp => gp.GymId == gymId && gp.Subscribtion_Type == Subscribtion_type.Week);
        //    if (gymPrice == null)
        //    {
        //        _context.GymPrices.Add(gymPrices);
        //    }
        //    else
        //    {
        //        gymPrice.Subscribtion_Price = gymPrices.Subscribtion_Price;
        //        gymPrice.Subscribtion_Type = Subscribtion_type.Week;
        //        gymPrice.GymId = gymId;
        //        _context.Entry(gymPrice).State = EntityState.Modified;
        //    }
        //    await this.Commit();
        //}


        //public async Task AddPerMonthPrice(string gymId, GymPrices gymPrices)
        //{
        //    var gymPrice = await _context.GymPrices.FirstOrDefaultAsync(gp => gp.GymId == gymId && gp.Subscribtion_Type == Subscribtion_type.Month);
        //    if (gymPrice == null)
        //    {
        //        _context.GymPrices.Add(gymPrices);
        //    }
        //    else
        //    {
        //        gymPrice.Subscribtion_Price = gymPrices.Subscribtion_Price;
        //        gymPrice.Subscribtion_Type = Subscribtion_type.Month;
        //        gymPrice.GymId = gymId;
        //        _context.Entry(gymPrice).State = EntityState.Modified;
        //    }
        //    await this.Commit();
        //}


        //public async Task AddPerYearPrice(string gymId, GymPrices gymPrices)
        //{
        //    var gymPrice = await _context.GymPrices.FirstOrDefaultAsync(gp => gp.GymId == gymId && gp.Subscribtion_Type == Subscribtion_type.Year);
        //    if (gymPrice == null)
        //    {
        //        _context.GymPrices.Add(gymPrices);
        //    }
        //    else
        //    {
        //        gymPrice.Subscribtion_Price = gymPrices.Subscribtion_Price;
        //        gymPrice.Subscribtion_Type = Subscribtion_type.Year;
        //        gymPrice.GymId = gymId;
        //        _context.Entry(gymPrice).State = EntityState.Modified;
        //    }
        //    await this.Commit();
        //}

    }
}
