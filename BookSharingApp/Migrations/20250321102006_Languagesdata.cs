using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookSharingApp.Migrations
{
    /// <inheritdoc />
    public partial class Languagesdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "hi", true, "Hindi" },
                    { 2, "en", true, "English" },
                    { 3, "ta", true, "Tamil" },
                    { 4, "te", true, "Telugu" },
                    { 5, "kn", true, "Kannada" },
                    { 6, "ml", true, "Malayalam" },
                    { 7, "gu", true, "Gujarati" },
                    { 8, "mr", true, "Marathi" },
                    { 9, "bn", true, "Bengali" },
                    { 10, "pa", true, "Punjabi" },
                    { 11, "or", true, "Odia" },
                    { 12, "as", true, "Assamese" },
                    { 13, "ur", true, "Urdu" },
                    { 14, "sa", true, "Sanskrit" },
                    { 15, "ks", true, "Kashmiri" },
                    { 16, "sd", true, "Sindhi" },
                    { 17, "mni", true, "Manipuri (Meitei)" },
                    { 18, "bho", true, "Bhojpuri" },
                    { 19, "mai", true, "Maithili" },
                    { 20, "es", true, "Spanish" },
                    { 21, "fr", true, "French" },
                    { 22, "de", true, "German" },
                    { 23, "zh", true, "Chinese (Mandarin)" },
                    { 24, "ja", true, "Japanese" },
                    { 25, "ru", true, "Russian" },
                    { 26, "it", true, "Italian" },
                    { 27, "pt", true, "Portuguese" },
                    { 28, "ar", true, "Arabic" },
                    { 29, "ko", true, "Korean" },
                    { 30, "sw", true, "Swahili" },
                    { 31, "nl", true, "Dutch" },
                    { 32, "tr", true, "Turkish" },
                    { 33, "vi", true, "Vietnamese" },
                    { 34, "th", true, "Thai" },
                    { 35, "pl", true, "Polish" },
                    { 36, "fa", true, "Persian (Farsi)" },
                    { 37, "sv", true, "Swedish" },
                    { 38, "uk", true, "Ukrainian" },
                    { 39, "he", true, "Hebrew" },
                    { 40, "raj", true, "Rajasthani" },
                    { 41, "ne", true, "Nepali" },
                    { 42, "tulu", true, "Tulu" },
                    { 43, "bhb", true, "Bhil" },
                    { 44, "santali", true, "Santali" },
                    { 45, "ho", true, "Ho" },
                    { 46, "kur", true, "Kumaoni" },
                    { 47, "no", true, "Norwegian" },
                    { 48, "da", true, "Danish" },
                    { 49, "fi", true, "Finnish" },
                    { 50, "hu", true, "Hungarian" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
