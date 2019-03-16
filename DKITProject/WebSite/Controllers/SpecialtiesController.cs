using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DKITProject.DAL;
using DKITProject.ViewModel;

namespace DKITProject.WebSite.Controllers
{
    public class SpecialtiesController : Controller
    {
        private ApplicationContext context;
        private const int pageCount = 3;

        public SpecialtiesController(ApplicationContext _context)
        {
            context = _context;
        }

        [HttpGet("api/specialtieslist/{pageNumber}")]
        public IActionResult GetSpecialtiesList(int pageNumber = 1)
        {
            var specialties = context.Specialties
                .Select(s => new SpecialtyViewPreview
                {
                    Id = s.Id,
                    Announce = s.Announce,
                    Name = s.Name,
                    ImgIcon = s.ImgIcon
                })
                .ToList();
            
            return Ok(specialties);
        }

        [HttpGet("api/getspecialitybyid/{id}")]
        public IActionResult GetSpecialityByid(int? id) 
        {
            if(id == null)
                return BadRequest("Id is null");

            var specialty = context.Specialties.FirstOrDefault(s => s.Id == id);

            if(specialty == null)
                return BadRequest("Speciality not found");

            return Ok(new SpecialtyView
            {
                Id = specialty.Id,
                Name = specialty.Name,
                Content = specialty.Content,
                ImgIcon = specialty.ImgIcon,
                
            });
        }
    }
}