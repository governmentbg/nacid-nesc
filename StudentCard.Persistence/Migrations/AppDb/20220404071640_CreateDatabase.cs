using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

#nullable disable

namespace StudentCard.Persistence.Migrations.AppDb
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "sentdate",
                table: "emailaddressee",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.CreateTable(
                name: "personbasic",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(type: "text", nullable: true),
                    middlename = table.Column<string>(type: "text", nullable: true),
                    lastname = table.Column<string>(type: "text", nullable: true),
                    othernames = table.Column<string>(type: "text", nullable: true),
                    fullname = table.Column<string>(type: "text", nullable: true),
                    firstnamealt = table.Column<string>(type: "text", nullable: true),
                    middlenamealt = table.Column<string>(type: "text", nullable: true),
                    lastnamealt = table.Column<string>(type: "text", nullable: true),
                    othernamesalt = table.Column<string>(type: "text", nullable: true),
                    fullnamealt = table.Column<string>(type: "text", nullable: true),
                    uin = table.Column<string>(type: "text", nullable: true),
                    foreignernumber = table.Column<string>(type: "text", nullable: true),
                    idnnumber = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    phonenumber = table.Column<string>(type: "text", nullable: true),
                    postcode = table.Column<string>(type: "text", nullable: true),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    birthdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    birthcountry = table.Column<string>(type: "text", nullable: true),
                    birthdistrict = table.Column<string>(type: "text", nullable: true),
                    birthmunicipality = table.Column<string>(type: "text", nullable: true),
                    birthsettlement = table.Column<string>(type: "text", nullable: true),
                    foreignerbirthsettlement = table.Column<string>(type: "text", nullable: true),
                    citizenship = table.Column<string>(type: "text", nullable: true),
                    secondcitizenship = table.Column<string>(type: "text", nullable: true),
                    residencecountry = table.Column<string>(type: "text", nullable: true),
                    residencedistrict = table.Column<string>(type: "text", nullable: true),
                    residencemunicipality = table.Column<string>(type: "text", nullable: true),
                    residencesettlement = table.Column<string>(type: "text", nullable: true),
                    residenceaddress = table.Column<string>(type: "text", nullable: true),
                    personstudentid = table.Column<int>(type: "integer", nullable: true),
                    persondoctoralid = table.Column<int>(type: "integer", nullable: true),
                    personsecondaryid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personbasic", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "persondoctoral",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    startdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    enddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    personbasicid = table.Column<int>(type: "integer", nullable: false),
                    institution = table.Column<string>(type: "text", nullable: true),
                    subordinate = table.Column<string>(type: "text", nullable: true),
                    institutionspeciality = table.Column<string>(type: "text", nullable: true),
                    studentstatus = table.Column<string>(type: "text", nullable: true),
                    studentevent = table.Column<string>(type: "text", nullable: true),
                    admissionreason = table.Column<string>(type: "text", nullable: true),
                    petype = table.Column<int>(type: "integer", nullable: false),
                    pehighschooltype = table.Column<int>(type: "integer", nullable: false),
                    pediplomanumber = table.Column<string>(type: "text", nullable: true),
                    pediplomadate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    peresearcharea = table.Column<string>(type: "text", nullable: true),
                    peeducationalqualification = table.Column<string>(type: "text", nullable: true),
                    peinstitution = table.Column<string>(type: "text", nullable: true),
                    pesubordinate = table.Column<string>(type: "text", nullable: true),
                    peinstitutionspeciality = table.Column<string>(type: "text", nullable: true),
                    peinstitutionname = table.Column<string>(type: "text", nullable: true),
                    pesubordinatename = table.Column<string>(type: "text", nullable: true),
                    pespecialityname = table.Column<string>(type: "text", nullable: true),
                    pecountry = table.Column<string>(type: "text", nullable: true),
                    perecognizedspeciality = table.Column<string>(type: "text", nullable: true),
                    peacquiredspeciality = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persondoctoral", x => x.id);
                    table.ForeignKey(
                        name: "FK_persondoctoral_personbasic_personbasicid",
                        column: x => x.personbasicid,
                        principalTable: "personbasic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "personimage",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    key = table.Column<Guid>(type: "uuid", nullable: false),
                    hash = table.Column<string>(type: "text", nullable: true),
                    size = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    mimetype = table.Column<string>(type: "text", nullable: true),
                    dbid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personimage", x => x.id);
                    table.ForeignKey(
                        name: "FK_personimage_personbasic_id",
                        column: x => x.id,
                        principalTable: "personbasic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "personsecondary",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    graduationyear = table.Column<int>(type: "integer", nullable: false),
                    country = table.Column<string>(type: "text", nullable: true),
                    school = table.Column<string>(type: "text", nullable: true),
                    schoolsettlement = table.Column<string>(type: "text", nullable: true),
                    foreignschoolname = table.Column<string>(type: "text", nullable: true),
                    profession = table.Column<string>(type: "text", nullable: true),
                    diplomanumber = table.Column<string>(type: "text", nullable: true),
                    diplomadate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    personbasicid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personsecondary", x => x.id);
                    table.ForeignKey(
                        name: "FK_personsecondary_personbasic_personbasicid",
                        column: x => x.personbasicid,
                        principalTable: "personbasic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "personstudent",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    facultynumber = table.Column<string>(type: "text", nullable: true),
                    course = table.Column<int>(type: "integer", nullable: false),
                    studentsemester = table.Column<int>(type: "integer", nullable: false),
                    personbasicid = table.Column<int>(type: "integer", nullable: false),
                    institution = table.Column<string>(type: "text", nullable: true),
                    subordinate = table.Column<string>(type: "text", nullable: true),
                    institutionspeciality = table.Column<string>(type: "text", nullable: true),
                    studentstatus = table.Column<string>(type: "text", nullable: true),
                    studentevent = table.Column<string>(type: "text", nullable: true),
                    admissionreason = table.Column<string>(type: "text", nullable: true),
                    petype = table.Column<int>(type: "integer", nullable: false),
                    pehighschooltype = table.Column<int>(type: "integer", nullable: false),
                    pediplomanumber = table.Column<string>(type: "text", nullable: true),
                    pediplomadate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    peresearcharea = table.Column<string>(type: "text", nullable: true),
                    peeducationalqualification = table.Column<string>(type: "text", nullable: true),
                    peinstitution = table.Column<string>(type: "text", nullable: true),
                    pesubordinate = table.Column<string>(type: "text", nullable: true),
                    peinstitutionspeciality = table.Column<string>(type: "text", nullable: true),
                    peinstitutionname = table.Column<string>(type: "text", nullable: true),
                    pesubordinatename = table.Column<string>(type: "text", nullable: true),
                    pespecialityname = table.Column<string>(type: "text", nullable: true),
                    pecountry = table.Column<string>(type: "text", nullable: true),
                    perecognizedspeciality = table.Column<string>(type: "text", nullable: true),
                    peacquiredspeciality = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personstudent", x => x.id);
                    table.ForeignKey(
                        name: "FK_personstudent_personbasic_personbasicid",
                        column: x => x.personbasicid,
                        principalTable: "personbasic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "basepersonsemester",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    period = table.Column<string>(type: "text", nullable: true),
                    studentstatus = table.Column<string>(type: "text", nullable: true),
                    studentevent = table.Column<string>(type: "text", nullable: true),
                    educationfeetype = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    hasscholarship = table.Column<bool>(type: "boolean", nullable: false),
                    usehostel = table.Column<bool>(type: "boolean", nullable: false),
                    useholidaybase = table.Column<bool>(type: "boolean", nullable: false),
                    participatedintprograms = table.Column<bool>(type: "boolean", nullable: false),
                    persondoctoralid = table.Column<int>(type: "integer", nullable: true),
                    personstudentid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_basepersonsemester", x => x.id);
                    table.ForeignKey(
                        name: "FK_basepersonsemester_persondoctoral_persondoctoralid",
                        column: x => x.persondoctoralid,
                        principalTable: "persondoctoral",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_basepersonsemester_personstudent_personstudentid",
                        column: x => x.personstudentid,
                        principalTable: "personstudent",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_basepersonsemester_persondoctoralid",
                table: "basepersonsemester",
                column: "persondoctoralid");

            migrationBuilder.CreateIndex(
                name: "IX_basepersonsemester_personstudentid",
                table: "basepersonsemester",
                column: "personstudentid");

            migrationBuilder.CreateIndex(
                name: "IX_persondoctoral_personbasicid",
                table: "persondoctoral",
                column: "personbasicid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_personsecondary_personbasicid",
                table: "personsecondary",
                column: "personbasicid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_personstudent_personbasicid",
                table: "personstudent",
                column: "personbasicid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "basepersonsemester");

            migrationBuilder.DropTable(
                name: "personimage");

            migrationBuilder.DropTable(
                name: "personsecondary");

            migrationBuilder.DropTable(
                name: "persondoctoral");

            migrationBuilder.DropTable(
                name: "personstudent");

            migrationBuilder.DropTable(
                name: "personbasic");

            migrationBuilder.AlterColumn<DateTime>(
                name: "sentdate",
                table: "emailaddressee",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
