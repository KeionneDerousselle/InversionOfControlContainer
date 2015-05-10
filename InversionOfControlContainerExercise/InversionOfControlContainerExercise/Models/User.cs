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
        public string Username { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public decimal Weight { get; set; }
        public int DailyCaloricIntake { get; set; }
        public Log Log { get; set; }

        public User()
        {

        }

        public override bool Equals(object obj)
        {
            bool equals = false;
            if(obj is User)
            {
                User other = (obj as User);

                equals = (this.Id == other.Id) &&
                         (this.Name.Equals(other.Name)) &&
                         (this.Password.Equals(other.Password)) &&
                         (this.Gender.Equals(other.Gender));
            }
            return equals;
        }
    }
}