﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCContainerProject.Exceptions
{
   public class TypeNotRegisteredException : Exception
    {
       public TypeNotRegisteredException(string message = "") : base(message)
       {
       }
    }
}
