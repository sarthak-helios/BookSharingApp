﻿// <auto-generated />
using System;
using BookSharingApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookSharingApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250321102006_Languagesdata")]
    partial class Languagesdata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookSharingApp.Models.CategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Novels, short stories, and literary works",
                            IsActive = true,
                            Name = "Fiction"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Biographies, self-help, history, and factual books",
                            IsActive = true,
                            Name = "Non-Fiction"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Physics, chemistry, biology, and scientific research",
                            IsActive = true,
                            Name = "Science"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Programming, IT, and tech-related topics",
                            IsActive = true,
                            Name = "Technology"
                        },
                        new
                        {
                            Id = 5,
                            Description = "World history, wars, and civilizations",
                            IsActive = true,
                            Name = "History"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Ethics, metaphysics, and philosophical works",
                            IsActive = true,
                            Name = "Philosophy"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Crime, detective, and suspense novels",
                            IsActive = true,
                            Name = "Mystery & Thriller"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Love stories and romantic fiction",
                            IsActive = true,
                            Name = "Romance"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Mythical, magical, and supernatural books",
                            IsActive = true,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Kids books, fairy tales, and young readers",
                            IsActive = true,
                            Name = "Children"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Futuristic, space, and technological adventures",
                            IsActive = true,
                            Name = "Science Fiction"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Scary, supernatural, and horror stories",
                            IsActive = true,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 13,
                            Description = "Stories of real-life people",
                            IsActive = true,
                            Name = "Biography & Memoir"
                        },
                        new
                        {
                            Id = 14,
                            Description = "Personal development, motivation, and guidance",
                            IsActive = true,
                            Name = "Self-Help"
                        },
                        new
                        {
                            Id = 15,
                            Description = "Entrepreneurship, investing, and business strategies",
                            IsActive = true,
                            Name = "Business & Finance"
                        },
                        new
                        {
                            Id = 16,
                            Description = "Mental health, therapy, and psychology books",
                            IsActive = true,
                            Name = "Psychology"
                        },
                        new
                        {
                            Id = 17,
                            Description = "Fitness, nutrition, and healthy living",
                            IsActive = true,
                            Name = "Health & Wellness"
                        },
                        new
                        {
                            Id = 18,
                            Description = "Books on faith, beliefs, and religious studies",
                            IsActive = true,
                            Name = "Religion & Spirituality"
                        },
                        new
                        {
                            Id = 19,
                            Description = "Collections of poetry and lyrical works",
                            IsActive = true,
                            Name = "Poetry"
                        },
                        new
                        {
                            Id = 20,
                            Description = "Superheroes, manga, and illustrated stories",
                            IsActive = true,
                            Name = "Comics & Graphic Novels"
                        },
                        new
                        {
                            Id = 21,
                            Description = "Textbooks, academic, and educational resources",
                            IsActive = true,
                            Name = "Education"
                        },
                        new
                        {
                            Id = 22,
                            Description = "Cookbooks, recipes, and culinary arts",
                            IsActive = true,
                            Name = "Cooking"
                        },
                        new
                        {
                            Id = 23,
                            Description = "Travel guides, adventure books, and tourism",
                            IsActive = true,
                            Name = "Travel"
                        },
                        new
                        {
                            Id = 24,
                            Description = "Books on various sports, fitness, and athletes",
                            IsActive = true,
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 25,
                            Description = "Government, policies, and political science",
                            IsActive = true,
                            Name = "Politics"
                        });
                });

            modelBuilder.Entity("BookSharingApp.Models.ClubModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Clubs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified),
                            IsActive = true,
                            Location = "",
                            Logo = "default.jpg",
                            Name = "Book Club",
                            UpdatedAt = new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified),
                            IsActive = true,
                            Location = "",
                            Logo = "default.jpg",
                            Name = "Magazine Club",
                            UpdatedAt = new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified),
                            IsActive = true,
                            Location = "Badmosh",
                            Logo = "default.jpg",
                            Name = "Paper Club",
                            UpdatedAt = new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("BookSharingApp.Models.ClubUsersModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("ClubId", "UserId")
                        .IsUnique();

                    b.ToTable("ClubUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClubId = 1,
                            CreatedAt = new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified),
                            IsActive = true,
                            Role = "admin",
                            UpdatedAt = new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            ClubId = 2,
                            CreatedAt = new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified),
                            IsActive = true,
                            Role = "admin",
                            UpdatedAt = new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified),
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            ClubId = 3,
                            CreatedAt = new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified),
                            IsActive = true,
                            Role = "clubadmin",
                            UpdatedAt = new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified),
                            UserId = 1
                        });
                });

            modelBuilder.Entity("BookSharingApp.Models.LanguageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "hi",
                            IsActive = true,
                            Name = "Hindi"
                        },
                        new
                        {
                            Id = 2,
                            Code = "en",
                            IsActive = true,
                            Name = "English"
                        },
                        new
                        {
                            Id = 3,
                            Code = "ta",
                            IsActive = true,
                            Name = "Tamil"
                        },
                        new
                        {
                            Id = 4,
                            Code = "te",
                            IsActive = true,
                            Name = "Telugu"
                        },
                        new
                        {
                            Id = 5,
                            Code = "kn",
                            IsActive = true,
                            Name = "Kannada"
                        },
                        new
                        {
                            Id = 6,
                            Code = "ml",
                            IsActive = true,
                            Name = "Malayalam"
                        },
                        new
                        {
                            Id = 7,
                            Code = "gu",
                            IsActive = true,
                            Name = "Gujarati"
                        },
                        new
                        {
                            Id = 8,
                            Code = "mr",
                            IsActive = true,
                            Name = "Marathi"
                        },
                        new
                        {
                            Id = 9,
                            Code = "bn",
                            IsActive = true,
                            Name = "Bengali"
                        },
                        new
                        {
                            Id = 10,
                            Code = "pa",
                            IsActive = true,
                            Name = "Punjabi"
                        },
                        new
                        {
                            Id = 11,
                            Code = "or",
                            IsActive = true,
                            Name = "Odia"
                        },
                        new
                        {
                            Id = 12,
                            Code = "as",
                            IsActive = true,
                            Name = "Assamese"
                        },
                        new
                        {
                            Id = 13,
                            Code = "ur",
                            IsActive = true,
                            Name = "Urdu"
                        },
                        new
                        {
                            Id = 14,
                            Code = "sa",
                            IsActive = true,
                            Name = "Sanskrit"
                        },
                        new
                        {
                            Id = 15,
                            Code = "ks",
                            IsActive = true,
                            Name = "Kashmiri"
                        },
                        new
                        {
                            Id = 16,
                            Code = "sd",
                            IsActive = true,
                            Name = "Sindhi"
                        },
                        new
                        {
                            Id = 17,
                            Code = "mni",
                            IsActive = true,
                            Name = "Manipuri (Meitei)"
                        },
                        new
                        {
                            Id = 18,
                            Code = "bho",
                            IsActive = true,
                            Name = "Bhojpuri"
                        },
                        new
                        {
                            Id = 19,
                            Code = "mai",
                            IsActive = true,
                            Name = "Maithili"
                        },
                        new
                        {
                            Id = 20,
                            Code = "es",
                            IsActive = true,
                            Name = "Spanish"
                        },
                        new
                        {
                            Id = 21,
                            Code = "fr",
                            IsActive = true,
                            Name = "French"
                        },
                        new
                        {
                            Id = 22,
                            Code = "de",
                            IsActive = true,
                            Name = "German"
                        },
                        new
                        {
                            Id = 23,
                            Code = "zh",
                            IsActive = true,
                            Name = "Chinese (Mandarin)"
                        },
                        new
                        {
                            Id = 24,
                            Code = "ja",
                            IsActive = true,
                            Name = "Japanese"
                        },
                        new
                        {
                            Id = 25,
                            Code = "ru",
                            IsActive = true,
                            Name = "Russian"
                        },
                        new
                        {
                            Id = 26,
                            Code = "it",
                            IsActive = true,
                            Name = "Italian"
                        },
                        new
                        {
                            Id = 27,
                            Code = "pt",
                            IsActive = true,
                            Name = "Portuguese"
                        },
                        new
                        {
                            Id = 28,
                            Code = "ar",
                            IsActive = true,
                            Name = "Arabic"
                        },
                        new
                        {
                            Id = 29,
                            Code = "ko",
                            IsActive = true,
                            Name = "Korean"
                        },
                        new
                        {
                            Id = 30,
                            Code = "sw",
                            IsActive = true,
                            Name = "Swahili"
                        },
                        new
                        {
                            Id = 31,
                            Code = "nl",
                            IsActive = true,
                            Name = "Dutch"
                        },
                        new
                        {
                            Id = 32,
                            Code = "tr",
                            IsActive = true,
                            Name = "Turkish"
                        },
                        new
                        {
                            Id = 33,
                            Code = "vi",
                            IsActive = true,
                            Name = "Vietnamese"
                        },
                        new
                        {
                            Id = 34,
                            Code = "th",
                            IsActive = true,
                            Name = "Thai"
                        },
                        new
                        {
                            Id = 35,
                            Code = "pl",
                            IsActive = true,
                            Name = "Polish"
                        },
                        new
                        {
                            Id = 36,
                            Code = "fa",
                            IsActive = true,
                            Name = "Persian (Farsi)"
                        },
                        new
                        {
                            Id = 37,
                            Code = "sv",
                            IsActive = true,
                            Name = "Swedish"
                        },
                        new
                        {
                            Id = 38,
                            Code = "uk",
                            IsActive = true,
                            Name = "Ukrainian"
                        },
                        new
                        {
                            Id = 39,
                            Code = "he",
                            IsActive = true,
                            Name = "Hebrew"
                        },
                        new
                        {
                            Id = 40,
                            Code = "raj",
                            IsActive = true,
                            Name = "Rajasthani"
                        },
                        new
                        {
                            Id = 41,
                            Code = "ne",
                            IsActive = true,
                            Name = "Nepali"
                        },
                        new
                        {
                            Id = 42,
                            Code = "tulu",
                            IsActive = true,
                            Name = "Tulu"
                        },
                        new
                        {
                            Id = 43,
                            Code = "bhb",
                            IsActive = true,
                            Name = "Bhil"
                        },
                        new
                        {
                            Id = 44,
                            Code = "santali",
                            IsActive = true,
                            Name = "Santali"
                        },
                        new
                        {
                            Id = 45,
                            Code = "ho",
                            IsActive = true,
                            Name = "Ho"
                        },
                        new
                        {
                            Id = 46,
                            Code = "kur",
                            IsActive = true,
                            Name = "Kumaoni"
                        },
                        new
                        {
                            Id = 47,
                            Code = "no",
                            IsActive = true,
                            Name = "Norwegian"
                        },
                        new
                        {
                            Id = 48,
                            Code = "da",
                            IsActive = true,
                            Name = "Danish"
                        },
                        new
                        {
                            Id = 49,
                            Code = "fi",
                            IsActive = true,
                            Name = "Finnish"
                        },
                        new
                        {
                            Id = 50,
                            Code = "hu",
                            IsActive = true,
                            Name = "Hungarian"
                        });
                });

            modelBuilder.Entity("BookSharingApp.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastLogIn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("MFA")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("Profile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified),
                            Email = "sarthak.vadgama.hs@gmail.com",
                            IsActive = true,
                            MFA = true,
                            Mobile = "+91 8989258867",
                            Name = "Admin",
                            Password = "admin123",
                            Points = 0,
                            Profile = "default.jpg",
                            ResetToken = "",
                            UpdatedAt = new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("BookSharingApp.Models.ClubUsersModel", b =>
                {
                    b.HasOne("BookSharingApp.Models.ClubModel", "Club")
                        .WithMany()
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookSharingApp.Models.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
