using ETrainerWEB.Models;
using Microsoft.EntityFrameworkCore;

namespace ETrainerWEB.Seeders
{
    public class IngredientSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Ingredient>().HasData(
                new Ingredient()
                {
                    Id = 1,
                    Name = "Jabłko",
                    PortionWeight = 120,
                    CaloricityPerGram = 50,
                    User = null
                },
                new Ingredient()
                {
                    Id = 2,
                    Name = "Jajo",
                    PortionWeight = 60,
                    CaloricityPerGram = 155,
                    User = null
                },
                new Ingredient()
                {
                    Id = 3,
                    Name = "Brokuł",
                    PortionWeight = 500,
                    CaloricityPerGram = 31,
                    User = null
                },
                new Ingredient()
                {
                    Id = 4,
                    Name = "Kromka chleba",
                    PortionWeight = 30,
                    CaloricityPerGram = 260,
                    User = null
                },
                new Ingredient()
                {
                    Id = 5,
                    Name = "Herbata",
                    PortionWeight = 100,
                    CaloricityPerGram = 0,
                    User = null
                },
                new Ingredient()
                {
                    Id = 6,
                    Name = "Baton zbożowy",
                    PortionWeight = 40,
                    CaloricityPerGram = 412,
                    User = null
                },
                new Ingredient()
                {
                    Id = 7,
                    Name = "Coca cola",
                    PortionWeight = 500,
                    CaloricityPerGram = 37.5,
                    User = null
                });
        }
    }
}