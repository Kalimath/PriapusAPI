#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MbDevelopment.Greenmaster.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Taxonomy.Kingdoms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LatinName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxonomy.Kingdoms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taxonomy.Phyla",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxonKingdomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KingdomId = table.Column<int>(type: "int", nullable: false),
                    LatinName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxonomy.Phyla", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taxonomy.Phyla_Taxonomy.Kingdoms_KingdomId",
                        column: x => x.KingdomId,
                        principalTable: "Taxonomy.Kingdoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taxonomy.Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhylumId = table.Column<int>(type: "int", nullable: false),
                    LatinName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxonomy.Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taxonomy.Classes_Taxonomy.Phyla_PhylumId",
                        column: x => x.PhylumId,
                        principalTable: "Taxonomy.Phyla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taxonomy.Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    LatinName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxonomy.Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taxonomy.Orders_Taxonomy.Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Taxonomy.Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taxonomy.Families",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    LatinName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxonomy.Families", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taxonomy.Families_Taxonomy.Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Taxonomy.Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taxonomy.Genera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyId = table.Column<int>(type: "int", nullable: false),
                    LatinName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxonomy.Genera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taxonomy.Genera_Taxonomy.Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Taxonomy.Families",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taxonomy.Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenusId = table.Column<int>(type: "int", nullable: false),
                    LatinName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cultivar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxonomy.Species", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taxonomy.Species_Taxonomy.Genera_GenusId",
                        column: x => x.GenusId,
                        principalTable: "Taxonomy.Genera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Taxonomy.Kingdoms",
                columns: new[] { "Id", "Description", "LatinName" },
                values: new object[,]
                {
                    { 1, "The kingdom of animals.", "Animalia" },
                    { 2, "The kingdom of plants.", "Plantae" },
                    { 3, "The kingdom of fungi.", "Fungi" },
                    { 4, "The kingdom of protista.", "Protista" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Taxonomy.Classes_PhylumId",
                table: "Taxonomy.Classes",
                column: "PhylumId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxonomy.Families_OrderId",
                table: "Taxonomy.Families",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxonomy.Genera_FamilyId",
                table: "Taxonomy.Genera",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxonomy.Orders_ClassId",
                table: "Taxonomy.Orders",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxonomy.Phyla_KingdomId",
                table: "Taxonomy.Phyla",
                column: "KingdomId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxonomy.Species_GenusId",
                table: "Taxonomy.Species",
                column: "GenusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Taxonomy.Species");

            migrationBuilder.DropTable(
                name: "Taxonomy.Genera");

            migrationBuilder.DropTable(
                name: "Taxonomy.Families");

            migrationBuilder.DropTable(
                name: "Taxonomy.Orders");

            migrationBuilder.DropTable(
                name: "Taxonomy.Classes");

            migrationBuilder.DropTable(
                name: "Taxonomy.Phyla");

            migrationBuilder.DropTable(
                name: "Taxonomy.Kingdoms");
        }
    }
}
