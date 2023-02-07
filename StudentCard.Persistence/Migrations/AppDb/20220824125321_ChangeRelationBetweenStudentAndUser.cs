using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace StudentCard.Persistence.Migrations.AppDb
{
    public partial class ChangeRelationBetweenStudentAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_student_studentid",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_studentid",
                table: "user");

            migrationBuilder.DropColumn(
                name: "studentid",
                table: "user");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "student",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_student_user_id",
                table: "student",
                column: "id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_student_user_id",
                table: "student");

            migrationBuilder.AddColumn<int>(
                name: "studentid",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "student",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
    }
}
