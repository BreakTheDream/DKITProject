using System;
using System.Collections.Generic;

namespace DKITProject.ViewModel
{
    public class NewView
    {
        public int Id { get; set; }
        public string Headline { get; set; }
        public string Content { get; set; }
        public string ImgPreview { get; set; }
        public ICollection<string> Images { get; set; }
        public DateTime DatePost { get; set; }
    }

    public class NewViewPreview 
    {
        public int Id { get; set; }
        public string Headline { get; set; }
        public string Content { get; set; }
        public string ImgPreview { get; set; }
        public DateTime DatePost { get; set; }
    }
}