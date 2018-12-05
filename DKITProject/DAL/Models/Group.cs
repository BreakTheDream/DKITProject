namespace DKITProject.DAL.Models 
{
    public class Group 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User[] Users { get; set; } 
    }
}
    
