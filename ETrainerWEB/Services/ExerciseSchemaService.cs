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
    public class ExerciseSchemaService
    {
        private readonly ETrainerDbContext _db;
        private readonly PropertyCopierService<ExerciseSchema> _propertyCopier;
        private readonly AutomapperService _automapper;


        public ExerciseSchemaService(ETrainerDbContext db,PropertyCopierService<ExerciseSchema> propertyCopierService,AutomapperService automapperService)
        {
            _db = db;
            _propertyCopier = propertyCopierService;
            _automapper = automapperService;
        }
        public async Task<List<ExerciseSchemaDTO>> GetExerciseSchemas()
        {
            var exerciseSchema = (await _db.ExerciseSchemas.ToListAsync()).ToList();
            var exerciseSchemaDTO = _automapper.Mapper.Map<List<ExerciseSchema>,List<ExerciseSchemaDTO>>(exerciseSchema);
            return exerciseSchemaDTO;
        }
        public async Task<bool> AddExerciseSchema(ExerciseSchemaDTO exerciseSchemaDTO)
        {
            var exerciseSchema = _automapper.Mapper.Map<ExerciseSchemaDTO,ExerciseSchema>(exerciseSchemaDTO);
            _db.ExerciseSchemas.Add(exerciseSchema);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<bool> EditExerciseSchema(ExerciseSchemaDTO exerciseSchemaDTO)
        { 
            var exerciseSchema = (_db.ExerciseSchemas.FirstOrDefault(e => e.Id == exerciseSchemaDTO.Id));
            if (exerciseSchema == null) return false;
            var updatedexerciseSchema = _automapper.Mapper.Map<ExerciseSchemaDTO, ExerciseSchema>(exerciseSchemaDTO);
            _propertyCopier.Copy(updatedexerciseSchema,exerciseSchema);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteExerciseSchema(int id)
        {
            var exerciseSchema = _db.ExerciseSchemas.FirstOrDefault(e => e.Id == id);
            if (exerciseSchema == null) return false;
            _db.ExerciseSchemas.Remove(exerciseSchema);
            return await _db.SaveChangesAsync() > 0;
        }
        
    }
}