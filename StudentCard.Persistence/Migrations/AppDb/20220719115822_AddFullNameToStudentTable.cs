using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentCard.Persistence.Migrations.AppDb
{
    public partial class AddFullNameToStudentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "firstname",
                table: "student",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "firstnamealt",
                table: "student",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firstname",
                table: "student");

            migrationBuilder.DropColumn(
                name: "firstnamealt",
                table: "student");
        }
    }
}
