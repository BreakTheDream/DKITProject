using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DKITProject.DAL;
using DKITProject.ViewModel;

namespace DKITProject.WebSite.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationContext context;
        private const int pageCount = 3;

        public NewsController(ApplicationContext _context)
        {
            context = _context;
        }

        [HttpGet("api/newslist/{pageNumber}")]
        public async Task<IActionResult> GetNewsList(int pageNumber = 1)
        {
            var news = await context.News.Where(n => n.Approved)
                .OrderByDescending(n => n.DatePost)
                .Skip(pageCount * (pageNumber - 1))
                .Take(pageCount)
                .Select(n => new NewViewPreview
                {
                    Id = n.Id,
                    Content = n.Content,
                    Headline = n.Headline,
                    DatePost = n.DatePost,
                    ImgPreview = n.ImgPreview,
                    Views = n.Views
                })
                .ToListAsync();

            return Ok(news);
        }

        [HttpGet("api/newbyid/{id}")]
        public async Task<IActionResult> GetNewById(int? id)
        {
            if (id == null)
                return BadRequest("Id is null");

            var @new = await context.News.FirstOrDefaultAsync(n => n.Id == id);

            if (@new == null)
                return BadRequest("New not found");

            return Ok(new NewView
            {
                Id = @new.Id,
                Headline = @new.Headline,
                Content = @new.Content,
                ImgPreview = @new.ImgPreview,
                Images = @new.Images.Split(','),
                DatePost = @new.DatePost,
                Views = @new.Views
            });
        }
    }
}