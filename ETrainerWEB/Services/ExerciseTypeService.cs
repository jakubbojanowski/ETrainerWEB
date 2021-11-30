using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETrainerWEB.Data;
using ETrainerWEB.Models;
using ETrainerWEB.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace ETrainerWEB.Services
{
    public class ExerciseTypeService
    {
        private readonly ETrainerDbContext _db;
        private readonly AutomapperService _automapper;
        public ExerciseTypeService(ETrainerDbContext db,AutomapperService automapperService)
        {
            _db = db;
            _automapper = automapperService;
        }
        public async Task<List<ExerciseTypeDTO>> GetExercisesType()
        {
            var exerciseType = await _db.ExerciseTypes.ToListAsync();
            var exerciseTypeDTO = _automapper.Mapper.Map<List<ExerciseType>,List<ExerciseTypeDTO>>(exerciseType);
            return exerciseTypeDTO;
        }
        public async Task<ExerciseTypeDTO> GetExerciseTypeById(int id)
        {
            var exerciseType = await _db.ExerciseTypes.FirstOrDefaultAsync(e => e.Id == id);
            var exerciseTypeDTO = _automapper.Mapper.Map<ExerciseType,ExerciseTypeDTO>(exerciseType);
            return exerciseTypeDTO;
        }
        public static List<string> GetCategories()
        {
            return Enum.GetNames(typeof(Category)).ToList();
        }
    }
}