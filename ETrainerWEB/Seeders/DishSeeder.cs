using ETrainerWEB.Models;
using Microsoft.EntityFrameworkCore;

namespace ETrainerWEB.Seeders
{
    public class DishSeeder
    {
         public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Dish>().HasData(
                new Dish()
                {
                    Id = 1,
                    Name = "Ryba po grecku",
                    PortionWeight = 200,
                    CaloricityPerGram = 99,
                    User = null
                },
                new Dish()
                {
                    Id = 2,
                    Name = "Sałatka warzywna",
                    PortionWeight = 230,
                    CaloricityPerGram = 145,
                    User = null
                });
        }
    }
}