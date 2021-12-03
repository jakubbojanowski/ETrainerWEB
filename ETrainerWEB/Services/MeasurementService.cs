using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETrainerWEB.Data;
using ETrainerWEB.Models;
using ETrainerWEB.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ETrainerWEB.Services
{
    public class MeasurementService
    {
        private readonly ETrainerDbContext _db;
        private readonly PropertyCopierService<Measurement> _propertyCopier;
        private readonly AutomapperService _automapper;
        private readonly string _userId;
        public MeasurementService(ETrainerDbContext db,PropertyCopierService<Measurement> propertyCopierService,AutomapperService automapperService,IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _propertyCopier = propertyCopierService;
            _automapper = automapperService;
            _userId = "847d87ee-9d7f-46cb-85cc-a26bc731796f";
            //_userId  = _db.Users.Where(e => e.UserName == httpContextAccessor.HttpContext.User.Identity.Name).Select(r => r.Id).FirstOrDefault();
        }
        public async Task<MeasurementDTO> GetMeasurementByDate(DateTime date)
        {
            if (string.IsNullOrEmpty(_userId)) return null;
            var measurement = await _db.Measurements.Where(e => e.User.Id == _userId && e.Date.Date == date.Date).FirstOrDefaultAsync();
            var measurementDTO = _automapper.Mapper.Map<Measurement, MeasurementDTO>(measurement);
            return measurementDTO;
        }
        public async Task<List<MeasurementDTO>> GetMeasurements()
        {
            if (string.IsNullOrEmpty(_userId)) return null;
            var measurement = await _db.Measurements.Where(e => e.User.Id == _userId).OrderBy(e=>e.Date).ToListAsync();
            var measurementDTO = _automapper.Mapper.Map<List<Measurement>, List<MeasurementDTO>>(measurement);
            return measurementDTO;
        }
        public async Task<int> AddMeasurement(MeasurementDTO measurementDTO)
        {
            var todayMeasurement = await GetMeasurementByDate(measurementDTO.Date);
            if (todayMeasurement != null) return 0;
            if (string.IsNullOrEmpty(_userId)) return 0;
            measurementDTO.User = await _db.Users.FirstOrDefaultAsync(e => e.Id == _userId);
            var measurement = _automapper.Mapper.Map<MeasurementDTO,Measurement>(measurementDTO);
            await _db.Measurements.AddAsync(measurement);
            await _db.SaveChangesAsync();
            return measurement.Id;
        }
        public async Task<int> EditMeasurement(MeasurementDTO measurementDTO)
        {
            if (string.IsNullOrEmpty(_userId)) return 0;
            measurementDTO.User = await _db.Users.FirstOrDefaultAsync(e => e.Id == _userId);
            var measurement = await _db.Measurements.FirstOrDefaultAsync(e =>e.User.Id == _userId &&e.Id == measurementDTO.Id);
            if (measurement == null) return 0;
            measurement.Properties = measurementDTO.Properties;
            await _db.SaveChangesAsync();
            return measurement.Id;
        }
        public async Task<bool> DeleteMeasurement(int id)
        {
            if (string.IsNullOrEmpty(_userId)) return false;
            var measurement = await _db.Measurements.FirstOrDefaultAsync(e => e.User.Id == _userId && e.Id == id);
            if (measurement == null) return false;
            _db.Measurements.Remove(measurement);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}