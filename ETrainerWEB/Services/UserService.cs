using System.Linq;
using System.Threading.Tasks;
using ETrainerWEB.Data;
using ETrainerWEB.Models;
using ETrainerWEB.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ETrainerWEB.Services
{
    public class UserService
    {
        private readonly ETrainerDbContext _db;
        private readonly PropertyCopierService<Measurement> _propertyCopier;
        private readonly AutomapperService _automapper;
        private readonly string _userId;

        public UserService(ETrainerDbContext db,PropertyCopierService<Measurement> propertyCopierService,AutomapperService automapperService,IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _propertyCopier = propertyCopierService;
            _automapper = automapperService;
            _userId  = _db.Users.Where(e => e.UserName == httpContextAccessor.HttpContext.User.Identity.Name).Select(r => r.Id).FirstOrDefault();
        }
        public UserDTO GetProfile()
        {
            if (string.IsNullOrEmpty(_userId)) return null;
            var user = (_db.Users.Where(e=>e.Id == _userId).Include(s=>s.Measurement).FirstOrDefault());
            var userDTO = _automapper.Mapper.Map<User,UserDTO>(user);
            return userDTO;
        }
        public MeasurementDTO GetMeasurement()
        {
            if (string.IsNullOrEmpty(_userId)) return null;
            var measurement = (_db.Measurements.FirstOrDefault(e => e.Id==_userId));
            var measurementDTO = _automapper.Mapper.Map<Measurement,MeasurementDTO>(measurement);
            return measurementDTO;
        }
        public async Task<bool> EditMeasurement(MeasurementDTO measurementDTO)
        { 
            if (string.IsNullOrEmpty(_userId)) return false;
            var measurement = (_db.Measurements.FirstOrDefault(e => e.Id == _userId));
            if (measurement == null) return false;
            measurementDTO.Id = _userId;
            var updatedMeasurement = _automapper.Mapper.Map<MeasurementDTO, Measurement>(measurementDTO);
            _propertyCopier.Copy(updatedMeasurement,measurement);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<bool> CreateMeasurement(MeasurementDTO measurementDTO)
        {
            if (string.IsNullOrEmpty(_userId)) return false;
            var userMeasurement = GetMeasurement();
            if (userMeasurement != null) return false;
            measurementDTO.Id = _userId;
            var measurement = _automapper.Mapper.Map<MeasurementDTO,Measurement>(measurementDTO);
            _db.Measurements.Add(measurement);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}