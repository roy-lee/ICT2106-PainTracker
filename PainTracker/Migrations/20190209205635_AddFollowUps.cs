using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PainTracker.Migrations
{
    public partial class AddFollowUps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FollowUpQuestion",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Question = table.Column<string>(nullable: true),
                    FollowUpRefId = table.Column<int>(nullable: false),
                    FollowUpDTOFollowUpId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowUpQuestion", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "FollowUpDTO",
                columns: table => new
                {
                    FollowUpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    State = table.Column<int>(nullable: false),
                    FollowUpQuestionQuestionId = table.Column<int>(nullable: true),
                    DateGenerated = table.Column<DateTime>(nullable: false),
                    NotifyPatientFlag = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowUpDTO", x => x.FollowUpId);
                    table.ForeignKey(
                        name: "FK_FollowUpDTO_FollowUpQuestion_FollowUpQuestionQuestionId",
                        column: x => x.FollowUpQuestionQuestionId,
                        principalTable: "FollowUpQuestion",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FollowUpDTO_FollowUpQuestionQuestionId",
                table: "FollowUpDTO",
                column: "FollowUpQuestionQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUpQuestion_FollowUpDTOFollowUpId",
                table: "FollowUpQuestion",
                column: "FollowUpDTOFollowUpId");

            migrationBuilder.AddForeignKey(
                name: "FK_FollowUpQuestion_FollowUpDTO_FollowUpDTOFollowUpId",
                table: "FollowUpQuestion",
                column: "FollowUpDTOFollowUpId",
                principalTable: "FollowUpDTO",
                principalColumn: "FollowUpId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FollowUpDTO_FollowUpQuestion_FollowUpQuestionQuestionId",
                table: "FollowUpDTO");

            migrationBuilder.DropTable(
                name: "FollowUpQuestion");

            migrationBuilder.DropTable(
                name: "FollowUpDTO");
        }
    }
}
