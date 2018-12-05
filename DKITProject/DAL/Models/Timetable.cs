namespace DKITProject.DAL.Models
{
    public class Timetable
    {
        public int Id { get; set; }
        public string Img { get; set; }
        public int TimetableTypeId { get; set; }
        public TimetableType TimetableType { get; set; }
    }
}