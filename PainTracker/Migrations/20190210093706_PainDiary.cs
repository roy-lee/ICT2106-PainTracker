using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExploreCalifornia.Migrations
{
    public partial class PainDiary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PainDiary",
                columns: table => new
                {
                    patientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    patientName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PainDiary", x => x.patientId);
                });

            migrationBuilder.CreateTable(
                name: "PainEntry",
                columns: table => new
                {
                    painEntryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    patientId = table.Column<int>(nullable: false),
                    painIntensity = table.Column<int>(nullable: false),
                    painArea = table.Column<int>(nullable: false),
                    painDuration = table.Column<int>(nullable: false),
                    sleepTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PainEntry", x => x.painEntryId);
                    table.ForeignKey(
                        name: "FK_PainEntry_PainDiary_patientId",
                        column: x => x.patientId,
                        principalTable: "PainDiary",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interference",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(nullable: true),
                    severity = table.Column<int>(nullable: false),
                    duration = table.Column<int>(nullable: false),
                    painEntryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interference_PainEntry_painEntryId",
                        column: x => x.painEntryId,
                        principalTable: "PainEntry",
                        principalColumn: "painEntryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mood",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    moodType = table.Column<int>(nullable: false),
                    duration = table.Column<int>(nullable: false),
                    painEntryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mood_PainEntry_painEntryId",
                        column: x => x.painEntryId,
                        principalTable: "PainEntry",
                        principalColumn: "painEntryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interference_painEntryId",
                table: "Interference",
                column: "painEntryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mood_painEntryId",
                table: "Mood",
                column: "painEntryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PainEntry_patientId",
                table: "PainEntry",
                column: "patientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interference");

            migrationBuilder.DropTable(
                name: "Mood");

            migrationBuilder.DropTable(
                name: "PainEntry");

            migrationBuilder.DropTable(
                name: "PainDiary");
        }
    }
}
