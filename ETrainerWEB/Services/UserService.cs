using System.Linq;
using System.Threading.Tasks;
using ETrainerWEB.Data;
using ETrainerWEB.Models;
using ETrainerWEB.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace ETrainerWEB.Services
{
    public class UserService
    {
        private readonly ETrainerDbContext _db;
        private readonly PropertyCopierService<Measurement> _propertyCopier;
        private readonly AutomapperService _automapper;
        
        
        public UserService(ETrainerDbContext db,PropertyCopierService<Measurement> propertyCopierService,AutomapperService automapperService)
        {
            _db = db;
            _propertyCopier = propertyCopierService;
            _automapper = automapperService;
        }
        public UserDTO GetProfile()
        {
            var user = (_db.Users.Include(s=>s.Measurement).FirstOrDefault());
            var userDTO = _automapper.Mapper.Map<User,UserDTO>(user);
            return userDTO;
        }
        public MeasurementDTO GetMeasurement(string Id)
        {
            var measurement = (_db.Measurements.FirstOrDefault(e => e.Id==Id));
            var measurementDTO = _automapper.Mapper.Map<Measurement,MeasurementDTO>(measurement);
            return measurementDTO;
        }
        public async Task<bool> EditMeasurement(MeasurementDTO measurementDTO)
        { 
            var measurement = (_db.Measurements.FirstOrDefault(e => e.Id == measurementDTO.Id));
            if (measurement == null) return false;
            var updatedMeasurement = _automapper.Mapper.Map<MeasurementDTO, Measurement>(measurementDTO);
            _propertyCopier.Copy(updatedMeasurement,measurement);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<bool> CreateMeasurement(MeasurementDTO measurementDTO)
        {
            var userMeasurement = GetMeasurement(measurementDTO.Id);
            if (userMeasurement != null) return false;
            var measurement = _automapper.Mapper.Map<MeasurementDTO,Measurement>(measurementDTO);
            _db.Measurements.Add(measurement);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}