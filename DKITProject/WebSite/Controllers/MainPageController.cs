using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DKITProject.DAL;
using DKITProject.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DKITProject.WebSite.Controllers
{
    [Route("api/mainpageinfo")]
    public class MainPageController : Controller
    {
        private ApplicationContext context;
        private const int countItems = 5;
        private ILogger logger;

        public MainPageController(ApplicationContext _context, ILoggerFactory loggerFactory)
        {
            context = _context;
            logger = loggerFactory.CreateLogger("FileLogger");
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
            try
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

                if (news == null)
                    throw new NullReferenceException();

                return news;
            } 
            catch (Exception exception)
            {
                logger.LogInformation(exception, "Exception in GetNews method:" + exception.Message, null);
                return Task.FromResult<List<NewViewPreview>>(null);
            }
        }

        public Task<List<SpecialtyViewPreview>> GetSpecialties()
        {
            try
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

                if (specialties == null)
                    throw new NullReferenceException();

                return specialties;
            }
            catch (Exception exception)
            {
                logger.LogInformation(exception, "Exception in GetSpecialties method:" + exception.Message, null);
                return Task.FromResult<List<SpecialtyViewPreview>>(null);
            }
        }

        public Task<List<PartnerView>> GetPartners() 
        {
            try
            {
                var partners = context.Partners.Select(p => new PartnerView
                {
                    Img = p.Img
                })
                .ToListAsync();

                if (partners == null)
                    throw new NullReferenceException();

                return partners;
            }
            catch (Exception exception)
            {
                logger.LogInformation(exception, "Exception in GetPartners method:" + exception.Message, null);
                return Task.FromResult<List<PartnerView>>(null);
            }
        }

        public Task<List<CertificateView>> GetCertificates() 
        {
            try
            {
                var certificates = context.Certificates.Select(c => new CertificateView
                {
                    Img = c.Img
                })
                .ToListAsync();

                if (certificates == null)
                    throw new NullReferenceException();

                return certificates;
            } 
            catch (Exception exception)
            {
                logger.LogInformation(exception, "Exception in GetCertificates method:" + exception.Message, null);
                return Task.FromResult<List<CertificateView>>(null);
            }
        }
    }
}