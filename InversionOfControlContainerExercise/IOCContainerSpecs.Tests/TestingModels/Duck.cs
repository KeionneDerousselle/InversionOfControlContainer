using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCContainerSpecs.Tests.TestingModels
{
    public class Duck : IAnimal, INoiseMaker
    {
        public string ExecuteNoise()
        {
            return "Quack!";
        }
        public string PerformAnimalBehavior()
        {
            return "Swims and " + ExecuteNoise() + "s";
        }
    }
}
