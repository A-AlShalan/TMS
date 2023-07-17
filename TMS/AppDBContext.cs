using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TMS
{
	public class AppDBContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public AppDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
        {
            var connectionstring = _configuration.GetConnectionString("database");
            modelBuilder.UseNpgsql(connectionstring);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converterPriority = new EnumToStringConverter<Priority>();
            var converterTaskStatus = new EnumToStringConverter<TaskStatus>();

            modelBuilder
                .Entity<Tasks>()
                .Property(e => e.Priority)
                .HasConversion(converterPriority);
            modelBuilder
                .Entity<Tasks>()
                .Property(e => e.TaskStatus)
                .HasConversion(converterTaskStatus);
        }

        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TasksList> TasksLists { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Loggings> Loggings { get; set; }

    }
}

