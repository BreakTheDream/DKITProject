using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DKITProject.DAL;
using Microsoft.EntityFrameworkCore;
using DKITProject.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using DKITProject.ViewModel;

namespace DKITProject.Administration.Controllers
{
    public class EventAdministrationController : Controller
    {
        private ApplicationContext context;

        public EventAdministrationController(ApplicationContext _context)
        {
            context = _context;
        }

        [Authorize]
        [HttpPost("api/postevent")]
        public async Task<IActionResult> PostEvent([FromBody] AdministrationEventViewModel view)
        {
            if (ModelState.IsValid)
            {
                context.Events.Add(new Event
                {
                    ImgIcon = view.ImgIcon,
                    ImgPreview = view.ImgPreview,
                    Headline = view.Headline,
                    Content = view.Content,
                    Announce = view.Announce,
                    DateEnd = view.DateEnd,
                    DatePost = view.DatePost,
                    DateStart = view.DateStart,
                    EventType = view.EventType
                });
                await context.SaveChangesAsync();
                return Ok(view);
            }
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpPut("api/putevent")]
        public async Task<IActionResult> PutEvent([FromBody] AdministrationEventViewModel view)
        {
            if (ModelState.IsValid)
            {
                Event @event = await context.Events.FirstOrDefaultAsync(e => e.Id == view.Id);

                @event.ImgIcon = view.ImgIcon;
                @event.ImgPreview = view.ImgPreview;
                @event.Headline = view.Headline;
                @event.Content = view.Content;
                @event.Announce = view.Announce;
                @event.DateEnd = view.DateEnd;
                @event.DatePost = view.DatePost;
                @event.DateStart = view.DateStart;
                @event.EventType = view.EventType;

                context.Events.Update(@event);
                await context.SaveChangesAsync();
            }
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpDelete("api/deleteeventbyid/{id}")]
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
