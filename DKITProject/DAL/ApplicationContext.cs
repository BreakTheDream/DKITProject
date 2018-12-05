using Microsoft.EntityFrameworkCore;
using DKITProject.DAL.Models;

namespace DKITProject.DAL
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<AdditionalEducation> AdditionalEducations { get; set; }
        public DbSet<AdditionalEducationParticipant> AdditionalEducationParticipants { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<ControlNumber> ControlNumbers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<TimetableType> TimetableTypes { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<WorkshopParticipant> WorkshopParticipants { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}