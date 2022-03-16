using E_Library_04.Model;
using Microsoft.EntityFrameworkCore;

namespace E_Library_04.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<SubjectManagement> SubjectManagement { get; set; }
        public DbSet<LessionManagement> LessionManagement { get; set; }
        public DbSet<ExamAndTestManagement> ExamAndTestManagement { get; set; }
        public DbSet<HelpManagement> HelpManagement { get; set; }
        public DbSet<NotificationManagement> NotificationManagement { get; set; }
        public DbSet<FileData> FileData { get; set; }
        public DbSet<SystemManagement> SystemManagement { get; set; }
        public DbSet<ResourceManagement> ResourceManagement { get; set; }
        public DbSet<Admin> Admin { get; set; }
    }
}

