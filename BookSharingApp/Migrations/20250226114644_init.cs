using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookSharingApp.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Profile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MFA = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    LastLogIn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClubUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubUsers_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClubUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Location", "Logo", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified), true, "", "default.jpg", "Book Club", new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified), true, "", "default.jpg", "Magazine Club", new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified), true, "Badmosh", "default.jpg", "Paper Club", new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "IsActive", "LastLogIn", "MFA", "Mobile", "Name", "Password", "Points", "Profile", "ResetToken", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified), "sarthak.vadgama.hs@gmail.com", true, null, true, "+91 8989258867", "Admin", "admin", 0, "default.jpg", "", new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ClubUsers",
                columns: new[] { "Id", "ClubId", "CreatedAt", "IsActive", "Role", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified), true, "admin", new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified), true, "admin", new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified), 1 },
                    { 3, 3, new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified), true, "clubadmin", new DateTime(2025, 2, 21, 10, 35, 14, 370, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_Name",
                table: "Clubs",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClubUsers_ClubId_UserId",
                table: "ClubUsers",
                columns: new[] { "ClubId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClubUsers_UserId",
                table: "ClubUsers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClubUsers");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
