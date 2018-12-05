namespace DKITProject.DAL.Models
{
    public class AdditionalEducationParticipant
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } 
        public string AdditionalEducationId { get; set; }
        public AdditionalEducation AdditionalEducation { get; set; }
    }
}