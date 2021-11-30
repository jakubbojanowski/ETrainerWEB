using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETrainerWEB.Data;
using ETrainerWEB.Models;
using ETrainerWEB.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ETrainerWEB.Services
{
    public class WorkoutSchemaService
    {
        private readonly ETrainerDbContext _db;
        private readonly PropertyCopierService<WorkoutSchema> _propertyCopier;
        private readonly AutomapperService _automapper;
        private readonly string _userId;
        public WorkoutSchemaService(ETrainerDbContext db,PropertyCopierService<WorkoutSchema> propertyCopierService,AutomapperService automapperService,IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _propertyCopier = propertyCopierService;
            _automapper = automapperService;
            _userId  = _db.Users.Where(e => e.UserName == httpContextAccessor.HttpContext.User.Identity.Name).Select(r => r.Id).FirstOrDefault();
        }
        public async Task<List<WorkoutSchemaDTO>> GetWorkoutSchemas()
        {
            if (string.IsNullOrEmpty(_userId)) return null;
            var workoutSchema = await _db.WorkoutSchemas.Where(e=>e.UserId == _userId).ToListAsync();
            var workoutSchemaDTO= _automapper.Mapper.Map<List<WorkoutSchema>, List<WorkoutSchemaDTO>>(workoutSchema);
            return workoutSchemaDTO;
        }
        public async Task<int> AddWorkoutSchema(WorkoutSchemaDTO workoutSchemaDTO)
        {
            if (string.IsNullOrEmpty(_userId)) return 0;
            var exist = await _db.WorkoutSchemas.FirstOrDefaultAsync(c => c.UserId ==_userId && c.Name == workoutSchemaDTO.Name);
            if ( exist != null) return 0;
            workoutSchemaDTO.UserId = _userId;
            var workoutSchema = _automapper.Mapper.Map<WorkoutSchemaDTO,WorkoutSchema>(workoutSchemaDTO);
            await _db.WorkoutSchemas.AddAsync(workoutSchema);
            await _db.SaveChangesAsync();
            return workoutSchema.Id;
        }
        public async Task<int> EditWorkoutSchema(WorkoutSchemaDTO workoutSchemaDTO)
        { 
            if (string.IsNullOrEmpty(_userId)) return 0;
            var workoutSchema = await _db.WorkoutSchemas.FirstOrDefaultAsync(e =>e.UserId == _userId && e.Id == workoutSchemaDTO.Id);
            if (workoutSchema == null) return 0;
            workoutSchemaDTO.UserId = _userId;
            var updatedWorkoutSchema = _automapper.Mapper.Map<WorkoutSchemaDTO, WorkoutSchema>(workoutSchemaDTO);
            _propertyCopier.Copy(updatedWorkoutSchema,workoutSchema);
            await _db.SaveChangesAsync();
            return workoutSchema.Id;
        }
        public async Task<bool> DeleteWorkoutSchema(int id)
        {
            if (string.IsNullOrEmpty(_userId)) return false;
            var workoutSchema = await _db.WorkoutSchemas.FirstOrDefaultAsync(e =>e.UserId == _userId && e.Id == id);
            if (workoutSchema == null) return false;
            _db.WorkoutSchemas.Remove(workoutSchema);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<List<ExerciseSchemaDTO>> GetExerciseSchema(int workoutId)
        {
            var workoutSchemas = await _db.WorkoutSchemasExercisesSchemas.Where(w=> w.WorkoutSchemaId==workoutId).Select(e=>e.ExerciseSchemaId).ToListAsync();
            var exerciseSchemas = await _db.ExerciseSchemas.Where(r =>r.UserId == _userId && workoutSchemas.Contains(r.Id)).ToListAsync();
            var exerciseSchemasDTO = _automapper.Mapper.Map<List<ExerciseSchema>,List<ExerciseSchemaDTO>>(exerciseSchemas);
            return exerciseSchemasDTO;
        }
        public async Task<bool> AddExerciseSchemaToWorkoutSchema(WorkoutSchemaExerciseSchemaDTO workoutSchemaExerciseSchemaDTO)
        {
            var workoutSchemaExerciseSchema = _automapper.Mapper.Map<WorkoutSchemaExerciseSchemaDTO,WorkoutSchemaExerciseSchema>(workoutSchemaExerciseSchemaDTO);
            await _db.WorkoutSchemasExercisesSchemas.AddAsync(workoutSchemaExerciseSchema);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteExerciseSchemaFromWorkoutSchema(int workoutId,int exerciseId)
        {
            var workoutSchemaExerciseSchema = await _db.WorkoutSchemasExercisesSchemas.FirstOrDefaultAsync(e => e.WorkoutSchemaId == workoutId && e.ExerciseSchemaId == exerciseId);
            if (workoutSchemaExerciseSchema == null) return false;
            _db.WorkoutSchemasExercisesSchemas.Remove(workoutSchemaExerciseSchema);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}