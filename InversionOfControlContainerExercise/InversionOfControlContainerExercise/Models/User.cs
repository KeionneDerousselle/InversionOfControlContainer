using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InversionOfControlContainerExercise.Models
{
    [Serializable]
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public decimal Weight { get; set; }
        public int DailyCaloricIntake { get; set; }
        public Log Log { get; set; }

        public User()
        {

        }
    }
}