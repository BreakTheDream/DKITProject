using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DKITProject.DAL;
using DKITProject.DAL.Models;
using Microsoft.AspNetCore.Authorization;

namespace DKITProject.Administration.Controllers
{
    public class NewsAdministrtationController : Controller
    {
        private ApplicationContext context;

        public NewsAdministrtationController(ApplicationContext _context)
        {
            context = _context;
        }

        [Authorize]
        [HttpPost("api/postnew")]
        public async Task<IActionResult> PostNew([FromBody] New view)
        {
            if (ModelState.IsValid)
            {
                context.News.Add(view);
                await context.SaveChangesAsync();
                return Ok(view);
            }
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpPut("api/putnew")]
        public async Task<IActionResult> PutNew([FromBody] New view)
        {
            if (ModelState.IsValid)
            {
                context.Update(view);
                await context.SaveChangesAsync();
            }
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpDelete("api/deletenewbyid/{id}")]
        public async Task<IActionResult> DeleteNew(int? id)
        {
            if (id is null) return BadRequest("Id is null");

            var @new = await context.News.FirstOrDefaultAsync(e => e.Id == id);

            if (@new is null) return BadRequest("New not found");

            context.News.Remove(@new);
            await context.SaveChangesAsync();

            return Ok(@new);
        }
    }
}
