using ETrainerWEB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    Properties = "XD",
                    Name = "NazwaTypu"
                });
        }
    }
}
