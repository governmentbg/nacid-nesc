// <auto-generated />
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
    [Migration("20221124092851_ChangeTableNameV2")]
    partial class ChangeTableNameV2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
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
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("sentdate");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("EmailId");

                    b.ToTable("emailaddressee");
                });

            modelBuilder.Entity("StudentCard.Data.HistoryLogs.HistoryLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("date");

                    b.Property<string>("IPAddress")
                        .HasColumnType("text")
                        .HasColumnName("ipaddress");

                    b.Property<string>("UAN")
                        .HasColumnType("text")
                        .HasColumnName("uan");

                    b.HasKey("Id");

                    b.ToTable("historylog");
                });

            modelBuilder.Entity("StudentCard.Data.IpAddresses.ExceptionIpAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.HasKey("Id");

                    b.ToTable("exceptionipaddress");
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

            modelBuilder.Entity("StudentCard.Data.Students.Student", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("birthdate");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<int>("ExternalId")
                        .HasColumnType("integer")
                        .HasColumnName("externalid");

                    b.Property<string>("UAN")
                        .HasColumnType("text")
                        .HasColumnName("uan");

                    b.Property<string>("Uin")
                        .HasColumnType("text")
                        .HasColumnName("uin");

                    b.HasKey("Id");

                    b.ToTable("student");
                });

            modelBuilder.Entity("StudentCard.Data.Users.PasswordToken", b =>
                {
                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("expirationtime");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("boolean")
                        .HasColumnName("isused");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.HasKey("Value");

                    b.HasIndex("UserId");

                    b.ToTable("passwordtoken");
                });

            modelBuilder.Entity("StudentCard.Data.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("createdate");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("NewEmailRequest")
                        .HasColumnType("text")
                        .HasColumnName("newemailrequest");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("text")
                        .HasColumnName("passwordsalt");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updatedate");

                    b.Property<string>("Username")
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("user");
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
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Email");
                });

            modelBuilder.Entity("StudentCard.Data.Students.Student", b =>
                {
                    b.HasOne("StudentCard.Data.Users.User", "User")
                        .WithOne()
                        .HasForeignKey("StudentCard.Data.Students.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentCard.Data.Users.PasswordToken", b =>
                {
                    b.HasOne("StudentCard.Data.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentCard.Data.Emails.Email", b =>
                {
                    b.Navigation("Addressees");
                });
#pragma warning restore 612, 618
        }
    }
}
