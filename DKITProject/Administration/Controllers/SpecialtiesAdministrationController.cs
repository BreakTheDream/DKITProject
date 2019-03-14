using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DKITProject.DAL;
using Microsoft.AspNetCore.Authorization;
using DKITProject.ViewModel;
using DKITProject.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DKITProject.Administration.Controllers
{
    public class SpecialtiesAdministrationController : Controller
    {
        private ApplicationContext context;

        public SpecialtiesAdministrationController(ApplicationContext _context)
        {
            context = _context;
        }

        [Authorize]
        [HttpPost("api/postspecialty")]
        public async Task<IActionResult> PostSpecialty([FromBody] AdministrationSpecialtyViewModel view)
        {
            if (ModelState.IsValid)
            {
                context.Specialties.Add(new Specialty
                {
                    Announce = view.Announce,
                    Content = view.Content,
                    ImgIcon = view.ImgIcon,
                    ImgPreview = view.ImgPreview,
                    Name = view.Name
                });
                await context.SaveChangesAsync();
                return Ok(view);
            }
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpPut("api/putspecialty")]
        public async Task<IActionResult> PutSpecialty([FromBody] AdministrationSpecialtyViewModel view)
        {
            if (ModelState.IsValid)
            {
                Specialty specialty = await context.Specialties.FirstOrDefaultAsync(e => e.Id == view.Id);

                specialty.ImgIcon = view.ImgIcon;
                specialty.ImgPreview = view.ImgPreview;
                specialty.Name = view.Name;
                specialty.Content = view.Content;
                specialty.Announce = view.Announce;

                context.Specialties.Update(specialty);
                await context.SaveChangesAsync();
            }
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpDelete("api/deletespecialtybyid/{id}")]
        public async Task<IActionResult> DeleteSpecialty(int? id)
        {
            if (id is null) return BadRequest("Id is null");

            Specialty specialty = await context.Specialties.FirstOrDefaultAsync(e => e.Id == id);

            if (specialty is null) return BadRequest("New not found");

            context.Specialties.Remove(specialty);
            await context.SaveChangesAsync();

            return Ok(specialty);
        }
    }
}
