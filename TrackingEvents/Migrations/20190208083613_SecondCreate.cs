using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingEvents.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_PainDiary_externalModuleId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "externalModuleId",
                table: "Events",
                newName: "painDiaryModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_externalModuleId",
                table: "Events",
                newName: "IX_Events_painDiaryModuleId");

            migrationBuilder.AddColumn<int>(
                name: "followupModuleId",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Followup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    followupTitle = table.Column<string>(nullable: true),
                    dateGenerated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followup", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_followupModuleId",
                table: "Events",
                column: "followupModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Followup_followupModuleId",
                table: "Events",
                column: "followupModuleId",
                principalTable: "Followup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_PainDiary_painDiaryModuleId",
                table: "Events",
                column: "painDiaryModuleId",
                principalTable: "PainDiary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Followup_followupModuleId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_PainDiary_painDiaryModuleId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Followup");

            migrationBuilder.DropIndex(
                name: "IX_Events_followupModuleId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "followupModuleId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "painDiaryModuleId",
                table: "Events",
                newName: "externalModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_painDiaryModuleId",
                table: "Events",
                newName: "IX_Events_externalModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_PainDiary_externalModuleId",
                table: "Events",
                column: "externalModuleId",
                principalTable: "PainDiary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
