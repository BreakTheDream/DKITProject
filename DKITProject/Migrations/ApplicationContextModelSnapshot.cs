﻿// <auto-generated />
using System;
using DKITProject.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DKITProject.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DKITProject.DAL.Models.Achievement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Announce");

                    b.Property<bool>("Approved");

                    b.Property<string>("Content");

                    b.Property<string>("Headline");

                    b.Property<string>("Images");

                    b.Property<string>("ImgPreview");

                    b.HasKey("Id");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("DKITProject.DAL.Models.AdditionalEducation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Announce");

                    b.Property<string>("Content");

                    b.Property<int>("Count");

                    b.Property<DateTime>("DateEnd");

                    b.Property<DateTime>("DatePost");

                    b.Property<DateTime>("DateStart");

                    b.Property<string>("Headline");

                    b.Property<string>("ImgIcon");

                    b.Property<string>("ImgPreview");

                    b.HasKey("Id");

                    b.ToTable("AdditionalEducations");
                });

            modelBuilder.Entity("DKITProject.DAL.Models.AdditionalEducationParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalEducationId");

                    b.Property<int?>("AdditionalEducationId1");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalEducationId1");

                    b.ToTable("AdditionalEducationParticipants");
                });

            modelBuilder.Entity("DKITProject.DAL.Models.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Img");

                    b.HasKey("Id");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("DKITProject.DAL.Models.ControlNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count");

                    b.Property<int>("SpecialtyId");

                    b.HasKey("Id");

                    b.HasIndex("SpecialtyId")
                        .IsUnique();

                    b.ToTable("ControlNumbers");
                });

            modelBuilder.Entity("DKITProject.DAL.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("DKITProject.DAL.Models.New", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Announce");

                    b.Property<bool>("Approved");

                    b.Property<string>("Content");

                    b.Property<DateTime>("DatePost");

                    b.Property<string>("Headline");

                    b.Property<string>("Images");

                    b.Property<string>("ImgPreview");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("DKITProject.DAL.Models.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Img");

                    b.HasKey("Id");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("DKITProject.DAL.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DKITProject.DAL.Models.Specialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Announce");

                    b.Property<string>("Content");

                    b.Property<string>("ImgIcon");

                    b.Property<string>("ImgPreviev");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("DKITProject.DAL.Models.Timetable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Img");

                    b.Property<int>("TimetableTypeId");

                    b.Property<string>("TimetableTypeId1");

                    b.HasKey("Id");

                    b.HasIndex("TimetableTypeId1");

                    b.ToTable("Timetables");
                });

            modelBuilder.Entity("DKITProject.DAL.Models.TimetableType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TimetableTypes");
                });

            modelBuilder.Entity("DKITProject.DAL.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName");

                    b.Property<int>("GroupId");

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DKITProject.DAL.Models.Workshop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Announce");

                    b.Property<string>("Content");

                    b.Property<int>("Count");

                    b.Property<DateTime>("DateEnd");

                    b.Property<DateTime>("DatePost");

                    b.Property<DateTime>("DateStart");

                    b.Property<string>("Headline");

                    b.Property<string>("ImgIcon");

                    b.Property<string>("ImgPreview");

                    b.HasKey("Id");

                    b.ToTable("Workshops");
                });

            modelBuilder.Entity("DKITProject.DAL.Models.WorkshopParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("WorkshopId");

                    b.Property<int?>("WorkshopId1");

                    b.HasKey("Id");

                    b.HasIndex("WorkshopId1");

                    b.ToTable("WorkshopParticipants");
                });

            modelBuilder.Entity("DKITProject.DAL.Models.AdditionalEducationParticipant", b =>
                {
                    b.HasOne("DKITProject.DAL.Models.AdditionalEducation", "AdditionalEducation")
                        .WithMany("AdditionalEducationParticipants")
                        .HasForeignKey("AdditionalEducationId1");
                });

            modelBuilder.Entity("DKITProject.DAL.Models.ControlNumber", b =>
                {
                    b.HasOne("DKITProject.DAL.Models.Specialty", "Specialty")
                        .WithOne("ControlNumber")
                        .HasForeignKey("DKITProject.DAL.Models.ControlNumber", "SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DKITProject.DAL.Models.Timetable", b =>
                {
                    b.HasOne("DKITProject.DAL.Models.TimetableType", "TimetableType")
                        .WithMany()
                        .HasForeignKey("TimetableTypeId1");
                });

            modelBuilder.Entity("DKITProject.DAL.Models.User", b =>
                {
                    b.HasOne("DKITProject.DAL.Models.Group", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DKITProject.DAL.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DKITProject.DAL.Models.WorkshopParticipant", b =>
                {
                    b.HasOne("DKITProject.DAL.Models.Workshop", "Workshop")
                        .WithMany("WorkshopParticipants")
                        .HasForeignKey("WorkshopId1");
                });
#pragma warning restore 612, 618
        }
    }
}
