using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DKITProject.DAL;
using DKITProject.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using DKITProject.ViewModel;

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
        public async Task<IActionResult> PostNew([FromBody] AdministrationNewViewModel view)
        {
            if (ModelState.IsValid)
            {
                context.News.Add(new New
                {
                    Content = view.Content,
                    Approved = view.Approved,
                    DatePost = view.DatePost,
                    Headline = view.Headline,
                    Images = view.Images,
                    ImgPreview = view.ImgPreview
                });
                await context.SaveChangesAsync();
                return Ok(view);
            }
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpPut("api/putnew")]
        public async Task<IActionResult> PutNew([FromBody] AdministrationNewViewModel view)
        {
            if (ModelState.IsValid)
            {
                New @new = await context.News.FirstOrDefaultAsync(e => e.Id == view.Id);

                @new.Content = view.Content;
                @new.Approved = view.Approved;
                @new.DatePost = view.DatePost;
                @new.Headline = view.Headline;
                @new.Images = view.Images;
                @new.ImgPreview = view.ImgPreview;

                context.News.Update(@new);
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
