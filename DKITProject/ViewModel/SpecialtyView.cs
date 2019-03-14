namespace DKITProject.ViewModel
{
    public class SpecialtyView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Announce { get; set; }
        public string Content { get; set; }
        public string ImgIcon { get; set; }
    }

    public class SpecialtyViewPreview {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Announce { get; set; }
        public string ImgIcon { get; set; }
    }

    public class AdministrationSpecialtyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Announce { get; set; }
        public string Content { get; set; }
        public string ImgIcon { get; set; }
        public int ControlNumberId { get; set; }
        public int ControlNumber { get; set; }
    }
}