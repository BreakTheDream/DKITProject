namespace DKITProject.DAL.Models 
{
    public class User 
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
    }
}
