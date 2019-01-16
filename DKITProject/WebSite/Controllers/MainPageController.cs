using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DKITProject.DAL;
using DKITProject.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DKITProject.WebSite.Controllers
{
    [Route("api/mainpageinfo")]
    public class MainPageController : Controller
    {
        private ApplicationContext context;
        private const int countItems = 5;

        public MainPageController(ApplicationContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMainPageInfoAsync()
        {

            ICollection<SpecialtyViewPreview> specialties = await GetSpecialties();
            ICollection<NewViewPreview> news = await GetNews();
            ICollection<PartnerView> partners = await GetPartners();
            ICollection<CertificateView> certificates = await GetCertificates();

            MainPageModelView mainPaigInfo = new MainPageModelView
            {
                News = news,
                Specialties = specialties,
                Certificates = certificates,
                Partners = partners
            };

            return Ok(mainPaigInfo);
        }

        public Task<List<NewViewPreview>> GetNews()
        {
            var news = context.News.Where(n => n.Approved)
                .OrderByDescending(n => n.DatePost)
                .Take(countItems)
                .Select(n => new NewViewPreview
                {
                    Id = n.Id,
                    Content = n.Content,
                    Headline = n.Headline,
                    DatePost = n.DatePost,
                    ImgPreview = n.ImgPreview
                })
            .ToListAsync();

            return news;
        }

        public Task<List<SpecialtyViewPreview>> GetSpecialties()
        {
            var specialties = context.Specialties
                .Select(s => new SpecialtyViewPreview
                {
                    Id = s.Id,
                    Name = s.Name,
                    Announce = s.Announce,
                    ImgIcon = s.ImgIcon
                })
                .ToListAsync();

            return specialties;
        }

        public Task<List<PartnerView>> GetPartners() 
        {
            var partners = context.Partners.Select(p => new PartnerView 
            {
                Img = p.Img
            })
            .ToListAsync();

            return partners;
        }

        public Task<List<CertificateView>> GetCertificates() 
        {
            var certificates = context.Certificates.Select(c => new CertificateView
            {
                Img = c.Img
            })
            .ToListAsync();

            return certificates;
        }
    }
}