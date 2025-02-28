using BookSharingApp.Models;
using BookSharingApp.Services;
using Microsoft.EntityFrameworkCore;

namespace BookSharingApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { Id = 1, Name = "Admin", Mobile = "+91 8989258867", Email = "sarthak.vadgama.hs@gmail.com", Password = "admin123", CreatedAt = DateTime.Parse("2025-02-21 10:35:14.370"), IsActive = true, MFA = true, Points = 0, Profile = "default.jpg", ResetToken = "", LastLogIn = null, UpdatedAt = DateTime.Parse("2025-02-21 10:35:14.370") }
                );

            modelBuilder.Entity<ClubModel>().HasData(
                    new ClubModel { Id = 1, Name = "Book Club", IsActive = true, Location = "", Logo = "default.jpg", CreatedAt = DateTime.Parse("2025-02-21 10:35:14.370"), UpdatedAt = DateTime.Parse("2025-02-21 10:35:14.370") }, new ClubModel { Id = 2, Name = "Magazine Club", IsActive = true, Location = "", Logo = "default.jpg", CreatedAt = DateTime.Parse("2025-02-21 10:35:14.370"), UpdatedAt = DateTime.Parse("2025-02-21 10:35:14.370") }, new ClubModel { Id = 3, Name = "Paper Club", IsActive = true, Location = "Badmosh", Logo = "default.jpg", CreatedAt = DateTime.Parse("2025-02-21 10:35:14.370"), UpdatedAt = DateTime.Parse("2025-02-21 10:35:14.370") }
                );

            modelBuilder.Entity<ClubUsersModel>().HasData(
                new ClubUsersModel { Id = 1, ClubId = 1, UserId = 1, Role = "admin", IsActive = true, CreatedAt = DateTime.Parse("2025-02-21 10:35:14.370"), UpdatedAt = DateTime.Parse("2025-02-21 10:35:14.370") },
            new ClubUsersModel { Id = 2, ClubId = 2, UserId = 1, Role = "admin", IsActive = true, CreatedAt = DateTime.Parse("2025-02-21 10:35:14.370"), UpdatedAt = DateTime.Parse("2025-02-21 10:35:14.370") },
            new ClubUsersModel { Id = 3, ClubId = 3, UserId = 1, Role = "clubadmin", IsActive = true, CreatedAt = DateTime.Parse("2025-02-21 10:35:14.370"), UpdatedAt = DateTime.Parse("2025-02-21 10:35:14.370") }
                );
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ClubModel> Clubs { get; set; }
        public DbSet<ClubUsersModel> ClubUsers { get; set; }
    }
}
