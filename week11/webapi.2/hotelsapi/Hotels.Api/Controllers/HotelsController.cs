﻿namespace Hotels.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Data;
    using Data.Entities;
    using Extensions.Map;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Memory;
    using Models.Hotels;
    using Services;

    [Route("api/hotels")]
    [ApiController]
    //[Authorize]
    public class HotelsController : ControllerBase
    {
        private readonly ApiDbContext context;
        private readonly ISimpleLogger logger;
        private readonly IMemoryCache memoryCache;

        public HotelsController(ApiDbContext context, ISimpleLogger logger, IMemoryCache memoryCache)
        {
            this.context = context;
            this.logger = logger;
            this.memoryCache = memoryCache;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotelResource>> Get(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Negative id exception");
            }

            //var key =  $"_entity"

            var entity = await this.context.Hotels.FindAsync(id);
            if (entity == null)
            {
                return this.NotFound();
            }

            this.logger.LogInfo("HotelsController-Get(id) hit");

            return entity.MapAsModel();
        }

        [HttpPost]
        public async Task<ActionResult<Hotel>> Post(CreateHotelResource model)
        {
            var entity = model.MapAsNewEntity();
            this.context.Hotels.Add(entity);

            await this.context.SaveChangesAsync();

            return this.CreatedAtAction("Get", new {id = entity.Id}, entity.MapAsModel());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, UpdateHotelResource model)
        {
            var entity = await this.context.Hotels.FindAsync(id);
            if (entity == null)
            {
                return this.NotFound();
            }

            entity.UpdateWith(model);
            this.context.Hotels.Update(entity);
            await this.context.SaveChangesAsync();

            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> Delete(int id)
        {
            var hotel = await this.context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return this.NotFound();
            }

            var rooms = await this.context.Rooms.Include(x=>x.Hotel).Where(x => x.Hotel.Id == id).ToListAsync();
            foreach (var room in rooms)
            {
                this.context.Rooms.Remove(room);
            }

            this.context.Hotels.Remove(hotel);
            await this.context.SaveChangesAsync();
            
            return hotel;
        }

        [HttpGet("long-running")]
        public async Task<ActionResult<string>> LongRunning(CancellationToken token)
        {
            while (true)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                if (token.IsCancellationRequested == true)
                {
                    break;
                }
                this.logger.LogInfo("Operation in progress ...");
            }
            return "done";
        }
    }
}
