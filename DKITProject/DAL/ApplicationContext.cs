using Microsoft.EntityFrameworkCore;
using DKITProject.DAL.Models;

namespace DKITProject.DAL
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<ControlNumber> ControlNumbers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<TimetableType> TimetableTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}