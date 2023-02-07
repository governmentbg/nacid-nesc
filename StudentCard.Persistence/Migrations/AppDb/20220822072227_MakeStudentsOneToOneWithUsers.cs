using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentCard.Persistence.Migrations.AppDb
{
    public partial class MakeStudentsOneToOneWithUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "studentid",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_studentid",
                table: "user",
                column: "studentid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_user_student_studentid",
                table: "user",
                column: "studentid",
                principalTable: "student",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_student_studentid",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_studentid",
                table: "user");

            migrationBuilder.AlterColumn<int>(
                name: "studentid",
                table: "user",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
