using Microsoft.EntityFrameworkCore;

namespace ETrainerWEB.Seeders
{
    public static class MainSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            ExerciseTypeSeeder.Seed(modelBuilder);
            IngredientSeeder.Seed(modelBuilder);
            DishSeeder.Seed(modelBuilder);
        }
    }
}