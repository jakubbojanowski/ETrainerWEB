using ETrainerWEB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETrainerWEB.Seeders
{
    public class UserSeeder
    {
        /*public static void Seed(ModelBuilder builder)
        {
            builder.Entity<User>(b =>
            {
                b.HasData(new User
                {
                    Id = 1,
                    City = "ZG",
                    Country = "PL",
                    DateOfBirth = DateTime.Now,
                    Email = "mw@wp.pl",
                    Login = "byczeq",
                    Password = "qwerty",
                });
                b.OwnsOne(e => e.Measurement).HasData(new
                {
                    Id = 1,
                    Properties = "XD",
                    UserId = 1
            });
            });*/


            //builder.Entity<User>().OwnsOne(e => e.Measurement).HasData(
            //    new User()
            //    {
            //        Id = 1,
            //        City = "ZG",
            //        Country = "PL",
            //        DateOfBirth = DateTime.Now,
            //        Email = "mw@wp.pl",
            //        Login = "byczeq",
            //        Password = "qwerty",
            //    });
        //}
    }
}
