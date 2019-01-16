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

        [HttpGet("api/newslist/{pageNumber}")]
        public IActionResult GetNewsList(int pageNumber = 1) 
        {
            var news = context.News.Where(n => n.Approved)
                .OrderByDescending(n => n.DatePost)
                .Skip(pageCount * (pageNumber - 1))
                .Take(pageCount)
                .Select(n => new NewViewPreview
                {
                    Id = n.Id,
                    Content = n.Content,
                    Headline = n.Headline,
                    DatePost = n.DatePost,
                    ImgPreview = n.ImgPreview
                })
                .ToList();

            return Ok(news);
        }

        [HttpGet("api/newbyid/{id}")]
        public IActionResult GetNewById(int id)
        {
            if(id == null)
                return BadRequest("Id is null");

            var @new = context.News.FirstOrDefault(n => n.Id == id);

            if(@new == null)
                return BadRequest("New not found");

            return Ok(new NewView 
            {
                Id = @new.Id,
                Headline = @new.Headline,
                Content = @new.Content,
                ImgPreview = @new.ImgPreview,
                Images = @new.Images.Split(','),
                DatePost = @new.DatePost
            });
        }

    }
}