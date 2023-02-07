using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

#nullable disable

namespace StudentCard.Persistence.Migrations.AppDb
{
    public partial class SplitSemesters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "basestudentsemester");

            migrationBuilder.DropColumn(
                name: "course",
                table: "studentuniversity");

            migrationBuilder.DropColumn(
                name: "studentsemester",
                table: "studentuniversity");

            migrationBuilder.RenameColumn(
                name: "personstudentid",
                table: "studentbasic",
                newName: "studentuniversityid");

            migrationBuilder.RenameColumn(
                name: "personsecondaryid",
                table: "studentbasic",
                newName: "studentsecondaryid");

            migrationBuilder.RenameColumn(
                name: "persondoctoralid",
                table: "studentbasic",
                newName: "studentdoctoralid");

            migrationBuilder.CreateTable(
                name: "studentdoctoralsemester",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    protocoldate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    protocolnumber = table.Column<string>(type: "text", nullable: true),
                    yeartype = table.Column<int>(type: "integer", nullable: false),
                    studentdoctoralid = table.Column<int>(type: "integer", nullable: true),
                    educationfeetype = table.Column<string>(type: "text", nullable: true),
                    studentstatus = table.Column<string>(type: "text", nullable: true),
                    studentevent = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    hasscholarship = table.Column<bool>(type: "boolean", nullable: false),
                    usehostel = table.Column<bool>(type: "boolean", nullable: false),
                    useholidaybase = table.Column<bool>(type: "boolean", nullable: false),
                    participatedintprograms = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentdoctoralsemester", x => x.id);
                    table.ForeignKey(
                        name: "FK_studentdoctoralsemester_studentdoctoral_studentdoctoralid",
                        column: x => x.studentdoctoralid,
                        principalTable: "studentdoctoral",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "studentuniversitysemester",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    period = table.Column<string>(type: "text", nullable: true),
                    course = table.Column<int>(type: "integer", nullable: false),
                    studentsemester = table.Column<int>(type: "integer", nullable: false),
                    studentuniversityid = table.Column<int>(type: "integer", nullable: true),
                    educationfeetype = table.Column<string>(type: "text", nullable: true),
                    studentstatus = table.Column<string>(type: "text", nullable: true),
                    studentevent = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    hasscholarship = table.Column<bool>(type: "boolean", nullable: false),
                    usehostel = table.Column<bool>(type: "boolean", nullable: false),
                    useholidaybase = table.Column<bool>(type: "boolean", nullable: false),
                    participatedintprograms = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentuniversitysemester", x => x.id);
                    table.ForeignKey(
                        name: "FK_studentuniversitysemester_studentuniversity_studentuniversi~",
                        column: x => x.studentuniversityid,
                        principalTable: "studentuniversity",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentdoctoralsemester_studentdoctoralid",
                table: "studentdoctoralsemester",
                column: "studentdoctoralid");

            migrationBuilder.CreateIndex(
                name: "IX_studentuniversitysemester_studentuniversityid",
                table: "studentuniversitysemester",
                column: "studentuniversityid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentdoctoralsemester");

            migrationBuilder.DropTable(
                name: "studentuniversitysemester");

            migrationBuilder.RenameColumn(
                name: "studentuniversityid",
                table: "studentbasic",
                newName: "personstudentid");

            migrationBuilder.RenameColumn(
                name: "studentsecondaryid",
                table: "studentbasic",
                newName: "personsecondaryid");

            migrationBuilder.RenameColumn(
                name: "studentdoctoralid",
                table: "studentbasic",
                newName: "persondoctoralid");

            migrationBuilder.AddColumn<int>(
                name: "course",
                table: "studentuniversity",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "studentsemester",
                table: "studentuniversity",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "basestudentsemester",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    educationfeetype = table.Column<string>(type: "text", nullable: true),
                    hasscholarship = table.Column<bool>(type: "boolean", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    participatedintprograms = table.Column<bool>(type: "boolean", nullable: false),
                    period = table.Column<string>(type: "text", nullable: true),
                    studentdoctoralid = table.Column<int>(type: "integer", nullable: true),
                    studentevent = table.Column<string>(type: "text", nullable: true),
                    studentstatus = table.Column<string>(type: "text", nullable: true),
                    studentuniversityid = table.Column<int>(type: "integer", nullable: true),
                    useholidaybase = table.Column<bool>(type: "boolean", nullable: false),
                    usehostel = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_basestudentsemester", x => x.id);
                    table.ForeignKey(
                        name: "FK_basestudentsemester_studentdoctoral_studentdoctoralid",
                        column: x => x.studentdoctoralid,
                        principalTable: "studentdoctoral",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_basestudentsemester_studentuniversity_studentuniversityid",
                        column: x => x.studentuniversityid,
                        principalTable: "studentuniversity",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_basestudentsemester_studentdoctoralid",
                table: "basestudentsemester",
                column: "studentdoctoralid");

            migrationBuilder.CreateIndex(
                name: "IX_basestudentsemester_studentuniversityid",
                table: "basestudentsemester",
                column: "studentuniversityid");
        }
    }
}
