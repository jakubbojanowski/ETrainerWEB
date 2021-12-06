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
                cfg.CreateMap<Workout, WorkoutDTO>().ReverseMap();
                cfg.CreateMap<Exercise, ExerciseDTO>().ReverseMap();
                cfg.CreateMap<ExerciseType, ExerciseTypeDTO>().ReverseMap();
                cfg.CreateMap<ExerciseSchema, ExerciseSchemaDTO>().ReverseMap();
                cfg.CreateMap<WorkoutSchema, WorkoutSchemaDTO>().ReverseMap();
                cfg.CreateMap<WorkoutSchemaExerciseSchema, WorkoutSchemaExerciseSchemaDTO>().ReverseMap();
                cfg.CreateMap<User, UserDTO>().ReverseMap();
                cfg.CreateMap<Measurement, MeasurementDTO>().ReverseMap();
                cfg.CreateMap<Meal, MealDTO>().ReverseMap();
                cfg.CreateMap<Dish, DishDTO>().ReverseMap();
                cfg.CreateMap<MealsDishes, MealsDishesDTO>().ReverseMap();
                cfg.CreateMap<Ingredient, IngredientDTO>().ReverseMap();
                cfg.CreateMap<DishesIngredients, DishesIngredientsDTO>().ReverseMap();
            });
            Mapper = configuration.CreateMapper();
        }
    }
}