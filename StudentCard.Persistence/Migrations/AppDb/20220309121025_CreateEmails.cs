using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace StudentCard.Persistence.Migrations.AppDb
{
    public partial class CreateEmails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "emailtype",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    subject = table.Column<string>(type: "text", nullable: true),
                    body = table.Column<string>(type: "text", nullable: true),
                    alias = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    vieworder = table.Column<int>(type: "integer", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emailtype", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "email",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    typeid = table.Column<int>(type: "integer", nullable: false),
                    subject = table.Column<string>(type: "text", nullable: true),
                    body = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_email", x => x.id);
                    table.ForeignKey(
                        name: "FK_email_emailtype_typeid",
                        column: x => x.typeid,
                        principalTable: "emailtype",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "emailaddressee",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    emailid = table.Column<int>(type: "integer", nullable: false),
                    addresseetype = table.Column<int>(type: "integer", nullable: false),
                    address = table.Column<string>(type: "text", nullable: true),
                    sentdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emailaddressee", x => x.id);
                    table.ForeignKey(
                        name: "FK_emailaddressee_email_emailid",
                        column: x => x.emailid,
                        principalTable: "email",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_email_typeid",
                table: "email",
                column: "typeid");

            migrationBuilder.CreateIndex(
                name: "IX_emailaddressee_emailid",
                table: "emailaddressee",
                column: "emailid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emailaddressee");

            migrationBuilder.DropTable(
                name: "email");

            migrationBuilder.DropTable(
                name: "emailtype");
        }
    }
}
