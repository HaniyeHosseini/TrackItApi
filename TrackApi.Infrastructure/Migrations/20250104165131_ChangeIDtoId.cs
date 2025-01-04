using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIDtoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Tags",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Plans",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Jobs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Goals",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tags",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Plans",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Jobs",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Goals",
                newName: "ID");
        }
    }
}
