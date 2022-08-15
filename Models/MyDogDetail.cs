using System;
using System.ComponentModel.DataAnnotations;

namespace MyDogDetail.Models
{
    public class DogData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }


        public string DateOfBirth { get; set; }

        public string PetWeight { get; set; }

        public string WeightUnit { get; set; }

        public string PetBreed { get; set; }


    }
}
