using Microsoft.EntityFrameworkCore.Migrations;

namespace ThumbUp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Localizations",
                columns: table => new
                {
                    LocID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocName = table.Column<string>(nullable: true),
                    LocDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizations", x => x.LocID);
                });

            migrationBuilder.CreateTable(
                name: "LocalizationRatings",
                columns: table => new
                {
                    LRaID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LRaRating = table.Column<short>(nullable: false),
                    LRaOpinion = table.Column<string>(nullable: true),
                    LRaLocID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizationRatings", x => x.LRaID);
                    table.ForeignKey(
                        name: "FK_LocalizationRatings_Localizations_LRaLocID",
                        column: x => x.LRaLocID,
                        principalTable: "Localizations",
                        principalColumn: "LocID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocalizationRatings_LRaLocID",
                table: "LocalizationRatings",
                column: "LRaLocID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalizationRatings");

            migrationBuilder.DropTable(
                name: "Localizations");
        }
    }
}
