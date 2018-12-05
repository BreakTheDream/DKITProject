using System;

namespace DKITProject.ViewModel
{
    public class AdditionalEducationView
    {
        public int Id { get; set; }
        public string Headline { get; set; }
        public string Announce { get; set; }
        public string Content { get; set; }
        public string ImgIcon { get; set; }
        public string ImgPreview { get; set; }
        public DateTime DatePost { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int Count { get; set; }
    }
}