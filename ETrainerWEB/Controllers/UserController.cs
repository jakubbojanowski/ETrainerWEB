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
    public class UserController : ControllerBase
    {
        private readonly ETrainerDbContext _db;
        public UserController(ETrainerDbContext db)
        {
            _db = db;
        }
        //Get all users
        [HttpGet]
        public async Task<List<User>> Users()
        {
            //return (await _db.Users.Include(e=>e.Friended).ToListAsync()).ToList();
            return (await _db.Users.ToListAsync()).ToList();
        }
    }
}