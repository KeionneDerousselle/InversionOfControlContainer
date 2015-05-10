using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InversionOfControlContainerExercise.Models
{
    [Serializable]
    public class Exercise
    {
        public string Name { get; set; }
        public int CaloriesBurned { get; set; }
    }
}