using AngularApp_TT.Server.Models.Auth;
using AngularApp_TT.Server.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using AngularApp_TT.Models.Entity;



namespace AngularApp_TT.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = true;
        }

        public DbSet<Accounts> Account { get; set; }
        public DbSet<СryptoRate> СryptoRate { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Accounts>()
                .HasMany(a => a.UserHistoryList)
                .WithOne(c => c.Accounts)
                .HasForeignKey(c => c.AccountsId);

            SeedData(modelBuilder);

        }

        public void SeedData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Accounts>().HasData(new Accounts
            {
                Id = 1, // Убедитесь, что ID уникален и не конфликтует с уже существующими записями
                Email = "admin@example.com",
                Password = "admin",
                // UserHistoryList не нужно указывать при создании начальных данных
            });
        }
    }
}