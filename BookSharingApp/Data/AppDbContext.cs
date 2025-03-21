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

            modelBuilder.Entity<CategoryModel>().HasData(new CategoryModel { Id = 1, Name = "Fiction", Description = "Novels, short stories, and literary works", IsActive = true },
            new CategoryModel { Id = 2, Name = "Non-Fiction", Description = "Biographies, self-help, history, and factual books", IsActive = true },
            new CategoryModel { Id = 3, Name = "Science", Description = "Physics, chemistry, biology, and scientific research", IsActive = true },
            new CategoryModel { Id = 4, Name = "Technology", Description = "Programming, IT, and tech-related topics", IsActive = true },
            new CategoryModel { Id = 5, Name = "History", Description = "World history, wars, and civilizations", IsActive = true },
            new CategoryModel { Id = 6, Name = "Philosophy", Description = "Ethics, metaphysics, and philosophical works", IsActive = true },
            new CategoryModel { Id = 7, Name = "Mystery & Thriller", Description = "Crime, detective, and suspense novels", IsActive = true },
            new CategoryModel { Id = 8, Name = "Romance", Description = "Love stories and romantic fiction", IsActive = true },
            new CategoryModel { Id = 9, Name = "Fantasy", Description = "Mythical, magical, and supernatural books", IsActive = true },
            new CategoryModel { Id = 10, Name = "Children", Description = "Kids books, fairy tales, and young readers", IsActive = true },
            new CategoryModel { Id = 11, Name = "Science Fiction", Description = "Futuristic, space, and technological adventures", IsActive = true },
            new CategoryModel { Id = 12, Name = "Horror", Description = "Scary, supernatural, and horror stories", IsActive = true },
            new CategoryModel { Id = 13, Name = "Biography & Memoir", Description = "Stories of real-life people", IsActive = true },
            new CategoryModel { Id = 14, Name = "Self-Help", Description = "Personal development, motivation, and guidance", IsActive = true },
            new CategoryModel { Id = 15, Name = "Business & Finance", Description = "Entrepreneurship, investing, and business strategies", IsActive = true },
            new CategoryModel { Id = 16, Name = "Psychology", Description = "Mental health, therapy, and psychology books", IsActive = true },
            new CategoryModel { Id = 17, Name = "Health & Wellness", Description = "Fitness, nutrition, and healthy living", IsActive = true },
            new CategoryModel { Id = 18, Name = "Religion & Spirituality", Description = "Books on faith, beliefs, and religious studies", IsActive = true },
            new CategoryModel { Id = 19, Name = "Poetry", Description = "Collections of poetry and lyrical works", IsActive = true },
            new CategoryModel { Id = 20, Name = "Comics & Graphic Novels", Description = "Superheroes, manga, and illustrated stories", IsActive = true },
            new CategoryModel { Id = 21, Name = "Education", Description = "Textbooks, academic, and educational resources", IsActive = true },
            new CategoryModel { Id = 22, Name = "Cooking", Description = "Cookbooks, recipes, and culinary arts", IsActive = true },
            new CategoryModel { Id = 23, Name = "Travel", Description = "Travel guides, adventure books, and tourism", IsActive = true },
            new CategoryModel { Id = 24, Name = "Sports", Description = "Books on various sports, fitness, and athletes", IsActive = true },
            new CategoryModel { Id = 25, Name = "Politics", Description = "Government, policies, and political science", IsActive = true }
            );

            modelBuilder.Entity<LanguageModel>().HasData(
                // **Indian Languages (Prioritized)**:
                new LanguageModel { Id = 1, Code = "hi", Name = "Hindi", IsActive = true },
                new LanguageModel { Id = 2, Code = "en", Name = "English", IsActive = true },
                new LanguageModel { Id = 3, Code = "ta", Name = "Tamil", IsActive = true },
                new LanguageModel { Id = 4, Code = "te", Name = "Telugu", IsActive = true },
                new LanguageModel { Id = 5, Code = "kn", Name = "Kannada", IsActive = true },
                new LanguageModel { Id = 6, Code = "ml", Name = "Malayalam", IsActive = true },
                new LanguageModel { Id = 7, Code = "gu", Name = "Gujarati", IsActive = true },
                new LanguageModel { Id = 8, Code = "mr", Name = "Marathi", IsActive = true },
                new LanguageModel { Id = 9, Code = "bn", Name = "Bengali", IsActive = true },
                new LanguageModel { Id = 10, Code = "pa", Name = "Punjabi", IsActive = true },
                new LanguageModel { Id = 11, Code = "or", Name = "Odia", IsActive = true },
                new LanguageModel { Id = 12, Code = "as", Name = "Assamese", IsActive = true },
                new LanguageModel { Id = 13, Code = "ur", Name = "Urdu", IsActive = true },
                new LanguageModel { Id = 14, Code = "sa", Name = "Sanskrit", IsActive = true },
                new LanguageModel { Id = 15, Code = "ks", Name = "Kashmiri", IsActive = true },
                new LanguageModel { Id = 16, Code = "sd", Name = "Sindhi", IsActive = true },
                new LanguageModel { Id = 17, Code = "mni", Name = "Manipuri (Meitei)", IsActive = true },
                new LanguageModel { Id = 18, Code = "bho", Name = "Bhojpuri", IsActive = true },
                new LanguageModel { Id = 19, Code = "mai", Name = "Maithili", IsActive = true },

                // **Major Global Languages**:
                new LanguageModel { Id = 20, Code = "es", Name = "Spanish", IsActive = true },
                new LanguageModel { Id = 21, Code = "fr", Name = "French", IsActive = true },
                new LanguageModel { Id = 22, Code = "de", Name = "German", IsActive = true },
                new LanguageModel { Id = 23, Code = "zh", Name = "Chinese (Mandarin)", IsActive = true },
                new LanguageModel { Id = 24, Code = "ja", Name = "Japanese", IsActive = true },
                new LanguageModel { Id = 25, Code = "ru", Name = "Russian", IsActive = true },
                new LanguageModel { Id = 26, Code = "it", Name = "Italian", IsActive = true },
                new LanguageModel { Id = 27, Code = "pt", Name = "Portuguese", IsActive = true },
                new LanguageModel { Id = 28, Code = "ar", Name = "Arabic", IsActive = true },
                new LanguageModel { Id = 29, Code = "ko", Name = "Korean", IsActive = true },

                // **Regional/Popular Languages Across Continents**:
                new LanguageModel { Id = 30, Code = "sw", Name = "Swahili", IsActive = true },
                new LanguageModel { Id = 31, Code = "nl", Name = "Dutch", IsActive = true },
                new LanguageModel { Id = 32, Code = "tr", Name = "Turkish", IsActive = true },
                new LanguageModel { Id = 33, Code = "vi", Name = "Vietnamese", IsActive = true },
                new LanguageModel { Id = 34, Code = "th", Name = "Thai", IsActive = true },
                new LanguageModel { Id = 35, Code = "pl", Name = "Polish", IsActive = true },
                new LanguageModel { Id = 36, Code = "fa", Name = "Persian (Farsi)", IsActive = true },
                new LanguageModel { Id = 37, Code = "sv", Name = "Swedish", IsActive = true },
                new LanguageModel { Id = 38, Code = "uk", Name = "Ukrainian", IsActive = true },
                new LanguageModel { Id = 39, Code = "he", Name = "Hebrew", IsActive = true },

                // **More Indian Regional and Tribal Languages**:
                new LanguageModel { Id = 40, Code = "raj", Name = "Rajasthani", IsActive = true },
                new LanguageModel { Id = 41, Code = "ne", Name = "Nepali", IsActive = true },
                new LanguageModel { Id = 42, Code = "tulu", Name = "Tulu", IsActive = true },
                new LanguageModel { Id = 43, Code = "bhb", Name = "Bhil", IsActive = true },
                new LanguageModel { Id = 44, Code = "santali", Name = "Santali", IsActive = true },
                new LanguageModel { Id = 45, Code = "ho", Name = "Ho", IsActive = true },
                new LanguageModel { Id = 46, Code = "kur", Name = "Kumaoni", IsActive = true },

                // **Less Common Global Languages**:
                new LanguageModel { Id = 47, Code = "no", Name = "Norwegian", IsActive = true },
                new LanguageModel { Id = 48, Code = "da", Name = "Danish", IsActive = true },
                new LanguageModel { Id = 49, Code = "fi", Name = "Finnish", IsActive = true },
                new LanguageModel { Id = 50, Code = "hu", Name = "Hungarian", IsActive = true }
                );
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ClubModel> Clubs { get; set; }
        public DbSet<ClubUsersModel> ClubUsers { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<LanguageModel> Languages { get; set; }
    }
}
