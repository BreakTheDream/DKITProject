using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DKITProject.DAL;
using Microsoft.AspNetCore.Authorization;

namespace DKITProject.Administration.Controllers
{
    public class SpecialtiesAdministrationController : Controller
    {
        private ApplicationContext context;

        public SpecialtiesAdministrationController(ApplicationContext _context)
        {
            context = _context;
        }
    }
}
