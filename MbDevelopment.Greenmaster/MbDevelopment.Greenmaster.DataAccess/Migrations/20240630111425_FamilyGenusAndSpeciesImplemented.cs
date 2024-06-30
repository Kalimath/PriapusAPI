using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MbDevelopment.Greenmaster.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FamilyGenusAndSpeciesImplemented : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommonName",
                table: "Taxonomy.Species",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Taxonomy.Species",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TrademarkName",
                table: "Taxonomy.Species",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommonName",
                table: "Taxonomy.Species");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Taxonomy.Species");

            migrationBuilder.DropColumn(
                name: "TrademarkName",
                table: "Taxonomy.Species");
        }
    }
}
