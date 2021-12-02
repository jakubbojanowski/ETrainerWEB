using ETrainerWEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ETrainerWEB.Seeders;

namespace ETrainerWEB.Data
{
    public partial class ETrainerDbContext : IdentityDbContext<User>  
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
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<WorkoutSchema> WorkoutSchemas { get; set; }
        public DbSet<WorkoutSchemaExerciseSchema> WorkoutSchemasExercisesSchemas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            modelBuilder.Entity<IdentityRole>(entity => entity.Property(m => m.Id).HasMaxLength(85));

            modelBuilder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(85));

            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(85));

            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name).HasMaxLength(85));
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            /*modelBuilder.Entity<Workout>(entity =>
            {
                entity.HasMany(b => b.Exercises)
                    .WithOne()
                    .HasForeignKey(e => e.WorkoutId);
            });*/
            
            /*modelBuilder.Entity<ExerciseType>(entity =>
            {
                entity.HasMany(b => b.Exercises)
                    .WithOne()
                    .HasForeignKey(e => e.TypeId);
            });*/
            
            /*modelBuilder.Entity<ExerciseType>(entity =>
            {
                entity.HasMany(b => b.ExerciseSchemas)
                    .WithOne()
                    .HasForeignKey(e => e.TypeId);
            });*/

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
            //modelBuilder.Seed();
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}



