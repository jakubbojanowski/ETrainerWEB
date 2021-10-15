using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETrainerWEB.Data;
using ETrainerWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ETrainerWEB.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class ExerciseTypeController : ControllerBase
    {
        private readonly ETrainerDbContext _db;
        public ExerciseTypeController(ETrainerDbContext db)
        {
            _db = db;
        }
        //Get all exercise types
        [HttpGet]
        public async Task<List<ExerciseType>> ExerciseTypes()
        {
            /*var tmp =  (await _db.ExerciseTypes.ToListAsync()).ToList();
            Dictionary<string, string> prop = new Dictionary<string, string>();
            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(tmp[0].Properties);*/
            return (await _db.ExerciseTypes.ToListAsync()).ToList();
        } 
    }
}
