using E_Trainer_WEB.Data;
using E_Trainer_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace E_Trainer_WEB.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ExerciseController : Controller
    {
        private ETrainerDBContext _context;
        public ExerciseController(ETrainerDBContext context)
        {
            _context = context;
        }
        //Get all exercises
        [HttpGet]
        public async Task<List<Exercise>> GetAllExercises()
        {
            return (await _context.Exercises.ToListAsync()).ToList();
        }
        //Add new exercise 
        [HttpPost]
        public async Task<bool> AddNewExercise([FromBody()] Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();
            return true;
        }
        //Edit exercise
        [HttpPut("{id},{name}")]
        public async Task<bool> EditExercise(int id, string name)
        {
            Exercise _exercise = _context.Exercises.Where(e => e.id == id).FirstOrDefault();
            _exercise.name = name;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
