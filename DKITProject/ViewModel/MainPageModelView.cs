using System.Collections.Generic;

namespace DKITProject.ViewModel
{
    public class MainPageModelView
    {
        public ICollection<SpecialtyViewPreview> Specialties { get; set; }
        public ICollection<NewViewPreview> News { get; set; }
        public ICollection<PartnerView> Partners { get; set; }
        public ICollection<CertificateView> Certificates { get; set; }
    }
}