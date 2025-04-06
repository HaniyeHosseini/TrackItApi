using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveReferencesFromModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTags_Jobs_JobId",
                table: "JobTags");

            migrationBuilder.DropForeignKey(
                name: "FK_JobTags_Tags_TagId",
                table: "JobTags");

            migrationBuilder.DropIndex(
                name: "IX_JobTags_TagId",
                table: "JobTags");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_JobTags_TagId",
                table: "JobTags",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTags_Jobs_JobId",
                table: "JobTags",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobTags_Tags_TagId",
                table: "JobTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
