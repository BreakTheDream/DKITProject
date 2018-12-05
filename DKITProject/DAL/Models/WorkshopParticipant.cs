namespace DKITProject.DAL.Models
{
    public class WorkshopParticipant
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } 
        public string WorkshopId { get; set; }
        public Workshop Workshop { get; set; }
    }
}