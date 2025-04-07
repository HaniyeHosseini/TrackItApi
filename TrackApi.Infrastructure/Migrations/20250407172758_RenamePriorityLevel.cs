using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenamePriorityLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prioritylevel",
                table: "Jobs",
                newName: "PriorityLevel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriorityLevel",
                table: "Jobs",
                newName: "Prioritylevel");
        }
    }
}
