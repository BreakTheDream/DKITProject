using System.Collections.Generic;

namespace DKITProject.ViewModel
{
    public class AchievementView
    {
        public int Id { get; set; }
        public string Headline { get; set; }
        public string Announce { get; set; }
        public string ImgPreview { get; set; }
        public string Content { get; set; }
        public ICollection<string> Images { get; set; }
        //public string Images { get; set; }
    }
}