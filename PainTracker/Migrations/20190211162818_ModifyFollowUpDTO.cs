using Microsoft.EntityFrameworkCore.Migrations;

namespace PainTracker.Migrations
{
    public partial class ModifyFollowUpDTO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FollowUpDTO_FollowUpQuestion_FollowUpQuestionQuestionId",
                table: "FollowUpDTO");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowUpQuestion_FollowUpDTO_FollowUpDTOFollowUpId",
                table: "FollowUpQuestion");

            migrationBuilder.DropIndex(
                name: "IX_FollowUpDTO_FollowUpQuestionQuestionId",
                table: "FollowUpDTO");

            migrationBuilder.DropColumn(
                name: "FollowUpRefId",
                table: "FollowUpQuestion");

            migrationBuilder.DropColumn(
                name: "FollowUpQuestionQuestionId",
                table: "FollowUpDTO");

            migrationBuilder.RenameColumn(
                name: "FollowUpDTOFollowUpId",
                table: "FollowUpQuestion",
                newName: "FollowUpId");

            migrationBuilder.RenameIndex(
                name: "IX_FollowUpQuestion_FollowUpDTOFollowUpId",
                table: "FollowUpQuestion",
                newName: "IX_FollowUpQuestion_FollowUpId");

            migrationBuilder.AddForeignKey(
                name: "FK_FollowUpQuestion_FollowUpDTO_FollowUpId",
                table: "FollowUpQuestion",
                column: "FollowUpId",
                principalTable: "FollowUpDTO",
                principalColumn: "FollowUpId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FollowUpQuestion_FollowUpDTO_FollowUpId",
                table: "FollowUpQuestion");

            migrationBuilder.RenameColumn(
                name: "FollowUpId",
                table: "FollowUpQuestion",
                newName: "FollowUpDTOFollowUpId");

            migrationBuilder.RenameIndex(
                name: "IX_FollowUpQuestion_FollowUpId",
                table: "FollowUpQuestion",
                newName: "IX_FollowUpQuestion_FollowUpDTOFollowUpId");

            migrationBuilder.AddColumn<int>(
                name: "FollowUpRefId",
                table: "FollowUpQuestion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FollowUpQuestionQuestionId",
                table: "FollowUpDTO",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FollowUpDTO_FollowUpQuestionQuestionId",
                table: "FollowUpDTO",
                column: "FollowUpQuestionQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_FollowUpDTO_FollowUpQuestion_FollowUpQuestionQuestionId",
                table: "FollowUpDTO",
                column: "FollowUpQuestionQuestionId",
                principalTable: "FollowUpQuestion",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowUpQuestion_FollowUpDTO_FollowUpDTOFollowUpId",
                table: "FollowUpQuestion",
                column: "FollowUpDTOFollowUpId",
                principalTable: "FollowUpDTO",
                principalColumn: "FollowUpId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
