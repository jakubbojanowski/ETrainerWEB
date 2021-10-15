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
    public class WorkoutController : ControllerBase
    {
        private readonly ETrainerDbContext _db;
        public WorkoutController(ETrainerDbContext db)
        {
            _db = db;
        }
        //Get all workouts
        [HttpGet]
        public async Task<List<Workout>> Workouts()
        {
            return (await _db.Workouts.Include(s => s.Exercises).ToListAsync()).ToList();
        }
        //Get user's workouts
        [HttpGet("{id:int}")]
        public async Task<List<Workout>> UserWorkouts ([FromRoute]int id)
        {
            return (await _db.Workouts.Where(e => e.UserId == id).Include(s => s.Exercises).ToListAsync()).ToList();
        }
        //Get workout by id 
        [HttpGet("{id:int}")]
        public Workout Workout([FromRoute]int id)
        {
            return (_db.Workouts.Where(e => e.Id == id).Include(s => s.Exercises).FirstOrDefault());
        }
        //Add new workout
        [HttpPost]
        public async Task<bool> Workout([FromBody] Workout workout)
        {
            _db.Workouts.Add(workout);
            await _db.SaveChangesAsync();
            return true;
        }
        //Edit workout
        [HttpPut("{id:int},{name},{duration:int}")]
        public async Task<bool> Workout(int id,string name,int duration)
        {
            var workout = _db.Workouts.FirstOrDefault(e => e.Id == id);
            if (workout == null) return false;
            workout.Duration = duration;
            workout.Name = name;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
