using ETrainerWEB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETrainerWEB.Seeders
{
    public static class MainSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            ExerciseTypeSeeder.Seed(modelBuilder);
            //UserSeeder.Seed(modelBuilder);
            //MeasurementSeeder.Seed(modelBuilder);
        }
    }
}