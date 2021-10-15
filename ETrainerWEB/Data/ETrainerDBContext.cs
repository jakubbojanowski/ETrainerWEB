using ETrainerWEB.Models;
using Microsoft.EntityFrameworkCore;

namespace ETrainerWEB.Data
{
    public partial class ETrainerDbContext : DbContext
    {
        public ETrainerDbContext(DbContextOptions<ETrainerDbContext> options) : base(options)
        {

        }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseType> ExerciseTypes { get; set; }
        public DbSet<ExerciseSchema> ExerciseSchemas { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<DishesIngredients> DishesIngredients { get; set; }
        public DbSet<MealsDishes> MealsDishes { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<Friends> Friends { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<WorkoutSchema> WorkoutSchemas { get; set; }
        public DbSet<WorkoutSchemasExercisesSchemas> WorkoutSchemasExercisesSchemas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Workout>(entity =>
            {
                entity.HasMany(b => b.Exercises)
                    .WithOne()
                    .HasForeignKey(e => e.WorkoutId);
            });
            
            modelBuilder.Entity<ExerciseType>(entity =>
            {
                entity.HasMany(b => b.Exercises)
                    .WithOne()
                    .HasForeignKey(e => e.TypeId);
            });
            
            modelBuilder.Entity<ExerciseType>(entity =>
            {
                entity.HasMany(b => b.ExerciseSchemas)
                    .WithOne()
                    .HasForeignKey(e => e.TypeId);
            });

            /*modelBuilder.Entity<Friends>()
                .HasKey(f => new { f.UserId, f.FriendId });
            
            modelBuilder.Entity<Friends>()
                .HasOne(f => f.User)
                .WithMany(f => f.Friends)
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<Friends>()
                .HasOne(f => f.Friend)
                .WithMany(f => f.Friended)
                .HasForeignKey(f => f.FriendId);*/

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}



