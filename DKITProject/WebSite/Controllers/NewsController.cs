using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DKITProject.DAL;
using DKITProject.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Web;

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

        [HttpGet("api/newslist/{pages}")]
        public IActionResult GetNewsList(int pages = 1) {
            var news = context.News.Where(n => n.Approved)
                .OrderByDescending(n => n.DatePost)
                .Skip(pageCount * (1 - 1))
                .Take(pageCount)
                .Select(n => new NewViewPreview
                {
                    Id = n.Id,
                    Announce = n.Announce,
                    Headline = n.Headline,
                    DatePost = n.DatePost,
                    ImgPreview = n.ImgPreview
                })
                .ToList();

            return Ok(news);
        }

    }
}