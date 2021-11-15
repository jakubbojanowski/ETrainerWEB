using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETrainerWEB.Data;
using ETrainerWEB.Models;
using ETrainerWEB.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace ETrainerWEB.Services
{
    public class WorkoutSchemaService
    {
        private readonly ETrainerDbContext _db;
        private readonly PropertyCopierService<WorkoutSchema> _propertyCopier;
        private readonly AutomapperService _automapper;


        public WorkoutSchemaService(ETrainerDbContext db,PropertyCopierService<WorkoutSchema> propertyCopierService,AutomapperService automapperService)
        {
            _db = db;
            _propertyCopier = propertyCopierService;
            _automapper = automapperService;
        }
        public async Task<List<WorkoutSchemaDTO>> GetWorkoutSchemas()
        {
            var workoutSchema = (await _db.WorkoutSchemas.ToListAsync()).ToList();
            var workoutSchemaDTO = _automapper.Mapper.Map<List<WorkoutSchema>,List<WorkoutSchemaDTO>>(workoutSchema);
            return workoutSchemaDTO;
        }
        public async Task<bool> AddWorkoutSchema(WorkoutSchemaDTO workoutSchemaDTO)
        {
            var workoutSchema = _automapper.Mapper.Map<WorkoutSchemaDTO,WorkoutSchema>(workoutSchemaDTO);
            _db.WorkoutSchemas.Add(workoutSchema);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<bool> EditWorkoutSchema(WorkoutSchemaDTO workoutSchemaDTO)
        { 
            var workoutSchema = (_db.WorkoutSchemas.FirstOrDefault(e => e.Id == workoutSchemaDTO.Id));
            if (workoutSchema == null) return false;
            var updatedWorkoutSchema = _automapper.Mapper.Map<WorkoutSchemaDTO, WorkoutSchema>(workoutSchemaDTO);
            _propertyCopier.Copy(updatedWorkoutSchema,workoutSchema);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteWorkoutSchema(int id)
        {
            var workoutSchema = _db.WorkoutSchemas.FirstOrDefault(e => e.Id == id);
            if (workoutSchema == null) return false;
            _db.WorkoutSchemas.Remove(workoutSchema);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}