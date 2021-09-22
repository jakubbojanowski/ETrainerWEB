using E_Trainer_WEB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Trainer_WEB.Data
{
    public partial class ETrainerDBContext : DbContext
    {
        public ETrainerDBContext(DbContextOptions<ETrainerDBContext> options) : base(options)
        {

        }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseType> ExerciseTypes { get; set; }
        public DbSet<ExerciseSchema> ExerciseSchemas { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Meal> Meals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Workout>(entity =>
            {
                entity.HasMany(b => b.Exercises)
                    .WithOne()
                    .HasForeignKey(e => e.workoutId);
            });
            
            modelBuilder.Entity<ExerciseType>(entity =>
            {
                entity.HasMany(b => b.Exercises)
                    .WithOne()
                    .HasForeignKey(e => e.typeId);
            });
            
            modelBuilder.Entity<ExerciseType>(entity =>
            {
                entity.HasMany(b => b.ExerciseSchemas)
                    .WithOne()
                    .HasForeignKey(e => e.typeId);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}



