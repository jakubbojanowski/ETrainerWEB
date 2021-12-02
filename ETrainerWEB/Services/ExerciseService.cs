using System.Linq;
using System.Threading.Tasks;
using ETrainerWEB.Data;
using ETrainerWEB.Models;
using ETrainerWEB.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ETrainerWEB.Services
{
    public class ExerciseService
    {
        private readonly ETrainerDbContext _db;
        private readonly PropertyCopierService<Exercise> _propertyCopier;
        private readonly AutomapperService _automapper;
        public ExerciseService(ETrainerDbContext db,PropertyCopierService<Exercise> propertyCopierService,AutomapperService automapperService,IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _propertyCopier = propertyCopierService;
            _automapper = automapperService;
        }
        public async Task<ExerciseDTO> GetExerciseById(int id)
        {
            var exercise = await _db.Exercises.FirstOrDefaultAsync(e => e.Id == id);
            var exerciseDTO = _automapper.Mapper.Map<Exercise,ExerciseDTO>(exercise);
            return exerciseDTO;
        }
        public async Task<int> AddExercise(ExerciseDTO exerciseDTO)
        {
            exerciseDTO.Workout = await _db.Workouts.FirstOrDefaultAsync(e => e.Id == exerciseDTO.CurrentWorkoutId);
            var exist = await _db.Exercises.FirstOrDefaultAsync(c => c.Properties == exerciseDTO.Properties && c.Workout.Id == exerciseDTO.Workout.Id);
            if ( exist != null) return 0;
            var exercise = _automapper.Mapper.Map<ExerciseDTO, Exercise>(exerciseDTO);
            await _db.Exercises.AddAsync(exercise);
            await _db.SaveChangesAsync();
            return exercise.Id;
        }
        public async Task<bool> EditExercise(ExerciseDTO exerciseDTO)
        { 
            
            var exercise = await _db.Exercises.FirstOrDefaultAsync(e => e.Id == exerciseDTO.Id);
            if (exercise == null) return false;
            var updatedExercise = _automapper.Mapper.Map<ExerciseDTO, Exercise>(exerciseDTO);
            _propertyCopier.Copy(updatedExercise,exercise);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteExercise(int id)
        {
            var exercise = await _db.Exercises.FirstOrDefaultAsync(e => e.Id == id);
            if (exercise == null) return false;
            _db.Exercises.Remove(exercise);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}