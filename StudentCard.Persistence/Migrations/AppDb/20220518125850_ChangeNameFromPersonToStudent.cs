using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

#nullable disable

namespace StudentCard.Persistence.Migrations.AppDb
{
    public partial class ChangeNameFromPersonToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "studentbasic",
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
                    table.PrimaryKey("PK_studentbasic", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "studentdoctoral",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    startdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    enddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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
                    peacquiredforeigneducationalqualification = table.Column<string>(type: "text", nullable: true),
                    peinstitution = table.Column<string>(type: "text", nullable: true),
                    pesubordinate = table.Column<string>(type: "text", nullable: true),
                    peinstitutionspeciality = table.Column<string>(type: "text", nullable: true),
                    peinstitutionname = table.Column<string>(type: "text", nullable: true),
                    pesubordinatename = table.Column<string>(type: "text", nullable: true),
                    pespecialityname = table.Column<string>(type: "text", nullable: true),
                    pecountry = table.Column<string>(type: "text", nullable: true),
                    perecognizedspeciality = table.Column<string>(type: "text", nullable: true),
                    peacquiredspeciality = table.Column<string>(type: "text", nullable: true),
                    perecognitionnumber = table.Column<string>(type: "text", nullable: true),
                    perecognitiondate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentdoctoral", x => x.id);
                    table.ForeignKey(
                        name: "FK_studentdoctoral_studentbasic_id",
                        column: x => x.id,
                        principalTable: "studentbasic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentimage",
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
                    table.PrimaryKey("PK_studentimage", x => x.id);
                    table.ForeignKey(
                        name: "FK_studentimage_studentbasic_id",
                        column: x => x.id,
                        principalTable: "studentbasic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentsecondary",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    graduationyear = table.Column<int>(type: "integer", nullable: false),
                    country = table.Column<string>(type: "text", nullable: true),
                    school = table.Column<string>(type: "text", nullable: true),
                    schoolsettlement = table.Column<string>(type: "text", nullable: true),
                    foreignschoolname = table.Column<string>(type: "text", nullable: true),
                    profession = table.Column<string>(type: "text", nullable: true),
                    diplomanumber = table.Column<string>(type: "text", nullable: true),
                    diplomadate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    recognitionnumber = table.Column<string>(type: "text", nullable: true),
                    recognitiondate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentsecondary", x => x.id);
                    table.ForeignKey(
                        name: "FK_studentsecondary_studentbasic_id",
                        column: x => x.id,
                        principalTable: "studentbasic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentuniversity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    facultynumber = table.Column<string>(type: "text", nullable: true),
                    course = table.Column<int>(type: "integer", nullable: false),
                    studentsemester = table.Column<int>(type: "integer", nullable: false),
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
                    peacquiredforeigneducationalqualification = table.Column<string>(type: "text", nullable: true),
                    peinstitution = table.Column<string>(type: "text", nullable: true),
                    pesubordinate = table.Column<string>(type: "text", nullable: true),
                    peinstitutionspeciality = table.Column<string>(type: "text", nullable: true),
                    peinstitutionname = table.Column<string>(type: "text", nullable: true),
                    pesubordinatename = table.Column<string>(type: "text", nullable: true),
                    pespecialityname = table.Column<string>(type: "text", nullable: true),
                    pecountry = table.Column<string>(type: "text", nullable: true),
                    perecognizedspeciality = table.Column<string>(type: "text", nullable: true),
                    peacquiredspeciality = table.Column<string>(type: "text", nullable: true),
                    perecognitionnumber = table.Column<string>(type: "text", nullable: true),
                    perecognitiondate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentuniversity", x => x.id);
                    table.ForeignKey(
                        name: "FK_studentuniversity_studentbasic_id",
                        column: x => x.id,
                        principalTable: "studentbasic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "basestudentsemester",
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
                    studentdoctoralid = table.Column<int>(type: "integer", nullable: true),
                    studentuniversityid = table.Column<int>(type: "integer", nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "basestudentsemester");

            migrationBuilder.DropTable(
                name: "studentimage");

            migrationBuilder.DropTable(
                name: "studentsecondary");

            migrationBuilder.DropTable(
                name: "studentdoctoral");

            migrationBuilder.DropTable(
                name: "studentuniversity");

            migrationBuilder.DropTable(
                name: "studentbasic");

            migrationBuilder.CreateTable(
                name: "personbasic",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    birthcountry = table.Column<string>(type: "text", nullable: true),
                    birthdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    birthdistrict = table.Column<string>(type: "text", nullable: true),
                    birthmunicipality = table.Column<string>(type: "text", nullable: true),
                    birthsettlement = table.Column<string>(type: "text", nullable: true),
                    citizenship = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    firstname = table.Column<string>(type: "text", nullable: true),
                    firstnamealt = table.Column<string>(type: "text", nullable: true),
                    foreignerbirthsettlement = table.Column<string>(type: "text", nullable: true),
                    foreignernumber = table.Column<string>(type: "text", nullable: true),
                    fullname = table.Column<string>(type: "text", nullable: true),
                    fullnamealt = table.Column<string>(type: "text", nullable: true),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    idnnumber = table.Column<string>(type: "text", nullable: true),
                    lastname = table.Column<string>(type: "text", nullable: true),
                    lastnamealt = table.Column<string>(type: "text", nullable: true),
                    middlename = table.Column<string>(type: "text", nullable: true),
                    middlenamealt = table.Column<string>(type: "text", nullable: true),
                    othernames = table.Column<string>(type: "text", nullable: true),
                    othernamesalt = table.Column<string>(type: "text", nullable: true),
                    persondoctoralid = table.Column<int>(type: "integer", nullable: true),
                    personsecondaryid = table.Column<int>(type: "integer", nullable: true),
                    personstudentid = table.Column<int>(type: "integer", nullable: true),
                    phonenumber = table.Column<string>(type: "text", nullable: true),
                    postcode = table.Column<string>(type: "text", nullable: true),
                    residenceaddress = table.Column<string>(type: "text", nullable: true),
                    residencecountry = table.Column<string>(type: "text", nullable: true),
                    residencedistrict = table.Column<string>(type: "text", nullable: true),
                    residencemunicipality = table.Column<string>(type: "text", nullable: true),
                    residencesettlement = table.Column<string>(type: "text", nullable: true),
                    secondcitizenship = table.Column<string>(type: "text", nullable: true),
                    uin = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personbasic", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "persondoctoral",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    admissionreason = table.Column<string>(type: "text", nullable: true),
                    enddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    institution = table.Column<string>(type: "text", nullable: true),
                    institutionspeciality = table.Column<string>(type: "text", nullable: true),
                    peacquiredforeigneducationalqualification = table.Column<string>(type: "text", nullable: true),
                    peacquiredspeciality = table.Column<string>(type: "text", nullable: true),
                    pecountry = table.Column<string>(type: "text", nullable: true),
                    pediplomadate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    pediplomanumber = table.Column<string>(type: "text", nullable: true),
                    peeducationalqualification = table.Column<string>(type: "text", nullable: true),
                    pehighschooltype = table.Column<int>(type: "integer", nullable: false),
                    peinstitution = table.Column<string>(type: "text", nullable: true),
                    peinstitutionname = table.Column<string>(type: "text", nullable: true),
                    peinstitutionspeciality = table.Column<string>(type: "text", nullable: true),
                    perecognitiondate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    perecognitionnumber = table.Column<string>(type: "text", nullable: true),
                    perecognizedspeciality = table.Column<string>(type: "text", nullable: true),
                    peresearcharea = table.Column<string>(type: "text", nullable: true),
                    pespecialityname = table.Column<string>(type: "text", nullable: true),
                    pesubordinate = table.Column<string>(type: "text", nullable: true),
                    pesubordinatename = table.Column<string>(type: "text", nullable: true),
                    petype = table.Column<int>(type: "integer", nullable: false),
                    startdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    studentevent = table.Column<string>(type: "text", nullable: true),
                    studentstatus = table.Column<string>(type: "text", nullable: true),
                    subordinate = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persondoctoral", x => x.id);
                    table.ForeignKey(
                        name: "FK_persondoctoral_personbasic_id",
                        column: x => x.id,
                        principalTable: "personbasic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "personimage",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    dbid = table.Column<int>(type: "integer", nullable: false),
                    hash = table.Column<string>(type: "text", nullable: true),
                    key = table.Column<Guid>(type: "uuid", nullable: false),
                    mimetype = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    size = table.Column<long>(type: "bigint", nullable: false)
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
                    id = table.Column<int>(type: "integer", nullable: false),
                    country = table.Column<string>(type: "text", nullable: true),
                    diplomadate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    diplomanumber = table.Column<string>(type: "text", nullable: true),
                    foreignschoolname = table.Column<string>(type: "text", nullable: true),
                    graduationyear = table.Column<int>(type: "integer", nullable: false),
                    profession = table.Column<string>(type: "text", nullable: true),
                    recognitiondate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    recognitionnumber = table.Column<string>(type: "text", nullable: true),
                    school = table.Column<string>(type: "text", nullable: true),
                    schoolsettlement = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personsecondary", x => x.id);
                    table.ForeignKey(
                        name: "FK_personsecondary_personbasic_id",
                        column: x => x.id,
                        principalTable: "personbasic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "personstudent",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    admissionreason = table.Column<string>(type: "text", nullable: true),
                    course = table.Column<int>(type: "integer", nullable: false),
                    facultynumber = table.Column<string>(type: "text", nullable: true),
                    institution = table.Column<string>(type: "text", nullable: true),
                    institutionspeciality = table.Column<string>(type: "text", nullable: true),
                    peacquiredforeigneducationalqualification = table.Column<string>(type: "text", nullable: true),
                    peacquiredspeciality = table.Column<string>(type: "text", nullable: true),
                    pecountry = table.Column<string>(type: "text", nullable: true),
                    pediplomadate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    pediplomanumber = table.Column<string>(type: "text", nullable: true),
                    peeducationalqualification = table.Column<string>(type: "text", nullable: true),
                    pehighschooltype = table.Column<int>(type: "integer", nullable: false),
                    peinstitution = table.Column<string>(type: "text", nullable: true),
                    peinstitutionname = table.Column<string>(type: "text", nullable: true),
                    peinstitutionspeciality = table.Column<string>(type: "text", nullable: true),
                    perecognitiondate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    perecognitionnumber = table.Column<string>(type: "text", nullable: true),
                    perecognizedspeciality = table.Column<string>(type: "text", nullable: true),
                    peresearcharea = table.Column<string>(type: "text", nullable: true),
                    pespecialityname = table.Column<string>(type: "text", nullable: true),
                    pesubordinate = table.Column<string>(type: "text", nullable: true),
                    pesubordinatename = table.Column<string>(type: "text", nullable: true),
                    petype = table.Column<int>(type: "integer", nullable: false),
                    studentevent = table.Column<string>(type: "text", nullable: true),
                    studentsemester = table.Column<int>(type: "integer", nullable: false),
                    studentstatus = table.Column<string>(type: "text", nullable: true),
                    subordinate = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personstudent", x => x.id);
                    table.ForeignKey(
                        name: "FK_personstudent_personbasic_id",
                        column: x => x.id,
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
                    educationfeetype = table.Column<string>(type: "text", nullable: true),
                    hasscholarship = table.Column<bool>(type: "boolean", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    participatedintprograms = table.Column<bool>(type: "boolean", nullable: false),
                    period = table.Column<string>(type: "text", nullable: true),
                    persondoctoralid = table.Column<int>(type: "integer", nullable: true),
                    personstudentid = table.Column<int>(type: "integer", nullable: true),
                    studentevent = table.Column<string>(type: "text", nullable: true),
                    studentstatus = table.Column<string>(type: "text", nullable: true),
                    useholidaybase = table.Column<bool>(type: "boolean", nullable: false),
                    usehostel = table.Column<bool>(type: "boolean", nullable: false)
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
        }
    }
}
