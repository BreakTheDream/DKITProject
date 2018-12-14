using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DKITProject.DAL;
using DKITProject.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DKITProject.WebSite.Controllers
{
    public class WorkshopsController : Controller
    {
        private ApplicationContext context;
        private const int pageCount = 3;

        public WorkshopsController(ApplicationContext _context) 
        {
            context = _context;
        }

        [HttpGet("api/workshopslist/{pageNumber}")]
        public IActionResult GetWorkshopsList(int pageNumber = 1)
        {
            var workshops = context.Workshops.OrderByDescending(w => w.DatePost)
                .Skip(pageCount * (pageNumber - 1))
                .Take(pageCount)
                .Select(w => new WorkshopViewPreview 
                {
                    Id = w.Id,
                    Announce = w.Announce,
                    Headline = w.Headline,
                    DatePost = w.DatePost,
                    DateEnd = w.DateEnd,
                    DateStart = w.DateStart,
                    ImgIcon = w.ImgIcon,
                    Count = w.Count
                    
                })
                .ToList();

            return Ok(workshops);
        }

        [HttpGet("api/workshopbyid/{id}")]
        public IActionResult GetWorkshopById(int id) 
        {
            if(id == null)
                return BadRequest("Id is null");

            var workshop = context.Workshops.FirstOrDefault(w => w.Id == id);

            if(workshop == null)
                return BadRequest("Workshop not found");

            return Ok(new WorkshopView
            {
                Id = workshop.Id,
                Headline = workshop.Headline,
                Announce = workshop.Announce,
                Content = workshop.Content,
                ImgPreview = workshop.ImgPreview,
                DatePost = workshop.DatePost,
                DateStart = workshop.DateStart,
                DateEnd = workshop.DateEnd,
                Count = workshop.Count
            });
        }
    }
}