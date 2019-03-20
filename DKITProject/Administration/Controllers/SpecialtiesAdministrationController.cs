using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DKITProject.DAL;
using Microsoft.AspNetCore.Authorization;
using DKITProject.DAL.Models;
using DKITProject.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


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
        [HttpGet("api/administration/getspecialitybyid/{id}")]
        public async Task<IActionResult> GetSpecialityById(int? id)
        {
            if (id == null)
                return BadRequest("Id is null");

            var specialities = context.Specialties.Include(s => s.ControlNumber);

            Specialty specialty = await specialities
                .FirstOrDefaultAsync(e => e.Id == id);

            if (specialty is null)
                return BadRequest("New not found");

            return Ok(new AdministrationSpecialtyViewModel
            {
                Id = specialty.Id,
                Announce = specialty.Announce,
                Content = specialty.Content,
                ImgIcon = specialty.ImgIcon,
                Name = specialty.Name,
                ControlNumberId = specialty.ControlNumber.Id,
                ControlNumber = specialty.ControlNumber.Count
            });
        }

        [Authorize]
        [HttpPost("api/administration/postspeciality")]
        public async Task<IActionResult> PostSpecialty([FromBody] AdministrationSpecialtyViewModel view)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Specialty specialty = new Specialty
            {
                Announce = view.Announce,
                Content = view.Announce,
                ImgIcon = view.ImgIcon,
                Name = view.Name
            };

            var newSpeciality = await context.Specialties.AddAsync(specialty);

            ControlNumber controlNumber = new ControlNumber
            {
                Count = view.ControlNumber,
                SpecialtyId = newSpeciality.Entity.Id
            };

            await context.ControlNumbers.AddAsync(controlNumber);
            await context.SaveChangesAsync();

            return Ok(true);
        }

        [Authorize]
        [HttpPut("api/administration/putspeciality")]
        public async Task<IActionResult> PutSpecialty([FromBody] AdministrationSpecialtyViewModel view)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Specialty specialty = new Specialty
            {
                Id = view.Id,
                Announce = view.Announce,
                Content = view.Content,
                ImgIcon = view.ImgIcon,
                Name = view.Name
            };

            ControlNumber controlNumber = new ControlNumber
            {
                Id = view.ControlNumberId,
                Count = view.ControlNumber,
                SpecialtyId = view.Id
            };

            context.Specialties.Update(specialty);
            context.ControlNumbers.Update(controlNumber);

            await context.SaveChangesAsync();
            return Ok(true);
        }

        [Authorize]
        [HttpDelete("api/administration/deletespecialitybyid/{id}")]
        public async Task<IActionResult> DeleteSpecialty(int? id)
        {
            if (id is null)
                return BadRequest("Id is null");

            Specialty specialty = await context.Specialties.FirstOrDefaultAsync(e => e.Id == id);

            if (specialty is null)
                return BadRequest("New not found");

            context.Specialties.Remove(specialty);
            await context.SaveChangesAsync();

            return Ok(true);
        }
    }
}
