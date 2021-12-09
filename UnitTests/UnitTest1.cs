using System;
using Xunit;
using ETrainerWEB.Models;
using ETrainerWEB.Data;
using Microsoft.EntityFrameworkCore;
using ETrainerWEB.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTests
{
    public class UnitTest1
    {
        private readonly ETrainerDbContext _db;
        private readonly ExerciseTypeController _controller;

        public UnitTest1()
        {
            var options = new DbContextOptionsBuilder<ETrainerDbContext>()
            .UseInMemoryDatabase(databaseName: "etrainerdb")
            .Options;

            _db = new ETrainerDbContext(options);
            _db.ExerciseTypes.Add(new ExerciseType
            {
                Id = 1,
                Properties = "XD",
                Name = "NazwaTypu"
            });
            _db.SaveChanges();
            _controller = new ExerciseTypeController(_db);
        }

        [Fact]
        public void Test1()
        {
            //arrange
            int x = 3;
            int expected = 7;
            Task<List<ExerciseType>> lista = _controller.ExerciseTypes();


            //act
            int actual = x + 4;

            //assert
            Assert.Equal(expected, actual);

        }
    }
}
