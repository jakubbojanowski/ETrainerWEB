using System;
using System.Linq;
using System.Threading.Tasks;
using ETrainerWEB.Data;
using ETrainerWEB.Models;
using ETrainerWEB.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ETrainerWEB.Services
{
    public class WorkoutService
    {
        private readonly ETrainerDbContext _db;
        private readonly PropertyCopierService<Workout> _propertyCopier;
        private readonly AutomapperService _automapper;
        private readonly string _userId;
        public WorkoutService(ETrainerDbContext db,PropertyCopierService<Workout> propertyCopierService,AutomapperService automapperService,IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _propertyCopier = propertyCopierService;
            _automapper = automapperService;
            _userId  = _db.Users.Where(e => e.UserName == httpContextAccessor.HttpContext.User.Identity.Name).Select(r => r.Id).FirstOrDefault();
        }
        public async Task<WorkoutDTO> GetWorkoutByDate(DateTime date)
        {
            if (string.IsNullOrEmpty(_userId)) return null;
            var workout = await _db.Workouts.Where(e => e.User.Id == _userId && e.Date.Date == date.Date).Include(s => s.Exercises).FirstOrDefaultAsync();
            var workoutsDTO = _automapper.Mapper.Map<Workout, WorkoutDTO>(workout);
            return workoutsDTO;
        }
        public async Task<int> GetWorkoutIdByDate(DateTime date)
        {
            if (string.IsNullOrEmpty(_userId)) return 0;
            var workoutId = await _db.Workouts.Where(e => e.User.Id == _userId && e.Date.Date == date.Date).Select(x=>x.Id).FirstOrDefaultAsync();
            return workoutId;
        }
        public async Task<int> AddWorkout(WorkoutDTO workoutDTO)
        {
            var todayWorkout = await GetWorkoutByDate(workoutDTO.Date);
            if (todayWorkout != null) return 0;
            if (string.IsNullOrEmpty(_userId)) return 0;
            workoutDTO.User = await _db.Users.FirstOrDefaultAsync(e => e.Id == _userId);
            var workout = _automapper.Mapper.Map<WorkoutDTO,Workout>(workoutDTO);
            await _db.Workouts.AddAsync(workout);
            await _db.SaveChangesAsync();
            return workout.Id;
        }
    }
}