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
            var exerciseSchema = (await _db.ExerciseSchemas.Where(e => e.UserId == _userId).ToListAsync()).ToList();
            var exerciseSchemaDTO = _automapper.Mapper.Map<List<ExerciseSchema>, List<ExerciseSchemaDTO>>(exerciseSchema);
            return exerciseSchemaDTO;
            }
        public async Task<bool> AddExerciseSchema(ExerciseSchemaDTO exerciseSchemaDTO)
        {
            if (string.IsNullOrEmpty(_userId)) return false;
            exerciseSchemaDTO.UserId = _userId;
            var exerciseSchema = _automapper.Mapper.Map<ExerciseSchemaDTO,ExerciseSchema>(exerciseSchemaDTO);
            _db.ExerciseSchemas.Add(exerciseSchema);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<bool> EditExerciseSchema(ExerciseSchemaDTO exerciseSchemaDTO)
        { 
            if (string.IsNullOrEmpty(_userId)) return false;
            var exerciseSchema = (_db.ExerciseSchemas.FirstOrDefault(e => e.Id == exerciseSchemaDTO.Id));
            if (exerciseSchema == null) return false;
            exerciseSchemaDTO.UserId = _userId;
            var updatedexerciseSchema = _automapper.Mapper.Map<ExerciseSchemaDTO, ExerciseSchema>(exerciseSchemaDTO);
            _propertyCopier.Copy(updatedexerciseSchema,exerciseSchema);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteExerciseSchema(int id)
        {
            if (string.IsNullOrEmpty(_userId)) return false;
            var exerciseSchema = _db.ExerciseSchemas.FirstOrDefault(e => e.UserId == _userId && e.Id == id);
            if (exerciseSchema == null) return false;
            _db.ExerciseSchemas.Remove(exerciseSchema);
            return await _db.SaveChangesAsync() > 0;
        }
        
    }
}