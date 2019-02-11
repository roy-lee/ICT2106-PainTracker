using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PainTracker.Migrations
{
    public partial class AddFollowUpDTO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PainDairyID",
                table: "FollowUpDTO",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PainDairyDTO",
                columns: table => new
                {
                    PainDairyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PainDairyDTO", x => x.PainDairyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FollowUpDTO_PainDairyID",
                table: "FollowUpDTO",
                column: "PainDairyID");

            migrationBuilder.AddForeignKey(
                name: "FK_FollowUpDTO_PainDairyDTO_PainDairyID",
                table: "FollowUpDTO",
                column: "PainDairyID",
                principalTable: "PainDairyDTO",
                principalColumn: "PainDairyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FollowUpDTO_PainDairyDTO_PainDairyID",
                table: "FollowUpDTO");

            migrationBuilder.DropTable(
                name: "PainDairyDTO");

            migrationBuilder.DropIndex(
                name: "IX_FollowUpDTO_PainDairyID",
                table: "FollowUpDTO");

            migrationBuilder.DropColumn(
                name: "PainDairyID",
                table: "FollowUpDTO");
        }
    }
}
