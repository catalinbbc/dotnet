namespace Hotels.Api.Controllers
{
    using Hotels.Api.Data;
    using Hotels.Api.Data.Entities;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System;
    using Hotels.Api.Services;

    [Route("api/hotels")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly ApiDbContext context;
        private readonly INotificationService notificationService;


        public HotelsController(ApiDbContext context,  INotificationService notificationService    )
        {
            this.context = context;
            this.notificationService = notificationService;

        }

        // GET: api/hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            return await this.context.Hotels.ToListAsync();
        }

        // GET: api/hotels/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var todoItem = await this.context.Hotels.FindAsync(id);

            if (todoItem == null)
            {
                return this.NotFound();
            }

            return todoItem;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotels(int id, Hotel hotel)
        {
            if (id < 0)
            {
                throw new ArgumentException("negative id");
            }

            this.context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.HotelsExists(id))
                {
                    return this.NotFound();
                }

                throw;
            }

            return this.NoContent();
        }

        // POST: api/hotels
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotels(Hotel hotel)
        {
            this.context.Hotels.Add(hotel);
            await this.context.SaveChangesAsync();

            this.notificationService.Notify($"hotel with id {hotel.Id} created!");
            return this.CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/hotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> DeleteHotel(int id)
        {
            var item = await this.context.Hotels.FindAsync(id);

            if (item == null)
            {
                return this.NotFound();
            }

            this.context.Hotels.Remove(item);
            await this.context.SaveChangesAsync();

            return item;
        }


        private bool HotelsExists(long id)
        {
            return this.context.Hotels.Any(e => e.Id == id);
        }
    }
}
