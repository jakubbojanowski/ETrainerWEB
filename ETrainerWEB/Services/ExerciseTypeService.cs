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
        private readonly PropertyCopierService<ExerciseType> _propertyCopier;
        private readonly AutomapperService _automapper;
        
        public ExerciseTypeService(ETrainerDbContext db,PropertyCopierService<ExerciseType> propertyCopierService,AutomapperService automapperService)
        {
            _db = db;
            _propertyCopier = propertyCopierService;
            _automapper = automapperService;
        }
        public async Task<List<ExerciseTypeDTO>> GetExercisesType()
        {
            var exerciseType = (await _db.ExerciseTypes.ToListAsync()).ToList();
            var exerciseTypeDTO = _automapper.Mapper.Map<List<ExerciseType>,List<ExerciseTypeDTO>>(exerciseType);
            return exerciseTypeDTO;
        }

        public ExerciseTypeDTO GetExerciseTypeById(int id)
        {
            var exerciseType = (_db.ExerciseTypes.FirstOrDefault(e => e.Id == id));
            var exerciseTypeDTO = _automapper.Mapper.Map<ExerciseType,ExerciseTypeDTO>(exerciseType);
            return exerciseTypeDTO;
        }
        public async Task<List<String>> GetCategories()
        {
            List<String> categoryList = new();
            foreach (var value in Enum.GetNames(typeof(Category)))
            {
                categoryList.Add(value);
            }
            return categoryList;
        }
    }
}