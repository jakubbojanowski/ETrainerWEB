using AutoMapper;
using ETrainerWEB.Models;
using ETrainerWEB.Models.DTO;

namespace ETrainerWEB.Services
{
    public class AutomapperService
    {
        public readonly IMapper Mapper;
        public AutomapperService()
        {
            var configuration = new MapperConfiguration(cfg => 
            {
            
                cfg.CreateMap<Workout, WorkoutDTO>();
                cfg.CreateMap<WorkoutDTO, Workout>();
                cfg.CreateMap<Exercise, ExerciseDTO>();
                cfg.CreateMap<ExerciseDTO, Exercise>();
                cfg.CreateMap<ExerciseType, ExerciseTypeDTO>();
                cfg.CreateMap<ExerciseTypeDTO, ExerciseType>();

            });

            Mapper = configuration.CreateMapper();
        }
        
    }
}