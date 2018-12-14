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
    public class AdditionalEducationController : Controller
    {
        private ApplicationContext context;
        private const int pageCount = 3;

        public AdditionalEducationController(ApplicationContext _context)
        {
            context = _context;
        }

        [HttpGet("api/additionaleducation/{pageNumber}")]
        public IActionResult GetAdditionalEducations(int pageNumber = 1) 
        {
            var additionaleducations = context.AdditionalEducations
                .OrderByDescending(a => a.DatePost)
                .Skip(pageCount * (pageNumber - 1))
                .Take(pageCount)
                .Select(a => new AdditionalEducationViewPreview 
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
            
            return Ok(additionaleducations);
        }

        [HttpGet("api/additionaleducation/{id}")]
        public IActionResult GetAdditionalEducationById(int id) 
        {
            if(id == null) 
                return BadRequest("Id is null");
            
            var additionalEducation = context.AdditionalEducations.FirstOrDefault(a => a.Id == id);

            if(additionalEducation == null)
                return BadRequest("Additional Education not found");

            return Ok(new AdditionalEducationView 
            {
                Id = additionalEducation.Id,
                Headline = additionalEducation.Headline,
                Announce = additionalEducation.Announce,
                Content = additionalEducation.Content,
                ImgPreview = additionalEducation.ImgPreview,
                DatePost = additionalEducation.DatePost,
                DateStart = additionalEducation.DateStart,
                DateEnd = additionalEducation.DateEnd,
                Count = additionalEducation.Count
            });
        }
    }
}