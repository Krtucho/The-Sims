using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Relations;

namespace WebApplication1.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Mission_Requieres_Skill>().HasKey(table => new
            {
                table.MissionID,
                table.SkillID
            });
            builder.Entity<Sim_Activity>().HasKey(table => new
            {
                table.SimID,
                table.ActivityID
            });
            builder.Entity<Sim_Skill>().HasKey(table => new
            {
                table.SimID,
                table.SkillID
            });
            builder.Entity<Traveler>().HasKey(table => new
            {
                table.SimID,
                table.WorldID,
                table.DateID
            });
            builder.Entity<Traveler_Mission_Date>().HasKey(table => new
            {
                table.SimID,
                table.MissionID,
                table.DateID
            });

        }

        // Simples (No dependen de otras clases, no existen llaves foraneas

        public DbSet<LifeStage> LifeStage { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<World> World { get; set; }
        public DbSet<Date> Date { get; set; }
        public DbSet<PetType> PetType { get; set; }
        public DbSet<Profession> Profession { get; set; }
        public DbSet<Activity> Activity { get; set; }

        //Compuestas

        public DbSet<Sim_Profession> Sim_Profession { get; set; }//
        public DbSet<Profession_Skill> Profession_Skill { get; set; }
        public DbSet<ActivityImprovesSkill> ActivityImprovesSkill { get; set; }
        public DbSet<Neighborhood> Neighborhood { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<Mission> Mission { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<ServicePlace> ServicePlace { get; set; }
        public DbSet<Activity_RSkill> Activity_RSkills { get; set; }
        public DbSet<Mission_Requieres_Skill> Mission_Requieres_Skills { get; set; }
        public DbSet<Sim_Activity> Sim_Activity { get; set; }
        public DbSet<Sim_Skill> Sim_Skill { get; set; }
        public DbSet<Traveler> Traveler { get; set; }
        public DbSet<Traveler_Mission_Date> Traveler_Mission_Date { get; set; }
        public DbSet<Sim> Sim { get; set; }
        public DbSet<Home> Home { get; set; }




    }
}
