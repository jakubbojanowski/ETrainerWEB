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
    public class ExerciseTypeController : ControllerBase
    {
        private ETrainerDBContext _context;
        public ExerciseTypeController(ETrainerDBContext context)
        {
            _context = context;
        }
        //Get all exercise types
        [HttpGet]
        public async Task<List<ExerciseType>> GetAllExerciseTypes()
        {
            return (await _context.ExerciseTypes.Include(s => s.Exercises).Include(e => e.ExerciseSchemas).ToListAsync()).ToList();
        } 
    }
}
