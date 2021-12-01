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
    public class ExerciseSchemaService
    {
        private readonly ETrainerDbContext _db;
        private readonly PropertyCopierService<ExerciseSchema> _propertyCopier;
        private readonly AutomapperService _automapper;
        private readonly string _userId;
        public ExerciseSchemaService(ETrainerDbContext db,PropertyCopierService<ExerciseSchema> propertyCopierService,AutomapperService automapperService,IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _propertyCopier = propertyCopierService;
            _automapper = automapperService;
            _userId  = _db.Users.Where(e => e.UserName == httpContextAccessor.HttpContext.User.Identity.Name).Select(r => r.Id).FirstOrDefault();
        }
        public async Task<List<ExerciseSchemaDTO>> GetExerciseSchemas()
        {
            if (string.IsNullOrEmpty(_userId)) return null;
            var exerciseSchema = await _db.ExerciseSchemas.Where(e => e.UserId == _userId).ToListAsync();
            var exerciseSchemaDTO = _automapper.Mapper.Map<List<ExerciseSchema>, List<ExerciseSchemaDTO>>(exerciseSchema);
            return exerciseSchemaDTO;
        }
        public async Task<int> AddExerciseSchema(ExerciseSchemaDTO exerciseSchemaDTO)
        {
            if (string.IsNullOrEmpty(_userId)) return 0;
            var exist = await _db.ExerciseSchemas.FirstOrDefaultAsync(c => c.UserId == _userId && c.Properties == exerciseSchemaDTO.Properties);
            if ( exist != null) return 0;
            exerciseSchemaDTO.UserId = _userId;
            var exerciseSchema = _automapper.Mapper.Map<ExerciseSchemaDTO,ExerciseSchema>(exerciseSchemaDTO);
            await _db.ExerciseSchemas.AddAsync(exerciseSchema);
            await _db.SaveChangesAsync();
            return exerciseSchema.Id;
        }
        public async Task<int> EditExerciseSchema(ExerciseSchemaDTO exerciseSchemaDTO)
        { 
            if (string.IsNullOrEmpty(_userId)) return 0;
            var exerciseSchema = await _db.ExerciseSchemas.FirstOrDefaultAsync(e => e.Id == exerciseSchemaDTO.Id);
            if (exerciseSchema == null) return 0;
            exerciseSchemaDTO.UserId = _userId;
            var updatedExerciseSchema = _automapper.Mapper.Map<ExerciseSchemaDTO, ExerciseSchema>(exerciseSchemaDTO);
            _propertyCopier.Copy(updatedExerciseSchema,exerciseSchema);
            await _db.SaveChangesAsync();
            return exerciseSchema.Id;
        }
        public async Task<bool> DeleteExerciseSchema(int id)
        {
            if (string.IsNullOrEmpty(_userId)) return false;
            var exerciseSchema = await _db.ExerciseSchemas.FirstOrDefaultAsync(e => e.UserId == _userId && e.Id == id);
            if (exerciseSchema == null) return false;
            _db.ExerciseSchemas.Remove(exerciseSchema);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}