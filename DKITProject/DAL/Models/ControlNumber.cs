namespace DKITProject.DAL.Models
{
    public class ControlNumber
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }
    }
}