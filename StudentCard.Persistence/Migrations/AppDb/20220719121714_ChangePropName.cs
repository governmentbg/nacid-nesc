using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentCard.Persistence.Migrations.AppDb
{
    public partial class ChangePropName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "firstnamealt",
                table: "student",
                newName: "fullnamealt");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "student",
                newName: "fullname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fullnamealt",
                table: "student",
                newName: "firstnamealt");

            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "student",
                newName: "firstname");
        }
    }
}
