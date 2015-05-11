using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCContainerSpecs.Tests.TestingModels
{
    public class Baby : INoiseMaker
    {
        public string ExecuteNoise()
        {
            return("*terrible high pitched wail*");
        }
    }
}
