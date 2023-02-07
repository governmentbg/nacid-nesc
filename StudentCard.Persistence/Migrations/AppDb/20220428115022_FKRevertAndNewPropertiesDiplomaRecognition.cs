using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

#nullable disable

namespace StudentCard.Persistence.Migrations.AppDb
{
    public partial class FKRevertAndNewPropertiesDiplomaRecognition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_persondoctoral_personbasic_personbasicid",
                table: "persondoctoral");

            migrationBuilder.DropForeignKey(
                name: "FK_personsecondary_personbasic_personbasicid",
                table: "personsecondary");

            migrationBuilder.DropForeignKey(
                name: "FK_personstudent_personbasic_personbasicid",
                table: "personstudent");

            migrationBuilder.DropIndex(
                name: "IX_personstudent_personbasicid",
                table: "personstudent");

            migrationBuilder.DropIndex(
                name: "IX_personsecondary_personbasicid",
                table: "personsecondary");

            migrationBuilder.DropIndex(
                name: "IX_persondoctoral_personbasicid",
                table: "persondoctoral");

            migrationBuilder.DropColumn(
                name: "personbasicid",
                table: "personstudent");

            migrationBuilder.DropColumn(
                name: "personbasicid",
                table: "personsecondary");

            migrationBuilder.DropColumn(
                name: "personbasicid",
                table: "persondoctoral");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "personstudent",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "peacquiredforeigneducationalqualification",
                table: "personstudent",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "perecognitiondate",
                table: "personstudent",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "perecognitionnumber",
                table: "personstudent",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "personsecondary",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "recognitiondate",
                table: "personsecondary",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "recognitionnumber",
                table: "personsecondary",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "persondoctoral",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "peacquiredforeigneducationalqualification",
                table: "persondoctoral",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "perecognitiondate",
                table: "persondoctoral",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "perecognitionnumber",
                table: "persondoctoral",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    passwordsalt = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    createdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updatedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "passwordtoken",
                columns: table => new
                {
                    value = table.Column<string>(type: "text", nullable: false),
                    expirationtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    isused = table.Column<bool>(type: "boolean", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passwordtoken", x => x.value);
                    table.ForeignKey(
                        name: "FK_passwordtoken_user_userid",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_passwordtoken_userid",
                table: "passwordtoken",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_persondoctoral_personbasic_id",
                table: "persondoctoral",
                column: "id",
                principalTable: "personbasic",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_personsecondary_personbasic_id",
                table: "personsecondary",
                column: "id",
                principalTable: "personbasic",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_personstudent_personbasic_id",
                table: "personstudent",
                column: "id",
                principalTable: "personbasic",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_persondoctoral_personbasic_id",
                table: "persondoctoral");

            migrationBuilder.DropForeignKey(
                name: "FK_personsecondary_personbasic_id",
                table: "personsecondary");

            migrationBuilder.DropForeignKey(
                name: "FK_personstudent_personbasic_id",
                table: "personstudent");

            migrationBuilder.DropTable(
                name: "passwordtoken");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropColumn(
                name: "peacquiredforeigneducationalqualification",
                table: "personstudent");

            migrationBuilder.DropColumn(
                name: "perecognitiondate",
                table: "personstudent");

            migrationBuilder.DropColumn(
                name: "perecognitionnumber",
                table: "personstudent");

            migrationBuilder.DropColumn(
                name: "recognitiondate",
                table: "personsecondary");

            migrationBuilder.DropColumn(
                name: "recognitionnumber",
                table: "personsecondary");

            migrationBuilder.DropColumn(
                name: "peacquiredforeigneducationalqualification",
                table: "persondoctoral");

            migrationBuilder.DropColumn(
                name: "perecognitiondate",
                table: "persondoctoral");

            migrationBuilder.DropColumn(
                name: "perecognitionnumber",
                table: "persondoctoral");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "personstudent",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "personbasicid",
                table: "personstudent",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "personsecondary",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "personbasicid",
                table: "personsecondary",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "persondoctoral",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "personbasicid",
                table: "persondoctoral",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_personstudent_personbasicid",
                table: "personstudent",
                column: "personbasicid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_personsecondary_personbasicid",
                table: "personsecondary",
                column: "personbasicid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_persondoctoral_personbasicid",
                table: "persondoctoral",
                column: "personbasicid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_persondoctoral_personbasic_personbasicid",
                table: "persondoctoral",
                column: "personbasicid",
                principalTable: "personbasic",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_personsecondary_personbasic_personbasicid",
                table: "personsecondary",
                column: "personbasicid",
                principalTable: "personbasic",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_personstudent_personbasic_personbasicid",
                table: "personstudent",
                column: "personbasicid",
                principalTable: "personbasic",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
