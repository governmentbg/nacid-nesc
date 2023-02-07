using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentCard.Persistence.Migrations.AppDb
{
    public partial class RemoveNamesFromUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fullname",
                table: "student");

            migrationBuilder.DropColumn(
                name: "fullnamealt",
                table: "student");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fullname",
                table: "student",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fullnamealt",
                table: "student",
                type: "text",
                nullable: true);
        }
    }
}
