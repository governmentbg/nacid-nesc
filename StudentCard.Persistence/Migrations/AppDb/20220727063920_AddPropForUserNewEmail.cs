using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentCard.Persistence.Migrations.AppDb
{
    public partial class AddPropForUserNewEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "newemailrequest",
                table: "user",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "newemailrequest",
                table: "user");
        }
    }
}
