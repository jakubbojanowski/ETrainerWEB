using E_Trainer_WEB.Data;
using E_Trainer_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Trainer_WEB.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ExerciseSchemaController : Controller
    {
        private ETrainerDBContext _context;
        public ExerciseSchemaController(ETrainerDBContext context)
        {
            _context = context;
        }
        //Get all exercise schemas
        [HttpGet]
        public async Task<List<ExerciseSchema>> GetAllExerciseSchemas()
        {
            return (await _context.ExerciseSchemas.ToListAsync()).ToList();
        }
        ////Create new exercise schema
        //[HttpGet]
        //public async Task CreateNewSchema([FromBody()]ExerciseType exerciseType)
        //{
            
        //}
    }
}
