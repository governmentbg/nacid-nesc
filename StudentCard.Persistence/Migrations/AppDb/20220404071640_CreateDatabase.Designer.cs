﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StudentCard.Persistence;

#nullable disable

namespace StudentCard.Persistence.Migrations.AppDb
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220404071640_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StudentCard.Data.Emails.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .HasColumnType("text")
                        .HasColumnName("body");

                    b.Property<string>("Subject")
                        .HasColumnType("text")
                        .HasColumnName("subject");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer")
                        .HasColumnName("typeid");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("email");
                });

            modelBuilder.Entity("StudentCard.Data.Emails.EmailAddressee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<int>("AddresseeType")
                        .HasColumnType("integer")
                        .HasColumnName("addresseetype");

                    b.Property<int>("EmailId")
                        .HasColumnType("integer")
                        .HasColumnName("emailid");

                    b.Property<DateTime>("SentDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("sentdate");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("EmailId");

                    b.ToTable("emailaddressee");
                });

            modelBuilder.Entity("StudentCard.Data.Nomenclatures.EmailType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .HasColumnType("text")
                        .HasColumnName("alias");

                    b.Property<string>("Body")
                        .HasColumnType("text")
                        .HasColumnName("body");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("isactive");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Subject")
                        .HasColumnType("text")
                        .HasColumnName("subject");

                    b.Property<int?>("ViewOrder")
                        .HasColumnType("integer")
                        .HasColumnName("vieworder");

                    b.HasKey("Id");

                    b.ToTable("emailtype");
                });

            modelBuilder.Entity("StudentCard.Data.Students.Base.BasePersonSemester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("EducationFeeType")
                        .HasColumnType("text")
                        .HasColumnName("educationfeetype");

                    b.Property<bool>("HasScholarship")
                        .HasColumnType("boolean")
                        .HasColumnName("hasscholarship");

                    b.Property<string>("Note")
                        .HasColumnType("text")
                        .HasColumnName("note");

                    b.Property<bool>("ParticipatedIntPrograms")
                        .HasColumnType("boolean")
                        .HasColumnName("participatedintprograms");

                    b.Property<string>("Period")
                        .HasColumnType("text")
                        .HasColumnName("period");

                    b.Property<int?>("PersonDoctoralId")
                        .HasColumnType("integer")
                        .HasColumnName("persondoctoralid");

                    b.Property<int?>("PersonStudentId")
                        .HasColumnType("integer")
                        .HasColumnName("personstudentid");

                    b.Property<string>("StudentEvent")
                        .HasColumnType("text")
                        .HasColumnName("studentevent");

                    b.Property<string>("StudentStatus")
                        .HasColumnType("text")
                        .HasColumnName("studentstatus");

                    b.Property<bool>("UseHolidayBase")
                        .HasColumnType("boolean")
                        .HasColumnName("useholidaybase");

                    b.Property<bool>("UseHostel")
                        .HasColumnType("boolean")
                        .HasColumnName("usehostel");

                    b.HasKey("Id");

                    b.HasIndex("PersonDoctoralId");

                    b.HasIndex("PersonStudentId");

                    b.ToTable("basepersonsemester");
                });

            modelBuilder.Entity("StudentCard.Data.Students.PersonBasic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BirthCountry")
                        .HasColumnType("text")
                        .HasColumnName("birthcountry");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birthdate");

                    b.Property<string>("BirthDistrict")
                        .HasColumnType("text")
                        .HasColumnName("birthdistrict");

                    b.Property<string>("BirthMunicipality")
                        .HasColumnType("text")
                        .HasColumnName("birthmunicipality");

                    b.Property<string>("BirthSettlement")
                        .HasColumnType("text")
                        .HasColumnName("birthsettlement");

                    b.Property<string>("Citizenship")
                        .HasColumnType("text")
                        .HasColumnName("citizenship");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("firstname");

                    b.Property<string>("FirstNameAlt")
                        .HasColumnType("text")
                        .HasColumnName("firstnamealt");

                    b.Property<string>("ForeignerBirthSettlement")
                        .HasColumnType("text")
                        .HasColumnName("foreignerbirthsettlement");

                    b.Property<string>("ForeignerNumber")
                        .HasColumnType("text")
                        .HasColumnName("foreignernumber");

                    b.Property<string>("FullName")
                        .HasColumnType("text")
                        .HasColumnName("fullname");

                    b.Property<string>("FullNameAlt")
                        .HasColumnType("text")
                        .HasColumnName("fullnamealt");

                    b.Property<int>("Gender")
                        .HasColumnType("integer")
                        .HasColumnName("gender");

                    b.Property<string>("IdnNumber")
                        .HasColumnType("text")
                        .HasColumnName("idnnumber");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("lastname");

                    b.Property<string>("LastNameAlt")
                        .HasColumnType("text")
                        .HasColumnName("lastnamealt");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text")
                        .HasColumnName("middlename");

                    b.Property<string>("MiddleNameAlt")
                        .HasColumnType("text")
                        .HasColumnName("middlenamealt");

                    b.Property<string>("OtherNames")
                        .HasColumnType("text")
                        .HasColumnName("othernames");

                    b.Property<string>("OtherNamesAlt")
                        .HasColumnType("text")
                        .HasColumnName("othernamesalt");

                    b.Property<int?>("PersonDoctoralId")
                        .HasColumnType("integer")
                        .HasColumnName("persondoctoralid");

                    b.Property<int?>("PersonSecondaryId")
                        .HasColumnType("integer")
                        .HasColumnName("personsecondaryid");

                    b.Property<int?>("PersonStudentId")
                        .HasColumnType("integer")
                        .HasColumnName("personstudentid");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phonenumber");

                    b.Property<string>("PostCode")
                        .HasColumnType("text")
                        .HasColumnName("postcode");

                    b.Property<string>("ResidenceAddress")
                        .HasColumnType("text")
                        .HasColumnName("residenceaddress");

                    b.Property<string>("ResidenceCountry")
                        .HasColumnType("text")
                        .HasColumnName("residencecountry");

                    b.Property<string>("ResidenceDistrict")
                        .HasColumnType("text")
                        .HasColumnName("residencedistrict");

                    b.Property<string>("ResidenceMunicipality")
                        .HasColumnType("text")
                        .HasColumnName("residencemunicipality");

                    b.Property<string>("ResidenceSettlement")
                        .HasColumnType("text")
                        .HasColumnName("residencesettlement");

                    b.Property<string>("SecondCitizenship")
                        .HasColumnType("text")
                        .HasColumnName("secondcitizenship");

                    b.Property<string>("Uin")
                        .HasColumnType("text")
                        .HasColumnName("uin");

                    b.HasKey("Id");

                    b.ToTable("personbasic");
                });

            modelBuilder.Entity("StudentCard.Data.Students.PersonDoctoral", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AdmissionReason")
                        .HasColumnType("text")
                        .HasColumnName("admissionreason");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("enddate");

                    b.Property<string>("Institution")
                        .HasColumnType("text")
                        .HasColumnName("institution");

                    b.Property<string>("InstitutionSpeciality")
                        .HasColumnType("text")
                        .HasColumnName("institutionspeciality");

                    b.Property<string>("PeAcquiredSpeciality")
                        .HasColumnType("text")
                        .HasColumnName("peacquiredspeciality");

                    b.Property<string>("PeCountry")
                        .HasColumnType("text")
                        .HasColumnName("pecountry");

                    b.Property<DateTime?>("PeDiplomaDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("pediplomadate");

                    b.Property<string>("PeDiplomaNumber")
                        .HasColumnType("text")
                        .HasColumnName("pediplomanumber");

                    b.Property<string>("PeEducationalQualification")
                        .HasColumnType("text")
                        .HasColumnName("peeducationalqualification");

                    b.Property<int>("PeHighSchoolType")
                        .HasColumnType("integer")
                        .HasColumnName("pehighschooltype");

                    b.Property<string>("PeInstitution")
                        .HasColumnType("text")
                        .HasColumnName("peinstitution");

                    b.Property<string>("PeInstitutionName")
                        .HasColumnType("text")
                        .HasColumnName("peinstitutionname");

                    b.Property<string>("PeInstitutionSpeciality")
                        .HasColumnType("text")
                        .HasColumnName("peinstitutionspeciality");

                    b.Property<string>("PeRecognizedSpeciality")
                        .HasColumnType("text")
                        .HasColumnName("perecognizedspeciality");

                    b.Property<string>("PeResearchArea")
                        .HasColumnType("text")
                        .HasColumnName("peresearcharea");

                    b.Property<string>("PeSpecialityName")
                        .HasColumnType("text")
                        .HasColumnName("pespecialityname");

                    b.Property<string>("PeSubordinate")
                        .HasColumnType("text")
                        .HasColumnName("pesubordinate");

                    b.Property<string>("PeSubordinateName")
                        .HasColumnType("text")
                        .HasColumnName("pesubordinatename");

                    b.Property<int>("PeType")
                        .HasColumnType("integer")
                        .HasColumnName("petype");

                    b.Property<int>("PersonBasicId")
                        .HasColumnType("integer")
                        .HasColumnName("personbasicid");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("startdate");

                    b.Property<string>("StudentEvent")
                        .HasColumnType("text")
                        .HasColumnName("studentevent");

                    b.Property<string>("StudentStatus")
                        .HasColumnType("text")
                        .HasColumnName("studentstatus");

                    b.Property<string>("Subordinate")
                        .HasColumnType("text")
                        .HasColumnName("subordinate");

                    b.HasKey("Id");

                    b.HasIndex("PersonBasicId")
                        .IsUnique();

                    b.ToTable("persondoctoral");
                });

            modelBuilder.Entity("StudentCard.Data.Students.PersonImage", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<int>("DbId")
                        .HasColumnType("integer")
                        .HasColumnName("dbid");

                    b.Property<string>("Hash")
                        .HasColumnType("text")
                        .HasColumnName("hash");

                    b.Property<Guid>("Key")
                        .HasColumnType("uuid")
                        .HasColumnName("key");

                    b.Property<string>("MimeType")
                        .HasColumnType("text")
                        .HasColumnName("mimetype");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<long>("Size")
                        .HasColumnType("bigint")
                        .HasColumnName("size");

                    b.HasKey("Id");

                    b.ToTable("personimage");
                });

            modelBuilder.Entity("StudentCard.Data.Students.PersonSecondary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .HasColumnType("text")
                        .HasColumnName("country");

                    b.Property<DateTime?>("DiplomaDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("diplomadate");

                    b.Property<string>("DiplomaNumber")
                        .HasColumnType("text")
                        .HasColumnName("diplomanumber");

                    b.Property<string>("ForeignSchoolName")
                        .HasColumnType("text")
                        .HasColumnName("foreignschoolname");

                    b.Property<int>("GraduationYear")
                        .HasColumnType("integer")
                        .HasColumnName("graduationyear");

                    b.Property<int>("PersonBasicId")
                        .HasColumnType("integer")
                        .HasColumnName("personbasicid");

                    b.Property<string>("Profession")
                        .HasColumnType("text")
                        .HasColumnName("profession");

                    b.Property<string>("School")
                        .HasColumnType("text")
                        .HasColumnName("school");

                    b.Property<string>("SchoolSettlement")
                        .HasColumnType("text")
                        .HasColumnName("schoolsettlement");

                    b.HasKey("Id");

                    b.HasIndex("PersonBasicId")
                        .IsUnique();

                    b.ToTable("personsecondary");
                });

            modelBuilder.Entity("StudentCard.Data.Students.PersonStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AdmissionReason")
                        .HasColumnType("text")
                        .HasColumnName("admissionreason");

                    b.Property<int>("Course")
                        .HasColumnType("integer")
                        .HasColumnName("course");

                    b.Property<string>("FacultyNumber")
                        .HasColumnType("text")
                        .HasColumnName("facultynumber");

                    b.Property<string>("Institution")
                        .HasColumnType("text")
                        .HasColumnName("institution");

                    b.Property<string>("InstitutionSpeciality")
                        .HasColumnType("text")
                        .HasColumnName("institutionspeciality");

                    b.Property<string>("PeAcquiredSpeciality")
                        .HasColumnType("text")
                        .HasColumnName("peacquiredspeciality");

                    b.Property<string>("PeCountry")
                        .HasColumnType("text")
                        .HasColumnName("pecountry");

                    b.Property<DateTime?>("PeDiplomaDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("pediplomadate");

                    b.Property<string>("PeDiplomaNumber")
                        .HasColumnType("text")
                        .HasColumnName("pediplomanumber");

                    b.Property<string>("PeEducationalQualification")
                        .HasColumnType("text")
                        .HasColumnName("peeducationalqualification");

                    b.Property<int>("PeHighSchoolType")
                        .HasColumnType("integer")
                        .HasColumnName("pehighschooltype");

                    b.Property<string>("PeInstitution")
                        .HasColumnType("text")
                        .HasColumnName("peinstitution");

                    b.Property<string>("PeInstitutionName")
                        .HasColumnType("text")
                        .HasColumnName("peinstitutionname");

                    b.Property<string>("PeInstitutionSpeciality")
                        .HasColumnType("text")
                        .HasColumnName("peinstitutionspeciality");

                    b.Property<string>("PeRecognizedSpeciality")
                        .HasColumnType("text")
                        .HasColumnName("perecognizedspeciality");

                    b.Property<string>("PeResearchArea")
                        .HasColumnType("text")
                        .HasColumnName("peresearcharea");

                    b.Property<string>("PeSpecialityName")
                        .HasColumnType("text")
                        .HasColumnName("pespecialityname");

                    b.Property<string>("PeSubordinate")
                        .HasColumnType("text")
                        .HasColumnName("pesubordinate");

                    b.Property<string>("PeSubordinateName")
                        .HasColumnType("text")
                        .HasColumnName("pesubordinatename");

                    b.Property<int>("PeType")
                        .HasColumnType("integer")
                        .HasColumnName("petype");

                    b.Property<int>("PersonBasicId")
                        .HasColumnType("integer")
                        .HasColumnName("personbasicid");

                    b.Property<string>("StudentEvent")
                        .HasColumnType("text")
                        .HasColumnName("studentevent");

                    b.Property<int>("StudentSemester")
                        .HasColumnType("integer")
                        .HasColumnName("studentsemester");

                    b.Property<string>("StudentStatus")
                        .HasColumnType("text")
                        .HasColumnName("studentstatus");

                    b.Property<string>("Subordinate")
                        .HasColumnType("text")
                        .HasColumnName("subordinate");

                    b.HasKey("Id");

                    b.HasIndex("PersonBasicId")
                        .IsUnique();

                    b.ToTable("personstudent");
                });

            modelBuilder.Entity("StudentCard.Data.Emails.Email", b =>
                {
                    b.HasOne("StudentCard.Data.Nomenclatures.EmailType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("StudentCard.Data.Emails.EmailAddressee", b =>
                {
                    b.HasOne("StudentCard.Data.Emails.Email", "Email")
                        .WithMany("Addressees")
                        .HasForeignKey("EmailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Email");
                });

            modelBuilder.Entity("StudentCard.Data.Students.Base.BasePersonSemester", b =>
                {
                    b.HasOne("StudentCard.Data.Students.PersonDoctoral", null)
                        .WithMany("Semesters")
                        .HasForeignKey("PersonDoctoralId");

                    b.HasOne("StudentCard.Data.Students.PersonStudent", null)
                        .WithMany("Semesters")
                        .HasForeignKey("PersonStudentId");
                });

            modelBuilder.Entity("StudentCard.Data.Students.PersonDoctoral", b =>
                {
                    b.HasOne("StudentCard.Data.Students.PersonBasic", "PersonBasic")
                        .WithOne("PersonDoctoral")
                        .HasForeignKey("StudentCard.Data.Students.PersonDoctoral", "PersonBasicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonBasic");
                });

            modelBuilder.Entity("StudentCard.Data.Students.PersonImage", b =>
                {
                    b.HasOne("StudentCard.Data.Students.PersonBasic", "PersonBasic")
                        .WithOne("PersonImage")
                        .HasForeignKey("StudentCard.Data.Students.PersonImage", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonBasic");
                });

            modelBuilder.Entity("StudentCard.Data.Students.PersonSecondary", b =>
                {
                    b.HasOne("StudentCard.Data.Students.PersonBasic", "PersonBasic")
                        .WithOne("PersonSecondary")
                        .HasForeignKey("StudentCard.Data.Students.PersonSecondary", "PersonBasicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonBasic");
                });

            modelBuilder.Entity("StudentCard.Data.Students.PersonStudent", b =>
                {
                    b.HasOne("StudentCard.Data.Students.PersonBasic", "PersonBasic")
                        .WithOne("PersonStudent")
                        .HasForeignKey("StudentCard.Data.Students.PersonStudent", "PersonBasicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonBasic");
                });

            modelBuilder.Entity("StudentCard.Data.Emails.Email", b =>
                {
                    b.Navigation("Addressees");
                });

            modelBuilder.Entity("StudentCard.Data.Students.PersonBasic", b =>
                {
                    b.Navigation("PersonDoctoral");

                    b.Navigation("PersonImage");

                    b.Navigation("PersonSecondary");

                    b.Navigation("PersonStudent");
                });

            modelBuilder.Entity("StudentCard.Data.Students.PersonDoctoral", b =>
                {
                    b.Navigation("Semesters");
                });

            modelBuilder.Entity("StudentCard.Data.Students.PersonStudent", b =>
                {
                    b.Navigation("Semesters");
                });
#pragma warning restore 612, 618
        }
    }
}
