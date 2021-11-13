using ETrainerWEB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETrainerWEB.Seeders
{
    public class MeasurementSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Measurement>().HasData(
                new Measurement()
                {
                    Id = 1,
                    Properties = "XD",
                    UserId = 1
                });
        }
    }
}
