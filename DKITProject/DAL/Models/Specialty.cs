namespace DKITProject.DAL.Models
{
    public class Specialty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Announce { get; set; }
        public string Content { get; set; }
        public string ImgIcon { get; set; }
        public string ImgPreview { get; set; }
        public int ControlNumberId { get; set; }
        public ControlNumber ControlNumber { get; set; }
    }
}