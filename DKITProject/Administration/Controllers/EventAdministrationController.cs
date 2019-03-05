using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DKITProject.DAL;
using Microsoft.EntityFrameworkCore;
using DKITProject.DAL.Models;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize]
        [HttpPut("api/putevent")]
        public async Task<IActionResult> PutEvent([FromBody] Event view)
        {
            if (ModelState.IsValid)
            {
                context.Update(view);
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
