using ETrainerWEB.Models;
using Microsoft.EntityFrameworkCore;

namespace ETrainerWEB.Seeders
{
    public class ExerciseTypeSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<ExerciseType>().HasData(
                new ExerciseType()
                {
                    Id = 1,
                    Icon = "run",
                    Category = Category.Kardio,
                    Name = "Bieganie",
                    Properties = "{\"Dystans[km]\":\"1\",\"Czas[min]\":\"6\"}"
                },
                new ExerciseType()
                {
                    Id = 2,
                    Icon = "dumbbell",
                    Category = Category.Klatka_piersiowa,
                    Name = "Wyciskanie sztangi",
                    Properties = "{\"Ciężar[kg]\":\"50\",\"Liczba powtórzeń\":\"8\",\"Liczba serii\":\"5\"}"
                },
                new ExerciseType()
                {
                    Id = 3,
                    Icon = "skate",
                    Category = Category.Kardio,
                    Name = "Jazda na łyżwach",
                    Properties = "{\"Czas[min]\":\"30\"}"
                },
                new ExerciseType()
                {
                    Id = 4,
                    Icon = "swim",
                    Category = Category.Kardio,
                    Name = "Pływanie",
                    Properties = "{\"Czas[min]\":\"20\",\"Liczba basenów\":\"10\"}"
                },
                new ExerciseType()
                {
                    Id = 5,
                    Icon = "run-fast",
                    Category = Category.Kardio,
                    Name = "Bieganie interwałowe",
                    Properties = "{\"Czas sprintu[min]\":\"1\",\"Czas odpoczynku[min]\":\"1\",\"Liczba powtórzeń\":\"10\"}"
                },
                new ExerciseType()
                {
                    Id = 7,
                    Icon = "yoga",
                    Category = Category.Ogólne,
                    Name = "Rozgrzewka",
                    Properties = "{\"Czas[min]\":\"10\"}"
                },
                new ExerciseType()
                {
                    Id = 8,
                    Icon = "walk",
                    Category = Category.Ogólne,
                    Name = "Marsz",
                    Properties = "{\"Czas[min]\":\"30\",\"Dystans[km]\":\"2.5\"}"
                },
                new ExerciseType()
                {
                    Id = 9,
                    Icon = "weight-lifter",
                    Category = Category.Nogi,
                    Name = "Przysiady ze sztangą",
                    Properties = "{\"Ciężar[kg]\":\"40\",\"Liczba powtórzeń\":\"5\",\"Liczba serii\":\"3\"}"
                },
                new ExerciseType()
                {
                    Id = 10,
                    Icon = "yoga",
                    Category = Category.Ogólne,
                    Name = "Rozciąganie",
                    Properties = "{\"Czas[min]\":\"15\"}"
                },
                new ExerciseType()
                {
                    Id = 11,
                    Icon = "human",
                    Category = Category.Nogi,
                    Name = "Przysiady",
                    Properties = "{\"Liczba powtórzeń\":\"20\",\"Liczba serii\":\"3\"}"
                },
                new ExerciseType()
                {
                    Id = 12,
                    Icon = "kettlebell",
                    Category = Category.Klatka_piersiowa,
                    Name = "Pompki",
                    Properties = "{\"Liczba powtórzeń\":\"10\",\"Liczba serii\":\"3\"}"
                },
                new ExerciseType()
                {
                    Id = 13,
                    Icon = "kettlebell",
                    Category = Category.Brzuch,
                    Name = "Brzuszki",
                    Properties = "{\"Liczba powtórzeń\":\"10\",\"Liczba serii\":\"5\"}"
                },
                new ExerciseType()
                {
                    Id = 14,
                    Icon = "human-handsup",
                    Category = Category.Plecy,
                    Name = "Podciąganie na drążku",
                    Properties = "{\"Liczba powtórzeń\":\"5\",\"Liczba serii\":\"5\"}"
                },
                new ExerciseType()
                {
                    Id = 15,
                    Icon = "plus-circle",
                    Category = Category.Własne,
                    Name = "",
                    Properties = "{}"
                }
            );
        }
    }
}
