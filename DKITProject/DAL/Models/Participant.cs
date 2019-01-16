using DKITProject.DAL;
using DKITProject.Enums;

namespace DKITProject.DAL.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public EventTypes EventType { get; set; }
    }
}
