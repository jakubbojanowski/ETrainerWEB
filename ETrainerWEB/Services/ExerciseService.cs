using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETrainerWEB.Data;
using ETrainerWEB.Models;
using ETrainerWEB.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace ETrainerWEB.Services
{
    public class ExerciseService
    {
        private readonly ETrainerDbContext _db;
        private readonly PropertyCopierService<Exercise> _propertyCopier;
        private readonly AutomapperService _automapper;
        
        
        public ExerciseService(ETrainerDbContext db,PropertyCopierService<Exercise> propertyCopierService,AutomapperService automapperService)
        {
            _db = db;
            _propertyCopier = propertyCopierService;
            _automapper = automapperService;
        }

        public async Task<List<ExerciseDTO>> GetExercises()
        {
            var exercises = (await _db.Exercises.ToListAsync()).ToList();
            var exercisesDTO = _automapper.Mapper.Map<List<Exercise>, List<ExerciseDTO>>(exercises);
            return exercisesDTO;
        }

        public ExerciseDTO GetExerciseById(int id)
        {
            var exercise = (_db.Exercises.Where(e => e.Id == id).FirstOrDefault());
            var exerciseDTO = _automapper.Mapper.Map<Exercise,ExerciseDTO>(exercise);
            return exerciseDTO;
        }
        public async Task<int> AddExercise(ExerciseDTO exerciseDTO)
        {
            var exercise = _automapper.Mapper.Map<ExerciseDTO, Exercise>(exerciseDTO);
            _db.Exercises.Add(exercise);
            await _db.SaveChangesAsync();
            return _db.Exercises.Where(c => c.Name == exerciseDTO.Name && c.Properties == exerciseDTO.Properties && c.WorkoutId == exerciseDTO.WorkoutId&& c.TypeId == exerciseDTO.TypeId).Select(e => e.Id).FirstOrDefault();

        }
        
        public async Task<bool> EditExercise(ExerciseDTO exerciseDTO)
        { 
            var exercise = _db.Exercises.FirstOrDefault(e => e.Id == exerciseDTO.Id);
            if (exercise == null) return false;
            var updatedExercise = _automapper.Mapper.Map<ExerciseDTO, Exercise>(exerciseDTO);
            _propertyCopier.Copy(updatedExercise,exercise);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteExercise(int id)
        {
            var exercise = _db.Exercises.FirstOrDefault(e => e.Id == id);
            if (exercise == null) return false;
            _db.Exercises.Remove(exercise);
            return await _db.SaveChangesAsync() > 0;
        }

    }
}