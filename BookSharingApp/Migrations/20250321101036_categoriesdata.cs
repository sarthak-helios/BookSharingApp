using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookSharingApp.Migrations
{
    /// <inheritdoc />
    public partial class categoriesdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "Novels, short stories, and literary works", true, "Fiction" },
                    { 2, "Biographies, self-help, history, and factual books", true, "Non-Fiction" },
                    { 3, "Physics, chemistry, biology, and scientific research", true, "Science" },
                    { 4, "Programming, IT, and tech-related topics", true, "Technology" },
                    { 5, "World history, wars, and civilizations", true, "History" },
                    { 6, "Ethics, metaphysics, and philosophical works", true, "Philosophy" },
                    { 7, "Crime, detective, and suspense novels", true, "Mystery & Thriller" },
                    { 8, "Love stories and romantic fiction", true, "Romance" },
                    { 9, "Mythical, magical, and supernatural books", true, "Fantasy" },
                    { 10, "Kids books, fairy tales, and young readers", true, "Children" },
                    { 11, "Futuristic, space, and technological adventures", true, "Science Fiction" },
                    { 12, "Scary, supernatural, and horror stories", true, "Horror" },
                    { 13, "Stories of real-life people", true, "Biography & Memoir" },
                    { 14, "Personal development, motivation, and guidance", true, "Self-Help" },
                    { 15, "Entrepreneurship, investing, and business strategies", true, "Business & Finance" },
                    { 16, "Mental health, therapy, and psychology books", true, "Psychology" },
                    { 17, "Fitness, nutrition, and healthy living", true, "Health & Wellness" },
                    { 18, "Books on faith, beliefs, and religious studies", true, "Religion & Spirituality" },
                    { 19, "Collections of poetry and lyrical works", true, "Poetry" },
                    { 20, "Superheroes, manga, and illustrated stories", true, "Comics & Graphic Novels" },
                    { 21, "Textbooks, academic, and educational resources", true, "Education" },
                    { 22, "Cookbooks, recipes, and culinary arts", true, "Cooking" },
                    { 23, "Travel guides, adventure books, and tourism", true, "Travel" },
                    { 24, "Books on various sports, fitness, and athletes", true, "Sports" },
                    { 25, "Government, policies, and political science", true, "Politics" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "admin123");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "admin");
        }
    }
}
