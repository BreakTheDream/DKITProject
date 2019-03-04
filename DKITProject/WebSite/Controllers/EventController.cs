﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DKITProject.DAL;
using DKITProject.ViewModel;
using Microsoft.EntityFrameworkCore;
using DKITProject.Enums;
using DKITProject.DAL.Models;

namespace DKITProject.WebSite.Controllers
{
    public class EventController : Controller
    {
        private ApplicationContext context;
        private const int pageCount = 10;

        public EventController(ApplicationContext _context)
        {
            context = _context;
        }

        [HttpGet("api/events/{pageNumber}/{type}")]
        public async Task<IActionResult> GetAdditionalEducationsAsync(EventTypes type, int pageNumber = 1)
        {
            var events = await context.Events
                .Where(e => e.EventType == type)
                .OrderByDescending(a => a.DatePost)
                .Skip(pageCount * (pageNumber - 1))
                .Take(pageCount)
                .Select(a => new EventViewPreview
                {
                    Id = a.Id,
                    Announce = a.Announce,
                    Headline = a.Headline,
                    DatePost = a.DatePost,
                    DateEnd = a.DateEnd,
                    DateStart = a.DateStart,
                    ImgIcon = a.ImgIcon,
                    PlacesCount = a.PlacesCount,
                    BusyPlacesCount = a.BusyPlacesCount
                })
                .ToListAsync();

            return Ok(events);
        }

        [HttpGet("api/event/{id}")]
        public async Task<IActionResult> GetAdditionalEducationById(int? id)
        {
            if (id == null)
                return BadRequest("Id is null");

            var @event = await context.Events.FirstOrDefaultAsync(a => a.Id == id);

            if (@event == null)
                return BadRequest("Additional Education not found");

            return Ok(new EventView
            {
                Id = @event.Id,
                Headline = @event.Headline,
                Announce = @event.Announce,
                Content = @event.Content,
                ImgPreview = @event.ImgPreview,
                DatePost = @event.DatePost,
                DateStart = @event.DateStart,
                DateEnd = @event.DateEnd,
                EventType = @event.EventType,
                BusyPlacesCount = @event.BusyPlacesCount,
                PlacesCount = @event.PlacesCount
            });
        }

        [HttpPost("api/postevent")]
        public async Task<IActionResult> PostEvent([FromBody] Event view)
        {
            if (ModelState.IsValid)
            {
                context.Events.Add(view);
                await context.SaveChangesAsync();
                return Ok(view);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("api/putevent")]
        public async Task<IActionResult> PutEvent([FromBody] Event view)
        {
            if (ModelState.IsValid)
            {
                context.Update(view);
                await context.SaveChangesAsync();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("api/deleteeventwbyid/{id}")]
        public async Task<IActionResult> DeleteEvent(int? id)
        {
            if (id is null) return BadRequest("Id is null");

            var @event = await context.Events.FirstOrDefaultAsync(e => e.Id == id);

            if (@event is null) return BadRequest("New not found");

            context.Events.Remove(@event);
            await context.SaveChangesAsync();

            return Ok(@event);
        }
    }
}