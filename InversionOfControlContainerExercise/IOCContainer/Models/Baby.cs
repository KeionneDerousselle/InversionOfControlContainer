﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCContainerProject.Models
{
    public class Baby : INoiseMaker
    {
        public string ExecuteNoise()
        {
            return("*terrible high pitched wail*");
        }
    }
}
