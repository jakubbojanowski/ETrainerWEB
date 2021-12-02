using System;
using System.Collections.Generic;

namespace ETrainerWEB.Models.DTO
{
    public class UserDTO
    {
        public string UserName { set; get; }
        public string Email { set; get; }
        public DateTime DateOfBirth { set; get; }
        public string City { set; get; }
        public string Country { set; get; }
        //public Measurement Measurement { set; get; }
        //public  ICollection<ExerciseSchema> ExerciseSchemas { get; set; }
    }
}