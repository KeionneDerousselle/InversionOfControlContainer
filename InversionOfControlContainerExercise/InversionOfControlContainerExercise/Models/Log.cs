using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InversionOfControlContainerExercise.Models
{
    [Serializable]
    public class Log
    {
        public IEnumerable<Exercise> DailyExercise {get; set;}
        public IEnumerable<Meal> DailyMeals { get; set; }
        public Log()
        {

        }
    }
}