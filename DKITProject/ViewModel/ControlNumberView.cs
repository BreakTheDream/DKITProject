using DKITProject.DAL.Models;

namespace DKITProject.ViewModel
{
    public class ControlNumberView
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int SpecialtyId { get; set; }
        public string SpecialtyName { get; set; } 
    }
}