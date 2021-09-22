using E_Trainer_WEB.Data;
using E_Trainer_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace E_Trainer_WEB.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WorkoutController : ControllerBase
    {
        private ETrainerDBContext _context;
        public WorkoutController(ETrainerDBContext context)
        {
            _context = context;
        }
        //Get all workouts
        [HttpGet]
        public async Task<List<Workout>> GetAllWorkouts()
        {
            return (await _context.Workouts.Include(s => s.Exercises).ToListAsync()).ToList();
        }
        //Get user's workouts
        [HttpGet("{id}")]
        public async Task<List<Workout>> GetUserWorkouts (int id)
        {

            return (await _context.Workouts.Where(e => e.userId == id).Include(s => s.Exercises).ToListAsync()).ToList();
        }
        //Get workout by id 
        [HttpGet("{id}")]
        public Workout GetWorkoutById(int id)
        {
            return (_context.Workouts.Where(e => e.id == id).Include(s => s.Exercises).FirstOrDefault());
        }
        //Add new workout
        [HttpPost]
        public async Task<bool> AddNewWorkout([FromBody()] Workout workout)
        {
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();
            return true;
        }
        //Edit workout
        [HttpPut("{id},{name},{duration}")]
        public async Task<bool> EditWorkout(int id,string name,int duration)
        {
            Workout _workout = _context.Workouts.Where(e => e.id == id).FirstOrDefault();
            _workout.duration =duration;
            _workout.name = name;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
