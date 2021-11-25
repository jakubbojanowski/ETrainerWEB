﻿using System;
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
        public WorkoutDTO GetWorkoutByDate(DateTime date)
        {
            if (string.IsNullOrEmpty(_userId)) return null;
            var workout = (_db.Workouts.Where(e => e.UserId == _userId && e.Date.Date == date.Date).Include(s => s.Exercises).FirstOrDefault());
            var workoutsDTO = _automapper.Mapper.Map<Workout, WorkoutDTO>(workout);
            return workoutsDTO;
        }

        public async Task<int> AddWorkout(WorkoutDTO workoutDTO)
        {
            var todayWorkout = GetWorkoutByDate(workoutDTO.Date);
            if (todayWorkout != null) return 0;
            if (string.IsNullOrEmpty(_userId)) return 0;
            workoutDTO.UserId = _userId;
            var workout = _automapper.Mapper.Map<WorkoutDTO,Workout>(workoutDTO);
            _db.Workouts.Add(workout);
            await _db.SaveChangesAsync();
            return _db.Workouts.Where(c => c.UserId ==_userId && c.Date.Date == workoutDTO.Date.Date).Select(e => e.Id).FirstOrDefault();
        }
        
        public async Task<bool> EditWorkout(WorkoutDTO workoutDTO)
        { 
            if (string.IsNullOrEmpty(_userId)) return false;
            var workout = (_db.Workouts.FirstOrDefault(e => e.UserId ==_userId && e.Date.Date == workoutDTO.Date.Date));
            if (workout == null) return false;
            workoutDTO.UserId = _userId;
            var updatedWorkout = _automapper.Mapper.Map<WorkoutDTO, Workout>(workoutDTO);
            _propertyCopier.Copy(updatedWorkout,workout);
            return await _db.SaveChangesAsync() > 0;
        }
        
    }
}