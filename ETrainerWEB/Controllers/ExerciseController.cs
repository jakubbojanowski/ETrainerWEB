using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETrainerWEB.Data;
using ETrainerWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETrainerWEB.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class ExerciseController : Controller
    {
        private readonly ETrainerDbContext _db;
        public ExerciseController(ETrainerDbContext db)
        {
            _db = db;
        }
        //Get all exercises
        [HttpGet]
        public async Task<List<Exercise>> Exercises()
        {
            return (await _db.Exercises.ToListAsync()).ToList();
        }
        //Add new exercise 
        [HttpPost]
        public async Task<bool> Exercise([FromBody()] Exercise exercise)
        {
            _db.Exercises.Add(exercise);
            await _db.SaveChangesAsync();
            return true;
        }
        //Edit exercise
        [HttpPut("{id},{name}")]
        public async Task<bool> Exercise(int id, string name)
        {
            Exercise exercise = _db.Exercises.Where(e => e.Id == id).FirstOrDefault();
            exercise.Name = name;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
