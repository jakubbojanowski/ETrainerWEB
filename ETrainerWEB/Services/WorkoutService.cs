using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;
using ETrainerWEB.Data;
using ETrainerWEB.Models;
using ETrainerWEB.Models.DTO;
using Microsoft.EntityFrameworkCore;


namespace ETrainerWEB.Services
{
    public class WorkoutService
    {
        private readonly ETrainerDbContext _db;
        private readonly PropertyCopierService<Workout> _propertyCopier;
        private readonly AutomapperService _automapper;


        public WorkoutService(ETrainerDbContext db,PropertyCopierService<Workout> propertyCopierService,AutomapperService automapperService)
        {
            _db = db;
            _propertyCopier = propertyCopierService;
            _automapper = automapperService;
        }
        public async Task<List<WorkoutDTO>> GetWorkouts()
        {
            var workouts = (await _db.Workouts.Include(s => s.Exercises).ToListAsync()).ToList();
            var workoutsDTO = _automapper.Mapper.Map<List<Workout>,List<WorkoutDTO>>(workouts);
            return workoutsDTO;
        }

        public async Task<List<WorkoutDTO>> GetUserWorkouts(string id)
        {
            var workouts = (await _db.Workouts.Where(e => e.UserId == id).Include(s => s.Exercises).ToListAsync()).ToList();
            var workoutsDTO = _automapper.Mapper.Map<List<Workout>,List<WorkoutDTO>>(workouts);
            return workoutsDTO;
        }
        
        public WorkoutDTO GetWorkoutById(int id)
        {
            var workout = (_db.Workouts.Where(e => e.Id == id).Include(s => s.Exercises).FirstOrDefault());
            var workoutsDTO = _automapper.Mapper.Map<Workout,WorkoutDTO>(workout);
            return workoutsDTO;
        }
        public WorkoutDTO GetWorkoutByDate(DateTime date)
        {
            var workout = (_db.Workouts.Where(e => e.Date.Date == date.Date).Include(s => s.Exercises).FirstOrDefault());
            var workoutsDTO = _automapper.Mapper.Map<Workout,WorkoutDTO>(workout);
            return workoutsDTO;
        }

        public async Task<bool> AddWorkout(WorkoutDTO workoutDTO)
        {
            var todayWorkout = GetWorkoutByDate(workoutDTO.Date);
            if (todayWorkout != null) return false;
            var workout = _automapper.Mapper.Map<WorkoutDTO,Workout>(workoutDTO);
            _db.Workouts.Add(workout);
            return await _db.SaveChangesAsync() > 0;
        }
        
        public async Task<bool> EditWorkout(WorkoutDTO workoutDTO)
        { 
            var workout = (_db.Workouts.FirstOrDefault(e => e.Date.Date == workoutDTO.Date.Date));
            if (workout == null) return false;
            var updatedWorkout = _automapper.Mapper.Map<WorkoutDTO, Workout>(workoutDTO);
            _propertyCopier.Copy(updatedWorkout,workout);
            return await _db.SaveChangesAsync() > 0;
        }
        
    }
}