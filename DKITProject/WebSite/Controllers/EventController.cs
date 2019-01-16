using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DKITProject.DAL;
using DKITProject.ViewModel;
using Microsoft.EntityFrameworkCore;
using DKITProject.Enums;

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
        public IActionResult GetAdditionalEducations(EventTypes type, int pageNumber = 1)
        {
            var events = context.Events
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
                    Count = a.Count
                })
                .ToList();

            return Ok(events);
        }

        [HttpGet("api/event/{id}")]
        public IActionResult GetAdditionalEducationById(int id)
        {
            if (id == null)
                return BadRequest("Id is null");

            var @event = context.Events.FirstOrDefault(a => a.Id == id);

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
                Count = @event.Count,
                EventType = @event.EventType
            });
        }
    }
}