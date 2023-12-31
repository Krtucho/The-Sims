﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220611042848_addallDataBase")]
    partial class addallDataBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("WebApplication1.Models.Activity", b =>
                {
                    b.Property<int>("ActivityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SkillID")
                        .HasColumnType("int");

                    b.HasKey("ActivityID");

                    b.HasIndex("SkillID");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("WebApplication1.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("WebApplication1.Models.Date", b =>
                {
                    b.Property<string>("DateID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DateID");

                    b.ToTable("Date");
                });

            modelBuilder.Entity("WebApplication1.Models.Gender", b =>
                {
                    b.Property<string>("GenderID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("GenderID");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("WebApplication1.Models.Home", b =>
                {
                    b.Property<int>("HomeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Bathrooms")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NeighborhoodID")
                        .HasColumnType("int");

                    b.Property<int>("Rooms")
                        .HasColumnType("int");

                    b.HasKey("HomeID");

                    b.HasIndex("NeighborhoodID");

                    b.ToTable("Home");
                });

            modelBuilder.Entity("WebApplication1.Models.LifeStage", b =>
                {
                    b.Property<string>("LifeStageID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LifeStageID");

                    b.ToTable("LifeStage");
                });

            modelBuilder.Entity("WebApplication1.Models.Mission", b =>
                {
                    b.Property<int>("MissionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Reward")
                        .HasColumnType("int");

                    b.Property<int>("WorldID")
                        .HasColumnType("int");

                    b.HasKey("MissionID");

                    b.HasIndex("WorldID");

                    b.ToTable("Mission");
                });

            modelBuilder.Entity("WebApplication1.Models.Neighborhood", b =>
                {
                    b.Property<int>("NeighborhoodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SkillID")
                        .HasColumnType("int");

                    b.Property<int>("WorldID")
                        .HasColumnType("int");

                    b.HasKey("NeighborhoodID");

                    b.HasIndex("SkillID");

                    b.HasIndex("WorldID");

                    b.ToTable("Neighborhood");
                });

            modelBuilder.Entity("WebApplication1.Models.Pet", b =>
                {
                    b.Property<int>("PetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("HomeID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PetTypeID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PetID");

                    b.HasIndex("HomeID");

                    b.HasIndex("PetTypeID");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("WebApplication1.Models.PetType", b =>
                {
                    b.Property<string>("PetTypeID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PetTypeID");

                    b.ToTable("PetType");
                });

            modelBuilder.Entity("WebApplication1.Models.Place", b =>
                {
                    b.Property<int>("PlaceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NeighborhoodID")
                        .HasColumnType("int");

                    b.HasKey("PlaceID");

                    b.HasIndex("NeighborhoodID");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("WebApplication1.Models.Profession", b =>
                {
                    b.Property<int>("ProfessionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BasicSalary")
                        .HasColumnType("int");

                    b.HasKey("ProfessionID");

                    b.ToTable("Profession");
                });

            modelBuilder.Entity("WebApplication1.Models.Relations.Activity_RSkill", b =>
                {
                    b.Property<int>("ActivityID")
                        .HasColumnType("int");

                    b.Property<int>("RequieredPoints")
                        .HasColumnType("int");

                    b.HasKey("ActivityID");

                    b.ToTable("Activity_RSkills");
                });

            modelBuilder.Entity("WebApplication1.Models.Relations.Mission_Requieres_Skill", b =>
                {
                    b.Property<int>("MissionID")
                        .HasColumnType("int");

                    b.Property<int>("SkillID")
                        .HasColumnType("int");

                    b.Property<int?>("MissiondID")
                        .HasColumnType("int");

                    b.Property<int>("RequieredPoint")
                        .HasColumnType("int");

                    b.HasKey("MissionID", "SkillID");

                    b.HasIndex("MissiondID");

                    b.HasIndex("SkillID");

                    b.ToTable("Mission_Requieres_Skills");
                });

            modelBuilder.Entity("WebApplication1.Models.Relations.Profession_Skill", b =>
                {
                    b.Property<int>("ProfessionID")
                        .HasColumnType("int");

                    b.Property<int>("ScoreLevel")
                        .HasColumnType("int");

                    b.Property<int>("SkillID")
                        .HasColumnType("int");

                    b.HasKey("ProfessionID");

                    b.HasIndex("SkillID");

                    b.ToTable("Profession_Skill");
                });

            modelBuilder.Entity("WebApplication1.Models.Relations.ServicePlace", b =>
                {
                    b.Property<int>("PlaceID")
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.HasKey("PlaceID");

                    b.ToTable("ServicePlace");
                });

            modelBuilder.Entity("WebApplication1.Models.Relations.Sim_Profession", b =>
                {
                    b.Property<int>("SimID")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("ProfessionID")
                        .HasColumnType("int");

                    b.HasKey("SimID");

                    b.HasIndex("ProfessionID");

                    b.ToTable("Sim_Profession");
                });

            modelBuilder.Entity("WebApplication1.Models.Relations.Sim_Skill", b =>
                {
                    b.Property<int>("SimID")
                        .HasColumnType("int");

                    b.Property<int>("SkillID")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("SimID", "SkillID");

                    b.HasIndex("SkillID");

                    b.ToTable("Sim_Skill");
                });

            modelBuilder.Entity("WebApplication1.Models.Relations.Traveler", b =>
                {
                    b.Property<int>("SimID")
                        .HasColumnType("int");

                    b.Property<int>("WorldID")
                        .HasColumnType("int");

                    b.Property<string>("DateID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SimID", "WorldID", "DateID");

                    b.HasIndex("DateID");

                    b.HasIndex("WorldID");

                    b.ToTable("Traveler");
                });

            modelBuilder.Entity("WebApplication1.Models.Relations.Traveler_Mission_Date", b =>
                {
                    b.Property<int>("SimID")
                        .HasColumnType("int");

                    b.Property<int>("MissionID")
                        .HasColumnType("int");

                    b.Property<string>("DateID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("MissiondID")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SimID", "MissionID", "DateID");

                    b.HasIndex("DateID");

                    b.HasIndex("MissiondID");

                    b.ToTable("Traveler_Mission_Date");
                });

            modelBuilder.Entity("WebApplication1.Models.Sim", b =>
                {
                    b.Property<int>("SimID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Balance")
                        .HasColumnType("int");

                    b.Property<string>("GenderID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("HomeID")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LifeStageID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SimID");

                    b.HasIndex("GenderID");

                    b.HasIndex("HomeID");

                    b.HasIndex("LifeStageID");

                    b.ToTable("Sim");
                });

            modelBuilder.Entity("WebApplication1.Models.Sim_Activity", b =>
                {
                    b.Property<int>("SimID")
                        .HasColumnType("int");

                    b.Property<int>("ActivityID")
                        .HasColumnType("int");

                    b.Property<string>("LastDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SimID", "ActivityID");

                    b.HasIndex("ActivityID");

                    b.ToTable("Sim_Activity");
                });

            modelBuilder.Entity("WebApplication1.Models.Skill", b =>
                {
                    b.Property<int>("SkillID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkillID");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("WebApplication1.Models.World", b =>
                {
                    b.Property<int>("WorldID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorldID");

                    b.ToTable("World");
                });

            modelBuilder.Entity("WebApplication1.Models.Activity", b =>
                {
                    b.HasOne("WebApplication1.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("WebApplication1.Models.Home", b =>
                {
                    b.HasOne("WebApplication1.Models.Neighborhood", "Neighborhood")
                        .WithMany()
                        .HasForeignKey("NeighborhoodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Neighborhood");
                });

            modelBuilder.Entity("WebApplication1.Models.Mission", b =>
                {
                    b.HasOne("WebApplication1.Models.World", "World")
                        .WithMany()
                        .HasForeignKey("WorldID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("World");
                });

            modelBuilder.Entity("WebApplication1.Models.Neighborhood", b =>
                {
                    b.HasOne("WebApplication1.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.World", "World")
                        .WithMany()
                        .HasForeignKey("WorldID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");

                    b.Navigation("World");
                });

            modelBuilder.Entity("WebApplication1.Models.Pet", b =>
                {
                    b.HasOne("WebApplication1.Models.Home", "Home")
                        .WithMany()
                        .HasForeignKey("HomeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.PetType", "PetType")
                        .WithMany()
                        .HasForeignKey("PetTypeID");

                    b.Navigation("Home");

                    b.Navigation("PetType");
                });

            modelBuilder.Entity("WebApplication1.Models.Place", b =>
                {
                    b.HasOne("WebApplication1.Models.Neighborhood", "Neighborhood")
                        .WithMany()
                        .HasForeignKey("NeighborhoodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Neighborhood");
                });

            modelBuilder.Entity("WebApplication1.Models.Relations.Activity_RSkill", b =>
                {
                    b.HasOne("WebApplication1.Models.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");
                });

            modelBuilder.Entity("WebApplication1.Models.Relations.Mission_Requieres_Skill", b =>
                {
                    b.HasOne("WebApplication1.Models.Mission", "Mission")
                        .WithMany()
                        .HasForeignKey("MissiondID");

                    b.HasOne("WebApplication1.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mission");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("WebApplication1.Models.Relations.Profession_Skill", b =>
                {
                    b.HasOne("WebApplication1.Models.Profession", "Profession")
                        .WithMany()
                        .HasForeignKey("ProfessionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profession");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("WebApplication1.Models.Relations.ServicePlace", b =>
                {
                    b.HasOne("WebApplication1.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");
                });

            modelBuilder.Entity("WebApplication1.Models.Relations.Sim_Profession", b =>
                {
                    b.HasOne("WebApplication1.Models.Profession", "Profession")
                        .WithMany()
                        .HasForeignKey("ProfessionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Sim", "Sim")
                        .WithMany()
                        .HasForeignKey("SimID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profession");

                    b.Navigation("Sim");
                });

            modelBuilder.Entity("WebApplication1.Models.Relations.Sim_Skill", b =>
                {
                    b.HasOne("WebApplication1.Models.Sim", "Sim")
                        .WithMany()
                        .HasForeignKey("SimID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sim");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("WebApplication1.Models.Relations.Traveler", b =>
                {
                    b.HasOne("WebApplication1.Models.Date", "Date")
                        .WithMany()
                        .HasForeignKey("DateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Sim", "Sim")
                        .WithMany()
                        .HasForeignKey("SimID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.World", "World")
                        .WithMany()
                        .HasForeignKey("WorldID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Date");

                    b.Navigation("Sim");

                    b.Navigation("World");
                });

            modelBuilder.Entity("WebApplication1.Models.Relations.Traveler_Mission_Date", b =>
                {
                    b.HasOne("WebApplication1.Models.Date", "Date")
                        .WithMany()
                        .HasForeignKey("DateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Mission", "Mission")
                        .WithMany()
                        .HasForeignKey("MissiondID");

                    b.HasOne("WebApplication1.Models.Sim", "Sim")
                        .WithMany()
                        .HasForeignKey("SimID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Date");

                    b.Navigation("Mission");

                    b.Navigation("Sim");
                });

            modelBuilder.Entity("WebApplication1.Models.Sim", b =>
                {
                    b.HasOne("WebApplication1.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderID");

                    b.HasOne("WebApplication1.Models.Home", "Home")
                        .WithMany()
                        .HasForeignKey("HomeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.LifeStage", "LifeStage")
                        .WithMany()
                        .HasForeignKey("LifeStageID");

                    b.Navigation("Gender");

                    b.Navigation("Home");

                    b.Navigation("LifeStage");
                });

            modelBuilder.Entity("WebApplication1.Models.Sim_Activity", b =>
                {
                    b.HasOne("WebApplication1.Models.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Sim", "Sim")
                        .WithMany()
                        .HasForeignKey("SimID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("Sim");
                });
#pragma warning restore 612, 618
        }
    }
}
