using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer
{
    public partial class HivDbContext : DbContext
    {
        public HivDbContext() { }

        public HivDbContext(DbContextOptions<HivDbContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<DoctorProfile> DoctorProfiles { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<HealthRecord> HealthRecords { get; set; } = null!;
        public virtual DbSet<TestResult> TestResults { get; set; } = null!;
        public virtual DbSet<Regimen> Regimens { get; set; } = null!;

        private string GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            return configuration.GetConnectionString("HivDatabase");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.Id);
            modelBuilder.Entity<Role>().HasKey(e => e.Id);
            modelBuilder.Entity<DoctorProfile>().HasKey(e => e.Id);
            modelBuilder.Entity<Schedule>().HasKey(e => e.Id);
            modelBuilder.Entity<HealthRecord>().HasKey(e => e.Id);
            modelBuilder.Entity<TestResult>().HasKey(e => e.Id);
            modelBuilder.Entity<Regimen>().HasKey(e => e.Id);
        }
    }
}
