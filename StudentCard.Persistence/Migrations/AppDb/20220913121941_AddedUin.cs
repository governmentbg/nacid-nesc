using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentCard.Persistence.Migrations.AppDb
{
    public partial class AddedUin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "uin",
                table: "student",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "uin",
                table: "student");
        }
    }
}
