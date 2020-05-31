using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportDash.Data;
using SportDash.Models;
using SportDash.Repository;

namespace SportDash.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaygroundPricesController : ControllerBase
    {
        public readonly IPlaygroundPriceRepository playgroundPriceRepository;


        public PlaygroundPricesController(IPlaygroundPriceRepository playgroundPriceRepository)
        {
            this.playgroundPriceRepository = playgroundPriceRepository;
        }

        // GET: api/PlaygroundPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaygroundPrice>>> GetplaygroundPrices()
        {
            return playgroundPriceRepository.GetAll().ToList();
        }

        // GET: api/PlaygroundPrices/5
        [HttpGet("{playgroundId}")]
        public async Task<ActionResult<IEnumerable<PlaygroundPrice>>> GetByPlayground(string playgroundId)
        {
            var playgroundPrice = playgroundPriceRepository.GetByPlayground(playgroundId);


            if (playgroundPrice == null)
            {
                return NotFound();
            }

            return playgroundPrice;
        }



        // PUT: api/PlaygroundPrices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutPlaygroundPrice(String g /*[FromRoute]String id, [FromBody] OldAndNewPlaygroundPrice oldAndNewplaygroundPrice*/)
        {
            Console.WriteLine();
            //TimeSpan timeSpan=new TimeSpan();
            //bool result = playgroundPriceRepository.UpdatePlaygroundPrice(oldAndNewplaygroundPrice.NewPlaygroundPrice, oldAndNewplaygroundPrice.OldPlaygroundPrice);
            //if (result == true)
            return Ok();
            //return BadRequest();
            //return NoContent();
        }



        // POST: api/PlaygroundPrices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PlaygroundPrice>> PostPlaygroundPrice(PlaygroundPrice playgroundPrice)
        {
            int found_id = playgroundPriceRepository.AddPlaygroundPrice(playgroundPrice);
            //if(found)
            //{
                return Ok();
            //}
            //else
            //{
                //return BadRequest();
            //}
            //try
            //{
            //    await playgroundPriceRepository.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (PlaygroundPriceExists(playgroundPrice.PlaygroundId))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return CreatedAtAction("GetPlaygroundPrice", new { id = playgroundPrice.PlaygroundId }, playgroundPrice);
        }
        /*
        // DELETE: api/PlaygroundPrices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlaygroundPrice>> DeletePlaygroundPrice(string id)
        {
            var playgroundPrice = await playgroundPriceRepository.playgroundPrices.FindAsync(id);
            if (playgroundPrice == null)
            {
                return NotFound();
            }

            playgroundPriceRepository.playgroundPrices.Remove(playgroundPrice);
            await playgroundPriceRepository.SaveChangesAsync();

            return playgroundPrice;
        }

        private bool PlaygroundPriceExists(string id)
        {
            return playgroundPriceRepository.playgroundPrices.Any(e => e.PlaygroundId == id);
        }
        */
    }
}
