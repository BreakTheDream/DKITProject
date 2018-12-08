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
            ICollection<WorkshopViewPreview> workshops = await GetWorkshops();
            ICollection<AdditionalEducationViewPreview> additionalEducations = await GetAdditionalEducations();
            ICollection<PartnerView> partners = await GetPartners();
            ICollection<CertificateView> certificates = await GetCertificates();

            MainPageModelView mainPaigInfo = new MainPageModelView
            {
                News = news,
                Specialties = specialties,
                Workshops = workshops,
                Certificates = certificates,
                Partners = partners,
                AdditionalEducation = additionalEducations

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
                    Announce = n.Announce,
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

        public Task<List<WorkshopViewPreview>> GetWorkshops()
        {
            var workshops = context.Workshops.OrderByDescending(w => w.DatePost)
                .Take(countItems).Select(w => new WorkshopViewPreview
                {
                    Id = w.Id,
                    Headline = w.Headline,
                    Announce = w.Announce,
                    ImgIcon = w.ImgIcon,
                    DatePost = w.DatePost,
                    DateStart = w.DateStart,
                    DateEnd = w.DateEnd,
                    Count = w.Count
                })
                .ToListAsync();
            
            return workshops;
        }

        public Task<List<AdditionalEducationViewPreview>> GetAdditionalEducations()
        {
            var additionalEducations = context.AdditionalEducations
                .Select(a => new AdditionalEducationViewPreview {
                    Id = a.Id,
                    Headline = a.Headline,
                    Announce = a.Announce,
                    ImgIcon = a.ImgIcon,
                    DatePost = a.DatePost,
                    DateStart = a.DateStart,
                    DateEnd = a.DateEnd,
                    Count = a.Count
                })
                .ToListAsync();

            return additionalEducations;
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