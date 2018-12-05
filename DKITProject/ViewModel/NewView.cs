using System;

namespace DKITProject.ViewModel
{
    public class NewView
    {
        public int Id { get; set; }
        public string Headline { get; set; }
        public string Announce { get; set; }
        public string Content { get; set; }
        public string ImgPreview { get; set; }
        public string[] Images { get; set; }
        public DateTime DatePost { get; set; }
    }
}