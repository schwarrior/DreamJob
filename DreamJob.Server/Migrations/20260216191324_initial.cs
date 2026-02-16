using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DreamJob.Server.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DreamJobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    JobDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DreamJobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsCustom = table.Column<bool>(type: "bit", nullable: false),
                    DreamJobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSkills_DreamJobs_DreamJobId",
                        column: x => x.DreamJobId,
                        principalTable: "DreamJobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DreamJobs",
                columns: new[] { "Id", "CreatedDate", "JobDetails", "LastModifiedDate", "Title" },
                values: new object[] { 1, new DateTime(2026, 2, 16, 19, 6, 54, 397, DateTimeKind.Utc), "We are seeking a talented Senior Full Stack Developer to join our innovative team. \n\n**About the Role:**\nIn this position, you will be responsible for designing, developing, and maintaining both front-end and back-end components of our web applications. You'll work closely with cross-functional teams to deliver high-quality software solutions.\n\n**What You'll Do:**\n• Design and implement scalable web applications\n• Collaborate with designers and product managers\n• Write clean, maintainable code\n• Mentor junior developers\n• Participate in code reviews and technical discussions\n\n**What We Offer:**\n• Competitive salary and benefits\n• Remote-first work environment\n• Professional development opportunities\n• Flexible working hours\n• Modern tech stack", new DateTime(2026, 2, 16, 19, 6, 54, 397, DateTimeKind.Utc), "Senior Full Stack Developer" });

            migrationBuilder.InsertData(
                table: "JobSkills",
                columns: new[] { "Id", "DreamJobId", "IsCustom", "Name" },
                values: new object[,]
                {
                    { 1, 1, false, "C#" },
                    { 2, 1, false, "Angular" },
                    { 3, 1, false, "TypeScript" },
                    { 4, 1, false, "SQL Server" },
                    { 5, 1, false, "REST APIs" },
                    { 6, 1, false, "Git" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_DreamJobId",
                table: "JobSkills",
                column: "DreamJobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobSkills");

            migrationBuilder.DropTable(
                name: "DreamJobs");
        }
    }
}
