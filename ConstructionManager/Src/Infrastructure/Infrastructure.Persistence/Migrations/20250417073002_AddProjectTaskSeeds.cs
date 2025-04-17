using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectTaskSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New corporate headquarters", "Office Building Construction" },
                    { 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "50-unit apartment building", "Residential Complex" },
                    { 3L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Highway expansion project", "Road Infrastructure" }
                });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "Id", "Description", "ProjectId", "Title" },
                values: new object[,]
                {
                    { 1L, "Clear and grade the site", 1L, "Site Preparation" },
                    { 2L, "Pour concrete foundation", 1L, "Foundation Work" },
                    { 3L, "Erect steel structure", 1L, "Structural Framing" },
                    { 4L, "Dig foundations", 2L, "Excavation" },
                    { 5L, "Install plumbing and electrical", 2L, "Utilities Installation" },
                    { 6L, "Drywall and flooring", 2L, "Interior Finishes" },
                    { 7L, "Mark road alignment", 3L, "Surveying" },
                    { 8L, "Prepare roadbed", 3L, "Grading" },
                    { 9L, "Lay asphalt surface", 3L, "Paving" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
