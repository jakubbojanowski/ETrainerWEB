using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETrainerWEB.Data;
using ETrainerWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETrainerWEB.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class ExerciseSchemaController : Controller
    {
        private readonly ETrainerDbContext _db;
        public ExerciseSchemaController(ETrainerDbContext db)
        {
            _db = db;
        }
        //Get all exercise schemas
        [HttpGet]
        public async Task<List<ExerciseSchema>> ExerciseSchemas()
        {
            return (await _db.ExerciseSchemas.ToListAsync()).ToList();
        }
        //Get user's exercise schemas
        [HttpGet("{id:int}")]
        public async Task<List<ExerciseSchema>> UserExerciseSchemas([FromRoute]int id)
        {
            return (await _db.ExerciseSchemas.ToListAsync()).ToList();
        }
        ////Create new exercise schema
        //[HttpGet]
        //public async Task CreateNewSchema([FromBody()]ExerciseType exerciseType)
        //{
            
        //}
    }
}
